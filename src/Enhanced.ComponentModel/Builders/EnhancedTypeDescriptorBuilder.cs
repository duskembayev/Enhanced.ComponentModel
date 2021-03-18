using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Enhanced.ComponentModel.Builders
{
    internal class EnhancedTypeDescriptorBuilder<T> : IEnhancedTypeDescriptorBuilder<T>
    {
        private readonly List<IEnhancedPropertyDescriptorBuilder> _properties;
        private readonly string _typeName;

        internal EnhancedTypeDescriptorBuilder(string typeName)
        {
            _properties = new List<IEnhancedPropertyDescriptorBuilder>();
            _typeName = typeName;
        }

        public IEnhancedPropertyDescriptorBuilder<T, TProperty> AddProperty<TProperty>(string propertyName)
        {
            var propertyDescriptorBuilder = new EnhancedPropertyDescriptorBuilder<T, TProperty>(propertyName);
            _properties.Add(propertyDescriptorBuilder);
            return propertyDescriptorBuilder;
        }

        EnhancedTypeDescriptor IEnhancedTypeDescriptorBuilder.Build()
        {
            var properties = _properties
                .Select(builder => builder.Build())
                .ToArray();

            return new EnhancedTypeDescriptor(_typeName, typeof(T), new PropertyDescriptorCollection(properties));
        }
    }
}