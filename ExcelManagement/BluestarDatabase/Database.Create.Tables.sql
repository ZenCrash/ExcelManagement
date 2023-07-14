/* Careate Tables */
CREATE DATABASE [ExcelManagement]
GO

USE [ExcelManagement]
GO

--Tables
CREATE TABLE [dbo].[companies](
	[Id] [UNIQUEIDENTIFIER] PRIMARY KEY NOT NULL,
	[CompanyName] [nvarchar](2000) NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[CompanyLogoUrl] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL
)
GO

CREATE TABLE [dbo].[people](
	[Id] [nvarchar](450) PRIMARY KEY NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256) NOT NULL,
	[JobTitle] [nvarchar](256) NULL,
	[Bio] [nvarchar](4000) NULL,
	[ProfileImageUrl] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,

	--Relationships
	[CompanyId] [UNIQUEIDENTIFIER] NOT NULL,
	[CreatedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,

	CONSTRAINT [FK_people_company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [companies] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_people_people_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [people] (Id) ON DELETE SET NULL,
	CONSTRAINT [FK_people_people_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [people] (Id) ON DELETE SET NULL
)
GO

CREATE TABLE [dbo].[roles](
	[Id] [nvarchar](450) PRIMARY KEY NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[RoleLogoUrl] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,

	--Relationships
	[CompanyId] [UNIQUEIDENTIFIER] NOT NULL,
	[CreatedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,

	CONSTRAINT [FK_people_company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [companies] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_people_people_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [people] (Id) ON DELETE SET NULL,
	CONSTRAINT [FK_people_people_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [people] (Id) ON DELETE SET NULL
)
GO

CREATE TABLE [dbo].[groups](
	[Id] [UNIQUEIDENTIFIER] PRIMARY KEY NOT NULL,
	[GroupName] [nvarchar](512) NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[GroupLogoUrl] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,

	--Relationships
	[CompanyId] [UNIQUEIDENTIFIER] NOT NULL,
	[CreatedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,

	CONSTRAINT [FK_groups_company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [companies] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_groups_people_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [people] (Id) ON DELETE SET NULL,
	CONSTRAINT [FK_groups_people_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [people] (Id) ON DELETE SET NULL
)
GO

CREATE TABLE [dbo].[files_and_folders](
	[Id] [UNIQUEIDENTIFIER] PRIMARY KEY NOT NULL,
	[ItemName] [nvarchar](512) NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[RelativeFilePath] [nvarchar](4000) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[DataType] [nvarchar] NOT NULL,

	--Relationships
	[CompanyId] [UNIQUEIDENTIFIER] NOT NULL,
	[CreatedById] [nvarchar](450) NULL,
	[UpdatedById] [nvarchar](450) NULL,

	CONSTRAINT [FK_files_and_folders_company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [companies] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_files_and_folders_people_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [people] (Id) ON DELETE SET NULL,
	CONSTRAINT [FK_files_and_folders_people_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [people] (Id) ON DELETE SET NULL
)
GO

--Brigde Tables
CREATE TABLE [people_roles] ( -- People + Roles
	[PersonId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	CONSTRAINT [PK_people_roles_Id] PRIMARY KEY ([PersonId], [RoleId]),
	CONSTRAINT [FK_people_roles_people_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [people] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_people_roles_roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [roles] (Id) ON DELETE CASCADE
)
GO

CREATE TABLE [people_groups] ( -- People + Groups
	[PersonId] [nvarchar](450) NOT NULL,
	[GroupId] [UNIQUEIDENTIFIER] NOT NULL,
	CONSTRAINT [PK_people_groups_Id] PRIMARY KEY ([PersonId], [GroupId]),
	CONSTRAINT [FK_people_groups_people_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [people] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_people_groups_groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [groups] (Id) ON DELETE CASCADE
)
GO

CREATE TABLE [people_files_and_folders] ( -- People + Files_And_Folders
	[PersonId] [nvarchar](450) NOT NULL,
	[FileAndFolderId] [UNIQUEIDENTIFIER] NOT NULL,
	CONSTRAINT [PK_people_files_and_folders_Id] PRIMARY KEY ([PersonId], [FileAndFolderId]),
	CONSTRAINT [FK_people_files_and_folders_people_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [people] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_people_files_and_folders_files_and_folders_FileAndFolderId] FOREIGN KEY ([FileAndFolderId]) REFERENCES [files_and_folders] (Id) ON DELETE CASCADE
)
GO

CREATE TABLE [roles_files_and_folders] ( -- Roles + Files_And_Folder
	[RoleId] [nvarchar](450) NOT NULL,
	[FileAndFolderId] [UNIQUEIDENTIFIER] NOT NULL,
	CONSTRAINT [PK_roles_files_and_folders_Id] PRIMARY KEY ([RoleId], [FileAndFolderId]),
	CONSTRAINT [FK_roles_files_and_folders_roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [roles] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_roles_files_and_folders_files_and_folders_FileAndFolderId] FOREIGN KEY ([FileAndFolderId]) REFERENCES [files_and_folders] (Id) ON DELETE CASCADE
)
GO

CREATE TABLE [groups_files_and_folders] ( -- Groups + Files_And_Folders
	[GroupId] [UNIQUEIDENTIFIER] NOT NULL,
	[FileAndFolderId] [UNIQUEIDENTIFIER] NOT NULL,
	CONSTRAINT [PK_groups_files_and_folders_Id] PRIMARY KEY ([GroupId], [FileAndFolderId]),
	CONSTRAINT [FK_groups_files_and_folders_groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [groups] (Id) ON DELETE CASCADE,
	CONSTRAINT [FK_groups_files_and_folders_files_and_folders_FileAndFolderId] FOREIGN KEY ([FileAndFolderId]) REFERENCES [files_and_folders] (Id) ON DELETE CASCADE
)
GO