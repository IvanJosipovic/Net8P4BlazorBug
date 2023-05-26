using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostBuilder, services) =>
            {
                services.AddWpfBlazorWebView();

#if DEBUG
                services.AddBlazorWebViewDeveloperTools();
#endif

            })
            .Build();

            host.RunAsync();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Resources.Add("services", host.Services);

            InitializeComponent();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }
    }
}