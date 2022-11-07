using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace VotingApp.Contexts
{
    public class VotingAppContexts : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VotingApp;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Polls> Polls { get; set; }
        public virtual DbSet<Votes> Votes { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<CountingVotes> CountingVotes { get; set; }


        public virtual ICollection<Users> SearchName(string searchName)
        {
            var result = Users
                .Where(x => x.Nickname.Contains(searchName))
                .ToList();
           
            return result; 
        }
        public virtual ICollection<Users> SearchEmail(string searchEmail)
        {
            var result = Users
                .Where(x => x.Email.Contains(searchEmail))
                .ToList();
            return result;
        }
        public virtual ICollection<Users> SerarchPassword(string searchPassword)
        {
            var result = Users
                .Where(x => x.Password.Contains(searchPassword))
                .ToList();
            return result;
        }

        public virtual ICollection<Polls> TakePollsTitle(string takePolls)
        {
            var result = Polls
                .Where(x => x.Title.Contains(takePolls))
                .ToList();
            return result;       
        }
        public virtual ICollection<Polls> TakePolls(int takePolls)
        {
            var result = Polls
                .Where(x => x.IDpoll.Equals(takePolls))
                .ToList();
            return result;
        }
        public virtual int LiczbaPoll() 
        {
            var result = Polls.Count();
            return result;
        }
        public virtual ICollection<Answers> ListaOdp(int IdPoll) 
        {
            var result = Answers.Where(x => x.Polls.IDpoll.Equals(IdPoll)).ToList();
                return result;
        }
        public virtual List<Answers> ListaOdp1(int IdPoll)
        {
            var result = Answers.Where(x => x.Polls.IDpoll.Equals(IdPoll)).ToList();
            return result;
        }
        public virtual List<Polls> ListaPytanId(string Login)
        {
            var result = Polls.Where(x => x.Users.Nickname.Contains(Login)).ToList();
            return result;
        }
        public virtual ICollection<Votes> SearchVotes(string searchVotes)
        {
            var result = Votes
                .Where(x => x.Vote.Equals(searchVotes))
                .ToList();
            return result;
        }
        public virtual List<Answers> PoOdp(int answer,int id) 
        {
            List<Answers> nowa = new List<Answers>();
            var result = Answers.Where(x => x.Polls.IDpoll.Equals(id)).ToList();
                foreach(Answers dan in result)
                {
                    if (dan.IDanswer == answer) 
                    {
                        nowa.Add(dan);
                    }
                }
                return nowa; 
        }

        public virtual int IleOdp(int idAnswer)
        {
            int result = CountingVotes.Count(x => x.Answers.IDanswer.Equals(idAnswer));
            return result;
        }

        public virtual ICollection<Users> SearchidUs(int searchid)
        {
            var result = Users
                .Where(x => x.IDuser.Equals(searchid))
                .ToList();

            return result;
        }
        public virtual ICollection<Polls> Searchidpo(int searchid)
        {
            var result = Polls
                .Where(x => x.IDpoll.Equals(searchid))
                .ToList();

            return result;
        }

        public virtual List<Votes> TakeVote(int serachidpoll,int searchiduser)
        {
            var result = Votes.Include(x => x.Users).Include(x => x.Polls).ToList();
            return result;
        }
    }
}
