using AeroVianca.CustonControls;
using AeroVianca.Utilities;
using AeroVianca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AeroVianca.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        readonly Tools Tools; 

        public LoginPage()
        {
            InitializeComponent();
            Tools = new Tools(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => Tools.MouseDown(e);
        private void btn_Minimize_Click(object sender, RoutedEventArgs e) => Tools.Minimize();
        private void btn_Closed_Click(object sender, RoutedEventArgs e) => Tools.Closed();
        private void TxtBlock_MouseDown(object sender, MouseButtonEventArgs e) 
        {
            if (Tools.validateTxtBoxPressed(e))
            {
                txt_UserName.Text     = string.Empty;
                txt_Password.Password = new SecureString();
                Tools.openPage(new RegisterPage()); 
            }
        }
    }
}
