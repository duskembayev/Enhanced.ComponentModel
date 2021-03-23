using System;
using System.Windows.Threading;
using WpfSample.Models;

namespace WpfSample
{
    public partial class MainWindow
    {
        private readonly MainViewModel _mainViewModel;
        private readonly DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _mainViewModel = new MainViewModel();

            _timer = new DispatcherTimer(
                TimeSpan.FromMilliseconds(300),
                DispatcherPriority.Normal,
                OnTimer,
                Dispatcher);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _timer.Start();
        }

        private void OnTimer(object? sender, EventArgs e)
        {
            _mainViewModel.Value = Environment.TickCount;
        }
    }
}