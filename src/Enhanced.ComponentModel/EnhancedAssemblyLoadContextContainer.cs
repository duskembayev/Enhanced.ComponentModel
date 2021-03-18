using System.Collections.Generic;
using System.Runtime.Loader;

namespace Enhanced.ComponentModel
{
    internal class EnhancedAssemblyLoadContextContainer : IEnhancedTypeDescriptionContainer
    {
        private readonly AssemblyLoadContext _assemblyLoadContext;

        internal EnhancedAssemblyLoadContextContainer(AssemblyLoadContext assemblyLoadContext)
        {
            _assemblyLoadContext = assemblyLoadContext;
        }

        IEnumerable<EnhancedTypeDescriptor> IEnhancedTypeDescriptionContainer.GetTypeDescriptors()
        {
            var registry = new EnhancedTypeDescriptionProviderRegistry();

            foreach (var assembly in _assemblyLoadContext.Assemblies)
                registry.RegisterAssembly(assembly);

            return registry.GetDescriptors();
        }
    }
}