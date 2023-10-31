use QUANLYCHUYENBAY3
go
-------------------TRIGGER------------------------------
--Đảm bảo không có người trùng CMND
go
CREATE TRIGGER CHECK_CMND
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
--Không lập phiếu cho hạng ghế chuyến bay đã có người đặt 
CREATE TRIGGER CHECK_PHIEU
ON [dbo].PHIEUDATCHO
FOR UPDATE,INSERT
AS
BEGIN
DECLARE @MaPhieu AS VARCHAR(255), @CHUYENBAY_MaChuyenBay char(45), @TEMP as INT
	SELECT @MaPhieu=inserted.MaPhieu FROM inserted
	SELECT @CHUYENBAY_MaChuyenBay = inserted.CHUYENBAY_MaChuyenBay from inserted
	SELECT @TEMP=COUNT(*) FROM dbo.VECHUYENBAY_DADAT
	WHERE @CHUYENBAY_MaChuyenBay = @CHUYENBAY_MaChuyenBay and @MaPhieu=@MaPhieu
	IF (@TEMP > 1)
		BEGIN
			PRINT('Mã vé đã được tạo')
			ROLLBACK TRANSACTION
		END
END
GO
--Đảm bảo giá vé > 0
CREATE TRIGGER CHECK_GiaVe
ON [dbo].DONGIA
FOR UPDATE,INSERT
AS
BEGIN
DECLARE @MaDonGia_HangVe AS INT
	SELECT @MaDonGia_HangVe=inserted.MaDonGia_HangVe FROM inserted
	IF (@MaDonGia_HangVe <= 0)
		BEGIN
			PRINT('Yêu cầu đơn giávé > 0')
			ROLLBACK TRANSACTION
		END
END
go