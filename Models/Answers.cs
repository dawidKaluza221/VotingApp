using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class Answers
    {
        [Key]
        public int IDanswer { get; set; }
        public string Answer { get; set; }
        public Polls Polls {get;set;}
        public ICollection<CountingVotes> CountingVotes { get; set; }
    }
}
