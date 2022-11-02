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
using VotingApp.Contexts;
using VotingApp.Models;

namespace VotingApp
{
    /// <summary>
    /// Logika interakcji dla klasy Glowna.xaml
    /// </summary>
    public partial class Glowna : Page
    {
        public VotingAppContexts contexts = new VotingAppContexts();
        private string login;

        public Glowna(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void bZaluguj_Click(object sender, RoutedEventArgs e)
        {
            Logowanie logowanie = new Logowanie();  
            this.NavigationService.Navigate(logowanie);
        }

        private void mojeAnkiety_Click(object sender, RoutedEventArgs e)
        {
            MojeAnkiety mojeAnkiety = new MojeAnkiety(login);
            this.NavigationService.Navigate(mojeAnkiety);       
        }
        
        private void dodajAnkiete_Click(object sender, RoutedEventArgs e)
        {
            Dodaj dodajAnkiete = new Dodaj(login);
            this.NavigationService.Navigate(dodajAnkiete);  
        }

        private void wszystkieAnkiety_Click(object sender, RoutedEventArgs e)
        {
            var c = contexts.LiczbaPoll();
            Ankiety ankiety = new Ankiety(login);
            this.NavigationService.Navigate(ankiety);
        }
    }
}
