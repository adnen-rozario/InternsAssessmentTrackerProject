using Microsoft.EntityFrameworkCore.Migrations;

namespace InternsAssessmentTracker.Entities.Migrations
{
    public partial class update_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Rating_Interns_InternsId",
                table: "Intern_Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Rating_RatingMaster_RatingMasterId",
                table: "Intern_Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Rating_Technologies_TechnologiesId",
                table: "Intern_Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intern_Rating",
                table: "Intern_Rating");

            migrationBuilder.RenameTable(
                name: "Intern_Rating",
                newName: "InternRating");

            migrationBuilder.RenameIndex(
                name: "IX_Intern_Rating_TechnologiesId",
                table: "InternRating",
                newName: "IX_InternRating_TechnologiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Intern_Rating_RatingMasterId",
                table: "InternRating",
                newName: "IX_InternRating_RatingMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_Intern_Rating_InternsId",
                table: "InternRating",
                newName: "IX_InternRating_InternsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InternRating",
                table: "InternRating",
                column: "InternRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternRating_Interns_InternsId",
                table: "InternRating",
                column: "InternsId",
                principalTable: "Interns",
                principalColumn: "InternsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternRating_RatingMaster_RatingMasterId",
                table: "InternRating",
                column: "RatingMasterId",
                principalTable: "RatingMaster",
                principalColumn: "RatingMasterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InternRating_Technologies_TechnologiesId",
                table: "InternRating",
                column: "TechnologiesId",
                principalTable: "Technologies",
                principalColumn: "TechnologiesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternRating_Interns_InternsId",
                table: "InternRating");

            migrationBuilder.DropForeignKey(
                name: "FK_InternRating_RatingMaster_RatingMasterId",
                table: "InternRating");

            migrationBuilder.DropForeignKey(
                name: "FK_InternRating_Technologies_TechnologiesId",
                table: "InternRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InternRating",
                table: "InternRating");

            migrationBuilder.RenameTable(
                name: "InternRating",
                newName: "Intern_Rating");

            migrationBuilder.RenameIndex(
                name: "IX_InternRating_TechnologiesId",
                table: "Intern_Rating",
                newName: "IX_Intern_Rating_TechnologiesId");

            migrationBuilder.RenameIndex(
                name: "IX_InternRating_RatingMasterId",
                table: "Intern_Rating",
                newName: "IX_Intern_Rating_RatingMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_InternRating_InternsId",
                table: "Intern_Rating",
                newName: "IX_Intern_Rating_InternsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intern_Rating",
                table: "Intern_Rating",
                column: "InternRatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Rating_Interns_InternsId",
                table: "Intern_Rating",
                column: "InternsId",
                principalTable: "Interns",
                principalColumn: "InternsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Rating_RatingMaster_RatingMasterId",
                table: "Intern_Rating",
                column: "RatingMasterId",
                principalTable: "RatingMaster",
                principalColumn: "RatingMasterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Rating_Technologies_TechnologiesId",
                table: "Intern_Rating",
                column: "TechnologiesId",
                principalTable: "Technologies",
                principalColumn: "TechnologiesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
