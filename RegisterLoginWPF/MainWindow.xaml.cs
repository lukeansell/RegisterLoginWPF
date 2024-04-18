using RegisterLogin;
using System.Data.SqlClient;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

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
        private SqlConnection myConn = new SqlConnection("Server=labVMH8OX\\SQLEXPRESS;database=RegisterLogin;integrated security = true");
        public MainWindow()
        {
            //InitDB();
            pgStart = new PgStart(this);
            pgLogin = new PgLogin(loginManager, this);
            pgRegister = new PgRegister(loginManager, this);
            InitializeComponent();
            //loginManager.LoadFromTxt();
            frm.Navigate(pgStart);

        }

        private void InitDB()
        {

            // create a table for users
            SqlConnection myConn = new SqlConnection("Server=labVMH8OX\\SQLEXPRESS;database=RegisterLogin;integrated security = true");
            string str = "SELECT * FROM tbl";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();


                //myCommand.ExecuteNonQuery();
                MessageBox.Show("", "MyProgram", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (myConn.State == System.Data.ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
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