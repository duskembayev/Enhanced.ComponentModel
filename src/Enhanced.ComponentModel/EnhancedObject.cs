using System;
using System.ComponentModel;
using Enhanced.ComponentModel.Exceptions;

namespace Enhanced.ComponentModel
{
    public abstract class EnhancedObject : IEnhancedObject
    {
        private readonly ICustomTypeDescriptor _innerDescriptor;

        protected EnhancedObject()
        {
            _innerDescriptor = TypeDescriptor
                .GetProvider(this)
                .GetTypeDescriptor(this) ?? throw new RuntimeException();
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return _innerDescriptor.GetAttributes();
        }

        string? ICustomTypeDescriptor.GetClassName()
        {
            return _innerDescriptor.GetClassName();
        }

        string? ICustomTypeDescriptor.GetComponentName()
        {
            return _innerDescriptor.GetComponentName();
        }

        TypeConverter? ICustomTypeDescriptor.GetConverter()
        {
            return _innerDescriptor.GetConverter();
        }

        EventDescriptor? ICustomTypeDescriptor.GetDefaultEvent()
        {
            return _innerDescriptor.GetDefaultEvent();
        }

        PropertyDescriptor? ICustomTypeDescriptor.GetDefaultProperty()
        {
            return _innerDescriptor.GetDefaultProperty();
        }

        object? ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return _innerDescriptor.GetEditor(editorBaseType);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return _innerDescriptor.GetEvents();
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return _innerDescriptor.GetEvents(attributes);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return _innerDescriptor.GetProperties();
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return _innerDescriptor.GetProperties(attributes);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return _innerDescriptor.GetPropertyOwner(pd);
        }
    }
}