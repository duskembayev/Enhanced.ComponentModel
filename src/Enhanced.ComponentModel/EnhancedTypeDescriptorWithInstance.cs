using System;
using System.ComponentModel;

namespace Enhanced.ComponentModel
{
    internal class EnhancedTypeDescriptorWithInstance : ICustomTypeDescriptor
    {
        private readonly ICustomTypeDescriptor _parent;
        private readonly object _instance;

        internal EnhancedTypeDescriptorWithInstance(ICustomTypeDescriptor parent, object instance)
        {
            _parent = parent;
            _instance = instance;
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return _parent.GetAttributes();
        }

        string? ICustomTypeDescriptor.GetClassName()
        {
            return _parent.GetClassName();
        }

        string? ICustomTypeDescriptor.GetComponentName()
        {
            return _parent.GetComponentName();
        }

        TypeConverter? ICustomTypeDescriptor.GetConverter()
        {
            return _parent.GetConverter();
        }

        EventDescriptor? ICustomTypeDescriptor.GetDefaultEvent()
        {
            return _parent.GetDefaultEvent();
        }

        PropertyDescriptor? ICustomTypeDescriptor.GetDefaultProperty()
        {
            return _parent.GetDefaultProperty();
        }

        object? ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return _parent.GetEditor(editorBaseType);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return _parent.GetEvents();
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return _parent.GetEvents(attributes);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return _parent.GetProperties();
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return _parent.GetProperties(attributes);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return _instance;
        }
    }
}