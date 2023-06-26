using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelManagement.DxBlazor.Migrations
{
    /// <inheritdoc />
    public partial class test22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPerson_People_PeopleId",
                table: "GroupPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_People_FilesAndFolders_FileAndFolderId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_People_PersonId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PersonId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_People_FileAndFolderId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupPerson",
                table: "GroupPerson");

            migrationBuilder.DropIndex(
                name: "IX_GroupPerson_PeopleId",
                table: "GroupPerson");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FileAndFolderId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "GroupPerson",
                newName: "GroupMembersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupPerson",
                table: "GroupPerson",
                columns: new[] { "GroupMembersId", "GroupsId" });

            migrationBuilder.CreateTable(
                name: "FileAndFolderPerson",
                columns: table => new
                {
                    FileAndFolderMembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilesAndFoldersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAndFolderPerson", x => new { x.FileAndFolderMembersId, x.FilesAndFoldersId });
                    table.ForeignKey(
                        name: "FK_FileAndFolderPerson_FilesAndFolders_FilesAndFoldersId",
                        column: x => x.FilesAndFoldersId,
                        principalTable: "FilesAndFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileAndFolderPerson_People_FileAndFolderMembersId",
                        column: x => x.FileAndFolderMembersId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    RoleMembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => new { x.RoleMembersId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PersonRole_People_RoleMembersId",
                        column: x => x.RoleMembersId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPerson_GroupsId",
                table: "GroupPerson",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAndFolderPerson_FilesAndFoldersId",
                table: "FileAndFolderPerson",
                column: "FilesAndFoldersId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RolesId",
                table: "PersonRole",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPerson_People_GroupMembersId",
                table: "GroupPerson",
                column: "GroupMembersId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupPerson_People_GroupMembersId",
                table: "GroupPerson");

            migrationBuilder.DropTable(
                name: "FileAndFolderPerson");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupPerson",
                table: "GroupPerson");

            migrationBuilder.DropIndex(
                name: "IX_GroupPerson_GroupsId",
                table: "GroupPerson");

            migrationBuilder.RenameColumn(
                name: "GroupMembersId",
                table: "GroupPerson",
                newName: "PeopleId");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FileAndFolderId",
                table: "People",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupPerson",
                table: "GroupPerson",
                columns: new[] { "GroupsId", "PeopleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PersonId",
                table: "Roles",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FileAndFolderId",
                table: "People",
                column: "FileAndFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPerson_PeopleId",
                table: "GroupPerson",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupPerson_People_PeopleId",
                table: "GroupPerson",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_FilesAndFolders_FileAndFolderId",
                table: "People",
                column: "FileAndFolderId",
                principalTable: "FilesAndFolders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_People_PersonId",
                table: "Roles",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
