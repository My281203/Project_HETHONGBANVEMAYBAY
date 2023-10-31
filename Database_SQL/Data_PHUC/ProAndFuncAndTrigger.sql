use QUANLYCHUYENBAY3
go

--------------------SAN BAY--------------------
create view XemSanBay as
select * from SANBAY
go

select * from XemSanBay
go

create trigger TriggerThemSanBay on SANBAY
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

create proc ThemSanBay
@MaSanBay varchar(20), @TenSanBay nvarchar(45), @ViTri nvarchar(50)
as
begin
	insert into SANBAY values(@MaSanBay, @TenSanBay, @ViTri)
end
go

create trigger TriggerXoaSanBay on SANBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT MaSanBay FROM SANBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT SANBAYDI_MaSanBay FROM TUYENBAY))
		BEGIN
			PRINT N'Khong The Xoa San Bay!'
			ROLLBACK TRANSACTION 
		END	
		ELSE
		BEGIN
			IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT SANBAYDEN_MaSanBay FROM TUYENBAY))
			BEGIN
				PRINT N'Khong The Xoa San Bay!'
				ROLLBACK TRANSACTION 
			END
			ELSE
			BEGIN
				IF EXISTS (SELECT * FROM deleted WHERE MaSanBay IN (SELECT SANBAYTRUNGGIAN_MaSanBay FROM TUYENBAY))
				BEGIN
					PRINT N'Khong The Xoa San Bay!'
					ROLLBACK TRANSACTION 				
				END
				ELSE
				BEGIN
					DELETE FROM SANBAY WHERE MaSanBay IN (SELECT MaSanBay FROM deleted)
				END
			END
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma San Bay Khong Ton Tai!'
	END
end
go

create proc XoaSanBay
@MaSanBay varchar(20)
as
begin
	delete from SANBAY where MaSanBay = @MaSanBay
end
go

create trigger TriggerSuaSanBay on SANBAY
instead of update
as
begin
	DECLARE @MaSanBay varchar(20), @TenSanBay nvarchar(45), @ViTri nvarchar(50)
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

create proc SuaSanBay
@MaSanBay varchar(20), @TenSanBay nvarchar(45), @ViTri nvarchar(50)
as
begin
	update SANBAY set TenSanBay=@TenSanBay, ViTri=@ViTri where MaSanBay=@MaSanBay
end
go

create proc TimSanBay
@MaSanBay varchar(20)
as
begin
	select * from SANBAY where MaSanBay=@MaSanBay
end
go

--------------------TUYEN BAY--------------------
create view XemTuyenBay as
select * from TUYENBAY
go

select * from XemTuyenBay
go

create function TaoMaTuyenBay(@MaSanBayDi varchar(3), @MaSanBayDen varchar(3))
returns varchar(7)
as
begin
	declare @MaTB varchar(7)
	 set @MaTB = concat(@MaSanBayDi, '-', @MaSanBayDen)
	return @MaTB
end
go

create trigger TriggerThemTuyenBay on TUYENBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaTuyenBay IN
	(
	SELECT MaTuyenBay
	FROM TUYENBAY
	))
	BEGIN
		PRINT N'Ma Tuyen Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO TUYENBAY
       SELECT MaTuyenBay, SANBAYDI_MaSanBay, SANBAYDEN_MaSanBay, SANBAYTRUNGGIAN_MaSanBay
       FROM inserted
	END
end
go

create proc ThemTuyenBay
@MaSanBayDi varchar(20),  @MaSanBayDen varchar(20),  @MaSanBayTG varchar(20)
as
begin
	declare @MaTuyenBay varchar(20)
	set @MaTuyenBay = dbo.TaoMaTuyenBay(@MaSanBayDi, @MaSanBayDen)
	insert into TUYENBAY values(@MaTuyenBay, @MaSanBayDi, @MaSanBayDen, @MaSanBayTG)
end
go

ThemTuyenBay 'BKK', 'VCA', null

create trigger TriggerXoaTuyenBay on TUYENBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaTuyenBay IN (SELECT MaTuyenBay FROM TUYENBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaTuyenBay IN (SELECT TUYENBAY_MaTuyenBay FROM CHUYENBAY))
		BEGIN
			PRINT N'Khong The Xoa Tuyen Bay!'
			ROLLBACK TRANSACTION 
		END	
		ELSE
		BEGIN
			DELETE FROM TUYENBAY WHERE MaTuyenBay IN (SELECT MaTuyenBay FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma Tuyen Bay Khong Ton Tai!'
	END
end
go

create proc XoaTuyenBay
@MaTuyenBay varchar(20)
as
begin
	delete from TUYENBAY where MaTuyenBay = @MaTuyenBay
end
go

create proc TimTuyenBay
@MaTuyenBay varchar(20)
as
begin
	select * from TUYENBAY where MaTuyenBay = @MaTuyenBay
end
go

--------------------MAY BAY--------------------
create view XemMayBay as
select * from MAYBAY
go

select * from XemMayBay
go

create trigger TriggerThemMayBay on MAYBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		PRINT N'Ma May Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	     INSERT INTO MAYBAY
       SELECT MaMayBay, LoaiMayBay, SoGhe
       FROM inserted
	END
end
go

create proc ThemMayBay
@MaMayBay varchar(20),  @LoaiMayBay nvarchar(45),  @SoGhe int
as
begin
	insert into MAYBAY values(@MaMayBay, @LoaiMayBay, @SoGhe)
end
go

create trigger TriggerSuaMayBay on MAYBAY
instead of update
as
begin
	DECLARE @MaMayBay varchar(20), @LoaiMayBay nvarchar(45), @SoGhe int
	IF EXISTS (SELECT * FROM inserted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		set @MaMayBay = (select MaMayBay from inserted)
		set @LoaiMayBay = (select LoaiMayBay from inserted)
		set @SoGhe = (select SoGhe from inserted)
		update MAYBAY set LoaiMayBay=@LoaiMayBay, SoGhe=@SoGhe where MaMayBay=@MaMayBay
	END
	ELSE
	BEGIN
		PRINT N'Ma May Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	END
end
go

create proc SuaMayBay
@MaMayBay varchar(20), @LoaiMayBay nvarchar(45), @SoGhe int
as
begin
	update MAYBAY set LoaiMayBay=@LoaiMayBay, SoGhe=@SoGhe where MaMayBay=@MaMayBay
end
go

create trigger TriggerXoaMayBay on MAYBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT MaMayBay FROM MAYBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT MaMayBay FROM CHUYENBAY))
		BEGIN
			PRINT N'Khong The Xoa May Bay!'
			ROLLBACK TRANSACTION 
		END	
		ELSE
		BEGIN
			DELETE FROM MAYBAY WHERE MaMayBay IN (SELECT MaMayBay FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma May Bay Khong Ton Tai!'
	END
end
go

create proc XoaMayBay
@MaMayBay varchar(20)
as
begin
	delete from MAYBAY where MaMayBay = @MaMayBay
end
go

create or alter proc TimMayBay
@MaMayBay varchar(20)
as
begin
	select * from MAYBAY where MaMayBay=@MaMayBay
end
go

--TimMayBay 'A320-01'

--------------------CHUYEN BAY--------------------
create view XemChuyenBay as
select * from CHUYENBAY
go

select * from XemChuyenBay
go

create function TaoMaChuyenBay(@NgayBay Date, @GioKhoiHanh Time, @MaTuyenBay varchar(7))
returns varchar(20)
as
begin
	declare @MaCB varchar(20), @Ngay char(2), @Thang char(2), @Gio char(2), @Phut char(2)
	set @Ngay = DAY(@NgayBay)
	set @Thang = MONTH(@NgayBay)
	set @Gio = DATENAME(HOUR, @GioKhoiHanh)
	set @Phut = DATENAME(MINUTE, @GioKhoiHanh)
	if (@Ngay <= 9)
	begin
		set @Ngay = concat('0', @Ngay)
	end
	if (@Thang <= 9)
	begin
		set @Thang = concat('0', @Thang)
	end
	if (@Gio <= 9)
	begin
		if (@Gio = 0)
		begin
			set @Gio = '00'
		end
		else
		begin
			set @Gio = concat('0', @Gio)
		end
	end
	if (@Phut <= 9)
	begin
		if (@Phut = 0)
		begin
			set @Phut = '00'
		end
		else
		begin
			set @Phut = concat('0', @Phut)
		end
	end
	set @MaCB = concat(@MaTuyenBay, '_', @Ngay, @Thang, YEAR(@NgayBay), @Gio, @Phut)
	return @MaCB
end
go

create trigger TriggerThemChuyenBay on CHUYENBAY
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
	BEGIN
		PRINT N'Ma Chuyen Bay Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
	   INSERT INTO CHUYENBAY 
	   SELECT MaChuyenBay, NgayBay, GioKhoiHanh, ThoiGianBay, ThoiGianDuKienDen, SoGheHang1, SoGheHang2, TUYENBAY_MaTuyenBay, MaMayBay 
	   FROM inserted
	END
end
go

create proc ThemChuyenBay
@NgayBay date,  @GioKhoiHanh Time, @ThoiGianBay Time, @ThoiGianDen Time, @SoGheH1 int, @SoGheH2 int, @MaTuyenBay varchar(20), @MaMayBay varchar(20)
as
begin
	declare @MaCB varchar(20)
	set @MaCB = dbo.TaoMaChuyenBay(@NgayBay, @GioKhoiHanh, @MaTuyenBay)
	insert into CHUYENBAY values(@MaCB, @NgayBay, @GioKhoiHanh, @ThoiGianBay, @ThoiGianDen, @SoGheH1, @SoGheH2, @MaTuyenBay, @MaMayBay)
end
go

--ThemChuyenBay '2022-11-08','06:00:00','00:55:00','6:55:00', 50, 100,'SGN-HAN','A320-01'

create trigger TriggerXoaChuyenBay on CHUYENBAY
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT CHUYENBAY_MaChuyenBay FROM PHIEUDATCHO))
			BEGIN
				PRINT N'Khong The Xoa Chuyen Bay!'
				ROLLBACK TRANSACTION 
			END	
		ELSE
		BEGIN
			IF EXISTS (SELECT * FROM deleted WHERE MaMayBay IN (SELECT CHUYENBAY_MaChuyenBay FROM VECHUYENBAY))
			BEGIN
				PRINT N'Khong The Xoa Chuyen Bay!'
				ROLLBACK TRANSACTION 
			END	
			ELSE
			BEGIN
				DELETE FROM CHUYENBAY WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM deleted)
			END 
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma Chuyen Bay Khong Ton Tai!'
	END
end
go


create proc XoaChuyenBay
@MaChuyenBay varchar(20)
as
begin
	delete from CHUYENBAY where MaChuyenBay=@MaChuyenBay
end
go

create trigger TriggerSuaChuyenBay on CHUYENBAY
instead of update
as
begin
	DECLARE @MaChuyenBay varchar(20), @ThoiGianBay Time, @ThoiGianDen Time, @SoGheH1 int, @SoGheH2 int, @MaMayBay varchar(20)
	IF EXISTS (SELECT * FROM inserted WHERE MaChuyenBay IN (SELECT MaChuyenBay FROM CHUYENBAY))
	BEGIN
		set @MaChuyenBay = (select MaChuyenBay from inserted)
		set @ThoiGianBay = (select ThoiGianBay from inserted)
		set @ThoiGianDen = (select ThoiGianDuKienDen from inserted)
		set @SoGheH1 = (select SoGheHang1 from inserted)
		set @SoGheH2 = (select SoGheHang2 from inserted)
		set @MaMayBay = (select MaMayBay from inserted)
		update CHUYENBAY 
		 set ThoiGianBay=@ThoiGianBay, ThoiGianDuKienDen=@ThoiGianDen, SoGheHang1=@SoGheH1, SoGheHang2=@SoGheH2, MaMayBay=@MaMayBay 
		 where MaChuyenBay=@MaChuyenBay
	END
	ELSE
	 BEGIN
		PRINT N'Ma Chuyen Bay Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	 END
end
go

create proc SuaChuyenBay
@MaChuyenBay varchar(20), @ThoiGianBay Time, @ThoiGianDen Time, @SoGheH1 int, @SoGheH2 int, @MaMayBay varchar(20)
as
begin
	update CHUYENBAY 
	set ThoiGianBay=@ThoiGianBay, ThoiGianDuKienDen=@ThoiGianDen, SoGheHang1=@SoGheH1, SoGheHang2=@SoGheH2, MaMayBay=@MaMayBay 
	where MaChuyenBay=@MaChuyenBay
end
go

create proc TimChuyenBay
@MaChuyenBay varchar(20)
as
begin
	select * from CHUYENBAY where MaChuyenBay=@MaChuyenBay
end
go
--------------------HANG VE--------------------
create view XemHangVe as
select * from HANGVE
go

select * from XemHangVe
go

create function TaoMaHangVe(@MaChuyenBay varchar(20), @HangVe char(4))
returns varchar(25)
as
begin
	declare @MaHangVe varchar(25)
	set @MaHangVe = CONCAT(@MaChuyenBay, '_', @HangVe)
	return @MaHangVe
end
go

create trigger TriggerThemHangVe on HANGVE
instead of insert
as
begin
	IF EXISTS (SELECT * FROM inserted WHERE MaHangVe IN (SELECT MaHangVe FROM HANGVE))
	BEGIN
		PRINT N'Ma Hang Ve Da Ton Tai!'
		ROLLBACK TRANSACTION 
	END
	ELSE
	BEGIN
		INSERT INTO HANGVE 
		SELECT MaHangVe, VECHUYENBAY, KhoiLuongToiDa, DonGia 
		FROM inserted
	END
end
go

create or alter proc ThemHangVe
@MaChuyenBay varchar(30), @HangVe char(4), @KhoiLuongToiDa int, @DonGia money
as
begin
	declare @MaHangVe varchar(30)
	set @MaHangVe = dbo.TaoMaHangVe(@MaChuyenBay, @HangVe)
	insert into HANGVE values(@MaHangVe, @MaChuyenBay, @KhoiLuongToiDa, @DonGia)
end
go

--ThemHangVe 'SGN-HAN_081120220600', 'HV01', '10', '1700000'

create trigger TriggerXoaHangVe on HANGVE
instead of delete
as
begin
	IF EXISTS (SELECT * FROM deleted WHERE MaHangVe IN (SELECT MaHangVe FROM HANGVE))
	BEGIN
		IF EXISTS (SELECT * FROM deleted WHERE MaHangVe IN (SELECT MAHANGVE FROM PHIEUDATCHO))
			BEGIN
				PRINT N'Khong The Xoa Hang Ve!'
				ROLLBACK TRANSACTION 
			END	
		ELSE
		BEGIN
			DELETE FROM HANGVE WHERE MaHangVe IN (SELECT MaHangVe FROM deleted)
		END
	END
	ELSE
	BEGIN
		PRINT N'Ma Hang Ve Khong Ton Tai!'
	END
end
go


create proc XoaHangVe
@MaHangVe varchar(30)
as
begin
	delete from HANGVE where MaHangVe=@MaHangVe
end
go

create trigger TriggerSuaHangVe on HANGVE
instead of update
as
begin
	DECLARE @MaHangVe varchar(30), @KhoiLuongToiDa int, @DonGia money
	IF EXISTS (SELECT * FROM inserted WHERE MaHangVe IN (SELECT MaHangVe FROM HANGVE))
	BEGIN
		set @MaHangVe = (select MaHangVe from inserted)
		set @KhoiLuongToiDa = (select KhoiLuongToiDa from inserted)
		set @DonGia = (select DonGia from inserted)
		update HANGVE 
		 set KhoiLuongToiDa=@KhoiLuongToiDa, DonGia=@DonGia 
		 where MaHangVe=@MaHangVe
	END
	ELSE
	 BEGIN
		PRINT N'Ma Hang Ve Khong Ton Tai!'
		ROLLBACK TRANSACTION 
	 END
end
go

create proc SuaHangVe
@MaHangVe varchar(30), @KhoiLuongToiDa int, @DonGia money
as
begin
	update HANGVE 
	set KhoiLuongToiDa=@KhoiLuongToiDa, DonGia=@DonGia 
	where MaHangVe=@MaHangVe
end
go

--SuaHangVe 'SGN-HAN_081120220600_HV02', 15, 1750000

create proc TimHangVe
@MaHangVe varchar(30)
as
begin
	select * from HANGVE where MaHangVe=@MaHangVe
end
go

--TimHangVe 'SGN-HAN_081120220600_HV02'

create view XemHoaDon as
select * from HOADON
go

select * from XemHangVe
go
