using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingApp.Migrations
{
    public partial class DodanieTabeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Vote",
                table: "Votes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CountingVotesIdCVotes",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountingVotes",
                columns: table => new
                {
                    IdCVotes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsVote = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountingVotes", x => x.IdCVotes);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_CountingVotes_CountingVotesIdCVotes",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "CountingVotes");

            migrationBuilder.DropIndex(
                name: "IX_Answers_CountingVotesIdCVotes",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CountingVotesIdCVotes",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "Vote",
                table: "Votes",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
