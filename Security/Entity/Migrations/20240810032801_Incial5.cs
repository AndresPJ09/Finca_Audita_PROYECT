using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class Incial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ciudad_id",
                table: "persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ciudadId",
                table: "persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "pais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "assessment_criteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating_range = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_criterian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_criteria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "checkLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calification_total = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "crops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "evidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Core = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evidences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad_id = table.Column<int>(type: "int", nullable: false),
                    ciudadId = table.Column<int>(type: "int", nullable: false),
                    Usuario_id = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farms_ciudad_ciudadId",
                        column: x => x.ciudadId,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_farms_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmsDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad_id = table.Column<int>(type: "int", nullable: false),
                    Usuario_id = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmsDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmsDto_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priece = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification_criteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assessment_criterian_id = table.Column<int>(type: "int", nullable: false),
                    assessment_criterianId = table.Column<int>(type: "int", nullable: false),
                    Checklist_id = table.Column<int>(type: "int", nullable: false),
                    checklistId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_qualifications_assessment_criteria_assessment_criterianId",
                        column: x => x.assessment_criterianId,
                        principalTable: "assessment_criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_qualifications_checkLists_checklistId",
                        column: x => x.checklistId,
                        principalTable: "checkLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "farmCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crop_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cropdsId = table.Column<int>(type: "int", nullable: false),
                    Farm_id = table.Column<int>(type: "int", nullable: false),
                    farmsId = table.Column<int>(type: "int", nullable: false),
                    num_hectareas = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farmCrops_crops_cropdsId",
                        column: x => x.cropdsId,
                        principalTable: "crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_farmCrops_farms_farmsId",
                        column: x => x.farmsId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviewTechnicals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    farm_id = table.Column<int>(type: "int", nullable: false),
                    farmsId = table.Column<int>(type: "int", nullable: false),
                    Tecnico_id = table.Column<int>(type: "int", nullable: false),
                    checkLists_id = table.Column<int>(type: "int", nullable: false),
                    checkListsdId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewTechnicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviewTechnicals_checkLists_checkListsdId",
                        column: x => x.checkListsdId,
                        principalTable: "checkLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviewTechnicals_farms_farmsId",
                        column: x => x.farmsId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fertilizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFertilization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeFertilization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityMix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviewTechnicals_id = table.Column<int>(type: "int", nullable: false),
                    reviewTechnicalssId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fertilizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fertilizations_reviewTechnicals_reviewTechnicalssId",
                        column: x => x.reviewTechnicalssId,
                        principalTable: "reviewTechnicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fumigations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFumigation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuiantityMix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviewTechnicals_id = table.Column<int>(type: "int", nullable: false),
                    reviewTechnicalsId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fumigations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fumigations_reviewTechnicals_reviewTechnicalsId",
                        column: x => x.reviewTechnicalsId,
                        principalTable: "reviewTechnicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FertilizationSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplies_id = table.Column<int>(type: "int", nullable: false),
                    suppliesId = table.Column<int>(type: "int", nullable: false),
                    fertilization_id = table.Column<int>(type: "int", nullable: false),
                    fertilizationId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizationSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizationSupplies_Supplies_suppliesId",
                        column: x => x.suppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizationSupplies_fertilizations_fertilizationId",
                        column: x => x.fertilizationId,
                        principalTable: "fertilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fumigationSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplies_id = table.Column<int>(type: "int", nullable: false),
                    suppliesId = table.Column<int>(type: "int", nullable: false),
                    fumigation_id = table.Column<int>(type: "int", nullable: false),
                    fumigationsId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fumigationSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fumigationSupplies_Fumigations_fumigationsId",
                        column: x => x.fumigationsId,
                        principalTable: "Fumigations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fumigationSupplies_Supplies_suppliesId",
                        column: x => x.suppliesId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviewEvidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evidence_id = table.Column<int>(type: "int", nullable: false),
                    EvidencesId = table.Column<int>(type: "int", nullable: false),
                    ReviewTechnicals_id = table.Column<int>(type: "int", nullable: false),
                    reviewTechnicalsId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FumigationsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewEvidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviewEvidences_Fumigations_FumigationsId",
                        column: x => x.FumigationsId,
                        principalTable: "Fumigations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reviewEvidences_evidences_EvidencesId",
                        column: x => x.EvidencesId,
                        principalTable: "evidences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviewEvidences_reviewTechnicals_reviewTechnicalsId",
                        column: x => x.reviewTechnicalsId,
                        principalTable: "reviewTechnicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_persona_ciudadId",
                table: "persona",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_pais_CiudadId",
                table: "pais",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_farmCrops_cropdsId",
                table: "farmCrops",
                column: "cropdsId");

            migrationBuilder.CreateIndex(
                name: "IX_farmCrops_farmsId",
                table: "farmCrops",
                column: "farmsId");

            migrationBuilder.CreateIndex(
                name: "IX_farms_ciudadId",
                table: "farms",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_farms_usuarioId",
                table: "farms",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmsDto_UsuarioId",
                table: "FarmsDto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_fertilizations_reviewTechnicalssId",
                table: "fertilizations",
                column: "reviewTechnicalssId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_fertilizationId",
                table: "FertilizationSupplies",
                column: "fertilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_suppliesId",
                table: "FertilizationSupplies",
                column: "suppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Fumigations_reviewTechnicalsId",
                table: "Fumigations",
                column: "reviewTechnicalsId");

            migrationBuilder.CreateIndex(
                name: "IX_fumigationSupplies_fumigationsId",
                table: "fumigationSupplies",
                column: "fumigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_fumigationSupplies_suppliesId",
                table: "fumigationSupplies",
                column: "suppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_qualifications_assessment_criterianId",
                table: "qualifications",
                column: "assessment_criterianId");

            migrationBuilder.CreateIndex(
                name: "IX_qualifications_checklistId",
                table: "qualifications",
                column: "checklistId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_EvidencesId",
                table: "reviewEvidences",
                column: "EvidencesId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_FumigationsId",
                table: "reviewEvidences",
                column: "FumigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_reviewTechnicalsId",
                table: "reviewEvidences",
                column: "reviewTechnicalsId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewTechnicals_checkListsdId",
                table: "reviewTechnicals",
                column: "checkListsdId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewTechnicals_farmsId",
                table: "reviewTechnicals",
                column: "farmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_pais_ciudad_CiudadId",
                table: "pais",
                column: "CiudadId",
                principalTable: "ciudad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_ciudadId",
                table: "persona",
                column: "ciudadId",
                principalTable: "ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pais_ciudad_CiudadId",
                table: "pais");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_ciudadId",
                table: "persona");

            migrationBuilder.DropTable(
                name: "farmCrops");

            migrationBuilder.DropTable(
                name: "FarmsDto");

            migrationBuilder.DropTable(
                name: "FertilizationSupplies");

            migrationBuilder.DropTable(
                name: "fumigationSupplies");

            migrationBuilder.DropTable(
                name: "qualifications");

            migrationBuilder.DropTable(
                name: "reviewEvidences");

            migrationBuilder.DropTable(
                name: "crops");

            migrationBuilder.DropTable(
                name: "fertilizations");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "assessment_criteria");

            migrationBuilder.DropTable(
                name: "Fumigations");

            migrationBuilder.DropTable(
                name: "evidences");

            migrationBuilder.DropTable(
                name: "reviewTechnicals");

            migrationBuilder.DropTable(
                name: "checkLists");

            migrationBuilder.DropTable(
                name: "farms");

            migrationBuilder.DropIndex(
                name: "IX_persona_ciudadId",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_pais_CiudadId",
                table: "pais");

            migrationBuilder.DropColumn(
                name: "Ciudad_id",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "ciudadId",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "pais");
        }
    }
}
