using System;

namespace Enhanced.ComponentModel.Builders
{
    public interface IEnhancedTypeDescriptorBuilder
    {
        internal EnhancedTypeDescriptor Build();
    }

    public interface IEnhancedTypeDescriptorBuilder<T> : IEnhancedTypeDescriptorBuilder
    {
        IEnhancedTypeDescriptorBuilder<T> AddProperty<TProperty>(
            string propertyName,
            Func<T, TProperty>? getter = null,
            Action<T, TProperty>? setter = null);
    }
}