﻿using System;
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
    /// Логика взаимодействия для TraceModalWindow.xaml
    /// </summary>
    public partial class TraceModalWindow : Window
    {
        public TraceModalWindow()
        {
            InitializeComponent();
        }

        DateTime selectedDate = DateTime.Now;

        private void Accept_Click(object sender, RoutedEventArgs e)
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
        public int GetMass
        {
            get { return Convert.ToInt32(Mass.Text); }
        }
        public DateTime GetDate
        {
            get { return selectedDate; }
        }

        private void DatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = (DateTime)DatePick.SelectedDate;
        }

        private void Start_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

        private void Finish_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

        private void Mass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void AutoInfo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }
    }
}
