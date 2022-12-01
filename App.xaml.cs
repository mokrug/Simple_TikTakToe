using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Simple_TikTakToe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        int counter = 0;
        GameLogic game = new();
        public static event EventHandler RematchEvent;

        private void Change_Image(object sender, RoutedEventArgs e)
        {
            Button? b = sender as Button;

            if (b != null)
            {
                if (counter % 2 == 0)
                {
                    b.Content = FindResource("XImage") as Image;
                    game.zahl_eintragen(b.Name, true);
                }
                else
                {
                    b.Content = FindResource("OImage") as Image;
                    game.zahl_eintragen(b.Name, false);
                }
                
                

                b.Opacity= 1;
                b.IsEnabled = false;
                counter++;
            }


        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? b = sender as Button;

            if (b != null)
            {
                if (counter % 2 == 0)
                {
                    b.Content = FindResource("XImage") as Image;
                }
                else
                {
                    b.Content = FindResource("OImage") as Image;
                }
                b.Opacity = 0.5;
            }
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? b = sender as Button;

            if (b != null && b.Opacity != 1)
            {
                b.Content = null;
            }
        }

        private void ExitGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Rematch(object sender, RoutedEventArgs e)
        {
            counter = 0;
            RematchEvent.Invoke(null, EventArgs.Empty);
        }
    }
}
