Create Database [BluestarDatabase]
GO
Use [BluestarDatabase]
GO

CREATE TABLE Company(
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](2000) NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[CompanyLogoUrl] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL

	PRIMARY KEY(Id)
);
GO

CREATE TABLE People(
	Id INT IDENTITY(1,1) NOT NULL,

	Created_By INT NOT NULL,
	Update_By INT NOT NULL,
	Company_Id INT NOT NULL,

	PRIMARY KEY(Id),
	FOREIGN KEY(Created_By) REFERENCES People(Id),
	FOREIGN KEY(Update_By) REFERENCES People(Id),
	FOREIGN KEY(Company_Id) REFERENCES Company(Id)
);
GO

CREATE TABLE Roles(
	Id INT IDENTITY(1,1) NOT NULL,

	Created_By INT NOT NULL,
	Update_By INT NOT NULL,
	Company_Id INT NOT NULL,

	PRIMARY KEY(Id),
	FOREIGN KEY(Created_By) REFERENCES People(Id),
	FOREIGN KEY(Update_By) REFERENCES People(Id),
	FOREIGN KEY(Company_Id) REFERENCES Company(Id)
);
GO

CREATE TABLE Groups(
	Id INT IDENTITY(1,1) NOT NULL,

	Created_By INT NOT NULL,
	Update_By INT NOT NULL,
	Company_Id INT NOT NULL,

	PRIMARY KEY(Id),
	FOREIGN KEY(Created_By) REFERENCES People(Id),
	FOREIGN KEY(Update_By) REFERENCES People(Id),
	FOREIGN KEY(Company_Id) REFERENCES Company(Id)
);
GO

CREATE TABLE FileAndFolders(
	Id INT IDENTITY(1,1) NOT NULL,

	Created_By INT NOT NULL,
	Update_By INT NOT NULL,
	Company_Id INT NOT NULL,

	PRIMARY KEY(Id),
	FOREIGN KEY(Created_By) REFERENCES People(Id),
	FOREIGN KEY(Update_By) REFERENCES People(Id),
	FOREIGN KEY(Company_Id) REFERENCES Company(Id)
);
GO

Create Table GroupingGroups (
	Parent_Group_Id Int NOT NULL,
	Child_Group_Id INT NOT NULL,

	PRIMARY KEY(Parent_Group_Id, Child_Group_Id),
	FOREIGN KEY(Parent_Group_Id) REFERENCES Groups(Id),
	FOREIGN KEY(Child_Group_Id) REFERENCES Groups(Id)
);
GO

CREATE TABLE PeopleRoles(
	Person_Id INT NOT NULL,
	Role_Id INT NOT NULL,

	PRIMARY KEY(Person_Id, Role_Id),
	FOREIGN KEY(Person_Id) REFERENCES People(Id),
	FOREIGN KEY(Role_Id) REFERENCES Roles(Id)
);
GO

CREATE TABLE PeopleGroup(
	Person_Id INT NOT NULL,
	Group_Id INT NOT NULL,
	PRIMARY KEY(Person_Id, Group_Id),
	FOREIGN KEY(Person_Id) REFERENCES People(Id),
	FOREIGN KEY(Group_Id) REFERENCES Groups(Id)
);
GO

CREATE TABLE FileAndFolderGroup(
	Group_Id INT NOT NULL,
	file_Id INT NOT NULL,
	PRIMARY KEY(Group_Id, file_Id),
	FOREIGN KEY(Group_Id) REFERENCES Groups(Id),
	FOREIGN KEY(file_Id) REFERENCES FileAndFolders(Id)
);
GO

CREATE TABLE FileAndFolderPeople(
	Person_Id INT NOT NULL,
	File_Id INT NOT NULL,
	PRIMARY KEY(Person_Id, File_Id),
	FOREIGN KEY(Person_Id) REFERENCES People(Id),
	FOREIGN KEY(File_Id) REFERENCES FileAndFolders(Id)
);
GO

CREATE TABLE FileAndFolderRoles(
	Role_Id INT NOT NULL,
	file_Id INT NOT NULL,
	PRIMARY KEY(Role_Id, file_Id),
	FOREIGN KEY(Role_Id) REFERENCES Roles(Id),
	FOREIGN KEY(file_Id) REFERENCES FileAndFolders(Id)
);
GO