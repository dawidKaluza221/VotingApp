using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class Polls
    {
        [Key]
        public int IDpoll { get; set; }
        public string Questions { get; set; }
        public bool Anonymous { get; set; }
        public string Title { get; set; }
        public Users Users { get; set; }
        
        public ICollection <Answers> Answers { get; set; }
        public ICollection <Votes> Votes { get; set; }
    }
}
