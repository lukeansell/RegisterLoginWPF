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

namespace RegisterLoginWPF
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {

        private readonly Window logRegForm;
        public Welcome(string user, Window logRegForm)
        {
            InitializeComponent();
            this.logRegForm = logRegForm;
            lblWelcomeUser.Content = "Welcome " + user;
        }

        private void Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            logRegForm.Close();
        }
    }
}
