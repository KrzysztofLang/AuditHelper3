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
using System.Xml.Linq;

namespace AuditHelper3
{
    /// <summary>
    /// Interaction logic for EnterData.xaml
    /// </summary>
    public partial class EnterData : Window
    {
        private GetData data;
        private string test = "penus";
        public EnterData()
        {
            InitializeComponent();
        }

        public string Test { get => test; set => test = value; }
        internal GetData Data { get => data; set => data = value; }

        private void continueData_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            data = new(enterName.Text, enterUser.Text, enterNote.Text);

            _ = MessageBox.Show(data.Name);
            _ = MessageBox.Show(data.AnyDeskID);

            foreach (var item in data.Shares)
            {
                _ = MessageBox.Show("Key: " + item.Key + ", Value: " + item.Value);
            }

            Close();

            _ = MessageBox.Show("Wyświetl hostname wewnątrz EnterData: " + Data.Hostname);
        }
    }
}
