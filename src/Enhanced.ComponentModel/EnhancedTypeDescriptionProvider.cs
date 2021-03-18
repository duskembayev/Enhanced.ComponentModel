using System;
using System.Collections.Immutable;
using System.ComponentModel;

namespace Enhanced.ComponentModel
{
    public partial class EnhancedTypeDescriptionProvider : TypeDescriptionProvider
    {
        private readonly ImmutableDictionary<Type, EnhancedTypeDescriptor> _typeDescriptors;

        internal EnhancedTypeDescriptionProvider(EnhancedTypeDescriptionProviderRegistry registry)
        {
            _typeDescriptors = registry
                .GetDescriptors()
                .ToImmutableDictionary(descriptor => descriptor.TargetType);

            SupportedTypes = _typeDescriptors.Keys.ToImmutableArray();
        }

        public ImmutableArray<Type> SupportedTypes { get; }

        public override bool IsSupportedType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return _typeDescriptors.ContainsKey(type);
        }

        public override ICustomTypeDescriptor? GetTypeDescriptor(Type objectType, object? instance)
        {
            if (objectType == null) throw new ArgumentNullException(nameof(objectType));

            if (_typeDescriptors.TryGetValue(objectType, out var typeDescriptor))
                return instance != null ? typeDescriptor.WithInstance(instance) : typeDescriptor;

            return null;
        }

        public override ICustomTypeDescriptor? GetExtendedTypeDescriptor(object? instance)
        {
            return instance != null ? GetTypeDescriptor(instance.GetType(), instance) : null;
        }
    }
}