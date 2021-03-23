using System.Windows;
using Enhanced.ComponentModel;

namespace WpfSample
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EnhancedTypeDescriptionProvider.CreateBuilder()
                .RegisterDefaultAssemblyLoadContext()
                .Build()
                .Apply();

            base.OnStartup(e);
        }
    }
}