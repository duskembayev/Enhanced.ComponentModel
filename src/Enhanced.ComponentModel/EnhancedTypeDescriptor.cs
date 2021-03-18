using System;
using System.ComponentModel;

namespace Enhanced.ComponentModel
{
    public partial class EnhancedTypeDescriptor : ICustomTypeDescriptor
    {
        private readonly string _typeName;
        private readonly PropertyDescriptorCollection _properties;

        internal EnhancedTypeDescriptor(string typeName, Type type, PropertyDescriptorCollection properties)
        {
            _typeName = typeName;
            _properties = properties;

            TargetType = type;
        }

        internal Type TargetType { get; }

        internal ICustomTypeDescriptor WithInstance(object instance)
        {
            return new EnhancedTypeDescriptorWithInstance(this, instance);
        }

        public AttributeCollection GetAttributes()
        {
            return AttributeCollection.Empty;
        }

        public string? GetClassName()
        {
            return _typeName;
        }

        public string? GetComponentName()
        {
            return _typeName;
        }

        public TypeConverter? GetConverter()
        {
            return null;
        }

        public EventDescriptor? GetDefaultEvent()
        {
            return null;
        }

        public PropertyDescriptor? GetDefaultProperty()
        {
            return null;
        }

        public object? GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents()
        {
            return EventDescriptorCollection.Empty;
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return EventDescriptorCollection.Empty;
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return _properties;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            if (attributes.Length == 0)
                return GetProperties();

            return PropertyDescriptorCollection.Empty;
        }

        public object? GetPropertyOwner(PropertyDescriptor pd)
        {
            return null;
        }
    }
}
