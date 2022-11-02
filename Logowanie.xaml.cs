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
    /// Logika interakcji dla klasy Logowanie.xaml
    /// </summary>
    public partial class Logowanie : Page
    {
        public VotingAppContexts contexts = new VotingAppContexts();
        Users x;
        public Logowanie()
        {
            InitializeComponent();
        }
        
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            
            var a = contexts.SearchName(username);
            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Zapomnieć wpisać loginu no kto to widział wstyd", "Save error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (txtPassword.Password.Length == 0)
            {
                MessageBox.Show("Dawaj hasło a nie", "Save error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
                if (!a.Any())
                {
                    MessageBox.Show("Podales bledny login", "Save error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if(password != a.First().Password) 
                {
                    MessageBox.Show("Niegrzeczny użytkowniku jak chcesz się włamać na czyjeśc konto to prosimy tego nie robić", "Save error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                Glowna glowna = new Glowna(username);
                this.NavigationService.Navigate(glowna);
        }
        
        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            Rejestrowanie rejestruj = new Rejestrowanie();
            this.NavigationService.Navigate(rejestruj);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
