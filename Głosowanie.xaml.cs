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
    /// Logika interakcji dla klasy Głosowanie.xaml
    /// </summary>
    public partial class Głosowanie : Page
    {
        public string tytul { get; set; }
        public string pytanie { get; set; }
        public string odp { get; set; }
        public VotingAppContexts contexts = new VotingAppContexts();
        private Polls poll;
        private CountingVotes Liczenie=new CountingVotes();
        private Answers answers;
        private string login;
        private Users users;
        private string name;
        private int idd;

        //private Votes votes;
        Votes votes= new Votes();
        bool sprawdzenie1 = false;
        bool sprawdzenie2 = false;
        public Głosowanie(Polls poll,string login) 
        {
            InitializeComponent();
            this.poll = poll;
            this.login = login;
            var b = contexts.SearchName(login);
            users = b.First();
            tytul = poll.Title;
            pytanie = poll.Questions;
            DataContext = this;
            var a = contexts.ListaOdp(poll.IDpoll);
        }
        private void bWyniki_Click(object sender, RoutedEventArgs e)
        {
            Wyniki wyniki = new Wyniki(poll,login);
            this.NavigationService.Navigate(wyniki);
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Ankiety ankiety = new Ankiety(login);
            this.NavigationService.Navigate(ankiety);   
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StackPanel_loaded(object sender, RoutedEventArgs e)
        {
            Buttonsy.Children.Clear();
            var a = contexts.ListaOdp1(poll.IDpoll);
            
            for (int i=0;i<a.Count;i++)
            {
                RadioButton rdo =new RadioButton();
                rdo.GroupName = "RadioBut";
                rdo.Name = "RadioButton"+i;
                rdo.Checked += new RoutedEventHandler(radioButton_CheckedChanged);
                rdo.Content = a[i].Answer;
                rdo.Tag=a[i].IDanswer;
                Buttonsy.Children.Add(rdo);
            }
            
        }

        private void Akceptacja_Click(object sender, RoutedEventArgs e)
        {
            
            var a = contexts.TakePolls(poll.IDpoll);
            var id=users.IDuser;
            var odp = contexts.TakeVote(a.First().IDpoll,id);
            
            foreach (Votes idus in odp) 
            {
                
                if (idus.Polls.IDpoll == a.First().IDpoll) 
                {
                    if (idus.Users.IDuser == id)
                    {
                        sprawdzenie1 = true;
                        break;
                    }
                }
            }
            if (sprawdzenie1 == true)
            {
                MessageBoxResult result = MessageBox.Show("Kolego ale juz głosowałes,zostajesz przeniesiony do wyników", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                if (MessageBoxResult.OK == result)
                {
                    Wyniki wyniki = new Wyniki(poll, login);
                    this.NavigationService.Navigate(wyniki);
                }
            }
            else
            {
                if (name != null)
                {

                    votes.Polls = a.First();
                    votes.Users = users;
                    votes.Vote = true;
                    contexts.Votes.Add(votes);

                    var b = contexts.PoOdp(idd, poll.IDpoll);
                    Liczenie.Answers = b.First();
                    Liczenie.IsVote = true;
                    contexts.CountingVotes.Add(Liczenie);

                    contexts.SaveChanges();
                    Wyniki wyniki = new Wyniki(poll, login);
                    this.NavigationService.Navigate(wyniki);

                }
                else
                {
                    MessageBox.Show("Ziomo kliknij w RadioButton", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

        }
        private void radioButton_CheckedChanged(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            name = (string)button.Content;
            idd = Int32.Parse(button.Tag.ToString());

        }
    }
}
