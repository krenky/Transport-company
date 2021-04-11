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
        public MainWindow()
        {
            InitializeComponent();
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
            AutoComboBox.Items.Add("");
        }
        auto Auto = new auto();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModalWindow AutoWindow = new ModalWindow();
            if(AutoWindow.ShowDialog() == true)
            {
                Auto.Add(AutoWindow.Model, AutoWindow.GNomber, AutoWindow.NameRider);
                //AutoComboBox.Items.Insert(Auto.End1, Auto.Automobile1[0, Auto.End1]);
                insert();
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
            for (int i = 0; i < auto.Count1; i++)
            {
                AutoComboBox.Items.Insert(i, Auto.Automobile1[0, i]);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TraceModalWindow traceModal = new TraceModalWindow();
            if (traceModal.ShowDialog() == true)
            {
                Auto.SearchAndAddTrace(AutoComboBox.Text, traceModal.GetStart, traceModal.GetFinish, traceModal.GetMass);
                AutoComboBox.DropDownClosed += OnDropDownClosed;
            }
        }
    }
}
