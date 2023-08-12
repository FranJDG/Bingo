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

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num;
        List<int> numerosPasados = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NuevoNumero_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            num = r.Next(1, 91);

            if (!VerificarListaCompleta())
            {
                while (numerosPasados.Contains(num))
                {
                    num = r.Next(1, 91);

                    if (!numerosPasados.Contains(num))
                    {
                        break;
                    }
                }

                string numeroActual = num.ToString();

                NumeroActual.Text = numeroActual;

                Grid container = GridTexBox;

                foreach (var textbox in container.Children.OfType<TextBox>())
                {
                    if (textbox.Tag != null && textbox.Tag.ToString() == numeroActual)
                    {
                        textbox.Background = Brushes.Green;
                        textbox.Foreground = Brushes.White;

                        numerosPasados.Add(num);
                    }
                }
            }
            else
            {
                MessageBox.Show("Fin del juego,\nhaz click en nuevo juego\npara volver a empezar", "Fin del juego", MessageBoxButton.OK, MessageBoxImage.Exclamation);                
            }          
            
        }

        private bool VerificarListaCompleta()
        {
            for (int i = 1; i <= 90; i++)
            {
                if (!numerosPasados.Contains(i))
                {
                    // La lista no contiene el número i, por lo que no está completa
                    return false;
                }
            }

            // La lista contiene todos los números del 1 al 90
            return true;
        }


        private void NuevoJuego_Click(object sender, RoutedEventArgs e)
        {
            numerosPasados.Clear();

            NumeroActual.Text = "";

            Grid container = GridTexBox;

            foreach (var textbox in container.Children.OfType<TextBox>())
            {  
                textbox.Background = Brushes.White;
                textbox.Foreground = Brushes.Black;
            }
        }

        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bingo\n\nCreado con WPF en Visual Studio\n\nv1.0   17/07/2023\n\nFran Díaz", "Acerca de Bingo", MessageBoxButton.OK, MessageBoxImage.Information);
        }        
    }
}

