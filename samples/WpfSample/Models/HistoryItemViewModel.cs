using System.ComponentModel;
using Enhanced.ComponentModel.Attributes;

namespace WpfSample.Models
{
    [Enhance]
    public class HistoryItemViewModel : Npc
    {
        private static readonly PropertyChangedEventArgs ActualDeltaChangedEventArgs = new(nameof(ActualDelta));

        public int CreatedAt { get; init; }

        public int ActualDelta { get; private set; }

        public void Recalculate(int actualTicks)
        {
            ActualDelta = actualTicks - CreatedAt;
            OnPropertyChanged(ActualDeltaChangedEventArgs);
        }
    }
}