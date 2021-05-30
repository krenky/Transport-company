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
    /// Логика взаимодействия для AutoModalWindow.xaml
    /// </summary>
    public partial class AutoModalWindow : Window
    {
        public AutoModalWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string Model
        {
            get { return ModelAuto.Text; }
        }
        public string GNomber
        {
            get { return GosNomber.Text; }
        }
        public string NameRider
        {
            get { return NameRide.Text; }
        }

        private void ModelAuto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

        private void ModelAuto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
                e.Handled = true;
        }

        private void GosNomber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetterOrDigit(e.Text, 0));
        }

        private void GosNomber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
                e.Handled = true;
        }

        private void NameRide_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

        private void NameRide_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Space)
                e.Handled = true;
        }
    }
}
