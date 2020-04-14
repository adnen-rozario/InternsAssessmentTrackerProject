using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternsAssessmentTracker.Entities.Migrations
{
    public partial class addednewtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OverallRating",
                table: "Interns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.MentorId);
                });

            migrationBuilder.CreateTable(
                name: "MentorProjectRelation",
                columns: table => new
                {
                    MentorProjectRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MentorId = table.Column<int>(nullable: false),
                    ProjectsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorProjectRelation", x => x.MentorProjectRelationId);
                    table.ForeignKey(
                        name: "FK_MentorProjectRelation_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "MentorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorProjectRelation_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "ProjectsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorProjectRelation_MentorId",
                table: "MentorProjectRelation",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorProjectRelation_ProjectsId",
                table: "MentorProjectRelation",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorProjectRelation");

            migrationBuilder.DropTable(
                name: "Mentor");

            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Interns");
        }
    }
}
