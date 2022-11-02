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
    public class PollsConfig : IEntityTypeConfiguration<Polls>
    {
        public void Configure(EntityTypeBuilder<Polls> builder)
        { 
            builder.ToTable("Polls");

            builder
                .HasMany(x => x.Votes)
                .WithOne(x => x.Polls);
            builder
                .HasMany(x => x.Answers)
                .WithOne(x => x.Polls);
        }
    }
}
