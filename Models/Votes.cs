using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class Votes
    {
        [Key]
        public int IDVote { get; set; }
        public bool Vote { get; set; }
        public Polls Polls { get; set; }
        public Users Users { get; set; }
    }
}
