namespace Enhanced.ComponentModel.Builders
{
    public interface IEnhancedTypeDescriptionProviderBuilder : IEnhancedTypeDescriptionProviderRegistry
    {
        EnhancedTypeDescriptionProvider Build();
    }
}