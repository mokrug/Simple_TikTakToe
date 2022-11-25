using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace Simple_TikTakToe
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            GameLogic.GameOverEvent += GameOverHandler;
        }

        // event handler
        public static void GameOverHandler(object sender, byte decider)
        {
            if (decider == 0)
            {
                // X gewonnen
            }
            else if (decider == 1)
            {
                // Kreis Gewonnen
            }
            else
            {
                //untenschieden
            }
        }



    }
}
