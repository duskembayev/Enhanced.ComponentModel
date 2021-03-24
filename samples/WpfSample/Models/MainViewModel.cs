using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Enhanced.ComponentModel.Attributes;

namespace WpfSample.Models
{
    [Enhance]
    public class MainViewModel : Npc
    {
        private static readonly PropertyChangedEventArgs ValueChangedEventArgs = new(nameof(ActualTickCount));

        private readonly ObservableCollection<HistoryItemViewModel> _history;
        private int _actualTickCount;

        public MainViewModel()
        {
            _actualTickCount = 0;
            _history = new ObservableCollection<HistoryItemViewModel>();
        }

        public int ActualTickCount
        {
            get => _actualTickCount;
            set
            {
                _actualTickCount = value;

                foreach (var itemViewModel in _history)
                    itemViewModel.Recalculate(_actualTickCount);

                _history.Add(new HistoryItemViewModel
                {
                    CreatedAt = _actualTickCount,
                });

                OnPropertyChanged(ValueChangedEventArgs);
            }
        }

        public IReadOnlyCollection<HistoryItemViewModel> History => _history;
    }
}