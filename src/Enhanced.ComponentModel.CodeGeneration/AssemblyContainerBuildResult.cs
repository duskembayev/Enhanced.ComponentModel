using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Enhanced.ComponentModel.CodeGeneration
{
    internal class AssemblyContainerBuildResult
    {
        public AssemblyContainerBuildResult(
            int count,
            string sourceCode,
            ImmutableArray<Diagnostic> diagnostics)
        {
            Count = count;
            SourceCode = sourceCode;
            Diagnostics = diagnostics;
        }

        public int Count { get; }
        public string SourceCode { get; }
        public ImmutableArray<Diagnostic> Diagnostics { get; }
    }
}