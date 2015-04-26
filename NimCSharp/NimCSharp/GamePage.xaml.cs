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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        ObservableCollection<RocksPerPile> Piles =
            new ObservableCollection<RocksPerPile>();

        Ellipse Rock;

        public GamePage()
        {
            //Piles.Add(new RocksPerPile { NumOfRocksInPile = 1 });
            //Piles.Add(new RocksPerPile { NumOfRocksInPile = 5 });

            Piles.Add(new RocksPerPile(5) {  });

            InitializeComponent();

            
        }

        public static Ellipse NewRock()
        {
            Ellipse R = new Ellipse();
            R.Fill = Brushes.Black;
            R.HorizontalAlignment = HorizontalAlignment.Center;
            R.VerticalAlignment = VerticalAlignment.Center;
            R.StrokeThickness = 3;
            R.Width = 20;
            R.Height = R.Width;
            return R;
        }

        public ObservableCollection<RocksPerPile> RockPerPileCollection
        {
            get { return Piles; }
        }

        private void EndTurn_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void NumToTake_Changed(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class RocksPerPile
    {
        public int NumOfRocksInPile;// { get; set; }
        public ObservableCollection<Ellipse> Rocks { get; set; }

        public RocksPerPile(int num)
        {
            NumOfRocksInPile = num;
            Rocks = new ObservableCollection<Ellipse>();

            for(int i = 0; i < NumOfRocksInPile; i++)
            {
                Rocks.Add(NewRock());
            }
        }

        public ObservableCollection<Ellipse> RocksPileStuff
        {
            get { return Rocks; }
        }

        public Ellipse NewRock()
        {
            Ellipse R = new Ellipse();
            R.Fill = Brushes.Black;
            R.HorizontalAlignment = HorizontalAlignment.Center;
            R.VerticalAlignment = VerticalAlignment.Center;
            R.StrokeThickness = 3;
            R.Width = 20;
            R.Height = R.Width;
            return R;
        }
    }
}
