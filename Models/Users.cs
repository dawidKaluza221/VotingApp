using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class  Users
    {
        [Key]
        public int IDuser { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        public ICollection <Polls> Polls { get; set; }
        public ICollection <Votes> Votes { get; set; }
    }
}
