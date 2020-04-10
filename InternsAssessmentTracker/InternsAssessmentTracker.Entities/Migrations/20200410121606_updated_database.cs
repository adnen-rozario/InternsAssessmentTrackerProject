using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternsAssessmentTracker.Entities.Migrations
{
    public partial class updated_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Rating_Rating_Master_Rating_MasterId",
                table: "Intern_Rating");

            migrationBuilder.DropTable(
                name: "Project_InternRelation");

            migrationBuilder.DropTable(
                name: "Project_TechnologiesRelation");

            migrationBuilder.DropTable(
                name: "Rating_Master");

            migrationBuilder.RenameColumn(
                name: "Rating_MasterId",
                table: "Intern_Rating",
                newName: "RatingMasterId");

            migrationBuilder.RenameColumn(
                name: "Intern_RatingId",
                table: "Intern_Rating",
                newName: "InternRatingId");

            migrationBuilder.RenameIndex(
                name: "IX_Intern_Rating_Rating_MasterId",
                table: "Intern_Rating",
                newName: "IX_Intern_Rating_RatingMasterId");

            migrationBuilder.CreateTable(
                name: "ProjectInternRelation",
                columns: table => new
                {
                    ProjectInternRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectsId = table.Column<int>(nullable: false),
                    InternsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInternRelation", x => x.ProjectInternRelationId);
                    table.ForeignKey(
                        name: "FK_ProjectInternRelation_Interns_InternsId",
                        column: x => x.InternsId,
                        principalTable: "Interns",
                        principalColumn: "InternsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectInternRelation_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "ProjectsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechnologiesRelation",
                columns: table => new
                {
                    ProjectTechnologiesRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectsId = table.Column<int>(nullable: false),
                    TechnologiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnologiesRelation", x => x.ProjectTechnologiesRelationId);
                    table.ForeignKey(
                        name: "FK_ProjectTechnologiesRelation_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "ProjectsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnologiesRelation_Technologies_TechnologiesId",
                        column: x => x.TechnologiesId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingMaster",
                columns: table => new
                {
                    RatingMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingMaster", x => x.RatingMasterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInternRelation_InternsId",
                table: "ProjectInternRelation",
                column: "InternsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInternRelation_ProjectsId",
                table: "ProjectInternRelation",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologiesRelation_ProjectsId",
                table: "ProjectTechnologiesRelation",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologiesRelation_TechnologiesId",
                table: "ProjectTechnologiesRelation",
                column: "TechnologiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Rating_RatingMaster_RatingMasterId",
                table: "Intern_Rating",
                column: "RatingMasterId",
                principalTable: "RatingMaster",
                principalColumn: "RatingMasterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intern_Rating_RatingMaster_RatingMasterId",
                table: "Intern_Rating");

            migrationBuilder.DropTable(
                name: "ProjectInternRelation");

            migrationBuilder.DropTable(
                name: "ProjectTechnologiesRelation");

            migrationBuilder.DropTable(
                name: "RatingMaster");

            migrationBuilder.RenameColumn(
                name: "RatingMasterId",
                table: "Intern_Rating",
                newName: "Rating_MasterId");

            migrationBuilder.RenameColumn(
                name: "InternRatingId",
                table: "Intern_Rating",
                newName: "Intern_RatingId");

            migrationBuilder.RenameIndex(
                name: "IX_Intern_Rating_RatingMasterId",
                table: "Intern_Rating",
                newName: "IX_Intern_Rating_Rating_MasterId");

            migrationBuilder.CreateTable(
                name: "Project_InternRelation",
                columns: table => new
                {
                    Project_InternRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InternsId = table.Column<int>(nullable: false),
                    ProjectsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_InternRelation", x => x.Project_InternRelationId);
                    table.ForeignKey(
                        name: "FK_Project_InternRelation_Interns_InternsId",
                        column: x => x.InternsId,
                        principalTable: "Interns",
                        principalColumn: "InternsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_InternRelation_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "ProjectsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project_TechnologiesRelation",
                columns: table => new
                {
                    Project_TechnologiesRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectsId = table.Column<int>(nullable: false),
                    TechnologiesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_TechnologiesRelation", x => x.Project_TechnologiesRelationId);
                    table.ForeignKey(
                        name: "FK_Project_TechnologiesRelation_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "ProjectsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_TechnologiesRelation_Technologies_TechnologiesId",
                        column: x => x.TechnologiesId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating_Master",
                columns: table => new
                {
                    Rating_MasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating_Master", x => x.Rating_MasterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_InternRelation_InternsId",
                table: "Project_InternRelation",
                column: "InternsId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_InternRelation_ProjectsId",
                table: "Project_InternRelation",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_TechnologiesRelation_ProjectsId",
                table: "Project_TechnologiesRelation",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_TechnologiesRelation_TechnologiesId",
                table: "Project_TechnologiesRelation",
                column: "TechnologiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Intern_Rating_Rating_Master_Rating_MasterId",
                table: "Intern_Rating",
                column: "Rating_MasterId",
                principalTable: "Rating_Master",
                principalColumn: "Rating_MasterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
