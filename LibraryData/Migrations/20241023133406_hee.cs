using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryData.Migrations
{
    /// <inheritdoc />
    public partial class hee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlImage",
                table: "Books",
                newName: "ImgFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgFile",
                table: "Books",
                newName: "UrlImage");
        }
    }
}
