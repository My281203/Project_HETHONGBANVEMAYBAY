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
    INNER JOIN THONGTINGIAODICH ON ChuyenBay.MaChuyenBay = THONGTINGIAODICH.MaChuyenBay
    WHERE
        CONVERT(date, ChuyenBay.NgayBay) < CONVERT(date, GETDATE()) -- Compare only the date parts

    -- Update VECHUYENBAY table
    UPDATE VECHUYENBAY
    SET is_deleted = 1
    FROM VECHUYENBAY
    INNER JOIN HOADON ON VECHUYENBAY.MaHoaDon = HOADON.MaHoaDon
    INNER JOIN THONGTINGIAODICH ON HOADON.MaGiaoDich = THONGTINGIAODICH.MaGiaoDich
    INNER JOIN CHONGOI ON THONGTINGIAODICH.MaGhe = CHONGOI.MaGhe
    INNER JOIN CHUYENBAY ON THONGTINGIAODICH.MaChuyenBay = CHUYENBAY.MaChuyenBay
    WHERE
        CONVERT(date, CHUYENBAY.NgayBay) < CONVERT(date, GETDATE()) -- Compare only the date parts
        AND CHUYENBAY.MaChuyenBay = CHONGOI.MaChuyenBay
        AND CHONGOI.MaGhe = THONGTINGIAODICH.MaGhe
        AND HOADON.is_deleted = 0; -- Add conditions based on the logic of your system
        
    COMMIT TRANSACTION; -- Commit the transaction if both updates succeed
END;
