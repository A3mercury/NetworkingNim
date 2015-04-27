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
    /// Interaction logic for GameSetup.xaml
    /// </summary>
    public partial class GameSetup : Page
    {
        ObservableCollection<RockPileData> RPData = new ObservableCollection<RockPileData>();
        List<int> RocksPerPile = new List<int>();

        public GameSetup()
        {
            InitializeComponent();
        }

        public ObservableCollection<RockPileData> PileCountCollection
        {
            get { return RPData; }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            if(DataIsValid())
                MainWindow._MainFrame.Navigate(new GamePage(RPData));
        }

        private bool DataIsValid()
        {
            bool result = true;

            int parsed;
            if(!int.TryParse(NumOfPiles.Text, out parsed))
                result = false;
            else
            {
                if (parsed < 3 || parsed > 9)
                    result = false;
                else
                {
                    foreach (RockPileData RPD in RPData)
                    {
                        if (RPD.Rocks < 0 && RPD.Rocks > 20)
                            result = false;
                    }
                }

            }

            return result;
        }

        private void NumOfPiles_Changed(object sender, TextChangedEventArgs e)
        {
            PileCountCollection.Clear();
            RPData.Clear();

            if (NumOfPiles.Text != "")
            {
                int num;
                if (int.TryParse(NumOfPiles.Text, out num))
                {

                    if (num < 3 || num > 9)
                    {
                        NumOfPiles.Foreground = Brushes.Red;
                    }
                    else
                    {
                        NumOfPiles.Foreground = Brushes.Black;

                        for(int i = 0; i < num; i++)
                        {

                            RPData.Add(new RockPileData
                            {
                                RockPile = "Number of Rocks for Pile " + (num + 1) + ": (1 - 20)",
                                Rocks = 0,
                                Location = i
                            });
                        }
                    }
                }
            }
        }
        private void RocksNum_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // checks to see if it is a valid number
            int num = 0;
            if(int.TryParse(tb.Text, out num))
            {
                if (num < 0 || num > 20)
                    tb.Foreground = Brushes.Red;
                else
                    tb.Foreground = Brushes.Black;
            }
        }
    }

    public class RockPileData
    {
        public string RockPile { get; set; }
        public int Rocks { get; set; }
        public int Location { get; set; }
    }
}
