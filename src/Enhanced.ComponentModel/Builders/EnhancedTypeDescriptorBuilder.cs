using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Enhanced.ComponentModel.Builders
{
    internal class EnhancedTypeDescriptorBuilder<T> : IEnhancedTypeDescriptorBuilder<T>
    {
        private readonly List<PropertyDescriptor> _properties;
        private readonly string _typeName;

        internal EnhancedTypeDescriptorBuilder(string typeName)
        {
            _properties = new List<PropertyDescriptor>();
            _typeName = typeName;
        }

        public IEnhancedTypeDescriptorBuilder<T> AddProperty<TProperty>(string propertyName, Func<T, TProperty>? getter = null, Action<T, TProperty>? setter = null)
        {
            _properties.Add(new EnhancedPropertyDescriptor<T, TProperty>(propertyName, getter, setter));
            return this;
        }

        EnhancedTypeDescriptor IEnhancedTypeDescriptorBuilder.Build()
        {
            var properties = _properties.ToArray();

            return new EnhancedTypeDescriptor(_typeName, typeof(T), new PropertyDescriptorCollection(properties));
        }
    }
}