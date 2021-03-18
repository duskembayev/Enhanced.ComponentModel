using System.Collections.Generic;

namespace Enhanced.ComponentModel
{
    public interface IEnhancedTypeDescriptionContainer
    {
        internal IEnumerable<EnhancedTypeDescriptor> GetTypeDescriptors();
    }
}