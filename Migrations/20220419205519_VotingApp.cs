using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Migrations
{
    public partial class VotingApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDuser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDuser);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    IDpoll = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anonymous = table.Column<bool>(type: "bit", nullable: false),
                    UsersIDuser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.IDpoll);
                    table.ForeignKey(
                        name: "FK_Polls_Users_UsersIDuser",
                        column: x => x.UsersIDuser,
                        principalTable: "Users",
                        principalColumn: "IDuser");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    IDanswer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollsIDpoll = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.IDanswer);
                    table.ForeignKey(
                        name: "FK_Answers_Polls_PollsIDpoll",
                        column: x => x.PollsIDpoll,
                        principalTable: "Polls",
                        principalColumn: "IDpoll");
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    IDVote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vote = table.Column<int>(type: "int", nullable: false),
                    PollsIDpoll = table.Column<int>(type: "int", nullable: true),
                    UsersIDuser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.IDVote);
                    table.ForeignKey(
                        name: "FK_Votes_Polls_PollsIDpoll",
                        column: x => x.PollsIDpoll,
                        principalTable: "Polls",
                        principalColumn: "IDpoll");
                    table.ForeignKey(
                        name: "FK_Votes_Users_UsersIDuser",
                        column: x => x.UsersIDuser,
                        principalTable: "Users",
                        principalColumn: "IDuser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_PollsIDpoll",
                table: "Answers",
                column: "PollsIDpoll");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_UsersIDuser",
                table: "Polls",
                column: "UsersIDuser");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PollsIDpoll",
                table: "Votes",
                column: "PollsIDpoll");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UsersIDuser",
                table: "Votes",
                column: "UsersIDuser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
