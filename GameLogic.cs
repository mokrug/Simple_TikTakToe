using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Simple_TikTakToe
{
    public class GameLogic
    {
        public static event EventHandler<byte> GameOverEvent;

       
        int[,] playfield = new int[3, 3];
        List<int> results = new();
        int spielzug;

        public GameLogic()
        {
            emptyArray();
            spielzug = 0;
        }

        public  void zahl_eintragen(string buttonName, bool isX)
        {
            // Bei X 10 eintragen, bei O 100
            int eintragen;
            if (isX)
            {
                eintragen = 10;
            }
            else
            {
                eintragen = 100;
            }

            // Button1 -> Feld [0,0] 
            if      (buttonName == "Btn1") { playfield[0, 0] = eintragen; }
            else if (buttonName == "Btn2") { playfield[0, 1] = eintragen; }
            else if (buttonName == "Btn3") { playfield[0, 2] = eintragen; }

            else if (buttonName == "Btn4") { playfield[1, 0] = eintragen; }
            else if (buttonName == "Btn5") { playfield[1, 1] = eintragen; }
            else if (buttonName == "Btn6") { playfield[1, 2] = eintragen; }

            else if (buttonName == "Btn7") { playfield[2, 0] = eintragen; }
            else if (buttonName == "Btn8") { playfield[2, 1] = eintragen; }
            else if (buttonName == "Btn9") { playfield[2, 2] = eintragen; }
            else
            {
                throw new Exception("Konnte den Button keinem Feld zuweisen");
            }

            // frühestens nach spielzug 4 
            if (spielzug > 3)
            {
                ergebnisse_überprüfen();
            }

            // nächster Spielzug
            spielzug++;
        }

         void ergebnisse_überprüfen()
        {
            // Geht jede reihe horizontal ab und addiert die 3 zahlen
            for (int y = 0; y < 3; y++)
            {
                int xzahl = 0;
                for (int x = 0; x < 3; x++)
                {
                    xzahl += playfield[y, x];
                }
                results.Add(xzahl);
            }

            // Geht jede reihe vertikal ab und addiert die 3 zahlen
            for (int x = 0; x < 3; x++)
            {
                int yzahl = 0;
                for (int y = 0; y < 3; y++)
                {
                    yzahl += playfield[y, x];
                }
                results.Add(yzahl);
            }

            // Überprüfung der diagonalen
            int diagonalen = 0;
            for (int y = 0; y < 3; y++)
            {
                diagonalen += playfield[y, y];
            }
            results.Add(diagonalen);

            diagonalen = 0;
            for (int y = 2; y >= 0; y--)
            {
                diagonalen += playfield[y, y];
            }
            results.Add(diagonalen);


            if (results.Contains(300))
            {
                CircleWon();
                spielzug = 0;
            }
            else if (results.Contains(30))
            {
                XWon();
                spielzug = 0;
            }
            else if (spielzug > 7)
            {
                Draw();
                spielzug = 0;
            }
            else
            {
                // weiterspielen
            }

            // Liste clearen für nächsten durchlauf
            results.Clear();
        }

        async void emptyArray()
        {
            // Geht jede reihe horizontal ab und setzt 0
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    playfield[y, x] = 0;
                }
            }
        }

        private void CircleWon()
        {
            // opens a Popup Window with specific Message
              
            GameOverWindow gameover = new GameOverWindow();
            gameover.gamefinishedreason = "Circle won the game!!!";
            gameover.ShowDialog();


        }

        private void XWon()
        {
            // opens a Popup Window with specific Message
                     
            GameOverWindow gameover = new GameOverWindow();
            gameover.gamefinishedreason = "X won the game!!!";
            gameover.ShowDialog();

        }

        private void Draw()
        {
            // opens a Popup Window with specific Message
                   
            GameOverWindow gameover = new GameOverWindow();
            gameover.gamefinishedreason = "Draw, nobody won!!!";
            gameover.ShowDialog();

        }



    }
}
