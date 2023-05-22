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
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AuditHelper3
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {

        private EnterData enterData;
        private bool adminCheckFinished = false;
        private bool dataCheckFinished = false;

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
                adminCheckFinished = true;
            }

            if (dataCheck.IsChecked == true)
            {
                enterData = new EnterData();
                enterData.Show();
                dataCheckFinished = true;
                _ = MessageBox.Show("Wyświetl hostname przed próbą zapisu: " + enterData.Data.Hostname);
            }

            /*if (adminCheck.IsChecked == true || dataCheck.IsChecked == true)
            {
                while (dataCheckFinished == false)
                {
                    continue;
                }
                
                _ = MessageBox.Show("Wyświetl hostname przed próbą zapisu: " + enterData.Data.Hostname);
                //SaveData();
            }*/

            Close();
        }

    }
}
