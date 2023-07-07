IF EXISTS (SELECT * FROM sys.databases WHERE name = 'BluestarDatabase')
	BEGIN
		DROP DATABASE [BluestarDatabase];
	END;
CREATE DATABASE [BluestarDatabase]