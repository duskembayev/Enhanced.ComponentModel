namespace Enhanced.ComponentModel.Builders
{
    public interface IEnhancedTypeDescriptorBuilder
    {
        internal EnhancedTypeDescriptor Build();
    }

    public interface IEnhancedTypeDescriptorBuilder<T> : IEnhancedTypeDescriptorBuilder
    {
        IEnhancedPropertyDescriptorBuilder<T, TProperty> AddProperty<TProperty>(string propertyName);
    }
}