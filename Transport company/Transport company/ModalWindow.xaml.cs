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
    /// Логика взаимодействия для ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        public ModalWindow()
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
            get { return Name.Text; }
        }
    }
}
