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

        public GameSetup()
        {
            RPData.Add(new RockPileData(1));
            RPData.Add(new RockPileData(2));
            RPData.Add(new RockPileData(3));

            InitializeComponent();
        }

        public ObservableCollection<RockPileData> PileCountCollection
        {
            get { return RPData; }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {

        }
    }

    public class RockPileData
    {
        public string RockPile { get; set; }
        public TextBox Rocks;

        public RockPileData(int PileNum)
        {
            Rocks = new TextBox();
            RockPile = "Number of Rocks for Pile " + PileNum + ": ";
        }

        public int RockTextBoxValue()
        {
            return int.Parse(Rocks.Text);
        }
    }
}
