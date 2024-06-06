/* CREATE BluestarDatabase DATABASE */

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'BluestarDatabase')
	BEGIN
		/* CREATE TABELS */
		USE [BluestarDatabase]

		--local variables
		DECLARE @CompanyId1 UNIQUEIDENTIFIER
		DECLARE @CompanyId2 UNIQUEIDENTIFIER

		SET @CompanyId1 = NEWID();
		SET @CompanyId2 = NEWID();

		--insert Companys
		insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl], [CreatedDate], [UpdatedDate]) 
		values (NEWID(), 'Intersteller Think Tank',	'Intersteller Think Tank - DescriptionText', 'www.google.com', GETDATE(), GETDATE());
		insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl], [CreatedDate], [UpdatedDate]) 
		values (NEWID(), 'Dog Fight International',	'Dog Fight International - DescriptionText', 'www.google.com', GETDATE(), GETDATE());

		BEGIN
			insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl], [CreatedDate], [UpdatedDate])
			values (@CompanyId1, 'pdm technology Group', 'pdm technology Group - DescriptionText', 'www.google.com', GETDATE(), GETDATE());
		END
		BEGIN
			insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl], [CreatedDate], [UpdatedDate]) 
			values (@CompanyId2, 'Alvon Dynamics', 'Alvon Dynamics - DescriptionText', 'www.google.com', GETDATE(), GETDATE());
		END

		--insert Groups
		BEGIN
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'pdm technology Group - IT Dep', 'pdm technology Group - IT Dep - Description', 'www.google.com', @CompanyId1, GETDATE(), GETDATE());
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'pdm technology Group - HR Dep', 'pdm technology Group - HR Dep - Description', 'www.google.com', @CompanyId1, GETDATE(), GETDATE());
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'pdm technology Group - Media Dep', 'pdm technology Group - Media Dep - Description', 'www.google.com', @CompanyId1, GETDATE(), GETDATE());
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'pdm technology Group - Exe Dep', 'pdm technology Group - Exe Dep - Description', 'www.google.com', @CompanyId1, GETDATE(), GETDATE());;
		END
		BEGIN
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'Alvon Dynamics - IT Dep', 'Alvon Dynamics - IT Dep - Description', 'www.google.com', @CompanyId2, GETDATE(), GETDATE());
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'Alvon Dynamics - HR Dep', 'Alvon Dynamics - HR Dep - Description', 'www.google.com', @CompanyId2, GETDATE(), GETDATE());
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'Alvon Dynamics - Media Dep', 'Alvon Dynamics - Media Dep - Description', 'www.google.com', @CompanyId2, GETDATE(), GETDATE());
			insert into Groups ([GroupId], [GroupName], [Description], [GroupLogoUrl], [CompanyId], [CreatedDate], [UpdatedDate]) 
			values (NEWID(), 'Alvon Dynamics - Exe Dep',	'Alvon Dynamics - Exe Dep - Description', 'www.google.com', @CompanyId2, GETDATE(), GETDATE());
		END
	END;
GO