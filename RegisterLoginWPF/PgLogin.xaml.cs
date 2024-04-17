using RegisterLogin;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegisterLoginWPF
{
    /// <summary>
    /// Interaction logic for PgLogin.xaml
    /// </summary>
    public partial class PgLogin : Page
    {
        private readonly LoginManager loginManager;
        private readonly MainWindow window;
        public PgLogin(LoginManager loginManager, MainWindow window)
        {
            this.loginManager = loginManager;
            this.window = window;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtLoginUser.Text;
            string password = txtLoginPassword.Text;
            bool valid = loginManager.CheckLogin(username, password);

            if (valid)
            {
                string loggedUsername = username;
                ClearFields();
                Window welcome = new Welcome(loggedUsername, window);
                welcome.Show();
                window.Close();
            }
            else
            {
                lblLoginStatus.Content = "Login failed";
                lblLoginStatus.Visibility = Visibility.Visible;
            }
        }
        private void ClearFields()
        {
            txtLoginUser.Text = "";
            txtLoginPassword.Text = "";
            lblLoginStatus.Visibility = Visibility.Hidden;
        }

        private void btnToRegister_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            window.GoToReg();
        }
    }
}
