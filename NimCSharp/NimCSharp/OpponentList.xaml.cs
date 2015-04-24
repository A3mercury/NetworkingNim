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
                opName = "Opponent 1",
                ipAddr = "10.56.0.2"
            });
            OpData.Add(new OpponentData
            {
                opName = "Opponent 2",
                ipAddr = "10.56.0.2"
            });
            OpData.Add(new OpponentData
            {
                opName = "Opponent 3",
                ipAddr = "10.56.0.2"
            });
            OpData.Add(new OpponentData
            {
                opName = "Opponent 4",
                ipAddr = "10.56.0.2"
            });

            InitializeComponent();
        }

        public ObservableCollection<OpponentData> OpponentCollection
        {
            get { return OpData; }
        }

        public class OpponentData
        {
            public string opName { get; set; }
            public string ipAddr { get; set; }
            //public Button inviteBtn;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
