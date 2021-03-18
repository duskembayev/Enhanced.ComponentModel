using System.Collections.Generic;
using System.Linq;
using Enhanced.ComponentModel.Builders;

namespace Enhanced.ComponentModel
{
    public abstract class EnhancedTypeDescriptionContainer : IEnhancedTypeDescriptionContainer
    {
        private readonly List<IEnhancedTypeDescriptorBuilder> _types;

        protected EnhancedTypeDescriptionContainer()
        {
            _types = new List<IEnhancedTypeDescriptorBuilder>();
        }

        IEnumerable<EnhancedTypeDescriptor> IEnhancedTypeDescriptionContainer.GetTypeDescriptors()
        {
            OnRegister();
            return _types.Select(builder => builder.Build());
        }

        protected IEnhancedTypeDescriptorBuilder<T> Register<T>(string typeName)
        {
            var typeDescriptorBuilder = new EnhancedTypeDescriptorBuilder<T>(typeName);
            _types.Add(typeDescriptorBuilder);
            return typeDescriptorBuilder;
        }

        protected abstract void OnRegister();
    }
}