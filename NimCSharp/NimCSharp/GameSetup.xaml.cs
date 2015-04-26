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
            //RPData.Add(new RockPileData
            //{
            //    RockPile = "Number of Rocks for Pile " + 1 + ": (1 - 20)",
            //    Rocks = 1
            //});
            //RPData.Add(new RockPileData
            //{
            //    RockPile = "Number of Rocks for Pile " + 2 + ": (1 - 20)",
            //    Rocks = 1
            //});
            //RPData.Add(new RockPileData
            //{
            //    RockPile = "Number of Rocks for Pile " + 3 + ": (1 - 20)",
            //    Rocks = 1
            //});
            //RPData.Add(new RockPileData
            //{
            //    RockPile = "Number of Rocks for Pile " + 4 + ": (1 - 20)",
            //    Rocks = 1
            //});

            InitializeComponent();
        }

        public ObservableCollection<RockPileData> PileCountCollection
        {
            get { return RPData; }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {

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
                                Rocks = 1
                            });
                        }
                    }
                }
            }
        }
        private void RocksNum_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            int num = 0;
            if(int.TryParse(tb.Text, out num))
            {
                if (num < 1 || num > 20)
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

        //public RockPileData(int PileNum)
        //{
        //    Rocks = new TextBox();
        //    Rocks.Width = 100;
        //    Rocks.Height = 20;
        //    //RockPile = "Number of Rocks for Pile " + PileNum + ": ";
        //}

        //public int RockTextBoxValue()
        //{
        //    return int.Parse(Rocks.Text);
        //}
    }
}
