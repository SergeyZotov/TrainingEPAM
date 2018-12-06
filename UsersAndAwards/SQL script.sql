USE master
IF(db_id(N'UsersAndAwards')) IS NOT NULL
	DROP DATABASE UsersAndAwards


CREATE DATABASE UsersAndAwards
GO

USE UsersAndAwards
CREATE TABLE Users(
	[Id] int not null primary key identity(1,1),
	[First Name] nvarchar(50),
	[Last Name] nvarchar(50),
	[Birthdate] datetime2,
	)

USE UsersAndAwards
CREATE TABLE Awards(
	[Id] int not null primary key identity(1,1),
	[Title] nvarchar(50),
	[Description] nvarchar(250)
	)

CREATE TABLE Relations(
			[Id] int not null primary key identity(1,1),
			[UserId] int not null,
			[AwardId] int not null,
			FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
			FOREIGN KEY (AwardId) REFERENCES Awards(Id) ON DELETE CASCADE
			)
GO

CREATE PROCEDURE AddAward(
		@title nvarchar(50),
		@description nvarchar(250))
AS
BEGIN
		INSERT INTO Awards
		VALUES(@title, @description)
END

CREATE TYPE AwardsIds AS TABLE(
		Id int);
GO

CREATE PROCEDURE AddUser(
	@fname nvarchar(50),
	@lname nvarchar(50),
	@bdate datetime2,
	@awardsIds AwardsIds readonly)
AS
BEGIN

	DECLARE @userId AS TABLE(id int)
	
	INSERT INTO Users
		OUTPUT Inserted.Id INTO @userId
			VALUES(@fname, @lname, @bdate)

	INSERT INTO Relations
		SELECT [@userId].Id, [@awardsIds].Id FROM  @userId, @awardsIds
END
GO

CREATE PROCEDURE GetUsers
AS
	SELECT [Id], [First Name], [Last Name], [Birthdate]
		FROM Users
Go

CREATE PROCEDURE EditUser( 
	@userId int,
	@fname nvarchar(50),
	@lname nvarchar(50),
	@bdate datetime2, 
	@awards AwardsIds readonly)
AS
	DELETE FROM Relations WHERE UserId = @userId;

	UPDATE Users
	SET [First Name] = @fname, [Last Name] = @lname, [Birthdate] = @bdate 
	WHERE Id = @userId;

	DELETE  FROM Relations
		WHERE Relations.UserId = @userId

	INSERT INTO Relations (UserId, AwardId)
		SELECT @userId, Id FROM @awards
Go

CREATE PROCEDURE EditAward(
	@awardId int,
	@title nvarchar(50),
	@description nvarchar(250))
AS

	UPDATE Awards
	SET [Title] = @title, [Description] = @description 
		WHERE Awards.Id = @awardId
GO

CREATE PROCEDURE DeleteUser(
		@userId int)
AS
	DELETE FROM Users WHERE [Id] = @userId;
	DELETE FROM Relations WHERE UserId = @userId
Go

CREATE PROCEDURE DeleteAward(@awardId int)
AS
	DELETE FROM Awards WHERE Id = @awardId;
	DELETE FROM Relations WHERE AwardId = @awardId
GO

CREATE PROCEDURE GetAwards
AS
	SELECT [Id], [Title], [Description]
		FROM Awards
Go

CREATE PROCEDURE GetUserRewards(@userId int)
AS

	SELECT Awards.Id, [Title], [Description]
		FROM Awards INNER JOIN Relations ON Awards.Id = Relations.AwardId
			WHERE UserId = @userId
GO

CREATE PROCEDURE InsertUserRewards(
	@userId int,
	@rewardIds AwardsIds READONLY)
As
	INSERT INTO Relations(UserId, AwardId)
		SELECT @userId, Id FROM @rewardIds

GO
