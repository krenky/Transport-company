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

namespace Transport_company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<AutoT> Company = new List<AutoT>();
        public MainWindow()
        {
            InitializeComponent();
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
        }
        TransportComp Auto = new TransportComp(5);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoModalWindow AutoWindow = new AutoModalWindow();
            if (AutoWindow.ShowDialog() == true)
            {
                Auto.Add(AutoWindow.Model, AutoWindow.GNomber, AutoWindow.NameRider);
                //AutoComboBox.Items.Insert(Auto.End1, Auto.Automobile1[0, Auto.End1]);
                AddInList(AutoWindow.Model, AutoWindow.GNomber, AutoWindow.NameRider);
                //insert();
                TableCompany.Items.Clear();
                foreach (var i in Company) 
                {
                    TableCompany.Items.Add();
                }
            } 
        }
        void OnDropDownClosed(object sender, EventArgs e)
        {
            if (AutoComboBox.IsDropDownOpen == false)
            {
                BlockInfo.Text = Auto.SearchAndPrint(AutoComboBox.Text);
            }
        }
        public void insert()
        {
            AutoComboBox.Items.Clear();
            for (int i = 0; i < Auto.Count; i++)
            {
                if (Auto.Company1[i].Automobile1 != null) 
                {
                    AutoComboBox.Items.Insert(i, Auto.Company1[i].Automobile1);
                } 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TraceModalWindow traceModal = new TraceModalWindow();
            if (traceModal.ShowDialog() == true)
            {
                Auto.SearchAndAddTrace(AutoComboBox.Text, traceModal.GetStart, traceModal.GetFinish, traceModal.GetMass);
                if (AutoComboBox.IsDropDownOpen == false)
                {
                    BlockInfo.Text = Auto.SearchAndPrint(AutoComboBox.Text);
                }
            }
        }
        public void AddInList(string Model, string Nomber, string Rider)
        {
            if (Auto.Count<5)
            {
                Company.Add(new AutoT(Model, Nomber, Rider));
            }
            else
            {
                Company.Insert(Auto.End1, new AutoT(Model, Nomber, Rider));
            }
        }

        private void TableCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
