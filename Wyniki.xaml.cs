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
using LiveCharts;
using LiveCharts.Wpf;
using VotingApp.Contexts;
using VotingApp.Models;

namespace VotingApp
{
    /// <summary>
    /// Logika interakcji dla klasy Wyniki.xaml
    /// </summary>
    public partial class Wyniki : Page
    {
        public string tytul { get; set; }
        public string pytanie { get; set; }
        public string odp { get; set; }
        public VotingAppContexts contexts = new VotingAppContexts();
        private CountingVotes Liczenie = new CountingVotes();
        private Polls poll;
        private string login;
        private string odpowiedz;
        private int ile;
        public class Odpowiedzi
        {
            string odpowiedz;
            int ile;
        }
        public Wyniki(Polls poll, string login) {
            this.login = login;
            InitializeComponent();
            this.poll = poll;
            tytul = poll.Title;
            pytanie = poll.Questions;
            DataContext = this;
            var a = contexts.ListaOdp(poll.IDpoll);

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
           
            PieChart1.Series =new SeriesCollection();
            foreach (var p in a)
            {
                int x = contexts.IleOdp(p.IDanswer);
                var pie = new PieSeries();
                pie.Title=p.Answer.ToString();
                pie.Values=new ChartValues<double> { x };
                pie.DataLabels=true;
                pie.LabelPoint = PointLabel;
                PieChart1.Series.Add(pie);
            }
            

            DataContext = this;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Odp_loaded(object sender, RoutedEventArgs e)
        {
            var a = contexts.ListaOdp1(poll.IDpoll);

            for (int i = 0; i<a.Count; i++)
            {
                var rdo = new ListViewItem();
                rdo.Content = a[i].Answer+"   -   "+contexts.IleOdp(a[i].IDanswer);
                Buttonsy.Items.Add(rdo);
            }

        }


        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Glowna  glowna = new Glowna(login);
            this.NavigationService.Navigate(glowna);
        }
    }
}
