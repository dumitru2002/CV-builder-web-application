using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVBuilderAuth.Migrations.Application
{
    /// <inheritdoc />
    public partial class templat33etable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CvTemplateIds",
                table: "CvTemplateIds");

            migrationBuilder.RenameTable(
                name: "CvTemplateIds",
                newName: "UseTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UseTemplates",
                table: "UseTemplates",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UseTemplates",
                table: "UseTemplates");

            migrationBuilder.RenameTable(
                name: "UseTemplates",
                newName: "CvTemplateIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CvTemplateIds",
                table: "CvTemplateIds",
                column: "Id");
        }
    }
}
