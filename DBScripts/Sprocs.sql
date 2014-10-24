DROP PROCEDURE [dbo].[GetAllStudents]
GO
DROP PROCEDURE [dbo].[GetStudent]
GO
DROP PROCEDURE [dbo].[InsertStudent]
GO
DROP PROCEDURE [dbo].[UpdateStudent]
GO
DROP PROCEDURE [dbo].[DeleteStudent]
GO
DROP PROCEDURE [dbo].[GetNextId]
GO

CREATE PROCEDURE GetAllStudents AS
	SELECT id, firstname, middlename, lastname, addressline1, addressline2, city, state, zipcode FROM Students;
GO

CREATE PROCEDURE GetStudent
	@id int
AS
	SELECT id, firstname, middlename, lastname, addressline1, addressline2, city, state, zipcode FROM Students WHERE id = @id;
GO

CREATE PROCEDURE InsertStudent
	@id int, @firstname nvarchar(40), @middlename nvarchar(40), @lastname nvarchar(255), @addressline1 nvarchar(255), @addressline2 nvarchar(255), @city nvarchar(255), @state nvarchar(40), @zipcode nvarchar(10)
AS
	INSERT INTO Students (id, firstname, middlename, lastname, addressline1, addressline2, city, state, zipcode)
	VALUES (@id, @firstname, @middlename, @lastname, @addressline1, @addressline2, @city, @state, @zipcode)
GO

CREATE PROCEDURE UpdateStudent
	@id int, @firstname nvarchar(40), @middlename nvarchar(40), @lastname nvarchar(255), @addressline1 nvarchar(255), @addressline2 nvarchar(255), @city nvarchar(255), @state nvarchar(40), @zipcode nvarchar(10)
AS
	UPDATE Students
		SET firstname = @firstname,
			middlename = @middlename,
			lastname = @lastname,
			addressline1 = @addressline1,
			addressline2 = @addressline2,
			city = @city,
			state = @state,
			zipcode = @zipcode
	WHERE id = @id
GO

CREATE PROCEDURE DeleteStudent
	@id int
AS
	DELETE FROM Students
	WHERE id = @id
GO

CREATE PROCEDURE GetNextId
AS
	SELECT MAX(id) + 1 FROM Students
GO