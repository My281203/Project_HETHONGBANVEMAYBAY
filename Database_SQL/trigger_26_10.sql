use HETHONGBANVEMAYBAY9
go
--------
create or ALTER function [dbo].[HienThiChuyenBay](@ngaybay date, @matuyenbay varchar(20))
 returns table 
 as
  return (
     select * from CHUYENBAY
	 where CHUYENBAY.MaTuyenBay like CONCAT('%',@matuyenbay,'%') and NgayBay=@ngaybay  
  )
---- 
go 
CREATE or alter function [dbo].[XemChoNgoiMayBay](@mamaybay1 varchar(20))
RETURNS TABLE
AS

    RETURN (
        SELECT * FROM CHONGOI
        WHERE CHONGOI.MaMayBay=@mamaybay1 AND TinhTrang = 0
    )
go 
--SAN BAY--
create or alter view XemSanBay as
select * from SANBAY
go

create  or alter trigger TriggerThemSanBay on SANBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		PRINT N'Ma San Bay Da Ton Tai!'
		ROLLBACK TRANSACTION
	END	
	ELSE
	BEGIN
		INSERT INTO SANBAY
		SELECT MaSanBay, TenSanBay, ViTri
		FROM inserted
	END
end
go

create  or alter proc ThemSanBay
@MaSanBay varchar(15), @TenSanBay nvarchar(30), @ViTri nvarchar(30)
as
begin
	insert into SANBAY values(@MaSanBay, @TenSanBay, @ViTri)
end

go
create   or alter trigger TriggerXoaSanBay on SANBAY
instead of delete
as
begin 
	IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT MaSanBayKhoiHanh FROM TUYENBAY_SANBAY) 
										OR MaSanBay IN (SELECT MaSanBayDen FROM TUYENBAY_SANBAY) )
		BEGIN
				PRINT N'Khong The Xoa San Bay!'
				ROLLBACK TRANSACTION 				
		END
		ELSE
		BEGIN
			DELETE FROM SANBAY WHERE MaSanBay IN (SELECT MaSanBay FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma San Bay Khong Ton Tai!'
	END
end


go
create  or alter proc XoaSanBay
@MaSanBay varchar(15)
as
begin
	delete from SANBAY where MaSanBay = @MaSanBay
end
go

create  or alter trigger TriggerSuaSanBay on SANBAY
instead of update
as
begin
	DECLARE @MaSanBay varchar(15), @TenSanBay nvarchar(30), @ViTri nvarchar(30)
	IF EXISTS (SELECT * FROM inserted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		set @MaSanBay = (select MaSanBay from inserted)
		set @TenSanBay = (select TenSanBay from inserted)
		set @ViTri = (select ViTri from inserted)
		update SANBAY set TenSanBay=@TenSanBay, ViTri=@ViTri where MaSanBay=@MaSanBay
	END
	ELSE
	BEGIN
		PRINT N'Ma San Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end
go 

create  or alter proc SuaSanBay 
@MaSanBay varchar(15), @TenSanBay nvarchar(30), @ViTri nvarchar(30)
as
begin
	update SANBAY set TenSanBay=@TenSanBay, ViTri=@ViTri where MaSanBay=@MaSanBay
end
go

create  or alter proc TimSanBay
@MaSanBay varchar(15)
as
begin
	select * from SANBAY where MaSanBay=@MaSanBay
end
go

--TUYENBAY--
create or alter view XemTuyenBay as
select * from TUYENBAY
go

create  or alter function TaoTenTuyenBay(@MaSanBayKhoiHanh varchar(15), @MaSanBayDen varchar(15))
returns nvarchar(50)
as
begin 
	declare @TenTB nvarchar(50)
	set @TenTB = concat(N'Tuyến bay ', @MaSanBayKhoiHanh, '-', @MaSanBayDen)
	return @TenTB
end
go

CREATE OR ALTER TRIGGER TriggerThemTuyenBay on TUYENBAY
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT * FROM inserted WHERE MaTuyenBay IN (SELECT MaTuyenBay FROM TUYENBAY))
    BEGIN
        PRINT N'Mã Tuyến Bay Đã Tồn Tại!'
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        DECLARE @MaSanBayKhoiHanh varchar(15), @MaSanBayDen varchar(15)
        DECLARE @StartPosition int

        SET @StartPosition = CHARINDEX(N'Tuyến bay', (SELECT TenTuyenBay FROM inserted))

        IF @StartPosition = 1
        BEGIN
            SET @MaSanBayKhoiHanh = SUBSTRING((SELECT TenTuyenBay FROM inserted), 11, CHARINDEX('-', (SELECT TenTuyenBay FROM inserted)) - 11)
            SET @MaSanBayDen = SUBSTRING((SELECT TenTuyenBay FROM inserted), CHARINDEX('-', (SELECT TenTuyenBay FROM inserted)) + 1, LEN((SELECT TenTuyenBay FROM inserted)))

            IF EXISTS (SELECT 1 FROM SANBAY WHERE MaSanBay = @MaSanBayKhoiHanh) AND EXISTS (SELECT 1 FROM SANBAY WHERE MaSanBay = @MaSanBayDen)
            BEGIN
                INSERT INTO TUYENBAY (MaTuyenBay, TenTuyenBay)
                SELECT MaTuyenBay, TenTuyenBay
                FROM inserted

                INSERT INTO TUYENBAY_SANBAY (MaTuyenBay, MaSanBayKhoiHanh, MaSanBayDen)
                SELECT MaTuyenBay, @MaSanBayKhoiHanh, @MaSanBayDen
                FROM inserted
            END
            ELSE
            BEGIN
                PRINT N'Có Mã Sân Bay Không Tồn Tại'
				ROLLBACK TRANSACTION
            END
        END
        ELSE
        BEGIN
            PRINT N'TenTuyenBay không bắt đầu bằng ''Tuyến bay'''
        END
    END
END
go

CREATE OR ALTER PROC ThemTuyenBay
@MaTuyenBay varchar(15), @TenTuyenBay nvarchar(50)
AS
BEGIN                 
                INSERT INTO TUYENBAY (MaTuyenBay, TenTuyenBay)
                VALUES (@MaTuyenBay, @TenTuyenBay)                       
END

go

create  or alter trigger TriggerXoaTuyenBay on TUYENBAY 
instead of delete
as
begin
	if exists (select * from deleted where MaTuyenBay in (select MaTuyenBay from TuyenBay))
		begin
			if exists (select * from deleted where MaTuyenBay in (select MaTuyenBay from CHUYENBAY))
				begin
					print N'Không Thể Xóa Tuyến Bay!'
					rollback transaction
				end
			else
				begin
					delete from TUYENBAY where MaTuyenBay in (select MaTuyenBay from deleted)
				end
		end
	else
		begin
		print N'Mã Tuyến Bay Không Tồn Tại!'
		end
end
go

create  or alter proc XoaTuyenBay
@MaTuyenBay varchar(15)
as
begin
	delete from TUYENBAY where MaTuyenBay = @MaTuyenBay
end
go


create  or alter proc TimTuyenBay
@MaTuyenBay varchar(15)
as
begin
	select * from TUYENBAY where MaTuyenBay = @MaTuyenBay
end
go		

--MAYBAY--
create  or alter view MaMayBayCuoi1 as
SELECT TOP 1 *
FROM MAYBAY
ORDER BY MaMayBay DESC
go 

create  or alter view MaNhanVienCuoi as
SELECT TOP 1 *
FROM NHANVIEN
ORDER BY MaNV DESC
go

CREATE or alter FUNCTION GetNextMaNV()
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @LastMaNV VARCHAR(10);
    DECLARE @NextMaNV VARCHAR(10);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaNV = MaNV
    FROM MaNhanVienCuoi;
    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaNV IS NULL
    BEGIN
        SET @NextMaNV = 'NV001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaNV, 3, 3) AS INT);
        SET @NextMaNV = 'NV' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaNV;
END;
go

CREATE or alter FUNCTION GetNextMaMayBay5()
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @LastMaMayBay VARCHAR(15);
    DECLARE @NextMaMayBay VARCHAR(15);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaMayBay = MaMayBay
    FROM MaMayBayCuoi1;
    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaMayBay IS NULL
    BEGIN
        SET @NextMaMayBay = 'MB001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaMayBay, 3, 3) AS INT);
        SET @NextMaMayBay = 'MB' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaMayBay;
END;
go

create or alter view XemMayBay as
select * from MAYBAY 
go
select * from CHONGOI
go
create or alter view XemMayBay1 as
select * from MAYBAY where MaMayBay in( select DISTINCT MaMayBay from CHONGOI where CHONGOI.machuyenbay is NULL)

go
select * from XemMayBay1


CREATE OR ALTER TRIGGER TriggerThemMayBay
ON MAYBAY
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem các Mã Máy Bay mới thêm đã tồn tại trong bảng MAYBAY hay chưa
    IF EXISTS (SELECT 1 FROM inserted i WHERE EXISTS (SELECT 1 FROM MAYBAY m WHERE m.MaMayBay = i.MaMayBay))
    BEGIN
        ROLLBACK;
        THROW 51000, N'Mã Máy Bay Đã Tồn Tại!', 1;
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO MAYBAY (MaMayBay, LoaiMayBay, SoGheLoaiA, SoGheLoaiB)
        SELECT MaMayBay, LoaiMayBay, SoGheLoaiA, SoGheLoaiB
        FROM inserted;

        -- Lấy 3 số cuối của MaMayBay
        DECLARE @SoCuoi INT;
        SET @SoCuoi = CAST(RIGHT((SELECT MaMayBay FROM inserted), 3) AS INT);

        -- Tạo biến để theo dõi số thứ tự tăng dần cho loại ghế A và B
        DECLARE @SoThuTuA INT;
        DECLARE @SoThuTuB INT;

        -- Lấy giá trị số thứ tự hiện tại cho loại ghế A
        SELECT @SoThuTuA = ISNULL(MAX(CAST(RIGHT(MaGhe, 2) AS INT)), 0)
        FROM CHONGOI
        WHERE MaMayBay IN (SELECT MaMayBay FROM inserted)
        AND SUBSTRING(MaGhe, LEN(MaGhe) - 2, 1) = 'A';

        -- Lấy giá trị số thứ tự hiện tại cho loại ghế B
        SELECT @SoThuTuB = ISNULL(MAX(CAST(RIGHT(MaGhe, 2) AS INT)), 0)
        FROM CHONGOI
        WHERE MaMayBay IN (SELECT MaMayBay FROM inserted)
        AND SUBSTRING(MaGhe, LEN(MaGhe) - 2, 1) = 'B';

        -- Thêm chỗ ngồi cho ghế loại A
        INSERT INTO CHONGOI (MaGhe, TinhTrang, LoaiGhe, GiaGhe, MaMayBay)
        SELECT
            CAST(@SoCuoi AS VARCHAR(3)) + 'A' + RIGHT('00' + CAST(@SoThuTuA + ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(2)), 2),
            0, N'Loại A', 9000000, (SELECT MaMayBay FROM inserted)
        FROM inserted
        CROSS APPLY (SELECT TOP (SoGheLoaiA) 1 AS n FROM master.dbo.spt_values) AS nums
        WHERE nums.n IS NOT NULL;

        -- Thêm chỗ ngồi cho ghế loại B
        INSERT INTO CHONGOI (MaGhe, TinhTrang, LoaiGhe, GiaGhe, MaMayBay)
        SELECT
            CAST(@SoCuoi AS VARCHAR(3)) + 'B' + RIGHT('00' + CAST(@SoThuTuB + ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(2)), 2),
            0, N'Loại B', 1200000, (SELECT MaMayBay FROM inserted)
        FROM inserted
        CROSS APPLY (SELECT TOP (SoGheLoaiB) 1 AS n FROM master.dbo.spt_values) AS nums
        WHERE nums.n IS NOT NULL;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH;
END;


go


create  or alter proc ThemMayBay
@MaMayBay varchar(15), @LoaiMayBay nvarchar(20), @SoGheLoaiA int, @SoGheLoaiB int
as
begin 
	insert into MAYBAY values(@MaMayBay, @LoaiMayBay, @SoGheLoaiA, @SoGheLoaiB)
end
go

create  or alter proc ThemMayBay4
 @LoaiMayBay nvarchar(20), @SoGheLoaiA int, @SoGheLoaiB int
as
begin 
    declare @MaMayBay varchar(15)
	set @MaMayBay = dbo.GetNextMaMayBay5()
	insert into MAYBAY values(@MaMayBay, @LoaiMayBay, @SoGheLoaiA, @SoGheLoaiB)
end
go

create   or alter trigger TriggerXoaMayBay on MAYBAY
instead of delete
as
begin 
	IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT MaMayBay FROM CHUYENBAY ))								
		BEGIN
				PRINT N'Không Thể Xóa Máy Bay!'
				ROLLBACK TRANSACTION 				
		END
		ELSE
		BEGIN
			DELETE FROM MAYBAY WHERE MaMayBay IN (SELECT MaMayBay FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Mã Máy Bay Không Tồn Tại!'
	END
end
go

create  or alter proc XoaMayBay
@MaMayBay varchar(15)
as
begin
	delete from MAYBAY where MaMayBay = @MaMayBay
end
go

create or alter trigger TriggerSuaMayBay on MAYBAY
instead of update
as
begin
	declare @MaMayBay varchar(15), @LoaiMayBay nvarchar(20), @SoGheLoaiA int, @SoGheLoaiB int 
	IF EXISTS (SELECT * FROM inserted where MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		SET @MaMayBay = (SELECT MaMayBay FROM inserted)
		SET @LoaiMayBay = (SELECT LoaiMayBay FROM inserted)
		SET @SoGheLoaiA = (SELECT SoGheLoaiA FROM inserted)
		SET @SoGheLoaiB = (SELECT SoGheLoaiB FROM inserted)
		UPDATE MAYBAY SET LoaiMayBay=@LoaiMayBay, SoGheLoaiA = @SoGheLoaiA,SoGheLoaiB = @SoGheLoaiB where MaMayBay=@MaMayBay
	END
	ELSE
	BEGIN
		PRINT N'Ma May Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end

go

create or alter proc SuaMayBay
@MaMayBay varchar(15), @LoaiMayBay nvarchar(20), @SoGheLoaiA int, @SoGheLoaiB int 
as
begin
	update MAYBAY set LoaiMayBay=@LoaiMayBay, SoGheLoaiA=@SoGheLoaiA, SoGheLoaiB= @SoGheLoaiB where MaMayBay=@MaMayBay
end
GO
create or alter proc TimMayBay
@MaMayBay varchar(20)
as
begin
	select * from MAYBAY where MaMayBay=@MaMayBay
end
go

--CHONGOI--
create or alter view XemChoNgoi as
select * from CHONGOI
go

CREATE OR ALTER TRIGGER TriggerThemChoNgoi ON CHONGOI
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT * FROM CHONGOI WHERE MaGhe IN (SELECT MaGhe FROM inserted))
    BEGIN
        PRINT N'Mã Chỗ Ngồi Đã Tồn Tại!'
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN
        IF NOT EXISTS (SELECT * FROM MAYBAY WHERE MaMayBay IN (SELECT MaMayBay FROM inserted))
        BEGIN
            PRINT N'Mã Máy Bay Không Tồn Tại!'
            ROLLBACK TRANSACTION
        END
        ELSE
        BEGIN
            INSERT INTO CHONGOI (MaGhe, TinhTrang, LoaiGhe, GiaGhe, MaMayBay,machuyenbay)
            SELECT MaGhe, TinhTrang, LoaiGhe, GiaGhe, MaMayBay,machuyenbay
            FROM inserted 
        END
    END
END
go

create or alter proc ThemChoNgoi
@MaGhe varchar(5), @TinhTrang bit, @LoaiGhe nvarchar(20), @GiaGhe int , @MaMayBay varchar(15),@machuyenbay varchar(15)
as
begin
	insert into CHONGOI values(@MaGhe, @TinhTrang, @LoaiGhe, @GiaGhe, @MaMayBay,@machuyenbay)
end
go



create or alter proc SuaChoNgoi
@MaGhe varchar(5), @TinhTrang bit, @LoaiGhe nvarchar(20), @GiaGhe int , @MaMayBay varchar(15),@machuyenbay varchar(15)
as
begin
	update CHONGOI set MaGhe=@MaGhe, TinhTrang=@TinhTrang, LoaiGhe=@LoaiGhe, GiaGhe=@GiaGhe, MaMayBay=@MaMayBay, machuyenbay = @machuyenbay
end
go

CREATE OR ALTER TRIGGER TriggerXoaChoNgoi ON CHONGOI
INSTEAD OF DELETE
AS
BEGIN
    
    IF EXISTS (SELECT 1 FROM CHONGOI WHERE MaGhe IN (SELECT MaGhe FROM deleted ))
		if exists (select 1 from THONGTINGIAODICH where MaGhe in (select MaGhe From deleted))
			BEGIN
				PRINT N'Thông Tin Giao Dịch Còn Tồn Tại!'
				ROLLBACK TRANSACTION
			END
		else
			BEGIN
				DELETE 
				FROM CHONGOI 
				WHERE MaGhe IN (SELECT MaGhe FROM deleted )
			END
						
	ELSE
			BEGIN
				PRINT N'Mã Chỗ Ngồi Không Tồn Tại!'
				ROLLBACK TRANSACTION
			END	
    
END
go

create or alter proc XoaChoNgoi
@MaGhe varchar(5)
as
begin
	delete from CHONGOI where MaGhe = @MaGhe
end

go
--KHACHHANG--

create or alter view HienThiKH as
select * from KHACHHANG
go

CREATE OR ALTER TRIGGER CHECK_CCCD_SDT_THEMKH ON KHACHHANG
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @DuplicateCCCD INT, @DuplicateSDT INT

    SELECT @DuplicateCCCD = COUNT(*)
    FROM KHACHHANG WHERE CCCD IN (SELECT CCCD FROM inserted)

    SELECT @DuplicateSDT = COUNT(*)
    FROM KHACHHANG WHERE SDT IN (SELECT SDT FROM inserted)

    IF @DuplicateCCCD > 0
    BEGIN
        PRINT N'Khách hàng không được cùng CCCD'
        ROLLBACK TRAN
    END
    ELSE IF @DuplicateSDT > 0
    BEGIN
        PRINT N'Khách hàng không được  cùng SDT'
        ROLLBACK TRAN
    END
    ELSE
    BEGIN
        INSERT INTO KHACHHANG (CCCD, HoTen, GioiTinh, SDT, NgaySinh, Email)
        SELECT CCCD, HoTen, GioiTinh, SDT, NgaySinh, Email
        FROM inserted
    END
END
go 

create or alter function TimKiemKH(@str nvarchar(50))
returns table
as
	return (
	select CCCD,HoTen,GioiTinh,SDT,NgaySinh,Email from KHACHHANG
	where CCCD like CONCAT('%',@str,'%') or SDT like CONCAT('%',@str,'%'))
go

create or alter proc ThemKH
@CCCD varchar(12), @TenKH nvarchar(30), @GioiTinh nvarchar(5), @SDT varchar(10), @NgaySinh date, @Email varchar(30)
as
begin tran
	insert into KHACHHANG values(@CCCD, @TenKH, @GioiTinh, @SDT, @NgaySinh, @Email)
	if(@@ERROR <> 0)
	begin
		print N'Lỗi khi insert'
		rollback
		return
	end
commit tran
go


CREATE OR ALTER TRIGGER CHECK_CCCD_SDT_SUAKH ON KHACHHANG
INSTEAD OF UPDATE
AS
BEGIN
    DECLARE @CCCD varchar(12), @TenKH nvarchar(30), @GioiTinh nvarchar(5), @SDT varchar(10), @NgaySinh date, @Email varchar(30)
    DECLARE @CCCDExists INT, @DuplicateCCCD INT, @DuplicateSDT INT

    SELECT @CCCDExists = COUNT(*)
    FROM KHACHHANG WHERE CCCD IN (SELECT CCCD FROM inserted)

    SELECT @DuplicateCCCD = COUNT(*)
    FROM KHACHHANG WHERE CCCD IN (SELECT CCCD FROM inserted) AND CCCD <> (SELECT CCCD FROM deleted)

    SELECT @DuplicateSDT = COUNT(*)
    FROM KHACHHANG WHERE SDT IN (SELECT SDT FROM inserted) AND SDT <> (SELECT SDT FROM deleted)

    IF @CCCDExists = 0
    BEGIN
        PRINT N'CCCD không tồn tại';
        ROLLBACK;
    END
    ELSE IF @DuplicateSDT > 0
    BEGIN
        PRINT N'Trùng SDT với khách hàng khác';
        ROLLBACK;
    END
    ELSE
    BEGIN
        UPDATE KHACHHANG
        SET 
            HoTen = (SELECT HoTen FROM inserted),
            GioiTinh = (SELECT GioiTinh FROM inserted),
            SDT = (SELECT SDT FROM inserted),
            NgaySinh = (SELECT NgaySinh FROM inserted),
            Email = (SELECT Email FROM inserted)
        WHERE CCCD = (SELECT CCCD FROM inserted);
    END
END
go
CREATE OR ALTER PROCEDURE SuaKH
    @CCCD varchar(12),
    @TenKH nvarchar(30),
    @GioiTinh nvarchar(5),
    @SDT varchar(10),
    @NgaySinh date,
    @Email varchar(30)
AS
BEGIN
    BEGIN TRAN;

    -- Thực hiện cập nhật thông tin khách hàng
UPDATE KHACHHANG
    SET
        HoTen = @TenKH,
        GioiTinh = @GioiTinh,
        SDT = @SDT,
        NgaySinh = @NgaySinh,
        Email = @Email
    WHERE CCCD = @CCCD;

    IF (@@ERROR <> 0)
    BEGIN
        PRINT N'Lỗi khi chỉnh sửa';
        ROLLBACK;
        RETURN;
    END;

    COMMIT;
END;

GO
create or alter trigger TriggerXoaKH on KHACHHANG
instead of delete
as
begin
	if exists (select * from deleted where CCCD IN (SELECT CCCD FROM KHACHHANG) )
	begin
		if exists (select * from deleted where CCCD IN (SELECT CCCD FROM HOADON) or CCCD IN (SELECT CCCD FROM THONGTINGIAODICH))
		BEGIN
				PRINT N'Không Thể Xóa Khách Hàng!'
				ROLLBACK TRANSACTION 				
		END
		ELSE
		BEGIN
			DELETE FROM KHACHHANG WHERE CCCD IN (SELECT CCCD FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Khách Hàng Không Tồn Tại!'
	END
end


go

create or alter proc XoaKH
@CCCD varchar(12)
as
begin tran
		
		delete from KHACHHANG
		where CCCD = @CCCD;

		if(@@ERROR <> 0)
		begin
			print N'Lỗi khi xóa khách hàng';
			rollback;
			return;
		end
commit tran;
go


--PHANQUYEN--
CREATE OR ALTER TRIGGER TriggerUyQuyen
ON PHANQUYEN
FOR INSERT
AS
BEGIN
    DECLARE @MaNV varchar(10)
    DECLARE @TaiKhoan varchar(30)
    DECLARE @MatKhau varchar(30)
    DECLARE @UyQuyen bit

    SELECT @MaNV = MaNV, @TaiKhoan = TaiKhoan, @MatKhau = MatKhau, @UyQuyen = UyQuyen
    FROM inserted    
    IF @TaiKhoan = 'Admin'
    BEGIN
        UPDATE PHANQUYEN
        SET UyQuyen = 1
        WHERE MaNV = @MaNV AND TaiKhoan = @TaiKhoan
    END
	   
    IF @TaiKhoan <> 'Admin'
    BEGIN
        UPDATE PHANQUYEN
        SET UyQuyen = 0
        WHERE MaNV = @MaNV AND TaiKhoan = @TaiKhoan
    END
END
GO

CREATE or alter PROCEDURE DoiMatKhau
    @MaNV varchar(10),
    @TaiKhoan varchar(30),
    @MatKhau varchar(30)
AS
BEGIN
    UPDATE PHANQUYEN
    SET MatKhau = @MatKhau
    WHERE MaNV = @MaNV AND TaiKhoan = @TaiKhoan
END
GO

CREATE or alter PROCEDURE DangNhap
    @TaiKhoan varchar(30),
    @MatKhau varchar(30)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Dem int;

    SELECT @Dem = COUNT(*)
    FROM PHANQUYEN
    WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau;

    IF @Dem = 1
        PRINT N'Đăng nhập thành công.';
    ELSE
        PRINT N'Đăng nhập thất bại.';
END
GO

--CHUYENBAY--
create or alter view XemChuyenBay as
select * from CHUYENBAY

go
create or alter view MaChuyenBayCuoi as
SELECT TOP 1 MaChuyenBay
FROM CHUYENBAY
ORDER BY MaChuyenBay DESC
go

CREATE OR ALTER PROCEDURE ThemNV
 @CCCD varchar(12), @TenNV nvarchar(30), @NgaySinh date, @GioiTinh nvarchar(5), @SDT varchar(10), @Diachi nvarchar(60)
AS
BEGIN
    declare @MaNV varchar(10)
	set @MaNV = dbo.GetNextMaNV()
    INSERT INTO NHANVIEN VALUES(@MaNV, @CCCD, @TenNV, @NgaySinh, @GioiTinh, @SDT, @Diachi);
    INSERT INTO PHANQUYEN (MaNV, TaiKhoan, MatKhau, UyQuyen) VALUES (@MaNV, @MaNV, '123456789', 0); -- Giả sử mật khẩu mặc định là 'MatKhauMacDinh' và không có quyền đặc biệt
END
go
CREATE or alter FUNCTION GetNextMaChuyenBay ()
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @LastMaChuyenBay VARCHAR(15);
    DECLARE @NextMaChuyenBay VARCHAR(15);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaChuyenBay = MaChuyenBay
    FROM MaChuyenBayCuoi;

    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaChuyenBay IS NULL
    BEGIN
        SET @NextMaChuyenBay = 'CB001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaChuyenBay, 3, 3) AS INT);
        SET @NextMaChuyenBay = 'CB' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaChuyenBay;
END;


go
create or alter trigger TriggerThemChuyenBay on CHUYENBAY
instead of insert
as
begin
	if exists (select * from inserted where MaChuyenBay in (select MaChuyenBay from CHUYENBAY))
		begin
			print N'Thêm chuyến bay không thành công, MaChuyenBay đã tồn tại'
			rollback tran
		end
	else
		begin
			if exists (select * from inserted where MaTuyenBay in (select MaTuyenBay from CHUYENBAY))
				begin 
					if exists (select * from inserted where MaMayBay in (select MaMayBay from MAYBAY))
						begin
						   declare @MaChuyenBay varchar(15),@MaMayBay varchar(15)
						   set @MaChuyenBay = (select MaChuyenBay from inserted)
						   set @MaMayBay = (select MaMayBay from inserted)
							print N'Thêm chuyến bay thành công'
							INSERT INTO CHUYENBAY
							SELECT *
							FROM inserted

							UPDATE  CHONGOI	SET machuyenbay = @MaChuyenBay where MaMayBay = @MaMayBay

						end
					else 
						begin
							print N'Thêm chuyến bay không thành công, MaMayBay không tồn tại'
							rollback tran
						end
				end
			else 
				begin
					print N'Thêm chuyến bay không thành công, MaTuyenBay không tồn tại'
					rollback tran
				end
		end
end
go

create or ALTER function TimKiem_TuyenBay(@str nvarchar(45),@str2 nvarchar(45))
returns table
as
	return (
	select MaTuyenBay from TUYENBAY_SANBAY
	where MaSanBayKhoiHanh like CONCAT('%',(select MaSanBay from SANBAY where ViTri like CONCAT('%',@str,'%')),'%') and MaSanBayDen like CONCAT('%',(select MaSanBay from SANBAY where ViTri like CONCAT('%',@str2,'%')),'%') )

go 

create or alter proc ThemChuyenBay
@MaChuyenBay char(20), @NgayBay Date, @GioKhoiHanh TIME, @ThoiGianBay TIME, @ThoiGianDenDuKien TIME, @MaTuyenBay char(20), @MaMayBay CHAR(20)
as
begin
	INSERT INTO CHUYENBAY VALUES(@MaChuyenBay, @NgayBay, @GioKhoiHanh, @ThoiGianBay, @ThoiGianDenDuKien, @MaTuyenBay, @MaMayBay);
    IF @@ERROR <> 0
		BEGIN
			print N'Lỗi khi thêm chuyến bay'
			ROLLBACK;
		END
end
go

create or alter proc ThemChuyenBay1
 @NgayBay Date, @GioKhoiHanh TIME, @ThoiGianBay TIME, @ThoiGianDenDuKien TIME, @MaTuyenBay char(20), @MaMayBay CHAR(20)
as
begin
    declare @MaCB char(20)
	set @MaCB = dbo.GetNextMaChuyenBay()
	INSERT INTO CHUYENBAY VALUES(@MaCB, @NgayBay, @GioKhoiHanh, @ThoiGianBay, @ThoiGianDenDuKien, @MaTuyenBay, @MaMayBay);
    IF @@ERROR <> 0
		BEGIN
			print N'Lỗi khi thêm chuyến bay'
			ROLLBACK;
		END
end
go

go


go
create or alter trigger TriggerXoaChuyenBay on CHUYENBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
		BEGIN
			IF EXISTS (SELECT * FROM deleted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM THONGTINGIAODICH))
				BEGIN
					PRINT N'Không thể xóa chuyến bay!'
					ROLLBACK TRANSACTION 
				END	
			ELSE
				BEGIN
				    declare @MaChuyenBay varchar(15)
					set @MaChuyenBay = (SELECT MaChuyenBay FROM deleted)

				   UPDATE ChoNgoi
                   SET TinhTrang = 0,
                   machuyenbay = NULL
                  FROM ChoNgoi where machuyenbay = @MaChuyenBay and MaMayBay in (select MaMayBay from deleted)
				  DELETE FROM CHUYENBAY WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM deleted)				
					print N'Xóa chuyến bay thành công'
				END
		END
	ELSE
		BEGIN
			PRINT N'Xóa chuyến bay không thành công, MaChuyenBay không tồn tại!'
			rollback tran
		END
end
go


create or alter proc XoaChuyenBay
@MaChuyenBay varchar(15)
as 
begin
	delete CHUYENBAY where MaChuyenBay = @MaChuyenBay
	IF @@ERROR <> 0
		BEGIN
			print N'Lỗi khi xóa chuyến bay'
			ROLLBACK;
		END
end
go


create or alter trigger TriggerSuaChuyenBay on CHUYENBAY
instead of update
as
begin
	DECLARE @MaChuyenBay varchar(15), @NgayBay date, @ThoiGianBay Time, @ThoiGianDenDuKien Time, @GioKhoiHanh time, @MaTuyenBay varchar(15), @MaMayBay varchar(15)
	IF EXISTS (SELECT * FROM inserted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
		IF EXISTS (SELECT * FROM inserted WHERE MaTuyenBay IN (SELECT MaTuyenBay FROM TUYENBAY))
			IF EXISTS (SELECT * FROM inserted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
				BEGIN
					set @NgayBay = (select NgayBay from inserted)
					set @ThoiGianBay = (select ThoiGianBay from inserted)
					set @ThoiGianDenDuKien = (select ThoiGianDenDuKien from inserted)
					set @GioKhoiHanh = (select GioKhoiHanh from inserted)
					set @MaTuyenBay = (select MaTuyenBay from inserted)
					set @MaMayBay = (select MaMayBay from inserted)
					set @MaChuyenBay = (select MaChuyenBay from inserted)
					update CHUYENBAY
						set NgayBay=@NgayBay, ThoiGianBay=@ThoiGianBay, ThoiGianDenDuKien=@ThoiGianDenDuKien, GioKhoiHanh=@GioKhoiHanh, MaTuyenBay=@MaTuyenBay, MaMayBay=@MaMayBay 
						where MaChuyenBay=@MaChuyenBay
					print N'Sửa chuyến bay thành công'
				END
			ELSE
				BEGIN
					PRINT N'Sửa chuyến bay không thành công, MaMayBay không tồn tại'
					ROLLBACK TRANSACTION 
				END
		ELSE
			BEGIN
				PRINT N'Sửa chuyến bay không thành công, MaTuyenBay không tồn tại'
				ROLLBACK TRANSACTION
			END
	ELSE
		BEGIN
			PRINT N'Sửa chuyến bay không thành công, MaChuyenBay không tồn tại!'
			ROLLBACK TRANSACTION 
		END
end
go


create or alter proc SuaChuyenBay
@MaChuyenBay varchar(15) ,@NgayBay Date ,@ThoiGianBay TIME, @ThoiGianDenDuKien TIME, @GioKhoiHanh TIME, @MaTuyenBay varchar(15) ,@MaMayBay varchar(15)
as
begin
	update CHUYENBAY set MaChuyenBay=@MaChuyenBay, NgayBay=@NgayBay, ThoiGianBay=@ThoiGianBay, ThoiGianDenDuKien=@ThoiGianDenDuKien, GioKhoiHanh=@GioKhoiHanh, MaTuyenBay=@MaTuyenBay, MaMayBay=@MaMayBay where MaChuyenBay=@MaChuyenBay
	IF @@ERROR <> 0
		BEGIN
			print N'Lỗi khi sửa chuyến bay'
			ROLLBACK;
		END
end
go

--NHAN VIEN--

create or alter  view XemNV as
select * from NHANVIEN
GO
create or alter trigger TriggerCheckThemNV on NHANVIEN
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE CCCD IN (SELECT CCCD FROM NHANVIEN))
	BEGIN
		PRINT N'Không được thêm 2 Nhân Viên cùng CCCD'
		ROLLBACK TRANSACTION 
	END
	Else IF EXISTS (SELECT * FROM inserted WHERE MaNV IN (SELECT MaNV FROM NHANVIEN))
	BEGIN
		PRINT N'Không được thêm cùng Mã Nhân Viên'
		ROLLBACK TRANSACTION 
	END
	Else IF EXISTS (SELECT * FROM inserted WHERE SDT IN (SELECT SDT FROM NHANVIEN))
	BEGIN
		PRINT N'Không thể thêm Nhân Viên có cùng Số Điện Thoại'
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
CREATE OR ALTER PROCEDURE ThemNV
@MaNV varchar(10), @CCCD varchar(12), @TenNV nvarchar(30), @NgaySinh date, @GioiTinh nvarchar(5), @SDT varchar(10), @Diachi nvarchar(60)
AS
BEGIN
    INSERT INTO NHANVIEN VALUES(@MaNV, @CCCD, @TenNV, @NgaySinh, @GioiTinh, @SDT, @Diachi);
    INSERT INTO PHANQUYEN (MaNV, TaiKhoan, MatKhau, UyQuyen) VALUES (@MaNV, @MaNV, '123456789', 0); -- Giả sử mật khẩu mặc định là 'MatKhauMacDinh' và không có quyền đặc biệt
END
go

create or alter trigger TriggerXoaPhanQuyenNhanVien ON NHANVIEN
instead of delete
as
begin
	BEGIN
	IF EXISTS (SELECT * FROM deleted WHERE MaNV IN (SELECT MaNV FROM NHANVIEN))
    BEGIN
        -- Xóa phân quyền của nhân viên từ bảng PHANQUYEN
        DELETE FROM PHANQUYEN WHERE MaNV IN (SELECT MaNV FROM deleted);   
    END
    ELSE
    BEGIN
        PRINT N'Không thể xóa phân quyền nhân viên vì không tồn tại.';
    END
	END
end


go
CREATE OR ALTER PROCEDURE XoaPhanQuyenNhanVien
@MaNV varchar(10)
AS
BEGIN
      DELETE FROM PHANQUYEN WHERE MaNV = @MaNV;   
END

go

CREATE OR ALTER TRIGGER TriggerSuaNV ON NHANVIEN
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Bắt đầu giao dịch
    BEGIN TRANSACTION;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE (
            EXISTS (SELECT 1 FROM NHANVIEN n WHERE n.CCCD = i.CCCD AND n.MaNV <> i.MaNV)
            OR
            EXISTS (SELECT 1 FROM NHANVIEN n WHERE n.MaNV = i.MaNV AND n.CCCD <> i.CCCD)
        )
    )
    BEGIN
        PRINT N'Không được cập nhật CCCD trùng với CCCD của nhân viên khác';
        ROLLBACK;
        RETURN;
    END

    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE EXISTS (SELECT 1 FROM NHANVIEN n WHERE n.SDT = i.SDT AND n.MaNV <> i.MaNV)
    )
    BEGIN
        PRINT N'Không thể cập nhật Số Điện Thoại trùng với nhân viên khác.';
        ROLLBACK;
        RETURN;
    END

    -- Thực hiện cập nhật vào bảng NHANVIEN nếu không có xung đột
    UPDATE NHANVIEN
    SET
        CCCD = i.CCCD,
        TenNV = i.TenNV,
        NgaySinh = i.NgaySinh,
        GioiTinh = i.GioiTinh,
        SDT = i.SDT,
		DiaChi = i.DiaChi
    FROM inserted i
    WHERE NHANVIEN.MaNV = i.MaNV;

    -- Commit giao dịch nếu không có xung đột
    COMMIT;
END
go

CREATE OR ALTER PROCEDURE SuaNV
@MaNV varchar(10), @CCCD varchar(12), @TenNV nvarchar(30), @NgaySinh date, @GioiTinh nvarchar(5), @SDT varchar(10), @Diachi nvarchar(60)
AS 
BEGIN 
    UPDATE NHANVIEN SET CCCD = @CCCD, TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SDT = @SDT ,DiaChi = @DiaChi  where MaNV = @MaNV 
END
go

--THONG TIN GIAO DICH--
create or alter function TimKiemTTGD(@str nvarchar(50))
returns table
as
	return (
	select MaGiaoDich, NgayDat, MaChuyenBay, MaGhe, CCCD from THONGTINGIAODICH
	where MaGiaoDich like CONCAT('%',@str,'%') or NgayDat like CONCAT('%',@str,'%') or MaChuyenBay like CONCAT('%',@str,'%') or MaGhe like CONCAT('%',@str,'%') or CCCD like CONCAT('%',@str,'%'))
go

create or alter trigger TriggerThongTinGiaoDich on THONGTINGIAODICH
instead of insert
as
begin
	if exists (select * from inserted where MaGiaoDich in (select MaGiaoDich from THONGTINGIAODICH))
		begin
			print N'Thêm giao dịch không thành công, MaGiaoDich đã tồn tại!'
			rollback tran 
		end
	else
		begin
		   insert into THONGTINGIAODICH
		   select MaGiaoDich, NgayDat, MaChuyenBay, MaGhe, CCCD,is_deleted
		   from inserted
		   print N'Thêm giao dịch thành công!'
		end
end
go

create or alter proc ThemGiaoDich
@MaGiaoDich char(15), @NgayDat Date, @MaChuyenBay char(15), @MaGhe char(5), @CCCD char(12),@is_deleted bit
as
begin
	if exists (select * from THONGTINGIAODICH where MaGiaoDich = @MaGiaoDich)
		begin
			print N'Thêm giao dịch không thành công, MaGiaoDich đã tồn tại'
		end
	else
		begin
			if exists (select * from CHUYENBAY where MaChuyenBay = @MaChuyenBay)
				begin 
					if exists (select * from KHACHHANG where CCCD = @CCCD)
						begin
							if exists (select * from CHONGOI where MaGhe = @MaGhe)
								begin
									print N'Thêm giao dịch thành công'
									insert into THONGTINGIAODICH values(@MaGiaoDich, @NgayDat, @MaChuyenBay, @MaGhe, @CCCD,@is_deleted)
								end
							else print N'Thêm giao dịch không thành công, MaGhe không tồn tại'
						end
					else print N'Thêm giao dịch không thành công, MaKhachHang không tồn tại'
				end
			else print N'Thêm giao dịch không thành công, MaChuyenBay không tồn tại'
		end
end
go

--------------Them
 create or ALTER function [dbo].[LayThongTinGiaoDich]()
 returns table
 as
 return (
 select MaGiaoDich from THONGTINGIAODICH where MaGhe not in (select MaGhe from CHONGOI))

 go

create or ALTER proc [dbo].[TimChuyenBay]
@MaChuyenBay varchar(15)
as
begin
	select * from CHUYENBAY where MaChuyenBay=@MaChuyenBay
end
 go

create or alter function LayNguocThoiGianBayvaMaSanBay(@str1 varchar(15))
returns table 
as
      return (
	  select distinct CHUYENBAY.GioKhoiHanh,TUYENBAY_SANBAY.MaTuyenBay,TUYENBAY_SANBAY.MaSanBayKhoiHanh,TUYENBAY_SANBAY.MaSanBayDen
from THONGTINGIAODICH,TUYENBAY_SANBAY,CHUYENBAY
where THONGTINGIAODICH.MaChuyenBay = CHUYENBAY.MaChuyenBay and CHUYENBAY.MaTuyenBay = TUYENBAY_SANBAY.MaTuyenBay and CHUYENBAY.MaChuyenBay=@str1
	  )
go 
-------
create  or alter function [dbo].[LayNguocThoiGianKhoiHanh_1](@str1 varchar(15))
returns table
 as
  return (
     select  ViTri from SANBAY where MaSanBay = @str1
  )
go
------

create or alter trigger TriggerXoaThongTinGiaoDich on THONGTINGIAODICH
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaGiaoDich IN (SELECT MaGiaoDich FROM THONGTINGIAODICH))
		BEGIN
			DELETE FROM THONGTINGIAODICH WHERE MaGiaoDich IN (SELECT MaGiaoDich FROM deleted)
			print N'Xóa thông tin giao dịch thành công'
		END
	ELSE
		BEGIN
			PRINT N'MaGiaoDich không tồn tại!'
		END
end
go

create or alter proc XoaThongTinGiaoDich
@MaGiaoDich varchar(15)
as 
begin
	delete THONGTINGIAODICH where MaGiaoDich = @MaGiaoDich
end
go



create or alter proc SuaThongTinGiaoDich
@MaGiaoDich char(15), @NgayDat Date, @MaChuyenBay char(15), @MaGhe char(5), @CCCD char(12)
as
begin
		update THONGTINGIAODICH
		set
			NgayDat = @NgayDat,
			MaChuyenBay = @MaChuyenBay,
			MaGhe = @MaGhe,
			CCCD = @CCCD
		where MaGiaoDich = @MaGiaoDich
						
end
go

--HOADON--
create or alter trigger TriggerThemHoaDon on HOADON
instead of insert
as
begin
	if exists (select * from inserted where MaHoaDon in (select MaHoaDon from HOADON))
		begin
			print N'Tạo hóa đơn không thành công, MaHoaDon đã tồn tại trong hệ thống'
			rollback tran
		end
	else
		if exists (select * from inserted where CCCD in (select CCCD from KHACHHANG))
			if exists (select * from inserted where MaNV in (select MaNV from NHANVIEN))
				begin
				   insert into HOADON 
				   select *
				   from inserted
				   print N'Tạo hóa đơn thành công!'
				end
			else
				begin
					print N'Tạo hóa đơn không thành công, MaNV không tồn tại trong hệ thống'
					rollback tran
				end
		else
			begin
				print N'Tạo hóa đơn không thành công, CCCD của khách hàng không tồn tại trong hệ thống'
				rollback tran
			end
end
go

create  or alter view MaHoaDonCuoi as
SELECT TOP 1 *
FROM HOADON
ORDER BY MaHoaDon DESC
go
---
CREATE or alter FUNCTION GetNextMaHD()
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @LastMaHD VARCHAR(15);
    DECLARE @NextMaHD VARCHAR(15);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaHD = MaHoaDon
    FROM MaHoaDonCuoi;
    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaHD IS NULL
    BEGIN
        SET @NextMaHD = 'HD001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaHD, 3, 3) AS INT);
        SET @NextMaHD = 'HD' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaHD;
END;
go 
---

create or alter view XemVeChuyenBay 
as
select * from VECHUYENBAY where is_deleted = 0
go
create or alter trigger TriggerVeChuyenBay on VECHUYENBAY
instead of insert
as
begin
	if exists (select * from inserted where MaVe in (select MaVe from VECHUYENBAY))
		begin
			print N'Tạo vé chuyến bay không thành công, MaVe đã tồn tại'
			rollback tran
		end
	else
		begin
		 if exists (select * from inserted where MaHoaDon in (select MaHoaDon from HOADON))
			if exists (select * from inserted where MaHoaDon not in (select MaHoaDon from VECHUYENBAY))
				begin
					insert into VECHUYENBAY
					select *
					from inserted
					print N'Tạo hóa đơn thành công!'
					
				end
			else
			  
				begin
					print N'Tạo vé chuyến bay không thành công, MaHoaDon đã tồn tại trong hạng vé'
					rollback tran
				end
		else
		      begin
			        print N'Tạo vé chuyến bay không thành công, MaHoaDon không tồn tại'
					rollback tran
			  end
		end
end
go

create  or alter view MaVeCuoi as
SELECT TOP 1 *
FROM VECHUYENBAY
ORDER BY MaVe DESC
go
---
CREATE or alter FUNCTION GetNextMaVe2()
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @LastMaVe VARCHAR(15);
    DECLARE @NextMaVe VARCHAR(15);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaVe = MaVe
    FROM MaVeCuoi;
    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaVe IS NULL
    BEGIN
        SET @NextMaVe = 'VE001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaVe, 3, 3) AS INT);
        SET @NextMaVe = 'VE' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaVe;
END;
go
--

go
create or alter proc ThemHoaDon
 @MaGiaoDich varchar(15),@NgayLap date, @ThanhTien int, @CCCD varchar(12), @MaNV varchar(10),@is_deleted bit
as
begin
	if (@MagiaoDich= '' or @ThanhTien = 0 or @CCCD='' or @MaNV ='')
		begin
			print N'Thiếu thông tin nhập vào'
		end
	else
         declare @MaHoaDon varchar(15)
		 set @MaHoaDon = dbo.GetNextMaHD()
		 insert into HOADON values(@MaHoaDon,@MagiaoDich, @NgayLap, @ThanhTien,@is_deleted, @CCCD, @MaNV)
		IF @@ERROR <> 0
			BEGIN
				print N'Lỗi khi sửa chuyến bay'
				ROLLBACK;
			END
end
go

create or alter trigger TriggerSuaHoaDon on HOADON
instead of update
as
begin
	if exists (select * from inserted where MaHoaDon in (select MaHoaDon from HOADON))
		if exists (select * from inserted where CCCD in (select CCCD from KHACHHANG))
			if exists (select * from inserted where MaNV in (select MaNV from NHANVIEN))
				begin
				declare @MaHoaDon varchar(15)
				set @MaHoaDon =    (select MaHoaDon from inserted)
				 
				   update HOADON set
					ThanhTien = (select ThanhTien from inserted),
					NgayLap= (select NgayLap from inserted),
					CCCD = (select CCCD from inserted),
					MaNV= (select MaNV from inserted)								
					where MaHoaDon= @MaHoaDon
				   print N'Sửa hóa đơn thành công!'
				end
			else
				begin
					print N'Sửa hóa đơn không thành công, MaNV không tồn tại trong hệ thống'
					rollback tran
				end
		else
			begin
				print N'Sửa hóa đơn không thành công, CCCD của khách hàng không tồn tại trong hệ thống'
				rollback tran
			end
	else
		begin
			print N'Sửa hóa đơn không thành công, MaHoaDon không tồn tại'
			rollback tran
		end
end
go


create or alter proc SuaHoaDon
@MaHoaDon varchar(15), @NgayLap date, @ThanhTien int, @CCCD varchar(12), @MaNV varchar(10)
as
begin
	update HOADON set NgayLap= @NgayLap, ThanhTien = @ThanhTien, CCCD = @CCCD , MaNV= @MaNV where MaHoaDon=@MaHoaDon
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Chỉnh Sửa'
			rollback
			return
		end
end
go

create or alter trigger TriggerXoaHoaDon on HOADON
instead of delete
as
begin
	if not exists (select * from deleted where MaHoaDon in (select MaHoaDon from HOADON))
		begin 
			print N'Mã hóa đơn không tồn tại'
			rollback tran
		end	
	else
		begin
			delete from VECHUYENBAY where MaHoaDon in (SELECT MaHoaDon FROM deleted)
			DELETE FROM HOADON WHERE MaHoaDon IN (SELECT MaHoaDon FROM deleted)
			print N'Xóa hóa đơn thành công'
		end
end
go


create or alter proc XoaHoaDon
@MaHoaDon varchar(15)
as
begin tran
	delete from HOADON where MaHoaDon= @MaHoaDon
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi Xóa'
			rollback
			return
		end
commit tran
go

--VECHUYENBAY
CREATE or alter FUNCTION GetNextMaVe1()
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @LastMaVe VARCHAR(15);
    DECLARE @NextMaVe VARCHAR(15);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaVe = MaVe
    FROM MaVeCuoi;
    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaVe IS NULL
    BEGIN
        SET @NextMaVe = 'VE001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaVe, 3, 3) AS INT);
        SET @NextMaVe = 'VE' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaVe;
END;
go
create or alter trigger TriggerVeChuyenBay on VECHUYENBAY
instead of insert
as
begin
	if exists (select * from inserted where MaVe in (select MaVe from VECHUYENBAY))
		begin
			print N'Tạo vé chuyến bay không thành công, MaVe đã tồn tại'
			rollback tran
		end
	else
		begin
		 if exists (select * from inserted where MaHoaDon in (select MaHoaDon from HOADON))
			if exists (select * from inserted where MaHoaDon not in (select MaHoaDon from VECHUYENBAY))
				begin
					insert into VECHUYENBAY
					select *
					from inserted
					print N'Tạo hóa đơn thành công!'
					
				end
			else
			  
				begin
					print N'Tạo vé chuyến bay không thành công, MaHoaDon đã tồn tại trong hạng vé'
					rollback tran
				end
		else
		      begin
			        print N'Tạo vé chuyến bay không thành công, MaHoaDon không tồn tại'
					rollback tran
			  end
		end
end
go

go
create or alter proc ThemVeChuyenBay
 @NgayTaoVe date, @MaHoaDon varchar(15),@is_deleted bit
as
begin
    declare @MaVe varchar(15)
	set @MaVe = dbo.GetNextMaVe1()
	insert into VECHUYENBAY values(@MaVe, @NgayTaoVe, @MaHoaDon,@is_deleted)
	IF @@ERROR <> 0
		BEGIN
			print N'Lỗi khi thêm vé chuyến bay'
			ROLLBACK;
		END
end
go

go
create or alter proc XoaVeChuyenBay
@MaVe varchar(15)
as
begin tran
	delete from VECHUYENBAY where MaVe = @MaVe
	if(@@ERROR <> 0)
		begin
			print N'Lỗi khi xóa vé chuyến bay'
			rollback
			return
		end
commit tran
go

create or alter function TimKiemVCB(@str nvarchar(50))
returns table
as
	return (
	select MaVe, NgayTaoVe, MaHoaDon from VECHUYENBAY
	where MaVe like CONCAT('%',@str,'%') or MaHoaDon like CONCAT('%',@str,'%'))
go

--THONGKEDOANHTHU--
--thống kê doanh thu từ ngày ? đến ngày ?
CREATE or alter PROC THONGKE
@d1 date, @d2 date
as
begin
	select NgayLap,sum(ThanhTien) AS TongTien from HOADON where NgayLap>=@d1 and NgayLap<=@d2 group by NgayLap
end
go

GO
CREATE OR ALTER   FUNCTION [dbo].[TimKiemKhungGioBay](@ngaybay date, @matuyenbay varchar(20))
RETURNS TABLE
AS
RETURN (
    SELECT DISTINCT GioKhoiHanh,CONVERT(date, NgayBay) AS NgayBay, MaChuyenBay
    FROM CHUYENBAY
    INNER JOIN TUYENBAY ON CHUYENBAY.MaTuyenBay = TUYENBAY.MaTuyenBay
    WHERE CHUYENBAY.MaTuyenBay LIKE CONCAT('%', @matuyenbay, '%') AND @ngaybay <  CONVERT(date, NgayBay)
);

/*CREATE OR ALTER TRIGGER TriggerHuyVeChuyenBay ON VECHUYENBAY
INSTEAD OF DELETE
AS
BEGIN
    SELECT v.MaVe, v.NgayTaoVe, v.MaHoaDon, t.MaChuyenBay
    INTO #Vechuyenbay
    FROM deleted v
    JOIN HOADON h ON v.MaHoaDon = h.MaHoaDon
    JOIN KHACHHANG k ON h.CCCD = k.CCCD
    JOIN THONGTINGIAODICH t ON k.CCCD = t.CCCD

    DECLARE @NgayBay date
    SELECT @NgayBay = c.NgayBay
    FROM CHUYENBAY c
    WHERE c.MaChuyenBay = (SELECT MaChuyenBay FROM #Vechuyenbay)

    DECLARE @Now date = GETDATE()

    DECLARE @DaysBeforeFlight int
    SET @DaysBeforeFlight = DATEDIFF(day, @Now, @NgayBay)

    IF @DaysBeforeFlight >= 2
    BEGIN
        DELETE FROM VECHUYENBAY WHERE MaVe IN (SELECT MaVe FROM #Vechuyenbay)
        PRINT N'Đã hoàn trả toàn bộ tiền cho vé hủy trước 2 ngày hoặc hơn.'
    END
    ELSE IF @DaysBeforeFlight = 1
    BEGIN
        UPDATE HOADON
        SET ThanhTien = ThanhTien * 0.5
        WHERE MaHoaDon IN (SELECT MaHoaDon FROM #Vechuyenbay)

        DELETE FROM VECHUYENBAY WHERE MaVe IN (SELECT MaVe FROM #Vechuyenbay)
        PRINT N'Đã hoàn trả 50% tiền cho vé hủy trước 1 ngày.'
    END
    ELSE
    BEGIN
       
        PRINT N'Không được phép hủy vé, quá thời hạn.'
    END
END
go

CREATE OR ALTER TRIGGER TriggerQuyDoiVeChuyenBay ON VECHUYENBAY
INSTEAD OF UPDATE
AS
BEGIN
   
    DECLARE @Now date = GETDATE()

    SELECT d.MaVe, d.NgayTaoVe, u.GiaGhe AS GiaMoi, t.MaChuyenBay, h.ThanhTien AS ThanhTienHoaDon
    INTO #VeQuyDoi
    FROM deleted d
    JOIN inserted i ON d.MaVe = i.MaVe
    JOIN CHONGOI u ON d.MaGhe = u.MaGhe
    JOIN THONGTINGIAODICH t ON d.MaHoaDon = t.MaHoaDon
    JOIN CHUYENBAY c ON t.MaChuyenBay = c.MaChuyenBay
    JOIN HOADON h ON d.MaHoaDon = h.MaHoaDon

    DECLARE @NgayBay date
    SELECT @NgayBay = c.NgayBay
    FROM CHUYENBAY c
    WHERE c.MaChuyenBay = (SELECT MaChuyenBay FROM #VeQuyDoi)

    DECLARE @DaysBeforeFlight int
    SET @DaysBeforeFlight = DATEDIFF(day, @Now, @NgayBay)

    IF @DaysBeforeFlight > 1 AND (i.GiaMoi < d.GiaMoi)
    BEGIN
        
        UPDATE HOADON
        SET ThanhTien = ThanhTien - d.GiaGhe
        WHERE MaHoaDon IN (SELECT MaHoaDon FROM #VeQuyDoi)

        UPDATE VECHUYENBAY
        SET MaVe = d.MaVe
        WHERE MaHoaDon IN (SELECT MaHoaDon FROM #VeQuyDoi)

        DELETE FROM VECHUYENBAY WHERE MaHoaDon IN (SELECT MaHoaDon FROM #VeQuyDoi)

        PRINT N'Đã hoàn tiền cho vé quy đổi trước ngày bay.'
    END
    ELSE IF @DaysBeforeFlight = 1 AND (i.GiaMoi < d.GiaMoi)
    BEGIN        
        UPDATE HOADON
        SET ThanhTien = ThanhTien - d.GiaGhe
        WHERE MaHoaDon IN (SELECT MaHoaDon FROM #VeQuyDoi)

        UPDATE VECHUYENBAY
        SET MaVe = d.MaVe
        WHERE MaHoaDon IN (SELECT MaHoaDon FROM #VeQuyDoi)

        DELETE FROM VECHUYENBAY WHERE MaHoaDon IN (SELECT MaHoaDon FROM #VeQuyDoi)

        PRINT N'Đã hoàn tiền cho vé quy đổi trước ngày bay.'
    END
    ELSE IF (i.GiaMoi > d.GiaMoi)
    BEGIN       
        PRINT N'Vui lòng bổ sung tiền cho vé quy đổi.'
    END
    ELSE
    BEGIN
        PRINT N'Không được phép quy đổi vé, quá thời hạn.'
    END
END*/
-----------
go
 create or ALTER function [dbo].[LayPhieuDatCho]()
 returns table
 as
 return (
 select * from THONGTINGIAODICH where MaGiaoDich not in (select MaGiaoDich from HOADON))
 go
 ----------
 go
create or alter function TimKiemTTGD(@str nvarchar(50))
returns table
as
	return (
	select MaGiaoDich, NgayDat, MaChuyenBay, MaGhe, CCCD from THONGTINGIAODICH
	where MaGiaoDich like CONCAT('%',@str,'%') or NgayDat like CONCAT('%',@str,'%') or MaChuyenBay like CONCAT('%',@str,'%') or MaGhe like CONCAT('%',@str,'%') or CCCD like CONCAT('%',@str,'%'))
go

create or alter trigger TriggerThongTinGiaoDich on THONGTINGIAODICH
instead of insert
as
begin
	if exists (select * from inserted where MaGiaoDich in (select MaGiaoDich from THONGTINGIAODICH))
		begin
			print N'Thêm giao dịch không thành công, MaGiaoDich đã tồn tại!'
			rollback tran 
		end
	else
		begin
		   insert into THONGTINGIAODICH
		   select MaGiaoDich, NgayDat, MaChuyenBay, MaGhe, CCCD,is_deleted
		   from inserted
		   print N'Thêm giao dịch thành công!'
		end
end
go

go


go
create or alter proc ThemGiaoDich
 @NgayDat Date, @MaChuyenBay char(15), @MaGhe char(5), @CCCD char(12),@is_deleted bit
as
begin
                declare @MaGiaoDich varchar(15), @NgayKhoiHanh DateTime
	            set @MaGiaoDich = dbo.GetNextMaGD()
				set @NgayKhoiHanh = (select NgayBay from CHUYENBAY where MaChuyenBay=@MaChuyenBay)

	if exists (select * from THONGTINGIAODICH where MaGiaoDich = @MaGiaoDich)
		begin
			print N'Thêm giao dịch không thành công, MaGiaoDich đã tồn tại'
		end
	if @NgayDat > @NgayKhoiHanh
	    begin
		    print N'Thêm giao dịch không thành công, Đã vượt quá thời gian ngày bay'
	    end
	else
		begin
			if exists (select * from CHUYENBAY where MaChuyenBay = @MaChuyenBay)
				begin 
					if exists (select * from KHACHHANG where CCCD = @CCCD)
						begin
							if exists (select * from CHONGOI where MaGhe = @MaGhe )
								begin
									print N'Thêm giao dịch thành công'
									UPDATE CHONGOI	set TinhTrang = 1 where MaGhe=@MaGhe
									
									insert into THONGTINGIAODICH values(@MaGiaoDich, @NgayDat, @MaChuyenBay, @MaGhe, @CCCD,@is_deleted)
								end
							else 
							 begin
							     print N'Thêm giao dịch không thành công, MaGhe không tồn tại' 
							end
							
						end
					else print N'Thêm giao dịch không thành công, MaKhachHang không tồn tại'
				end
			else print N'Thêm giao dịch không thành công, MaChuyenBay không tồn tại'
		end
end
go

--------------Them
 create or ALTER function [dbo].[LayThongTinGiaoDich]()
 returns table
 as
 return (
 select MaGiaoDich from THONGTINGIAODICH where MaGhe not in (select MaGhe from CHONGOI))

 go


create or alter trigger TriggerXoaThongTinGiaoDich on THONGTINGIAODICH
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaGiaoDich IN (SELECT MaGiaoDich FROM THONGTINGIAODICH))
		BEGIN
		    declare @MaGiaoDich varchar(15),@MaGhe char(10)
			set @MaGiaoDich = (select MaGiaoDich from deleted)
			set @MaGhe = (select MaGhe from deleted)
			update CHONGOI set TinhTrang = 0 where MaGhe=@MaGhe
			DELETE FROM THONGTINGIAODICH WHERE MaGiaoDich=@MaGiaoDich
			print N'Xóa thông tin giao dịch thành công'
		END
	ELSE
		BEGIN
			PRINT N'MaGiaoDich không tồn tại!'
		END
end
go

create or alter proc XoaThongTinGiaoDich
@MaGiaoDich varchar(15)
as 
begin
	delete THONGTINGIAODICH where MaGiaoDich = @MaGiaoDich
end
go


create or alter trigger TriggerSuaThongTinGiaoDich on THONGTINGIAODICH
instead of update
as
begin
	DECLARE @MaGiaoDich char(15), @NgayDat Date, @MaChuyenBay char(15), @MaGhe char(5), @CCCD char(12),@is_deleted bit
	IF EXISTS (SELECT * FROM inserted WHERE MaGiaoDich IN (SELECT MaGiaoDich FROM THONGTINGIAODICH))
		IF EXISTS (SELECT * FROM inserted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
			IF EXISTS (SELECT * FROM inserted WHERE CCCD IN (SELECT CCCD FROM KHACHHANG))
			      IF EXISTS (select * from inserted where MaGhe in (select MaGhe from CHONGOI))
				BEGIN 
				    declare @MaGheOld char(5)
					set @NgayDat = (select NgayDat from inserted)
					set @MaChuyenBay = (select MaChuyenBay from inserted)
					set @MaGhe = (select MaGhe from inserted)
					set @CCCD = (select CCCD from inserted)
					set @MaGheOld = (select MaGhe from THONGTINGIAODICH where MaGiaoDich = @MaGiaoDich)
					set @MaGiaoDich = (select MaGiaoDich from inserted)
					set @is_deleted = (select is_deleted from inserted)
					update THONGTINGIAODICH 
						set NgayDat=@NgayDat, MaChuyenBay=@MaChuyenBay, MaGhe=@MaGhe, CCCD=@CCCD, is_deleted = @is_deleted
						where MaGiaoDich=@MaGiaoDich
					UPDATE CHONGOI
               SET TinhTrang = CASE
                   WHEN MaGhe = @MaGhe THEN 1
                   WHEN MaGhe = @MaGheOld THEN 0
				   WHEN @is_deleted = 1 THEN 0
                   ELSE TinhTrang
               END
                 WHERE MaGhe IN (SELECT MaGhe FROM THONGTINGIAODICH WHERE MaGhe = @MaGhe AND MaGiaoDich = @MaGiaoDich AND MaChuyenBay = @MaChuyenBay);
					  
				END
				ELSE 
				 BEGIN
				          PRINT N'Sửa chuyến bay không thành công, Mã ghế không tồn tại'
					      ROLLBACK TRANSACTION 
				 END
			ELSE
				BEGIN
					PRINT N'Sửa chuyến bay không thành công, CCCD không tồn tại'
					ROLLBACK TRANSACTION 
				END
		ELSE
			BEGIN
				PRINT N'Sửa chuyến bay không thành công, MaChuyenBay không tồn tại'
				ROLLBACK TRANSACTION
			END
	ELSE
		BEGIN
			PRINT N'Sửa chuyến bay không thành công, MaGiaoDich không tồn tại!'
			ROLLBACK TRANSACTION 
		END
end
go
------------SuaThongTinGiaoDich2


create or alter proc SuaThongTinGiaoDich
@MaGiaoDich char(15), @NgayDat Date, @MaChuyenBay char(15), @MaGhe char(5), @CCCD char(12),@is_deleted bit
as
begin
		update THONGTINGIAODICH
		set
			NgayDat = @NgayDat,
			MaChuyenBay = @MaChuyenBay,
			MaGhe = @MaGhe,
			CCCD = @CCCD,
			is_deleted = @is_deleted
		where MaGiaoDich = @MaGiaoDich
						
end
go
-------------
create  or alter view MaGiaoDichCuoi as
SELECT TOP 1 *
FROM THONGTINGIAODICH
ORDER BY MaGiaoDich DESC

go
CREATE or alter FUNCTION dbo.GetMaGiaoDichCuoi()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 1 *
    FROM THONGTINGIAODICH
    ORDER BY MaGiaoDich DESC
)

go
CREATE or alter PROCEDURE dbo.GetMaGiaoDichCuoi1
AS
BEGIN
    SELECT TOP 1 *
    FROM THONGTINGIAODICH
    ORDER BY MaGiaoDich DESC
END

go

go
CREATE or alter FUNCTION GetNextMaGD()
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @LastMaGD VARCHAR(15);
    DECLARE @NextMaGD VARCHAR(15);

    -- Lấy mã chuyến bay cuối cùng từ view MaChuyenBayCuoi
    SELECT @LastMaGD = MaGiaoDich
    FROM MaGiaoDichCuoi;
    -- Nếu không tìm thấy giá trị cũ, bắt đầu từ CB001
    IF @LastMaGD IS NULL
    BEGIN
        SET @NextMaGD = 'GD001';
    END
    ELSE
    BEGIN
        -- Tạo mã chuyến bay tiếp theo
        DECLARE @LastCounter INT;
        SET @LastCounter = CAST(SUBSTRING(@LastMaGD, 3, 3) AS INT);
        SET @NextMaGD = 'GD' + RIGHT('00' + CAST(@LastCounter + 1 AS VARCHAR(3)), 3);
    END

    RETURN @NextMaGD;
END;
go
---FIX

go
create or ALTER   TRIGGER [dbo].[TriggerSuaChoNgoi] ON [dbo].[CHONGOI]
INSTEAD OF UPDATE
AS
BEGIN    
	DECLARE  @MaGhe varchar(5), @TinhTrang bit, @LoaiGhe nvarchar(20), @GiaGhe int , @MaMayBay varchar(15)
    IF NOT EXISTS (SELECT * FROM CHONGOI WHERE MaGhe IN (SELECT MaGhe FROM inserted))
      BEGIN
        PRINT N'Mã Chỗ Ngồi Không Tồn Tại!'
        ROLLBACK TRANSACTION
      END
    ELSE
      BEGIN       
        IF NOT EXISTS (SELECT * FROM MAYBAY WHERE MaMayBay IN (SELECT MaMayBay FROM inserted ))
           BEGIN
            PRINT N'Mã Máy Bay Không Tồn Tại!'
            ROLLBACK TRANSACTION
          END
        ELSE
           BEGIN
			set @MaGhe = (select MaGhe from inserted)
			set @TinhTrang = (select TinhTrang from inserted)
			set @LoaiGhe = (select LoaiGhe from inserted)
			set @GiaGhe = (select GiaGhe from inserted)
			set @MaMayBay = (select MaMayBay from inserted)
			update CHONGOI set TinhTrang=@TinhTrang, LoaiGhe=@LoaiGhe, GiaGhe=@GiaGhe, MaMayBay=@MaMayBay WHERE MaGhe=@MaGhe
           END
	END
END
    




----------------

go
CREATE or alter  PROCEDURE dbo.GetMaGiaoDichCuoi1
AS
BEGIN
    SELECT TOP 1 *
    FROM THONGTINGIAODICH
    ORDER BY MaGiaoDich DESC
END


go
go
create or ALTER  function [dbo].[LayNguocGioBayvaMaSanBay](@str1 varchar(15))
returns table 
as
      return (
	  select distinct CHUYENBAY.GioKhoiHanh,TUYENBAY_SANBAY.MaTuyenBay,TUYENBAY_SANBAY.MaSanBayKhoiHanh,TUYENBAY_SANBAY.MaSanBayDen,CHUYENBAY.MaMayBay,CHUYENBAY.NgayBay,CHUYENBAY.MaChuyenBay
from THONGTINGIAODICH,TUYENBAY_SANBAY,CHUYENBAY
where THONGTINGIAODICH.MaChuyenBay = CHUYENBAY.MaChuyenBay and CHUYENBAY.MaTuyenBay = TUYENBAY_SANBAY.MaTuyenBay and CHUYENBAY.MaChuyenBay=@str1
	  )
	  ------------
go
	  create or ALTER  function [dbo].[LayChoNgoi](@str1 varchar(15))
returns table 
as
      return (
	   select * from CHONGOI 
	   where MaGhe= @str1
	  )
	-------------------------
	go
CREATE OR ALTER PROCEDURE UpdateChoNgoiTinhTrang
AS
BEGIN
    BEGIN TRANSACTION; -- Begin a transaction to ensure atomicity

    -- Update ChoNgoi table
    UPDATE ChoNgoi
    SET TinhTrang = 0,
        machuyenbay = NULL
    FROM ChoNgoi
    INNER JOIN ChuyenBay ON ChoNgoi.MaMayBay = ChuyenBay.MaMayBay
    WHERE
        CONVERT(datetime, CONVERT(varchar, ChuyenBay.NgayBay, 101) + ' ' + CONVERT(varchar, ChuyenBay.GioKhoiHanh, 108)) < GETDATE()
        AND ChuyenBay.MaChuyenBay = ChoNgoi.machuyenbay;

    -- Update VECHUYENBAY table
    UPDATE VECHUYENBAY
    SET is_deleted = 1
    FROM VECHUYENBAY
    INNER JOIN HOADON ON VECHUYENBAY.MaHoaDon = HOADON.MaHoaDon
    INNER JOIN THONGTINGIAODICH ON HOADON.MaGiaoDich = THONGTINGIAODICH.MaGiaoDich
    INNER JOIN CHONGOI ON THONGTINGIAODICH.MaGhe = CHONGOI.MaGhe
    INNER JOIN CHUYENBAY ON THONGTINGIAODICH.MaChuyenBay = CHUYENBAY.MaChuyenBay
    WHERE
        CONVERT(datetime, CONVERT(varchar, CHUYENBAY.NgayBay, 101) + ' ' + CONVERT(varchar, CHUYENBAY.GioKhoiHanh, 108)) < GETDATE()
        AND CHUYENBAY.MaChuyenBay = CHONGOI.MaChuyenBay
        AND CHONGOI.MaGhe = THONGTINGIAODICH.MaGhe
        AND HOADON.is_deleted = 0; -- Add conditions based on the logic of your system
        
    COMMIT TRANSACTION; -- Commit the transaction if both updates succeed
END;

------------------------
select * from CHONGOI
exec UpdateChoNgoiTinhTrang

--------------------
go
 create or ALTER   TRIGGER [dbo].[TriggerSuaChoNgoi] ON [dbo].[CHONGOI]
INSTEAD OF UPDATE
AS
BEGIN    
	DECLARE  @MaGhe varchar(5), @TinhTrang bit, @LoaiGhe nvarchar(20), @GiaGhe int , @MaMayBay varchar(15),@machuyenBay varchar(15)
    IF NOT EXISTS (SELECT * FROM CHONGOI WHERE MaGhe IN (SELECT MaGhe FROM inserted))
    BEGIN
        PRINT N'Mã Chỗ Ngồi Không Tồn Tại!'
        ROLLBACK TRANSACTION
    END
    ELSE
    BEGIN       
        IF NOT EXISTS (SELECT * FROM MAYBAY WHERE MaMayBay IN (SELECT MaMayBay FROM inserted ))
        BEGIN
            PRINT N'Mã Máy Bay Không Tồn Tại!'
            ROLLBACK TRANSACTION
        END
        ELSE
        BEGIN
			UPDATE CHONGOI
           SET TinhTrang = i.TinhTrang,
           LoaiGhe = i.LoaiGhe,
           GiaGhe = i.GiaGhe,
           MaMayBay = i.MaMayBay,
		   machuyenbay = i.machuyenbay
        FROM CHONGOI c
        INNER JOIN inserted i ON c.MaGhe = i.MaGhe

        END
    END
END
go
---------------------
go
Create or ALTER function [dbo].[LayNguocGioKhoiHanh_1](@str1 varchar(15))
returns table
 as
  return (
     select  ViTri from SANBAY where MaSanBay = @str1
  )
----------------------28-10
go
create or ALTER   function [dbo].[TimKiemTTGD](@str nvarchar(50))
returns table
as
	return (
	select * from THONGTINGIAODICH
	where MaGiaoDich like CONCAT('%',@str,'%') or MaChuyenBay like CONCAT('%',@str,'%') or MaGhe like CONCAT('%',@str,'%') or CCCD like CONCAT('%',@str,'%'))
	go
-----------------
GO
create or ALTER   function [dbo].[TimKiemTTHD](@str nvarchar(50))
returns table
as
	return (
	select * from HOADON
	where MaHoaDon like CONCAT('%',@str,'%') or CCCD like CONCAT('%',@str,'%') or MaNV like CONCAT('%',@str,'%') or MaGiaoDich like CONCAT('%',@str,'%') )
GO
-------------------------------------

CREATE OR ALTER FUNCTION GetThongTinVeByMaVe(@MaVe varchar(15))
RETURNS TABLE
AS
RETURN (
    SELECT v.MaVe, v.is_deleted, h.MaHoaDon, h.MaGiaoDich, t.MaGhe, cb.NgayBay,cb.MaChuyenBay,kh.CCCD,kh.SDT,kh.HoTen,c.GiaGhe,v.NgayTaoVe
    FROM VECHUYENBAY v
    JOIN HOADON h ON v.MaHoaDon = h.MaHoaDon
    JOIN THONGTINGIAODICH t ON h.MaGiaoDich = t.MaGiaoDich
    JOIN CHONGOI c ON t.MaGhe = c.MaGhe
    JOIN CHUYENBAY cb ON cb.MaChuyenBay = t.MaChuyenBay
    JOIN KHACHHANG kh ON h.CCCD = kh.CCCD
    WHERE v.MaVe = @MaVe
);
go
-----------------------
CREATE OR ALTER PROCEDURE HuyVe
    @MaVe varchar(15)
AS
BEGIN
    DECLARE @MaHoaDon varchar(15), @MaGiaoDich varchar(15), @MaGhe varchar(5), @NgayBay date

    -- Lấy thông tin vé từ hàm và lưu vào các biến
    SELECT @MaVe = MaVe, @MaHoaDon = MaHoaDon, @MaGiaoDich = MaGiaoDich, @MaGhe = MaGhe, @NgayBay = NgayBay
    FROM GetThongTinVeByMaVe(@MaVe)

    DECLARE @Now date = GETDATE()
    DECLARE @DaysBeforeFlight int
    SET @DaysBeforeFlight = DATEDIFF(day, @Now, @NgayBay)

    DECLARE @ThanhTien1 DECIMAL(10, 2)

    IF NOT EXISTS (SELECT MaHoaDon FROM HOADON WHERE MaHoaDon = @MaHoaDon)	  
        BEGIN
            SET @ThanhTien1 = 0;
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Hóa đơn không tồn tại' AS 'ThongBao';
            RETURN;
        END
    ELSE IF NOT EXISTS (SELECT MaGiaoDich FROM THONGTINGIAODICH WHERE MaGiaoDich = @MaGiaoDich)
        BEGIN
            SET @ThanhTien1 = 0;
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Mã thông tin giao dịch không tồn tài' AS 'ThongBao';
            RETURN;
        END
    ELSE IF NOT EXISTS (SELECT MaGhe FROM CHONGOI WHERE MaGhe = @MaGhe AND TinhTrang = 1)
        BEGIN
            SET @ThanhTien1 = 0;
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Không tồn tại mã ghế' AS 'ThongBao';
            RETURN;
        END
    ELSE
    BEGIN
        IF @DaysBeforeFlight >= 2
        BEGIN
            -- Hủy vé trước 2 ngày hoặc hơn
            UPDATE VECHUYENBAY SET is_deleted = 1 WHERE MaVe = @MaVe
            SET @ThanhTien1 = (SELECT ThanhTien FROM HOADON WHERE MaHoaDon = @MaHoaDon);
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Đã hoàn trả toàn bộ tiền cho vé hủy trước 2 ngày hoặc hơn.' AS 'ThongBao';
            RETURN;
        END
        ELSE IF @DaysBeforeFlight = 1
        BEGIN
            -- Hủy vé trước 1 ngày
            UPDATE HOADON
            SET ThanhTien = ThanhTien * 0.5
            WHERE MaHoaDon = @MaHoaDon;

            UPDATE VECHUYENBAY SET is_deleted = 1 WHERE MaVe = @MaVe
            SET @ThanhTien1 = (SELECT ThanhTien FROM HOADON WHERE MaHoaDon = @MaHoaDon)
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Đã hoàn trả 50% tiền cho vé hủy trước 1 ngày.' AS 'ThongBao';
            RETURN;
        END
        ELSE
        BEGIN
            -- Quá thời hạn hủy vé
            UPDATE VECHUYENBAY SET is_deleted = 1 WHERE MaVe = @MaVe
            SET @ThanhTien1 = 0;
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Không được phép hủy vé, quá thời hạn.' AS 'ThongBao';
            RETURN;
        END
    END
END

---------------
go
create or alter function Dang_Nhap(@Username varchar(30), @Password varchar(30))
returns table 
as 
	return (select * from PHANQUYEN where TaiKhoan = @Username and MatKhau = @Password)
go

create or alter procedure SHOWINFORMATION
@taiKhoan varchar(30)
as
	begin
		select PHANQUYEN.TaiKhoan, PHANQUYEN.MatKhau, PHANQUYEN.UyQuyen, NHANVIEN.TenNV 
		FROM NHANVIEN FULL OUTER JOIN PHANQUYEN 
		ON NHANVIEN.MaNV = PHANQUYEN.MaNV WHERE PHANQUYEN.TaiKhoan = @taiKhoan 
	end
go

create or alter procedure DOIMATKHAU
@taiKhoan varchar(30),@matKhau varchar(30),@matKhauMoi varchar(30),@matKhauMoiNL varchar(30)
as
begin
	if(@taiKhoan = '' or @matKhau='' or @matKhauMoi='' or @matKhauMoiNL='')
	begin
		print N'Vui lòng nhập đủ thông tin!'
	end
	else
	begin
	if exists(select *from PHANQUYEN where TaiKhoan = @taiKhoan and MatKhau = @matKhau)
		begin
			if(@matKhauMoi=@matKhauMoiNL)
				begin
					update PHANQUYEN set MatKhau = @matKhauMoi where TaiKhoan = @taiKhoan
					print N'Đổi mật khẩu thành công'
				end
			else 
				begin
					print N'Mật khẩu nhập lại không đúng'
				end
		end
	else
		begin
			print N'Tên đăng nhập hoặc tài khoản không đúng'
		end
	end
end
go
---------------------------DoiVe
---------------
---- Đổi vé-------
----TH1 Đổi vé : Cùng chuyến bay- đổi số ghế (MCB,TB,MG update)--> check giá tiền phải trả lại hoặc bù thêm 
----TH2 Đổi vé: Cùng chuyến bay -khác ghế(MCB,TB,MGnew,GG

go
CREATE OR ALTER PROCEDURE DoiVe
    @MaVe varchar(15),
    @MaChuyenBaynew Varchar(15),
    @MaTuyenBaynew varchar(15),
    @MaGhenew varchar(5),
    @GiaGhenew int
AS
BEGIN
    DECLARE @MaHoaDon varchar(15), @MaGiaoDich varchar(15), @MaGhe varchar(5), @MaChuyenBay varchar(15), @MaTuyenBay varchar(15), @GiaGhe int
    SELECT @MaVe = MaVe, @MaHoaDon = MaHoaDon, @MaGiaoDich = MaGiaoDich, @MaGhe = MaGhe,@MaChuyenBay = MaChuyenBay,@MaTuyenBay = MaTuyenBay,@GiaGhe = GiaGhe
    FROM GetThongTinVeByMaVe(@MaVe)

    DECLARE @ThanhTien1 DECIMAL(10, 2)

    IF NOT EXISTS (SELECT MaHoaDon FROM HOADON WHERE MaHoaDon = @MaHoaDon)	  
        BEGIN
            SELECT N'Hóa đơn không tồn tại' AS 'ThongBao';
            RETURN;
        END
    ELSE IF NOT EXISTS (SELECT MaGiaoDich FROM THONGTINGIAODICH WHERE MaGiaoDich = @MaGiaoDich)
        BEGIN
            SELECT N'Mã thông tin giao dịch không tồn tài' AS 'ThongBao';
            RETURN;
        END
    ELSE IF NOT EXISTS (SELECT MaGhe FROM CHONGOI WHERE MaGhe = @MaGhe AND TinhTrang = 1)
        BEGIN
            SELECT  N'Không tồn tại mã ghế' AS 'ThongBao';
            RETURN;
        END
    ELSE IF NOT EXISTS (SELECT MaGhe FROM CHONGOI WHERE MaGhe = @MaGhenew AND TinhTrang = 0)
        BEGIN
            SELECT  N'Không tồn tại mã ghế' AS 'ThongBao';
            RETURN;
        END

	 ELSE IF NOT EXISTS (SELECT MaChuyenBay from CHUYENBAY WHERE MaChuyenBay = @MaChuyenBaynew)
        BEGIN
            SELECT  N'Không tồn tại chuyến bay' AS 'ThongBao';
            RETURN;
        END
	ELSE IF NOT EXISTS (SELECT MaTuyenBay from TUYENBAY WHERE MaTuyenBay = @MaTuyenBay)
        BEGIN
            SELECT  N'Không tồn tại tuyến bay' AS 'ThongBao';
            RETURN;
        END

	ELSE IF NOT EXISTS (SELECT MaVe from VECHUYENBAY WHERE MaVe = @MaVe and is_deleted = 0)
        BEGIN
            SELECT  N'Vé không còn hoạt động' AS 'ThongBao';
            RETURN;
        END
    ELSE

    BEGIN
        IF @MaChuyenBay=@MaChuyenBaynew 
		  IF @MaTuyenBay = @MaTuyenBaynew 
		    IF @MaGhenew != @MaGhe
               BEGIN

			UPDATE CHONGOI set TinhTrang = 1 where MaGhe = @MaGhenew
			UPDATE CHONGOI set TinhTrang = 0 where MaGhe = @MaGhe
			-------------
			UPDATE THONGTINGIAODICH set MaGhe = @MaGhenew where MaGiaoDich =@MaGiaoDich
			UPDATE HOADON set ThanhTien = @GiaGhenew where MaHoaDon = @MaHoaDon

            SET @ThanhTien1 = (SELECT ThanhTien FROM HOADON WHERE MaHoaDon = @MaHoaDon)- @GiaGhe;
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Đã hoàn trả toàn bộ tiền cho vé hủy trước 2 ngày hoặc hơn.' AS 'ThongBao', @MaGhenew as 'SoGhe',@MaChuyenBay as 'MachuyenBay';
            RETURN;
                END

              ELSE
			          BEGIN
					     SELECT  N'Không được đổi vé cùng ghế cùng chuyến bay' AS 'ThongBao';
                         RETURN;
					  END
		  ELSE
		         BEGIN 
				         SELECT  N'Mã tuyến bay không dúng nhau' AS 'ThongBao';
                         RETURN;
				 END
        ELSE
		  
			           BEGIN
					        UPDATE CHONGOI set TinhTrang = 1 where MaGhe = @MaGhenew
			                UPDATE CHONGOI set TinhTrang = 0 where MaGhe = @MaGhe
			-------------
			               UPDATE THONGTINGIAODICH set MaChuyenBay = @MaChuyenBaynew,MaGhe = @MaGhenew where MaGiaoDich =@MaGiaoDich
			               UPDATE HOADON set ThanhTien = @GiaGhenew where MaHoaDon = @MaHoaDon

                           SET @ThanhTien1 = (SELECT ThanhTien FROM HOADON WHERE MaHoaDon = @MaHoaDon) - @GiaGhe;
            SELECT @ThanhTien1 AS 'GiaTriThanhTien', N'Đã hoàn trả toàn bộ tiền cho vé hủy trước 2 ngày hoặc hơn.' AS 'ThongBao', @MaGhenew as 'SoGhe',@MaChuyenBay as 'MachuyenBay';
            RETURN;
					   END
		
		    
        
        
    END
END
---------------Test-------------------------------------------------------------------
EXEC DoiVe @MaVe = 'VE016', @MaChuyenBaynew = 'CB013', @MaTuyenBaynew = 'TB5', @MaGhenew = '6A001', @GiaGhenew = 8000000;
EXEC DoiVe @MaVe = 'VE017', @MaChuyenBaynew = 'CB013', @MaTuyenBaynew = 'TB5', @MaGhenew = '6A001', @GiaGhenew = 8000000;




