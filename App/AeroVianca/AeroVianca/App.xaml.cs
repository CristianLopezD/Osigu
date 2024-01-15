using AeroVianca.View;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AeroVianca
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            try
            {
                var loginView = new LoginPage();
                loginView.Show();
                loginView.IsVisibleChanged += (s, ev) =>
                {
                    if (loginView.IsVisible == false && loginView.IsLoaded)
                    {
                        var mainView = new MainPage();
                        mainView.Show();
                    }
                };
            }
            catch (Exception ex)
            {

            }
        }
    }

}
