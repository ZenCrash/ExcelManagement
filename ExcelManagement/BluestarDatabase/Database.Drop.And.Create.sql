/* CREATE BluestarDatabase DATABASE */

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'BluestarDatabase')
BEGIN
	DROP DATABASE [BluestarDatabase];
END
GO
CREATE DATABASE [BluestarDatabase];