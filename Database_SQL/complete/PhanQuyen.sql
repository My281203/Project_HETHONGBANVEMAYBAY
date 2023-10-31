
CREATE ROLE ADMINS
go
CREATE ROLE USERS
go
drop proc USP_CREATE_LOGIN_USER
CREATE or alter PROCEDURE USP_CREATE_LOGIN_USER
(
	@Role_Name VARCHAR(50),
	@Login_Name VARCHAR(50), 
	@Password_Login VARCHAR(50)
)
AS
BEGIN
    DECLARE @Login_UserName VARCHAR(50),
			@QueryLogin VARCHAR(100),
			@QueryUser VARCHAR(100)

	SET @Login_UserName = @Login_Name
	SET @QueryLogin ='CREATE LOGIN ' + @Login_UserName + ' WITH PASSWORD = ' + QUOTENAME(@Password_Login, '''')
	SET @QueryUser = CONCAT('CREATE USER ', @Login_UserName, ' FOR LOGIN ', @Login_UserName);

	EXEC (@QueryLogin)
	EXEC (@QueryUser)
	EXEC sys.sp_addrolemember @rolename = @Role_Name, 
	                          @membername = @Login_Name 
END
GO


create function Dang_Nhap(@Username char(20), @Password char(20))
returns table 
as 
	return (select * from TAIKHOAN where TenTaiKhoan = @Username and MatKhau = @Password)
