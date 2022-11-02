﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingApp.Contexts;

#nullable disable

namespace VotingApp.Migrations
{
    [DbContext(typeof(VotingAppContexts))]
    [Migration("20220506174752_ZmianaBazieV2")]
    partial class ZmianaBazieV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VotingApp.Models.Answers", b =>
                {
                    b.Property<int>("IDanswer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDanswer"), 1L, 1);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PollsIDpoll")
                        .HasColumnType("int");

                    b.HasKey("IDanswer");

                    b.HasIndex("PollsIDpoll");

                    b.ToTable("Answers", (string)null);
                });

            modelBuilder.Entity("VotingApp.Models.CountingVotes", b =>
                {
                    b.Property<int>("IdCVotes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCVotes"), 1L, 1);

                    b.Property<int?>("AnswersIDanswer")
                        .HasColumnType("int");

                    b.Property<bool>("IsVote")
                        .HasColumnType("bit");

                    b.HasKey("IdCVotes");

                    b.HasIndex("AnswersIDanswer");

                    b.ToTable("CountingVotes");
                });

            modelBuilder.Entity("VotingApp.Models.Polls", b =>
                {
                    b.Property<int>("IDpoll")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDpoll"), 1L, 1);

                    b.Property<bool>("Anonymous")
                        .HasColumnType("bit");

                    b.Property<string>("Questions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersIDuser")
                        .HasColumnType("int");

                    b.HasKey("IDpoll");

                    b.HasIndex("UsersIDuser");

                    b.ToTable("Polls", (string)null);
                });

            modelBuilder.Entity("VotingApp.Models.Users", b =>
                {
                    b.Property<int>("IDuser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDuser"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDuser");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("VotingApp.Models.Votes", b =>
                {
                    b.Property<int>("IDVote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDVote"), 1L, 1);

                    b.Property<int?>("PollsIDpoll")
                        .HasColumnType("int");

                    b.Property<int?>("UsersIDuser")
                        .HasColumnType("int");

                    b.Property<bool>("Vote")
                        .HasColumnType("bit");

                    b.HasKey("IDVote");

                    b.HasIndex("PollsIDpoll");

                    b.HasIndex("UsersIDuser");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("VotingApp.Models.Answers", b =>
                {
                    b.HasOne("VotingApp.Models.Polls", "Polls")
                        .WithMany("Answers")
                        .HasForeignKey("PollsIDpoll");

                    b.Navigation("Polls");
                });

            modelBuilder.Entity("VotingApp.Models.CountingVotes", b =>
                {
                    b.HasOne("VotingApp.Models.Answers", "Answers")
                        .WithMany("CountingVotes")
                        .HasForeignKey("AnswersIDanswer");

                    b.Navigation("Answers");
                });

            modelBuilder.Entity("VotingApp.Models.Polls", b =>
                {
                    b.HasOne("VotingApp.Models.Users", "Users")
                        .WithMany("Polls")
                        .HasForeignKey("UsersIDuser");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VotingApp.Models.Votes", b =>
                {
                    b.HasOne("VotingApp.Models.Polls", "Polls")
                        .WithMany("Votes")
                        .HasForeignKey("PollsIDpoll");

                    b.HasOne("VotingApp.Models.Users", "Users")
                        .WithMany("Votes")
                        .HasForeignKey("UsersIDuser");

                    b.Navigation("Polls");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VotingApp.Models.Answers", b =>
                {
                    b.Navigation("CountingVotes");
                });

            modelBuilder.Entity("VotingApp.Models.Polls", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("VotingApp.Models.Users", b =>
                {
                    b.Navigation("Polls");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
