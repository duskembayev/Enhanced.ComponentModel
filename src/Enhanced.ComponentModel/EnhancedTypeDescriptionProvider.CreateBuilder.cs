using Enhanced.ComponentModel.Builders;

namespace Enhanced.ComponentModel
{
    public partial class EnhancedTypeDescriptionProvider
    {
        public static IEnhancedTypeDescriptionProviderBuilder CreateBuilder()
        {
            return new EnhancedTypeDescriptionProviderBuilder();
        }
    }
}