using System.ComponentModel;
using Enhanced.ComponentModel;

namespace WpfSample.Models
{
    public abstract class Npc : EnhancedObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}