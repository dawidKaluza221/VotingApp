using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy Rejestrowanie.xaml
    /// </summary>
    public partial class Rejestrowanie : Page
    {
        public VotingAppContexts contexts = new VotingAppContexts();
        

        public Rejestrowanie()
        {
        
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            string email=txtEmail.Text;
            string username=txtUsername.Text;
            var a = contexts.SearchName(username);
            var b=contexts.SearchEmail(email);
            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Użytkowniku drogi uzupełnij login ", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Użytkowniku drogi uzupełnij email", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Użytkowniku drogi format maila nie pasuje", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtPassword.Password.Length == 0)
            {
                MessageBox.Show("Użytkowniku drogi uzupełnij hasło", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (a.Count == 0 && b.Any() == false)
                {
                    users.Nickname = txtUsername.Text;
                    users.Email = txtEmail.Text;
                    users.Password = txtPassword.Password;
                    contexts.Users.Add(users);
                    contexts.SaveChanges();
                    Logowanie loguj = new Logowanie();
                    this.NavigationService.Navigate(loguj);
                    return;
                }
                else 
                {
                    if (a.Any()==true)
                    {
                        MessageBox.Show("Uzytkownik o takim nicku juz istnieje", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if(b.Any()==true)
                    {
                        MessageBox.Show("Email został juz użyty", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                
            }
                
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
