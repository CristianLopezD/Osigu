using System.Windows;
using System.Windows.Input;
using AeroVianca.Utilities;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;

namespace AeroVianca.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private readonly Tools Tools;

        public MainPage()
        {
            InitializeComponent();
            Tools = new Tools(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => Tools.MouseDown(e);
        private void btn_Minimize_Click(object sender, RoutedEventArgs e) => Tools.Minimize();
        private void btn_Closed_Click(object sender, RoutedEventArgs e) => Tools.Closed();
        private void TxtBlock_MouseDown(object sender, MouseButtonEventArgs e) { if (Tools.validateTxtBoxPressed(e)) Tools.openPage(new RegisterPage()); }
        private void btn_Time_Click(object sender, RoutedEventArgs e) => Tools.AddToolTipButton((Button)sender, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        private void btn_Bell_Click(object sender, RoutedEventArgs e) => Tools.AddToolTipButton((Button)sender, $"{txt_DisplayName.Text} you have {new Random().Next(11)} Notification");
    }
}
