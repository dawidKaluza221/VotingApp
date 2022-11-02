using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class CountingVotes
    {
        [Key]
        public int IdCVotes { get; set; }
        public bool IsVote { get; set; }
        public Answers Answers { get; set; }
    }
}
