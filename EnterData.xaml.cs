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
        public EnterData()
        {
            InitializeComponent();
        }

        private void continueData_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            GetData data = new(enterName.Text, enterUser.Text, enterNote.Text);
            _ = MessageBox.Show(data.Name);
            
            
        }

        
    }
}
