using System.Collections.Generic;
using System.Linq;

namespace Enhanced.ComponentModel
{
    internal class EnhancedTypeDescriptionProviderRegistry : IEnhancedTypeDescriptionProviderRegistry
    {
        private readonly HashSet<IEnhancedTypeDescriptionContainer> _containers;

        internal EnhancedTypeDescriptionProviderRegistry()
        {
            _containers = new HashSet<IEnhancedTypeDescriptionContainer>();
        }

        public void Register(IEnhancedTypeDescriptionContainer container)
        {
            _containers.Add(container);
        }

        internal IEnumerable<EnhancedTypeDescriptor> GetDescriptors()
        {
            return _containers.SelectMany(container => container.GetTypeDescriptors());
        }
    }
}