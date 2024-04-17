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
    /// Interaction logic for PgRegister.xaml
    /// </summary>
    public partial class PgRegister : Page
    {
        private readonly LoginManager loginManager;
        private readonly MainWindow window;
        public PgRegister(LoginManager loginManager, MainWindow window)
        {
            this.loginManager = loginManager;
            this.window = window;
            InitializeComponent();
        }

        private void btnRegRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtRegUsername.Text;
            string password = txtRegPassword.Text;
            if (loginManager.AddUser(new Login(username, password)))
            {
                loginManager.AddUserToTxt(username, password);
                lblRegStatus.Content = "Registration was successful";
                
                window.GoToLogin();
                ClearFields();     
            }
            else
            {
                lblRegStatus.Content = "Username already exists";
                lblRegStatus.Visibility = Visibility.Visible;
            }
        }

        private void ClearFields()
        {
            txtRegUsername.Text = "";
            txtRegPassword.Text = "";
            lblRegStatus.Visibility = Visibility.Hidden;
        }

        private void btnRegLogin_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            window.GoToLogin();
        }
    }
}
