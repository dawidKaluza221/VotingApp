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
    /// Logika interakcji dla klasy Ankiety.xaml
    /// </summary>
    public partial class Ankiety : Page
    {
        public VotingAppContexts contexts = new VotingAppContexts();
        private int LiczbaElement;
        private string login;
        public List<Polls> listAnkiet { get; set; }
        public Ankiety( string login)
        {
            InitializeComponent();
            
            listAnkiet = new List<Polls>();
            if (contexts.Polls.Any() == true) 
            {
                foreach (Polls polls in contexts.Polls)
                {
                    if (polls.Anonymous == false)
                    {
                        listAnkiet.Add(polls);

                    }
                }
            }
            this.login = login;
            DataContext = this;

        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Glowna glowna = new Glowna(login);
            this.NavigationService.Navigate(glowna);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var items = (ListView)sender;
            var tytul = (Polls)items.SelectedItem;
            Głosowanie glos = new Głosowanie(tytul,login);
            this.NavigationService.Navigate(glos);
        }
    }
}
