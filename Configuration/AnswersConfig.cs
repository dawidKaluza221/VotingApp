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
    public class AnswersConfig : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
            builder.ToTable("Answers");

            builder
                .HasMany(x => x.CountingVotes)
                .WithOne(x => x.Answers);
        }
    }
}
