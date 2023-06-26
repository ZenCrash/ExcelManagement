using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelManagement.DxBlazor.Migrations
{
    /// <inheritdoc />
    public partial class test23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAndFolderPerson_FilesAndFolders_FilesAndFoldersId",
                table: "FileAndFolderPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileAndFolderPerson",
                table: "FileAndFolderPerson");

            migrationBuilder.DropIndex(
                name: "IX_FileAndFolderPerson_FilesAndFoldersId",
                table: "FileAndFolderPerson");

            migrationBuilder.RenameColumn(
                name: "FilesAndFoldersId",
                table: "FileAndFolderPerson",
                newName: "FileAndFolderMemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileAndFolderPerson",
                table: "FileAndFolderPerson",
                columns: new[] { "FileAndFolderMemberId", "FileAndFolderMembersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FileAndFolderPerson_FileAndFolderMembersId",
                table: "FileAndFolderPerson",
                column: "FileAndFolderMembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAndFolderPerson_FilesAndFolders_FileAndFolderMemberId",
                table: "FileAndFolderPerson",
                column: "FileAndFolderMemberId",
                principalTable: "FilesAndFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAndFolderPerson_FilesAndFolders_FileAndFolderMemberId",
                table: "FileAndFolderPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileAndFolderPerson",
                table: "FileAndFolderPerson");

            migrationBuilder.DropIndex(
                name: "IX_FileAndFolderPerson_FileAndFolderMembersId",
                table: "FileAndFolderPerson");

            migrationBuilder.RenameColumn(
                name: "FileAndFolderMemberId",
                table: "FileAndFolderPerson",
                newName: "FilesAndFoldersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileAndFolderPerson",
                table: "FileAndFolderPerson",
                columns: new[] { "FileAndFolderMembersId", "FilesAndFoldersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FileAndFolderPerson_FilesAndFoldersId",
                table: "FileAndFolderPerson",
                column: "FilesAndFoldersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAndFolderPerson_FilesAndFolders_FilesAndFoldersId",
                table: "FileAndFolderPerson",
                column: "FilesAndFoldersId",
                principalTable: "FilesAndFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
