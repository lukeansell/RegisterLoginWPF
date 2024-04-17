using System.Windows;
using System.Windows.Controls;

namespace RegisterLoginWPF
{
    /// <summary>
    /// Interaction logic for PgStart.xaml
    /// </summary>
    public partial class PgStart : Page
    {
        private readonly MainWindow window;
        public PgStart(MainWindow window)
        {
            this.window = window;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window.GoToLogin();
        }
    }
}
