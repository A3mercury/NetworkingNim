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

        List<Visibility> VisibleRocks = new List<Visibility>();

        int incomingPileNum;

        public GamePage(ObservableCollection<RockPileData> RPData)
        {
            incomingPileNum = RPData.Count;
            // for every pile sent
            for(int i = 0; i < RPData.Count; i++)
            {
                // for each rock in the pile
                for(int j = 0; j < 20; j++)
                {
                    if (j < RPData[i].Rocks)
                        VisibleRocks.Add(Visibility.Visible);
                    else
                        VisibleRocks.Add(Visibility.Hidden);
                }

                Piles.Add(new RocksPerPile
                {
                    NumberToTake = 0,
                    Vs1 = VisibleRocks[0], Vs2 = VisibleRocks[1], Vs3 = VisibleRocks[2], Vs4 = VisibleRocks[3],
                    Vs5 = VisibleRocks[4], Vs6 = VisibleRocks[5], Vs7 = VisibleRocks[6], Vs8 = VisibleRocks[7],
                    Vs9 = VisibleRocks[8], Vs10 = VisibleRocks[9], Vs11 = VisibleRocks[10], Vs12 = VisibleRocks[11],
                    Vs13 = VisibleRocks[12], Vs14 = VisibleRocks[13], Vs15 = VisibleRocks[14], Vs16 = VisibleRocks[15],
                    Vs17 = VisibleRocks[16], Vs18 = VisibleRocks[17], Vs19 = VisibleRocks[18], Vs20 = VisibleRocks[19]
                });
                
                // clear the list for the next pile
                VisibleRocks.Clear();
            }

            InitializeComponent(); 
        }

        public ObservableCollection<RocksPerPile> RockPerPileCollection
        {
            get { return Piles; }
        }

        private void EndTurn_Clicked(object sender, RoutedEventArgs e)
        {
            if(DataIsValid())
            {
                foreach(RocksPerPile RPP in Piles)
                {
                    if(RPP.NumberToTake != 0)
                    {
                        int num = RPP.NumberToTake;
                        if (RPP.Vs20 == Visibility.Visible && num > 0) {RPP.Vs20 = Visibility.Hidden; num--;}
                        if (RPP.Vs19 == Visibility.Visible && num > 0) {RPP.Vs19 = Visibility.Hidden; num--;}
                        if (RPP.Vs18 == Visibility.Visible && num > 0) {RPP.Vs18 = Visibility.Hidden; num--;}
                        if (RPP.Vs17 == Visibility.Visible && num > 0) {RPP.Vs17 = Visibility.Hidden; num--;}
                        if (RPP.Vs16 == Visibility.Visible && num > 0) {RPP.Vs16 = Visibility.Hidden; num--;}
                        if (RPP.Vs15 == Visibility.Visible && num > 0) {RPP.Vs15 = Visibility.Hidden; num--;}
                        if (RPP.Vs14 == Visibility.Visible && num > 0) {RPP.Vs14 = Visibility.Hidden; num--;}
                        if (RPP.Vs13 == Visibility.Visible && num > 0) {RPP.Vs13 = Visibility.Hidden; num--;}
                        if (RPP.Vs12 == Visibility.Visible && num > 0) {RPP.Vs12 = Visibility.Hidden; num--;}
                        if (RPP.Vs11 == Visibility.Visible && num > 0) {RPP.Vs11 = Visibility.Hidden; num--;}
                        if (RPP.Vs10 == Visibility.Visible && num > 0) {RPP.Vs10 = Visibility.Hidden; num--;}
                        if (RPP.Vs9 ==  Visibility.Visible && num > 0) {RPP.Vs9 =  Visibility.Hidden; num--;}
                        if (RPP.Vs8 ==  Visibility.Visible && num > 0) {RPP.Vs8 =  Visibility.Hidden; num--;}
                        if (RPP.Vs7 ==  Visibility.Visible && num > 0) {RPP.Vs7 =  Visibility.Hidden; num--;}
                        if (RPP.Vs6 ==  Visibility.Visible && num > 0) {RPP.Vs6 =  Visibility.Hidden; num--;}
                        if (RPP.Vs5 ==  Visibility.Visible && num > 0) {RPP.Vs5 =  Visibility.Hidden; num--;}
                        if (RPP.Vs4 ==  Visibility.Visible && num > 0) {RPP.Vs4 =  Visibility.Hidden; num--;}
                        if (RPP.Vs3 ==  Visibility.Visible && num > 0) {RPP.Vs3 =  Visibility.Hidden; num--;}
                        if (RPP.Vs2 ==  Visibility.Visible && num > 0) {RPP.Vs2 =  Visibility.Hidden; num--;}
                        if (RPP.Vs1 ==  Visibility.Visible && num > 0) {RPP.Vs1 =  Visibility.Hidden; num--;}

                        RPP.NumberToTake = 0;
                        RocksListView.Items.Refresh();
                    }
                }
            }
        }

        private bool DataIsValid()
        {
            bool result = true;
            bool firstNon0 = false;

            foreach (RocksPerPile RPP in Piles)
            {
                if (result)
                {
                    // we found one that is not a 0
                    if (RPP.NumberToTake != 0 && !firstNon0)
                    {
                        firstNon0 = true;

                        // check to see if the number going to take is proper
                        int count = 0;
                        if (RPP.Vs1 == Visibility.Visible) count++;
                        if (RPP.Vs2 == Visibility.Visible) count++;
                        if (RPP.Vs3 == Visibility.Visible) count++;
                        if (RPP.Vs4 == Visibility.Visible) count++;
                        if (RPP.Vs5 == Visibility.Visible) count++;
                        if (RPP.Vs6 == Visibility.Visible) count++;
                        if (RPP.Vs7 == Visibility.Visible) count++;
                        if (RPP.Vs8 == Visibility.Visible) count++;
                        if (RPP.Vs9 == Visibility.Visible) count++;
                        if (RPP.Vs10 == Visibility.Visible) count++;
                        if (RPP.Vs11 == Visibility.Visible) count++;
                        if (RPP.Vs12 == Visibility.Visible) count++;
                        if (RPP.Vs13 == Visibility.Visible) count++;
                        if (RPP.Vs14 == Visibility.Visible) count++;
                        if (RPP.Vs15 == Visibility.Visible) count++;
                        if (RPP.Vs16 == Visibility.Visible) count++;
                        if (RPP.Vs17 == Visibility.Visible) count++;
                        if (RPP.Vs18 == Visibility.Visible) count++;
                        if (RPP.Vs19 == Visibility.Visible) count++;
                        if (RPP.Vs20 == Visibility.Visible) count++;

                        if (RPP.NumberToTake < 1 || RPP.NumberToTake > count)
                            result = false;
                    }
                    else if (RPP.NumberToTake != 0 && firstNon0)
                        result = false;
                }
            }

            // if all are still 0
            if (!firstNon0)
                result = false;

            return result;
        }

        private void NumToTake_Changed(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            int num;
            if(int.TryParse(tb.Text, out num))
            {
                
            }

        }

    }

    public class RocksPerPile
    {
        public int NumberToTake { get; set; }
        public Visibility Vs1 { get; set; }
        public Visibility Vs2 { get; set; }
        public Visibility Vs3 { get; set; }
        public Visibility Vs4 { get; set; }
        public Visibility Vs5 { get; set; }
        public Visibility Vs6 { get; set; }
        public Visibility Vs7 { get; set; }
        public Visibility Vs8 { get; set; }
        public Visibility Vs9 { get; set; }
        public Visibility Vs10 { get; set; }
        public Visibility Vs11 { get; set; }
        public Visibility Vs12 { get; set; }
        public Visibility Vs13 { get; set; }
        public Visibility Vs14 { get; set; }
        public Visibility Vs15 { get; set; }
        public Visibility Vs16 { get; set; }
        public Visibility Vs17 { get; set; }
        public Visibility Vs18 { get; set; }
        public Visibility Vs19 { get; set; }
        public Visibility Vs20 { get; set; }
    }
}
