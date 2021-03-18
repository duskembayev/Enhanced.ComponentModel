using System;
using System.ComponentModel;

namespace Enhanced.ComponentModel.Builders
{
    public interface IEnhancedPropertyDescriptorBuilder
    {
        internal PropertyDescriptor Build();
    }

    public interface IEnhancedPropertyDescriptorBuilder<T, TProperty> : IEnhancedPropertyDescriptorBuilder
    {
        IEnhancedPropertyDescriptorBuilder<T, TProperty> AddGetter(Func<T, TProperty> getter);
        IEnhancedPropertyDescriptorBuilder<T, TProperty> AddSetter(Action<T, TProperty> setter);
    }
}