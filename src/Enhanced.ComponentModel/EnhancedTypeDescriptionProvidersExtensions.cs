using System.ComponentModel;

namespace Enhanced.ComponentModel
{
    public static class EnhancedTypeDescriptionProvidersExtensions
    {
        public static void Apply(this EnhancedTypeDescriptionProvider @this)
        {
            foreach (var type in @this.SupportedTypes)
                TypeDescriptor.AddProvider(@this, type);
        }
    }
}