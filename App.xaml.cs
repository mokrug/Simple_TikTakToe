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

        private void Change_Image(object sender, RoutedEventArgs e)
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

                b.IsEnabled = false;
                counter++;
            }


        }
    }
}
