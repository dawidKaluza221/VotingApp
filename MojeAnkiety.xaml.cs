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
    /// Logika interakcji dla klasy MojeAnkiety.xaml
    /// </summary>
    public partial class MojeAnkiety : Page
    {
        public VotingAppContexts contexts = new VotingAppContexts();
        public List<Polls> listAnkiet { get; set; }
        ListView listview = new ListView();
        private Users users;
        Polls polls;
        private string login;

        public MojeAnkiety(string login)
        {
            InitializeComponent();
            this.login = login;
            var a = contexts.SearchName(login);
            listAnkiet = new List<Polls>();

            listAnkiet = contexts.ListaPytanId(login);
            
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
            var a = contexts.TakePolls(tytul.IDpoll);
            if (a.First().Anonymous == false)
            {
                MessageBoxResult result = MessageBox.Show("Jesli chcesz zakonczyc ankiete klikenij tak a jesli chcesz zobaczyc wynik kliknij nie", "Co dalej z twoim życiem", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    polls = a.First();
                    polls.Anonymous = true;
                    contexts.Polls.Update(polls);
                    contexts.SaveChanges();
                    this.NavigationService.Refresh();
                    MojeAnkiety mojeAnkiety = new MojeAnkiety(login);
                    this.NavigationService.Navigate(mojeAnkiety);
                }
                else if (result == MessageBoxResult.No)
                {
                    Wyniki wynik = new Wyniki(tytul,login);
                    this.NavigationService.Navigate(wynik);
                }
                else
                {
                    MojeAnkiety mojeAnkiety = new MojeAnkiety(login);
                    this.NavigationService.Navigate(mojeAnkiety);

                }

            }
            else 
            {
                MessageBoxResult result = MessageBox.Show("Ankieta została zakończona.Czy chcesz zobaczyć wynik?", "Co dalej z twoim życiem", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    Wyniki wynik = new Wyniki(tytul,login);
                    this.NavigationService.Navigate(wynik);
                }
                else
                {
                    MojeAnkiety mojeAnkiety = new MojeAnkiety(login);
                    this.NavigationService.Navigate(mojeAnkiety);

                }
            }
            
        }
    }
}
