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

namespace AeroVianca.CustonControls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
            txt_UserPass.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e) => Password = txt_UserPass.SecurePassword;

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txt_UserPassRevel.Text = txt_UserPass.Password;
            txt_UserPass.Visibility = Visibility.Collapsed;
            txt_UserPassRevel.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_UserPass.Password = txt_UserPassRevel.Text;
            txt_UserPassRevel.Visibility = Visibility.Collapsed;
            txt_UserPass.Visibility = Visibility.Visible;
        }

        private SecureString SecureStringConverter(string pass)
        {
            SecureString ret = new();
            foreach (char chr in pass.ToCharArray())
                ret.AppendChar(chr);
            return ret;
        }

        private void txt_UserPassRevel_LostFocus(object sender, RoutedEventArgs e)
        {
            chb_showPassword.IsChecked = false;
            //ShowPassword_Unchecked(sender, e);
        }

        private void txt_UserPassRevel_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            chb_showPassword.IsChecked = false;
        }
    }
}
