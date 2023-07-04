using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelManagement.DxBlazor.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CompanyLogoUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyCreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "FilesAndFolders",
                columns: table => new
                {
                    FilesAndFolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    RelativeFilePath = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileAndFolderCreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileAndFolderUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesAndFolders", x => x.FilesAndFolderId);
                    table.ForeignKey(
                        name: "FK_FilesAndFolders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonCreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileAndFolderFilesAndFolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Companies_MemberCompanyId",
                        column: x => x.MemberCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_FilesAndFolders_FileAndFolderFilesAndFolderId",
                        column: x => x.FileAndFolderFilesAndFolderId,
                        principalTable: "FilesAndFolders",
                        principalColumn: "FilesAndFolderId");
                    table.ForeignKey(
                        name: "FK_People_People_PersonCreatedById",
                        column: x => x.PersonCreatedById,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_People_People_PersonUpdatedById",
                        column: x => x.PersonUpdatedById,
                        principalTable: "People",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    GroupLogoUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupCreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GroupUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GroupId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_Groups_People_GroupCreatedById",
                        column: x => x.GroupCreatedById,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Groups_People_GroupUpdatedById",
                        column: x => x.GroupUpdatedById,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Groups_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    RoleLogoUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleCreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleUpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileAndFolderFilesAndFolderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_FilesAndFolders_FileAndFolderFilesAndFolderId",
                        column: x => x.FileAndFolderFilesAndFolderId,
                        principalTable: "FilesAndFolders",
                        principalColumn: "FilesAndFolderId");
                    table.ForeignKey(
                        name: "FK_Roles_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Roles_People_RoleCreatedById",
                        column: x => x.RoleCreatedById,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Roles_People_RoleUpdatedById",
                        column: x => x.RoleUpdatedById,
                        principalTable: "People",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyCreatedById",
                table: "Companies",
                column: "CompanyCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyUpdatedById",
                table: "Companies",
                column: "CompanyUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilesAndFolders_CompanyId",
                table: "FilesAndFolders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FilesAndFolders_FileAndFolderCreatedById",
                table: "FilesAndFolders",
                column: "FileAndFolderCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilesAndFolders_FileAndFolderUpdatedById",
                table: "FilesAndFolders",
                column: "FileAndFolderUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FilesAndFolders_GroupId",
                table: "FilesAndFolders",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CompanyId",
                table: "Groups",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupCreatedById",
                table: "Groups",
                column: "GroupCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupId1",
                table: "Groups",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupUpdatedById",
                table: "Groups",
                column: "GroupUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PersonId",
                table: "Groups",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FileAndFolderFilesAndFolderId",
                table: "People",
                column: "FileAndFolderFilesAndFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_People_MemberCompanyId",
                table: "People",
                column: "MemberCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonCreatedById",
                table: "People",
                column: "PersonCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonUpdatedById",
                table: "People",
                column: "PersonUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CompanyId",
                table: "Roles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_FileAndFolderFilesAndFolderId",
                table: "Roles",
                column: "FileAndFolderFilesAndFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PersonId",
                table: "Roles",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleCreatedById",
                table: "Roles",
                column: "RoleCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleUpdatedById",
                table: "Roles",
                column: "RoleUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_People_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_People_CompanyCreatedById",
                table: "Companies",
                column: "CompanyCreatedById",
                principalTable: "People",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_People_CompanyUpdatedById",
                table: "Companies",
                column: "CompanyUpdatedById",
                principalTable: "People",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesAndFolders_Groups_GroupId",
                table: "FilesAndFolders",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesAndFolders_People_FileAndFolderCreatedById",
                table: "FilesAndFolders",
                column: "FileAndFolderCreatedById",
                principalTable: "People",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesAndFolders_People_FileAndFolderUpdatedById",
                table: "FilesAndFolders",
                column: "FileAndFolderUpdatedById",
                principalTable: "People",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_People_CompanyCreatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_People_CompanyUpdatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_FilesAndFolders_People_FileAndFolderCreatedById",
                table: "FilesAndFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_FilesAndFolders_People_FileAndFolderUpdatedById",
                table: "FilesAndFolders");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_People_GroupCreatedById",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_People_GroupUpdatedById",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_People_PersonId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "FilesAndFolders");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
