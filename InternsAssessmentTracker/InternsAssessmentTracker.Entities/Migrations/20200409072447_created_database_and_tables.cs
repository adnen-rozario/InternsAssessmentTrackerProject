using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternsAssessmentTracker.Entities.Migrations
{
    public partial class created_database_and_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    InternsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.InternsId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectsId);
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

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologiesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologiesId);
                });

            migrationBuilder.CreateTable(
                name: "Project_InternRelation",
                columns: table => new
                {
                    Project_InternRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectsId = table.Column<int>(nullable: false),
                    InternsId = table.Column<int>(nullable: false)
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
                name: "Intern_Rating",
                columns: table => new
                {
                    Intern_RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InternsId = table.Column<int>(nullable: false),
                    TechnologiesId = table.Column<int>(nullable: false),
                    Rating_MasterId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern_Rating", x => x.Intern_RatingId);
                    table.ForeignKey(
                        name: "FK_Intern_Rating_Interns_InternsId",
                        column: x => x.InternsId,
                        principalTable: "Interns",
                        principalColumn: "InternsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intern_Rating_Rating_Master_Rating_MasterId",
                        column: x => x.Rating_MasterId,
                        principalTable: "Rating_Master",
                        principalColumn: "Rating_MasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intern_Rating_Technologies_TechnologiesId",
                        column: x => x.TechnologiesId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologiesId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Intern_Rating_InternsId",
                table: "Intern_Rating",
                column: "InternsId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_Rating_Rating_MasterId",
                table: "Intern_Rating",
                column: "Rating_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Intern_Rating_TechnologiesId",
                table: "Intern_Rating",
                column: "TechnologiesId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intern_Rating");

            migrationBuilder.DropTable(
                name: "Project_InternRelation");

            migrationBuilder.DropTable(
                name: "Project_TechnologiesRelation");

            migrationBuilder.DropTable(
                name: "Rating_Master");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
