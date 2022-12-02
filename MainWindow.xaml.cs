using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
        #region Properties
        TextBlock? winnerText;
        Button? rematchButton;
        Button? exitButton;
        ContentControl? playfieldControl;

        Button? playButton1;
        Button? playButton2;
        Button? playButton3;

        Button? playButton4;
        Button? playButton5;
        Button? playButton6;

        Button? playButton7;
        Button? playButton8;
        Button? playButton9;

        List<Button>? playbuttonList = new();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // get objects inside Window
            winnerText = FindName("GameOverText") as TextBlock;
            rematchButton = FindName("Rematch") as Button;
            exitButton = FindName("Exit") as Button;
            playfieldControl = FindName("PlayfieldControl") as ContentControl;

            LoadButtons();

            GameLogic.GameOverEvent += GameOverHandler;
            App.RematchEvent += RematchHandler;
        }

        #region Init
        private void LoadButtons()
        {
            if (playbuttonList != null)
            {
                playButton1 = FindName("Btn1") as Button;
                if (playButton1 != null) { playbuttonList.Add(playButton1); }

                playButton2 = FindName("Btn2") as Button;
                if (playButton2 != null) { playbuttonList.Add(playButton2); }

                playButton3 = FindName("Btn3") as Button;
                if (playButton3 != null) { playbuttonList.Add(playButton3); }

                //-------------------------------------------
                playButton4 = FindName("Btn4") as Button;
                if (playButton4 != null) { playbuttonList.Add(playButton4); }

                playButton5 = FindName("Btn5") as Button;
                if (playButton5 != null) { playbuttonList.Add(playButton5); }

                playButton6 = FindName("Btn6") as Button;
                if (playButton6 != null) { playbuttonList.Add(playButton6); }

                //-------------------------------------------
                playButton7 = FindName("Btn7") as Button;
                if (playButton7 != null) { playbuttonList.Add(playButton7); }

                playButton8 = FindName("Btn8") as Button;
                if (playButton8 != null) { playbuttonList.Add(playButton8); }

                playButton9 = FindName("Btn9") as Button;
                if (playButton9 != null) { playbuttonList.Add(playButton9); }
            }
        }

        #endregion

        #region Methods
        private void Window_SizeChanged(object? sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged) { this.Width = e.NewSize.Height; }
            else { this.Height = e.NewSize.Width; }
        }

        #endregion

        #region EventHandler
        private void GameOverHandler(object? sender, byte decider)
        {
            // opaccity von allen Sachen im Hintergrund auf 0,3 setzen
            if (playfieldControl != null)
            {
                playfieldControl.Opacity = 0.3;
            }

            // Entscheidung Gewinner -> Text ändern
            if (winnerText != null)
            {
                if (decider == 0)
                {
                    // X gewonnen
                    winnerText.Text = "X has won";

                }
                else if (decider == 1)
                {
                    // Kreis Gewonnen
                    winnerText.Text = "O has won";
                }
                else
                {
                    //untenschieden
                    winnerText.Text = "Draw";
                }

                // TextBlock aktivieren
                winnerText.Visibility = Visibility.Visible;
            }

            if (rematchButton != null)
            {
                rematchButton.Visibility = Visibility.Visible;
            }


            if (exitButton != null)
            {
                exitButton.Visibility = Visibility.Visible;
            }

            if (playbuttonList != null)
            {
                foreach (Button btn in playbuttonList)
                {
                    btn.IsEnabled = false;
                }
            }
        }

        private void RematchHandler(object? sender, EventArgs e)
        {
            if (winnerText != null)
            {
                winnerText.Visibility = Visibility.Hidden;
            }
            if (rematchButton != null)
            {
                rematchButton.Visibility = Visibility.Hidden;
            }
            if (exitButton != null)
            {
                exitButton.Visibility = Visibility.Hidden;
            }

            if (playfieldControl != null)
            {
                playfieldControl.Opacity = 1;
            }

            if (playbuttonList != null)
            {
                foreach (Button btn in playbuttonList)
                {
                    btn.Content = null;
                    btn.IsEnabled = true;
                }
            }

        }
        #endregion
    }
}

