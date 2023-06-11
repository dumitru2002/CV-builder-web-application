using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVBuilderAuth.Migrations.Application
{
    /// <inheritdoc />
    public partial class newtabletempla2te : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "CvTemplateIds",
                newName: "TempNr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempNr",
                table: "CvTemplateIds",
                newName: "TemplateId");
        }
    }
}
