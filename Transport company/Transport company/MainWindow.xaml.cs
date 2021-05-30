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
        List<TableAuto> Company = new List<TableAuto>();
        TableAuto traceList;
        TransportComp Auto = new TransportComp(5);
        int IndexTable = 0;

        public MainWindow()
        {
            InitializeComponent();
            Auto.AddAutoevent += Auto_AddAutoevent;
            Auto.AddTraceEvent += Auto_AddTraceEvent;
        }

        private void Auto_AddAutoevent()
        {
            TableCompany.ItemsSource = ConvertMassInList(Auto.Company1);
        }

        private void Auto_AddTraceEvent()
        {
            try
            {
                TableTrace.ItemsSource = ConvertTraceInList(Auto.Company1[IndexTable]);
            }
            catch(Exception)
            {
                MessageBox.Show("fatal");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//добавить авто кнопка
        {
            AutoModalWindow AutoWindow = new AutoModalWindow();
            if (AutoWindow.ShowDialog() == true)
            {
                Auto.Push(AutoWindow.Model, AutoWindow.GNomber, AutoWindow.NameRider);
            } 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Добавить маршрут кнопка
        {
            TraceModalWindow traceModal = new TraceModalWindow();
            if (traceModal.ShowDialog() == true)
            {
                Auto.SearchAndAddTrace(traceModal.AutoInfo.Text, traceModal.GetStart, traceModal.GetFinish, traceModal.GetMass, traceModal.GetDate);
                
            }
        }

        private void TableCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((TableAuto)TableCompany.CurrentItem != null)
                {
                    traceList = (TableAuto)TableCompany.CurrentItem;
                    IndexTable = TableCompany.SelectedIndex;
                    //TableTrace.ItemsSource = ConvertTraceInList(Auto.Company1, Auto.Search(traceList.Госномер));
                    //TableTrace.ItemsSource = ConvertTraceInList(Auto.Company1, IndexTable);
                    TableTrace.ItemsSource = ConvertTraceInList(Auto.Company1[IndexTable]);
                }
            }
            catch
            {

            }
        }

        private void TableCompany_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private List<TableAuto> ConvertMassInList(AutoT[] Mass)
        {
            List<TableAuto> List = new List<TableAuto>();
            foreach (AutoT i in Mass)
            {
                if (i != null)
                {
                    List.Add(new TableAuto(i.Automobile1, i.GosNamber1, i.Name1));
                }
            }
            return List;
        }
        private List<TraceList> ConvertTraceInList(AutoT Mass)
        {
            List<TraceList> traceLists = new List<TraceList>();
            foreach (DoublyNode i in Mass.Traces1)
            {
                traceLists.Add(new TraceList(i.Старт, i.Финиш, i.Время, i.Масса));
            }
            return traceLists;
        }

        
    }
    public class TableAuto
    {
        String Automobile;
        string GosNamber;
        string Name;

        public TableAuto(string automobile, string gosNamber, string name)
        {
            Automobile = automobile;
            GosNamber = gosNamber;
            Name = name;
        }

        public string Имя { get => Name; set => Name = value; }
        public string Госномер { get => GosNamber; set => GosNamber = value; }
        public string Модель { get => Automobile; set => Automobile = value; }
    }
    public class TraceList
    {
        string Start, Finish;
        DateTime Time;
        int Mass;
        public TraceList(string start, string finish, DateTime time, int mass)
        {
            Старт = start;
            Финиш = finish;
            Время = time;
            Масса = mass;
        }

        public string Старт { get => Start; set => Start = value; }
        public string Финиш { get => Finish; set => Finish = value; }
        public DateTime Время { get => Time; set => Time = value; }
        public int Масса { get => Mass; set => Mass = value; }
    }
}
