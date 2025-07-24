using System.Configuration;
using System.Data;
using System.Windows;

namespace ProjectPRN212
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var startup = new Startup();
            ServiceProvider = startup.ConfigureServices();
        }
    }

}
