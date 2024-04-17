using RegisterLogin;
using System.Windows;

namespace RegisterLoginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly LoginManager loginManager = new();
        //private string loggedUsername = "";
        private readonly PgStart pgStart;
        private readonly PgLogin pgLogin;
        private readonly PgRegister pgRegister;
        public MainWindow()
        {
            pgStart = new PgStart(this);
            pgLogin = new PgLogin(loginManager, this);
            pgRegister = new PgRegister(loginManager, this);
            InitializeComponent();
            loginManager.LoadFromTxt();
            frm.Navigate(pgStart);
        }

        public void GoToLogin()
        {
            frm.Navigate(pgLogin);
        }

        public void GoToLogin(string username)
        {
            pgLogin.txtLoginUser.Text = username;
            frm.Navigate(pgLogin);
        }

        public void GoToReg()
        {
            frm.Navigate(pgRegister);
        }

    }
}