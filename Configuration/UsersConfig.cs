using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VotingApp.Configuration
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
         { 
            builder.ToTable("Users");

            builder
                .HasMany(x => x.Polls)
                .WithOne(x => x.Users);
            builder
                .HasMany(x => x.Votes)
                .WithOne(x => x.Users);
         }
    }
}
