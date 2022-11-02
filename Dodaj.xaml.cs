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
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Page
    {
        private string login;
        public VotingAppContexts contexts = new VotingAppContexts();
        
        public Dodaj(string user)
        {
            InitializeComponent();

            this.login = user;
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Polls polls = new Polls();
            
            if (Title.Text.Length <= 5)
            {
                MessageBox.Show("No ziomo chcesz ankiete to wymyśl tytuł", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Question.Text.Length <= 5)
            {
                MessageBox.Show("No ziomo chcesz ankiete to wymyśl pytanko", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var a = contexts.SearchName(login);
                var b = contexts.TakePollsTitle(Title.Text);

                polls.Questions = Question.Text;
                polls.Title = Title.Text;
                if (a.Any() == true)
                {
                    polls.Users = a.First();
                }
                contexts.Add(polls);
                contexts.SaveChanges();

                foreach (var listBoxItem in OdpListBox.Items)
                {
                    Answers answer = new Answers();
                    answer.Answer = listBoxItem.ToString();
                    answer.Polls = polls;
                    contexts.Add(answer);

                }
               
                contexts.SaveChanges();

                var c = contexts.LiczbaPoll();
                Ankiety ankiety=new Ankiety(login);
                this.NavigationService.Navigate(ankiety);
            }
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void dodajOdp_Click(object sender, RoutedEventArgs e)
        {
            if (OdpListBox.Items.Count==8)
            {
                MessageBox.Show("Bro nie szlej max 8 odpowiedzi", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string odpowiedz = Odp.Text;
                Odp.Clear();
                OdpListBox.Items.Add(odpowiedz);

            }
           

        }




        private void usunOdp_Click(object sender, RoutedEventArgs e)
        {
            if (OdpListBox.SelectedItem == null)
            {
                MessageBox.Show("Nie no pierw zaznacz co chcesz usunąć bro", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }else
            OdpListBox.Items.Remove(OdpListBox.SelectedItem);
        }
    }
}
