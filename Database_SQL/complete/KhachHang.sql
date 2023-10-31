use QUANLYCHUYENBAY3
go 
CREATE or alter TRIGGER CHECK_CMND
ON KHACHHANG
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS (SELECT * FROM inserted WHERE CMND IN
	(
	SELECT CMND
	FROM KHACHHANG
	))
	BEGIN
		PRINT N'Không được chèn 2 khách hàng cùng CMND'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO KHACHHANG
       SELECT CMND,TenKH,SDT,GioiTinh,Diachi,NgaySinh
       FROM inserted
	END
END
go
--Không lập phiếu cho hạng ghế
-------------view hiển thị--------------
go
create view HienThiKH
as 
	select CMND,TenKH,SDT,GioiTinh,NgaySinh,Diachi from KHACHHANG
go
-------------PROC Thêm Khách Hàng ---------------
create or alter proc ThemKH
@CMND varchar(20), @TenKH nvarchar(45), @SDT  varchar(20), @GioiTinh   nvarchar(20), @Diachi nvarchar(100), @NgaySinh date
as
begin tran 
	if(@CMND = '' or @TenKH = '' or @SDT = '' or @GioiTinh ='' or @Diachi ='')
		begin
			print N'Thiếu thông tin nhập vào'
			rollback
			return
		end
	insert into KHACHHANG values(@CMND,@TenKH,@SDT,@GioiTinh, @Diachi, @NgaySinh)
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi insert'
			rollback
			return
		end
commit tran
go

---------------PROC Xóa Khách Hàng----------------
create or alter proc XoaKH
@CMND varchar(20)
as
begin tran
	if not exists (select * from KHACHHANG where CMND = @CMND)
		begin 
			print N'CMND khách hàng không hợp lệ'
			rollback
			return
		end 
	delete from KHACHHANG where CMND = @CMND
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Xóa'
			rollback
			return
		end
commit tran
go
create or alter proc SuaKH
@CMND varchar(20), @TenKH nvarchar(45), @SDT  varchar(20), @GioiTinh   nvarchar(20), @Diachi nvarchar(100), @NgaySinh date, @strcmnd varchar(20)
as
begin tran
	if not exists (select * from KHACHHANG where CMND = @strcmnd)
		begin
			print N'CMND không tồn tại'
			rollback
			return
		end
	else
		begin
			update KHACHHANG set
			CMND = @CMND,
			TenKH = @TenKH,
			SDT = @SDT,
			GioiTinh = @GioiTinh,
			Diachi = @Diachi,
			NgaySinh = @NgaySinh
			where CMND = @strcmnd

			if(@@ERROR <> 0)
				begin
					print N'Lỗi khi Chỉnh Sửa'
					rollback
					return
				end
		end
commit tran
go
create function TimKiem_KH(@str nvarchar(50))
returns table
as
	return (
	select CMND,TenKH,SDT,GioiTinh,NgaySinh,Diachi from KHACHHANG
	where CMND like CONCAT('%',@str,'%') or TenKH like CONCAT('%',@str,'%') or SDT like CONCAT('%',@str,'%'))
go