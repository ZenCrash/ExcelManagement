/* Create Test Data Locally */

USE [BluestarDatabase]
GO

--Companies
insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl]) values (NEWID(), 'pdm technology Group',		'pdm technology Group - DescriptionText',		'www.google.com');
insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl]) values (NEWID(), 'Alvon Dynamics',			'Alvon Dynamics - DescriptionText',				'www.google.com');
insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl]) values (NEWID(), 'Intersteller Think Tank',	'Intersteller Think Tank - DescriptionText',	'www.google.com');
insert into Companies ([Id], [CompanyName], [Description], [CompanyLogoUrl]) values (NEWID(), 'Dog Fight International',	'Dog Fight International - DescriptionText',	'www.google.com');

GO

--USE [BluestarDatabase]
--GO
----Departments
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'pdm technology Group - IT Dep',		'pdm technology Group - IT Dep - Description',		'9BB04FE6-87E2-48A9-8914-D6B44F97F326');
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'pdm technology Group - HR Dep',		'pdm technology Group - HR Dep - Description',		'9BB04FE6-87E2-48A9-8914-D6B44F97F326');
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'pdm technology Group - Media Dep',	'pdm technology Group - Media Dep - Description',	'9BB04FE6-87E2-48A9-8914-D6B44F97F326');
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'pdm technology Group - Exe Dep',	'pdm technology Group - Exe Dep - Description',		'9BB04FE6-87E2-48A9-8914-D6B44F97F326');

--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'Alvon Dynamics - IT Dep',			'Alvon Dynamics - IT Dep - Description',			'06278E21-C621-4818-B636-BE73CA239AC4');
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'Alvon Dynamics - HR Dep',			'Alvon Dynamics - HR Dep - Description',			'06278E21-C621-4818-B636-BE73CA239AC4');
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'Alvon Dynamics - Media Dep',		'Alvon Dynamics - Media Dep - Description',			'06278E21-C621-4818-B636-BE73CA239AC4');
--insert into Departments ([Id], [DepartmentName], [Description], [CompanyId]) values (NEWID(), 'Alvon Dynamics - Exe Dep',			'Alvon Dynamics - Exe Dep - Description',			'06278E21-C621-4818-B636-BE73CA239AC4');

--GO
