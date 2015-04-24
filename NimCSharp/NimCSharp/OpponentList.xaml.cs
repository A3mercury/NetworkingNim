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
using System.Collections.ObjectModel;

namespace NimCSharp
{
    /// <summary>
    /// Interaction logic for OpponentList.xaml
    /// </summary>
    public partial class OpponentList : Page
    {
        ObservableCollection<OpponentData> OpData = new ObservableCollection<OpponentData>();

        public OpponentList()
        {
            // Add some temp values
            OpData.Add(new OpponentData
            {
                OpponentName = "Opponent 1",
                IPAddress = "10.56.0.2"
            });
            OpData.Add(new OpponentData
            {
                OpponentName = "Opponent 2",
                IPAddress = "10.56.0.2"
            });
            OpData.Add(new OpponentData
            {
                OpponentName = "Opponent 3",
                IPAddress = "10.56.0.2"
            });
            OpData.Add(new OpponentData
            {
                OpponentName = "Opponent 4",
                IPAddress = "10.56.0.2"
            });

            InitializeComponent();

            ToggleChallengeVisibility(false);
            //ToggleChallengeVisibility(true);
        }

        public ObservableCollection<OpponentData> OpponentCollection
        {
            get { return OpData; }
        }

        public class OpponentData
        {
            public string OpponentName { get; set; }
            public string IPAddress { get; set; }
        }

        public void Invited()
        {
            ToggleChallengeVisibility(true);
        }

        private void AcceptGameInvite(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new WaitingOnOpponent());
        }

        private void DeclineGameInvite(object sender, RoutedEventArgs e)
        {
            ToggleChallengeVisibility(false);
        }

        private void ToggleChallengeVisibility(bool result)
        {
            if(result)
            {
                Challenged.Visibility = Visibility.Visible;
                Challenged_Label.Visibility = Visibility.Visible;
                Challenged_Accept.Visibility = Visibility.Visible;
                Challenged_Decline.Visibility = Visibility.Visible;
            }
            else
            {
                Challenged.Visibility = Visibility.Hidden;
                Challenged_Label.Visibility = Visibility.Hidden;
                Challenged_Accept.Visibility = Visibility.Hidden;
                Challenged_Decline.Visibility = Visibility.Hidden;
            }
        }
    }
}