using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Migrations
{
    public partial class ZmianaBazieV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_CountingVotes_CountingVotesIdCVotes",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_CountingVotesIdCVotes",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CountingVotesIdCVotes",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "AnswersIDanswer",
                table: "CountingVotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountingVotes_AnswersIDanswer",
                table: "CountingVotes",
                column: "AnswersIDanswer");

            migrationBuilder.AddForeignKey(
                name: "FK_CountingVotes_Answers_AnswersIDanswer",
                table: "CountingVotes",
                column: "AnswersIDanswer",
                principalTable: "Answers",
                principalColumn: "IDanswer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountingVotes_Answers_AnswersIDanswer",
                table: "CountingVotes");

            migrationBuilder.DropIndex(
                name: "IX_CountingVotes_AnswersIDanswer",
                table: "CountingVotes");

            migrationBuilder.DropColumn(
                name: "AnswersIDanswer",
                table: "CountingVotes");

            migrationBuilder.AddColumn<int>(
                name: "CountingVotesIdCVotes",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CountingVotesIdCVotes",
                table: "Answers",
                column: "CountingVotesIdCVotes");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_CountingVotes_CountingVotesIdCVotes",
                table: "Answers",
                column: "CountingVotesIdCVotes",
                principalTable: "CountingVotes",
                principalColumn: "IdCVotes");
        }
    }
}
