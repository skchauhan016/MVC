

CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO

CREATE TABLE [dbo].[Test_Sandeep](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Test_Sandeep]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO

ALTER TABLE [dbo].[Test_Sandeep]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO

CREATE TYPE [dbo].[UserTableType] AS TABLE(
	[Id] [bigint] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
	[CountryId] [int] NOT NULL
)
GO


CREATE PROC [dbo].[USER_INSERT_UPDATE]
@UserListTable UserTableType READONLY
AS
MERGE Test_Sandeep AS [Target]
USING @UserListTable AS [Source]
ON [Target].[Id]=[Source].[Id]
WHEN MATCHED THEN
UPDATE SET
FirstName=[Source].FirstName
,LastName=[Source].LastName
,Email=[Source].Email
,CityId=[Source].CityId
,CountryId=[Source].CountryId

WHEN NOT MATCHED THEN
INSERT 
(  
 [FirstName]
,[LastName]
,[Email]
,[CityId]
,[CountryId]

)
VALUES
(
[Source].[FirstName]
,[Source].[LastName]
,[Source].[Email]
,[Source].[CityId]
,[Source].[CountryId]

);
GO

CREATE PROC [dbo].[GET_USERS_BY_ID]
@Id int
As
Begin
SELECT  [Id]
      ,[FirstName]
      ,[LastName]
      ,[Email]
      ,[CityId]
      ,[CountryId]
  FROM [Test].[dbo].[Test_Sandeep] WHERE Id=@Id
  END
GO

CREATE PROC [dbo].[GET_USERS]
AS
BEGIN
SELECT Id, FirstName,LastName,Email,c1.CityName,c2.CountryName FROM Test_Sandeep t1
JOIN City c1 ON t1.CityId=c1.CityId
JOIN Country c2 ON t1.CityId=c2.CountryId
END
GO

CREATE PROC [dbo].[GET_COUNTRIES]
AS 
BEGIN
SELECT CountryId,CountryName FROM Country
END
GO
CREATE PROC [dbo].[GET_CITIES]
@CountryId int
AS 
BEGIN
SELECT CityId,CityName FROM City where CountryId=@CountryId
END
GO

CREATE PROC [dbo].[DELETE_USERS_BY_ID] 
@Id int
As
Begin
DELETE
  FROM [Test].[dbo].[Test_Sandeep] WHERE Id=@Id
  END
GO
