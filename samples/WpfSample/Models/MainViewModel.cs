using System.ComponentModel;
using Enhanced.ComponentModel;
using Enhanced.ComponentModel.Attributes;

namespace WpfSample.Models
{
    [Enhance]
    public class MainViewModel : EnhancedObject, INotifyPropertyChanged
    {
        private static readonly PropertyChangedEventArgs ValueChangedEventArgs
            = new PropertyChangedEventArgs(nameof(Value));

        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(ValueChangedEventArgs);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}