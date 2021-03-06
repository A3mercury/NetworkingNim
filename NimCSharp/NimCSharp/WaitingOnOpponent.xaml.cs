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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NimCSharp
{
    /// <summary>
    /// Interaction logic for WaitingOnOpponent.xaml
    /// </summary>
    public partial class WaitingOnOpponent : Page
    {
        public WaitingOnOpponent()
        {
            InitializeComponent();
        }

        private void CancelGame(object sender, RoutedEventArgs e)
        {
            // disconnect from opponent

            // go back to main menu
            MainWindow._MainFrame.Navigate(new MenuPage());
        }
    }
}
