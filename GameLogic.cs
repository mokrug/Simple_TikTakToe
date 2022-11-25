using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_TikTakToe
{
    internal class GameLogic
    {
        int[,] playfield = new int[3, 3];           
        List<int> results;                         
        int spielzug = 0;

        GameLogic()
        {
            emptyArray();
        }

        public void zahl_eintragen(string buttonName, bool isX)
        {

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
            for (int y = 3; y > 0; y--)
            {
                diagonalen += playfield[y, y];
            }
            results.Add(diagonalen);


            if (results.Contains(300))
            {
                //kreis wins
            }
            else if (results.Contains(30))
            {
                // x wins
            }
            else if(spielzug>9)
            {
                // unentschieden
            }
            else
            {
                // weiterspielen
            }
        }

        void emptyArray()
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
    }
}
