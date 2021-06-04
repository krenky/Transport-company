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

namespace Transport_company
{
    /// <summary>
    /// Логика взаимодействия для RemoveModalWindow.xaml
    /// </summary>
    public partial class RemoveModalWindow : Window
    {
        public RemoveModalWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public String GetFinish
        {
            get { return Finish.Text; }
        }
        public String GetStart
        {
            get { return Start.Text; }
        }

        private void Start_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

        private void Finish_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }
    }
}
