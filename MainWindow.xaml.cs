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

namespace AuditHelper3
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void continueMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            if (adminCheck.IsChecked == true)
            {
                User user = new();
                _ = MessageBox.Show(user.Password);
            }

            if (dataCheck.IsChecked == true)
            {
                EnterData enterData = new EnterData();
                enterData.Show();

            }

            Close();
        }

    }
}
