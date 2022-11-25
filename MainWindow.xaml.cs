using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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
        public void GameOverHandler(object sender, byte decider)
        {
            // Neuen style setzen der opaccity von allen sachen im Hintergrund auf 0,5 setz
            
            
            // Entscheidung Gewinner -> Text ändern
            TextBlock? winner = FindName("GameOverText") as TextBlock;

            if (winner != null)
            {
                // 
                if (decider == 0)
                {
                    // X gewonnen
                    winner.Text = "X has won";
                    
                }
                else if (decider == 1)
                {
                    // Kreis Gewonnen
                    winner.Text = "O has won";
                }
                else
                {
                    //untenschieden
                    winner.Text = "Draw";
                }

                // TextBlock aktivieren
                winner.Visibility = Visibility.Visible;
            }
        }



    }
}
