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

namespace NimCSharp
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public static string Username;

        public MenuPage()
        {
            InitializeComponent();

            Username = UsernameBox.Text;
        }

        private void FindPlayers(object sender, RoutedEventArgs e)
        {
            if(UsernameBox.Text != "" && UsernameBox.Text != "Username")
                MainWindow._MainFrame.Navigate(new OpponentList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // go to the game setup page for testing
            MainWindow._MainFrame.Navigate(new GameSetup());
        }
    }
}
