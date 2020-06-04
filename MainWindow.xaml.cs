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
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;

namespace ppeEntityWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void editfFilm(object sender, RoutedEventArgs e)
        {
            gestionFilm g = new gestionFilm();
            g.Show();
        }

        private void editCinema(object sender, RoutedEventArgs e)
        {
            gestionCinema g = new gestionCinema();
            g.Show();
        }
    }
}
