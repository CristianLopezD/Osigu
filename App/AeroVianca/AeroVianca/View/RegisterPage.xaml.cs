using AeroVianca.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace AeroVianca.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        readonly Tools Tools;

        public RegisterPage()
        {
            InitializeComponent();
            Tools = new Tools(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => Tools.MouseDown(e);
        private void btn_Minimize_Click(object sender, RoutedEventArgs e) => Tools.Minimize();
        private void btn_Closed_Click(object sender, RoutedEventArgs e) => Tools.Closed();

    }
}
