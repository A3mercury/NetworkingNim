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
    /// This Window is just the container for the pages inside of it.
    /// As soon as the Window is initialized it will navigate it's frame
    /// to the MenuPage
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame _MainFrame;

        public MainWindow()
        {
            InitializeComponent();

            _MainFrame = _MainWindowFrame;
          
            _MainWindowFrame.Navigate(new MenuPage());
        }
    }
}
