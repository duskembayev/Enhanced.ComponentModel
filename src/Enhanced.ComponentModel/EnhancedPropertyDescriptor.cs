using System;
using System.ComponentModel;

namespace Enhanced.ComponentModel
{
    internal class EnhancedPropertyDescriptor<T, TProperty> : PropertyDescriptor
    {
        private readonly Func<T, TProperty>? _getter;
        private readonly Action<T, TProperty>? _setter;

        internal EnhancedPropertyDescriptor(string name, Func<T, TProperty>? getter, Action<T, TProperty>? setter)
            : base(name, Array.Empty<Attribute>())
        {
            _getter = getter;
            _setter = setter;

            ComponentType = typeof(T);
            PropertyType = typeof(TProperty);
            IsReadOnly = _setter == null;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
            throw new NotSupportedException();
        }

        public override object? GetValue(object component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            if (_getter == null) throw new NotSupportedException();

            return _getter.Invoke((T) component);
        }

        public override void SetValue(object component, object value)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            if (_setter == null) throw new NotSupportedException();

            _setter.Invoke((T) component, (TProperty) value);
            OnValueChanged(component, EventArgs.Empty);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override Type ComponentType { get; }
        public override Type PropertyType { get; }
        public override bool IsReadOnly { get; }
    }
}