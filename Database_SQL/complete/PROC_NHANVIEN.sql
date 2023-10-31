use QUANLYCHUYENBAY3
go
CREATE or alter TRIGGER CHECK_CMND_MaNV
ON NHANVIEN
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS (SELECT * FROM inserted WHERE CMND IN (SELECT CMND FROM NHANVIEN))
	BEGIN
		PRINT N'Không được thêm 2 Nhân Viên cùng CMND'
		ROLLBACK TRANSACTION 
	END
	Else IF EXISTS (SELECT * FROM inserted WHERE MaNV IN (SELECT MaNV FROM NHANVIEN))
	BEGIN
		PRINT N'Không được thêm cùng Mã Nhân Viên'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	   INSERT INTO NHANVIEN
       SELECT *
       FROM inserted
	END
END
go

create view XEMNHANVIEN
as 
	select * from NHANVIEN
go

create or alter proc ThemNV
@MaNV varchar(20), @CMND varchar(20), @TenNV nvarchar(45), @GioiTinh nvarchar(20), @NgaySinh date, @SDT  varchar(20),@Diachi nvarchar(100)
as
begin tran
	if (@MaNV ='' or @CMND ='' or @TenNV ='' or @GioiTinh = '' or @SDT ='' or @Diachi ='')
		begin
			print N'Thiếu thông tin nhập vào'
			rollback
		end
	else
		begin
			insert into NHANVIEN values(@MaNV,@CMND,@TenNV,@GioiTinh,@NgaySinh,@SDT,@Diachi)
			if(@@ERROR <> 0)
				begin
					rollback
				end
		end
commit tran
go

create or alter proc XoaNV
@MaNV varchar(20)
as
begin tran
	if exists (select * from NHANVIEN where MaNV=@MaNV)
		begin 
			if exists (select * from TAIKHOAN where ID_NhanVien = @MaNV)
				begin
					delete from TAIKHOAN where ID_NhanVien = @MaNV
					if(@@ERROR <> 0)
						begin
							rollback
						end
				end
			delete from NHANVIEN where MaNV = @MaNV
			if(@@ERROR <> 0)
				begin
					rollback
				end
		end
	else
		begin
			print N'XÓA NHANVIEN KHÔNG THÀNH CÔNG'
			rollback
		end
commit tran
go 

create or alter proc ChinhSuaNV
@MaNV varchar(20), @CMND varchar(20), @TenNV nvarchar(45), @GioiTinh nvarchar(20), @NgaySinh date, @SDT  varchar(20),@Diachi nvarchar(100)
as 
begin tran
	if exists (select * from NHANVIEN where MaNV=@MaNV)
		begin
			update NHANVIEN
			set
			CMND =@CMND,
			TenNV = @TenNV,
			GioiTinh = @GioiTinh,
			NgaySinh = @NgaySinh,
			SDT = @SDT,
			Diachi = @Diachi
			where MaNV = @MaNV
		end

	else
		begin
			print N'CHỈNH SỬA NHANVIEN KHÔNG THÀNH CÔNG, DO KHÔNG TỒN TẠI MaNV'
			rollback
		end
commit tran
go
create or alter function TimKiem_NV(@str nvarchar(50))
returns table
as
	return (
	select * from NHANVIEN 
	where MaNV like CONCAT('%',@str,'%') or CMND like CONCAT('%',@str,'%') or TenNV like CONCAT('%',@str,'%'))
go