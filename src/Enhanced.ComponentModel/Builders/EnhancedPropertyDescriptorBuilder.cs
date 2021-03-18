using System;
using System.ComponentModel;

namespace Enhanced.ComponentModel.Builders
{
    internal class EnhancedPropertyDescriptorBuilder<T, TProperty> : IEnhancedPropertyDescriptorBuilder<T, TProperty>
    {
        private readonly string _propertyName;
        private Func<T, TProperty>? _getter;
        private Action<T, TProperty>? _setter;

        public EnhancedPropertyDescriptorBuilder(string propertyName)
        {
            _propertyName = propertyName;
        }

        public IEnhancedPropertyDescriptorBuilder<T, TProperty> AddGetter(Func<T, TProperty> getter)
        {
            _getter = getter;
            return this;
        }

        public IEnhancedPropertyDescriptorBuilder<T, TProperty> AddSetter(Action<T, TProperty> setter)
        {
            _setter = setter;
            return this;
        }

        PropertyDescriptor IEnhancedPropertyDescriptorBuilder.Build()
        {
            return new EnhancedPropertyDescriptor<T, TProperty>(_propertyName, _getter, _setter);
        }
    }
}