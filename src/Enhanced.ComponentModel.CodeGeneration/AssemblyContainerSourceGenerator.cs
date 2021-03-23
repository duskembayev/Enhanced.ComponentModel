using System.Diagnostics;
using Enhanced.ComponentModel.Attributes;
using Microsoft.CodeAnalysis;

namespace Enhanced.ComponentModel.CodeGeneration
{
    [Generator]
    public class AssemblyContainerSourceGenerator : ISourceGenerator
    {
        private const string AssemblyAttribute = "[assembly:{0}(\"{1}\")]";
        private static readonly string AssemblyAttributeName = typeof(EnhanceContainerAttribute).FullName;

        public void Initialize(GeneratorInitializationContext context)
        {
            // do nothing
        }

        public void Execute(GeneratorExecutionContext context)
        {
#if ENABLE_DEBUG
            Debugger.Launch();
#endif
            var buildResult = BuildContainerSource(context);

            foreach (var diagnostic in buildResult.Diagnostics)
                context.ReportDiagnostic(diagnostic);

            if (buildResult.Count == 0)
                return;

            context.CancellationToken.ThrowIfCancellationRequested();

            var assemblyAttributeSourceCode = string.Format(
                AssemblyAttribute,
                AssemblyAttributeName,
                AssemblyContainerConstants.ContainerTypeFullName);

            context.AddSource($"{AssemblyContainerConstants.ContainerTypeName}.g.cs", buildResult.SourceCode);
            context.AddSource("Enhanced.AssemblyInfo.g.cs", assemblyAttributeSourceCode);
        }

        private static AssemblyContainerBuildResult BuildContainerSource(GeneratorExecutionContext context)
        {
            var buildContainerSourceVisitor = new BuildContainerSourceVisitor(context.CancellationToken);
            context.Compilation.Assembly.Accept(buildContainerSourceVisitor);
            return buildContainerSourceVisitor.GetResult();
        }
    }
}