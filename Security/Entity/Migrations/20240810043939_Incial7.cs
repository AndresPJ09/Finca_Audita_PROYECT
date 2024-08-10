using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class Incial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_farmCrops_crops_cropdsId",
                table: "farmCrops");

            migrationBuilder.DropForeignKey(
                name: "FK_farmCrops_farms_farmsId",
                table: "farmCrops");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_ciudad_ciudadId",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_usuario_usuarioId",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_fertilizations_reviewTechnicals_reviewTechnicalssId",
                table: "fertilizations");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizationSupplies_Supplies_suppliesId",
                table: "FertilizationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizationSupplies_fertilizations_fertilizationId",
                table: "FertilizationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Fumigations_reviewTechnicals_reviewTechnicalsId",
                table: "Fumigations");

            migrationBuilder.DropForeignKey(
                name: "FK_fumigationSupplies_Fumigations_fumigationsId",
                table: "fumigationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_fumigationSupplies_Supplies_suppliesId",
                table: "fumigationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_ciudadId",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_qualifications_assessment_criteria_assessment_criterianId",
                table: "qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_qualifications_checkLists_checklistId",
                table: "qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewEvidences_evidences_EvidencesId",
                table: "reviewEvidences");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewEvidences_reviewTechnicals_reviewTechnicalsId",
                table: "reviewEvidences");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewTechnicals_checkLists_checkListsdId",
                table: "reviewTechnicals");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewTechnicals_farms_farmsId",
                table: "reviewTechnicals");

            migrationBuilder.DropForeignKey(
                name: "FK_rol_vista_rol_Rol_id",
                table: "rol_vista");

            migrationBuilder.DropForeignKey(
                name: "FK_rol_vista_vistas_Vista_id",
                table: "rol_vista");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_rol_Rol_id",
                table: "usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_usuario_Usuario_Id",
                table: "usuario_rol");

            migrationBuilder.DropTable(
                name: "FarmsDto");

            migrationBuilder.DropIndex(
                name: "IX_reviewTechnicals_checkListsdId",
                table: "reviewTechnicals");

            migrationBuilder.DropIndex(
                name: "IX_reviewTechnicals_farmsId",
                table: "reviewTechnicals");

            migrationBuilder.DropIndex(
                name: "IX_reviewEvidences_EvidencesId",
                table: "reviewEvidences");

            migrationBuilder.DropIndex(
                name: "IX_reviewEvidences_reviewTechnicalsId",
                table: "reviewEvidences");

            migrationBuilder.DropIndex(
                name: "IX_qualifications_assessment_criterianId",
                table: "qualifications");

            migrationBuilder.DropIndex(
                name: "IX_qualifications_checklistId",
                table: "qualifications");

            migrationBuilder.DropIndex(
                name: "IX_persona_ciudadId",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_fumigationSupplies_fumigationsId",
                table: "fumigationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_fumigationSupplies_suppliesId",
                table: "fumigationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_Fumigations_reviewTechnicalsId",
                table: "Fumigations");

            migrationBuilder.DropIndex(
                name: "IX_FertilizationSupplies_fertilizationId",
                table: "FertilizationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_FertilizationSupplies_suppliesId",
                table: "FertilizationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_fertilizations_reviewTechnicalssId",
                table: "fertilizations");

            migrationBuilder.DropIndex(
                name: "IX_farms_ciudadId",
                table: "farms");

            migrationBuilder.DropIndex(
                name: "IX_farms_usuarioId",
                table: "farms");

            migrationBuilder.DropIndex(
                name: "IX_farmCrops_cropdsId",
                table: "farmCrops");

            migrationBuilder.DropIndex(
                name: "IX_farmCrops_farmsId",
                table: "farmCrops");

            migrationBuilder.DropColumn(
                name: "checkListsdId",
                table: "reviewTechnicals");

            migrationBuilder.DropColumn(
                name: "farmsId",
                table: "reviewTechnicals");

            migrationBuilder.DropColumn(
                name: "EvidencesId",
                table: "reviewEvidences");

            migrationBuilder.DropColumn(
                name: "reviewTechnicalsId",
                table: "reviewEvidences");

            migrationBuilder.DropColumn(
                name: "assessment_criterianId",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "checklistId",
                table: "qualifications");

            migrationBuilder.DropColumn(
                name: "ciudadId",
                table: "persona");

            migrationBuilder.DropColumn(
                name: "fumigationsId",
                table: "fumigationSupplies");

            migrationBuilder.DropColumn(
                name: "suppliesId",
                table: "fumigationSupplies");

            migrationBuilder.DropColumn(
                name: "reviewTechnicalsId",
                table: "Fumigations");

            migrationBuilder.DropColumn(
                name: "fertilizationId",
                table: "FertilizationSupplies");

            migrationBuilder.DropColumn(
                name: "suppliesId",
                table: "FertilizationSupplies");

            migrationBuilder.DropColumn(
                name: "reviewTechnicalssId",
                table: "fertilizations");

            migrationBuilder.DropColumn(
                name: "ciudadId",
                table: "farms");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "farms");

            migrationBuilder.DropColumn(
                name: "cropdsId",
                table: "farmCrops");

            migrationBuilder.DropColumn(
                name: "farmsId",
                table: "farmCrops");

            migrationBuilder.AlterColumn<int>(
                name: "Crop_id",
                table: "farmCrops",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_reviewTechnicals_checkLists_id",
                table: "reviewTechnicals",
                column: "checkLists_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviewTechnicals_farm_id",
                table: "reviewTechnicals",
                column: "farm_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_Evidence_id",
                table: "reviewEvidences",
                column: "Evidence_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_ReviewTechnicals_id",
                table: "reviewEvidences",
                column: "ReviewTechnicals_id");

            migrationBuilder.CreateIndex(
                name: "IX_qualifications_Assessment_criterian_id",
                table: "qualifications",
                column: "Assessment_criterian_id");

            migrationBuilder.CreateIndex(
                name: "IX_qualifications_Checklist_id",
                table: "qualifications",
                column: "Checklist_id");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Ciudad_id",
                table: "persona",
                column: "Ciudad_id");

            migrationBuilder.CreateIndex(
                name: "IX_fumigationSupplies_fumigation_id",
                table: "fumigationSupplies",
                column: "fumigation_id");

            migrationBuilder.CreateIndex(
                name: "IX_fumigationSupplies_supplies_id",
                table: "fumigationSupplies",
                column: "supplies_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fumigations_reviewTechnicals_id",
                table: "Fumigations",
                column: "reviewTechnicals_id");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_fertilization_id",
                table: "FertilizationSupplies",
                column: "fertilization_id");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_supplies_id",
                table: "FertilizationSupplies",
                column: "supplies_id");

            migrationBuilder.CreateIndex(
                name: "IX_fertilizations_reviewTechnicals_id",
                table: "fertilizations",
                column: "reviewTechnicals_id");

            migrationBuilder.CreateIndex(
                name: "IX_farms_Ciudad_id",
                table: "farms",
                column: "Ciudad_id");

            migrationBuilder.CreateIndex(
                name: "IX_farms_Usuario_id",
                table: "farms",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_farmCrops_Crop_id",
                table: "farmCrops",
                column: "Crop_id");

            migrationBuilder.CreateIndex(
                name: "IX_farmCrops_Farm_id",
                table: "farmCrops",
                column: "Farm_id");

            migrationBuilder.AddForeignKey(
                name: "FK_farmCrops_crops_Crop_id",
                table: "farmCrops",
                column: "Crop_id",
                principalTable: "crops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_farmCrops_farms_Farm_id",
                table: "farmCrops",
                column: "Farm_id",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_farms_ciudad_Ciudad_id",
                table: "farms",
                column: "Ciudad_id",
                principalTable: "ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_farms_usuario_Usuario_id",
                table: "farms",
                column: "Usuario_id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fertilizations_reviewTechnicals_reviewTechnicals_id",
                table: "fertilizations",
                column: "reviewTechnicals_id",
                principalTable: "reviewTechnicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizationSupplies_Supplies_supplies_id",
                table: "FertilizationSupplies",
                column: "supplies_id",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizationSupplies_fertilizations_fertilization_id",
                table: "FertilizationSupplies",
                column: "fertilization_id",
                principalTable: "fertilizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fumigations_reviewTechnicals_reviewTechnicals_id",
                table: "Fumigations",
                column: "reviewTechnicals_id",
                principalTable: "reviewTechnicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fumigationSupplies_Fumigations_fumigation_id",
                table: "fumigationSupplies",
                column: "fumigation_id",
                principalTable: "Fumigations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fumigationSupplies_Supplies_supplies_id",
                table: "fumigationSupplies",
                column: "supplies_id",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_Ciudad_id",
                table: "persona",
                column: "Ciudad_id",
                principalTable: "ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_qualifications_assessment_criteria_Assessment_criterian_id",
                table: "qualifications",
                column: "Assessment_criterian_id",
                principalTable: "assessment_criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_qualifications_checkLists_Checklist_id",
                table: "qualifications",
                column: "Checklist_id",
                principalTable: "checkLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewEvidences_evidences_Evidence_id",
                table: "reviewEvidences",
                column: "Evidence_id",
                principalTable: "evidences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewEvidences_reviewTechnicals_ReviewTechnicals_id",
                table: "reviewEvidences",
                column: "ReviewTechnicals_id",
                principalTable: "reviewTechnicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewTechnicals_checkLists_checkLists_id",
                table: "reviewTechnicals",
                column: "checkLists_id",
                principalTable: "checkLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewTechnicals_farms_farm_id",
                table: "reviewTechnicals",
                column: "farm_id",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rol_vista_rol_Rol_id",
                table: "rol_vista",
                column: "Rol_id",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rol_vista_vistas_Vista_id",
                table: "rol_vista",
                column: "Vista_id",
                principalTable: "vistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_rol_Rol_id",
                table: "usuario_rol",
                column: "Rol_id",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_usuario_Usuario_Id",
                table: "usuario_rol",
                column: "Usuario_Id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_farmCrops_crops_Crop_id",
                table: "farmCrops");

            migrationBuilder.DropForeignKey(
                name: "FK_farmCrops_farms_Farm_id",
                table: "farmCrops");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_ciudad_Ciudad_id",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_usuario_Usuario_id",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_fertilizations_reviewTechnicals_reviewTechnicals_id",
                table: "fertilizations");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizationSupplies_Supplies_supplies_id",
                table: "FertilizationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizationSupplies_fertilizations_fertilization_id",
                table: "FertilizationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Fumigations_reviewTechnicals_reviewTechnicals_id",
                table: "Fumigations");

            migrationBuilder.DropForeignKey(
                name: "FK_fumigationSupplies_Fumigations_fumigation_id",
                table: "fumigationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_fumigationSupplies_Supplies_supplies_id",
                table: "fumigationSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_persona_ciudad_Ciudad_id",
                table: "persona");

            migrationBuilder.DropForeignKey(
                name: "FK_qualifications_assessment_criteria_Assessment_criterian_id",
                table: "qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_qualifications_checkLists_Checklist_id",
                table: "qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewEvidences_evidences_Evidence_id",
                table: "reviewEvidences");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewEvidences_reviewTechnicals_ReviewTechnicals_id",
                table: "reviewEvidences");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewTechnicals_checkLists_checkLists_id",
                table: "reviewTechnicals");

            migrationBuilder.DropForeignKey(
                name: "FK_reviewTechnicals_farms_farm_id",
                table: "reviewTechnicals");

            migrationBuilder.DropForeignKey(
                name: "FK_rol_vista_rol_Rol_id",
                table: "rol_vista");

            migrationBuilder.DropForeignKey(
                name: "FK_rol_vista_vistas_Vista_id",
                table: "rol_vista");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_rol_Rol_id",
                table: "usuario_rol");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_rol_usuario_Usuario_Id",
                table: "usuario_rol");

            migrationBuilder.DropIndex(
                name: "IX_reviewTechnicals_checkLists_id",
                table: "reviewTechnicals");

            migrationBuilder.DropIndex(
                name: "IX_reviewTechnicals_farm_id",
                table: "reviewTechnicals");

            migrationBuilder.DropIndex(
                name: "IX_reviewEvidences_Evidence_id",
                table: "reviewEvidences");

            migrationBuilder.DropIndex(
                name: "IX_reviewEvidences_ReviewTechnicals_id",
                table: "reviewEvidences");

            migrationBuilder.DropIndex(
                name: "IX_qualifications_Assessment_criterian_id",
                table: "qualifications");

            migrationBuilder.DropIndex(
                name: "IX_qualifications_Checklist_id",
                table: "qualifications");

            migrationBuilder.DropIndex(
                name: "IX_persona_Ciudad_id",
                table: "persona");

            migrationBuilder.DropIndex(
                name: "IX_fumigationSupplies_fumigation_id",
                table: "fumigationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_fumigationSupplies_supplies_id",
                table: "fumigationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_Fumigations_reviewTechnicals_id",
                table: "Fumigations");

            migrationBuilder.DropIndex(
                name: "IX_FertilizationSupplies_fertilization_id",
                table: "FertilizationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_FertilizationSupplies_supplies_id",
                table: "FertilizationSupplies");

            migrationBuilder.DropIndex(
                name: "IX_fertilizations_reviewTechnicals_id",
                table: "fertilizations");

            migrationBuilder.DropIndex(
                name: "IX_farms_Ciudad_id",
                table: "farms");

            migrationBuilder.DropIndex(
                name: "IX_farms_Usuario_id",
                table: "farms");

            migrationBuilder.DropIndex(
                name: "IX_farmCrops_Crop_id",
                table: "farmCrops");

            migrationBuilder.DropIndex(
                name: "IX_farmCrops_Farm_id",
                table: "farmCrops");

            migrationBuilder.AddColumn<int>(
                name: "checkListsdId",
                table: "reviewTechnicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "farmsId",
                table: "reviewTechnicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvidencesId",
                table: "reviewEvidences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reviewTechnicalsId",
                table: "reviewEvidences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "assessment_criterianId",
                table: "qualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "checklistId",
                table: "qualifications",
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
                name: "fumigationsId",
                table: "fumigationSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "suppliesId",
                table: "fumigationSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reviewTechnicalsId",
                table: "Fumigations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fertilizationId",
                table: "FertilizationSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "suppliesId",
                table: "FertilizationSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reviewTechnicalssId",
                table: "fertilizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ciudadId",
                table: "farms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "farms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Crop_id",
                table: "farmCrops",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "cropdsId",
                table: "farmCrops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "farmsId",
                table: "farmCrops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FarmsDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad_id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Usuario_id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_reviewTechnicals_checkListsdId",
                table: "reviewTechnicals",
                column: "checkListsdId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewTechnicals_farmsId",
                table: "reviewTechnicals",
                column: "farmsId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_EvidencesId",
                table: "reviewEvidences",
                column: "EvidencesId");

            migrationBuilder.CreateIndex(
                name: "IX_reviewEvidences_reviewTechnicalsId",
                table: "reviewEvidences",
                column: "reviewTechnicalsId");

            migrationBuilder.CreateIndex(
                name: "IX_qualifications_assessment_criterianId",
                table: "qualifications",
                column: "assessment_criterianId");

            migrationBuilder.CreateIndex(
                name: "IX_qualifications_checklistId",
                table: "qualifications",
                column: "checklistId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_ciudadId",
                table: "persona",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_fumigationSupplies_fumigationsId",
                table: "fumigationSupplies",
                column: "fumigationsId");

            migrationBuilder.CreateIndex(
                name: "IX_fumigationSupplies_suppliesId",
                table: "fumigationSupplies",
                column: "suppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_Fumigations_reviewTechnicalsId",
                table: "Fumigations",
                column: "reviewTechnicalsId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_fertilizationId",
                table: "FertilizationSupplies",
                column: "fertilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizationSupplies_suppliesId",
                table: "FertilizationSupplies",
                column: "suppliesId");

            migrationBuilder.CreateIndex(
                name: "IX_fertilizations_reviewTechnicalssId",
                table: "fertilizations",
                column: "reviewTechnicalssId");

            migrationBuilder.CreateIndex(
                name: "IX_farms_ciudadId",
                table: "farms",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_farms_usuarioId",
                table: "farms",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_farmCrops_cropdsId",
                table: "farmCrops",
                column: "cropdsId");

            migrationBuilder.CreateIndex(
                name: "IX_farmCrops_farmsId",
                table: "farmCrops",
                column: "farmsId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmsDto_UsuarioId",
                table: "FarmsDto",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_farmCrops_crops_cropdsId",
                table: "farmCrops",
                column: "cropdsId",
                principalTable: "crops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_farmCrops_farms_farmsId",
                table: "farmCrops",
                column: "farmsId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_farms_ciudad_ciudadId",
                table: "farms",
                column: "ciudadId",
                principalTable: "ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_farms_usuario_usuarioId",
                table: "farms",
                column: "usuarioId",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fertilizations_reviewTechnicals_reviewTechnicalssId",
                table: "fertilizations",
                column: "reviewTechnicalssId",
                principalTable: "reviewTechnicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizationSupplies_Supplies_suppliesId",
                table: "FertilizationSupplies",
                column: "suppliesId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizationSupplies_fertilizations_fertilizationId",
                table: "FertilizationSupplies",
                column: "fertilizationId",
                principalTable: "fertilizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fumigations_reviewTechnicals_reviewTechnicalsId",
                table: "Fumigations",
                column: "reviewTechnicalsId",
                principalTable: "reviewTechnicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fumigationSupplies_Fumigations_fumigationsId",
                table: "fumigationSupplies",
                column: "fumigationsId",
                principalTable: "Fumigations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fumigationSupplies_Supplies_suppliesId",
                table: "fumigationSupplies",
                column: "suppliesId",
                principalTable: "Supplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_ciudad_ciudadId",
                table: "persona",
                column: "ciudadId",
                principalTable: "ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_qualifications_assessment_criteria_assessment_criterianId",
                table: "qualifications",
                column: "assessment_criterianId",
                principalTable: "assessment_criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_qualifications_checkLists_checklistId",
                table: "qualifications",
                column: "checklistId",
                principalTable: "checkLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewEvidences_evidences_EvidencesId",
                table: "reviewEvidences",
                column: "EvidencesId",
                principalTable: "evidences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewEvidences_reviewTechnicals_reviewTechnicalsId",
                table: "reviewEvidences",
                column: "reviewTechnicalsId",
                principalTable: "reviewTechnicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewTechnicals_checkLists_checkListsdId",
                table: "reviewTechnicals",
                column: "checkListsdId",
                principalTable: "checkLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviewTechnicals_farms_farmsId",
                table: "reviewTechnicals",
                column: "farmsId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rol_vista_rol_Rol_id",
                table: "rol_vista",
                column: "Rol_id",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rol_vista_vistas_Vista_id",
                table: "rol_vista",
                column: "Vista_id",
                principalTable: "vistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_rol_Rol_id",
                table: "usuario_rol",
                column: "Rol_id",
                principalTable: "rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_rol_usuario_Usuario_Id",
                table: "usuario_rol",
                column: "Usuario_Id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
