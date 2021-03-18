namespace Enhanced.ComponentModel.Builders
{
    internal class EnhancedTypeDescriptionProviderBuilder : IEnhancedTypeDescriptionProviderBuilder
    {
        private readonly EnhancedTypeDescriptionProviderRegistry _registry;

        public EnhancedTypeDescriptionProviderBuilder()
        {
            _registry = new EnhancedTypeDescriptionProviderRegistry();
        }

        public void Register(IEnhancedTypeDescriptionContainer container)
        {
            _registry.Register(container);
        }

        public EnhancedTypeDescriptionProvider Build()
        {
            return new(_registry);
        }
    }
}