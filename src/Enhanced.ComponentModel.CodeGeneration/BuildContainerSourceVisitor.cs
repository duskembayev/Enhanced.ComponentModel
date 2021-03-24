using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Enhanced.ComponentModel.Attributes;
using Microsoft.CodeAnalysis;

namespace Enhanced.ComponentModel.CodeGeneration
{
    internal class BuildContainerSourceVisitor : SymbolVisitor
    {
        private static readonly string EnhanceAttributeName = typeof(EnhanceAttribute).FullName;

        private static readonly SymbolDisplayFormat SymbolDisplayFormat = new(
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
            globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted);

        private readonly AssemblyContainerSourceBuilder _builder;
        private readonly CancellationToken _cancellationToken;
        private readonly ImmutableArray<Diagnostic>.Builder _diagnostics;

        private static readonly DiagnosticDescriptor GenericClassErrorDescriptor = new(
            "ENH1010",
            "Generic types are not supported",
            "Type \"{0}\" is generic and not supported.",
            "Enhanced.ComponentModel",
            DiagnosticSeverity.Error,
            true);

        private static readonly DiagnosticDescriptor AbstractClassErrorDescriptor = new(
            "ENH1011",
            "Abstract types are not supported",
            "Type \"{0}\" is abstract and not supported.",
            "Enhanced.ComponentModel",
            DiagnosticSeverity.Error,
            true);

        public BuildContainerSourceVisitor(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _builder = new AssemblyContainerSourceBuilder();
            _diagnostics = ImmutableArray.CreateBuilder<Diagnostic>();
        }

        public AssemblyContainerBuildResult GetResult()
        {
            return new(
                _builder.RegisteredClassCount,
                _builder.Build(),
                _diagnostics.ToImmutable());
        }

        public override void VisitAssembly(IAssemblySymbol symbol)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            symbol.GlobalNamespace.Accept(this);
        }

        public override void VisitNamespace(INamespaceSymbol symbol)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            foreach (var namespaceOrTypeSymbol in symbol.GetMembers())
                namespaceOrTypeSymbol.Accept(this);
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            if (!IsValidClass(symbol))
                return;

            _builder.RegisterType(symbol.ToDisplayString(SymbolDisplayFormat));

            var targetSymbol = symbol;

            do
            {
                foreach (var member in targetSymbol.GetMembers())
                    member.Accept(this);

                targetSymbol = targetSymbol.BaseType;
            } while (targetSymbol != null);
        }

        public override void VisitProperty(IPropertySymbol symbol)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            if (!IsAccessible(symbol))
                return;

            _builder.RegisterProperty(
                symbol.Name,
                symbol.Type.ToDisplayString(SymbolDisplayFormat),
                IsAccessible(symbol.GetMethod),
                IsAccessible(symbol.SetMethod));
        }

        private bool IsValidClass(INamedTypeSymbol symbol)
        {
            var hasEnhanceAttribute = symbol
                .GetAttributes()
                .Any(attr => attr.AttributeClass?.ToDisplayString(SymbolDisplayFormat) == EnhanceAttributeName);

            if (!hasEnhanceAttribute)
                return false;

            if (symbol.IsAbstract)
            {
                AddError(AbstractClassErrorDescriptor, symbol);
                return false;
            }

            if (symbol.IsGenericType)
            {
                AddError(GenericClassErrorDescriptor, symbol);
                return false;
            }

            return true;
        }

        private static bool IsAccessible(IMethodSymbol? symbol)
        {
            return symbol != null && !symbol.IsInitOnly && IsAccessible((ISymbol) symbol);
        }

        private static bool IsAccessible(ISymbol? symbol)
        {
            return symbol != null && symbol.DeclaredAccessibility >= Accessibility.Internal;
        }

        private void AddError(DiagnosticDescriptor descriptor, ISymbol symbol)
        {
            var location = symbol.Locations.IsEmpty ? Location.None : symbol.Locations.ItemRef(0);
            _diagnostics.Add(Diagnostic.Create(descriptor, location, symbol.Name));
        }
    }
}