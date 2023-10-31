
-- Thêm dữ liệu cho các sân bay ở Việt Nam
INSERT INTO SANBAY (MaSanBay, TenSanBay, ViTri)
VALUES
    ('SGN', N'Sân bay Tân Sơn Nhất', N'Hồ Chí Minh'),
    ('HAN', N'Sân bay Nội Bài', N'Hà Nội'),
    ('DAD', N'Sân bay Đà Nẵng', N'Đà Nẵng'),
    ('CXR', N'Sân bay Cam Ranh', N'Khánh Hòa'),
    ('HUI', N'Sân bay Phú Bài', N'Thừa Thiên-Huế'),
    ('PQC', N'Sân bay Phú Quốc', N'Kiên Giang'),
    ('VCA', N'Sân bay Cần Thơ', N'Cần Thơ'),
    ('DLI', N'Sân bay Liên Khương', N'Lâm Đồng'),
    ('VCL', N'Sân bay Chu Lai', N'Quảng Nam');

-- Thêm thông tin vào bảng TUYENBAY
INSERT INTO TUYENBAY (MaTuyenBay, TenTuyenBay)
VALUES
    ('TB1', N'Tuyến bay SGN-HAN'),
    ('TB2', N'Tuyến bay SGN-DAD'),
    ('TB3', N'Tuyến bay HAN-CXR'),
    ('TB4', N'Tuyến bay DAD-HUI'),
	('TB5', N'Tuyến bay HAN-PQC'),
	('TB6', N'Tuyến bay VCA-DLI'),
	('TB7', N'Tuyến bay DLI-VCL'),
	('TB8', N'Tuyến bay HUI-PQC'),
	('TB9', N'Tuyến bay SGN-VCA'),
	('TB10', N'Tuyến bay HAN-DLI')
	

INSERT INTO TUYENBAY_SANBAY (MaTuyenBay,MaSanBayKhoiHanh, MaSanBayDen)
VALUES
	   ('TB1', 'SGN', 'HAN'),
	   ('TB2', 'SGN', 'DAD'),
	   ('TB3', 'HAN', 'CXR'),
	   ('TB4', 'DAD', 'HUI'),
	   ('TB5', 'HAN', 'PQC'),
	   ('TB6', 'VCA', 'DLI'),
	   ('TB7', 'DLI', 'VCL'),
	   ('TB8', 'HUI', 'PQC'),
	   ('TB9', 'SGN', 'VCA'),
	   ('TB10', 'HAN', 'DLI')

-- Thêm dữ liệu cho bảng MAYBAY
INSERT INTO MAYBAY (MaMayBay, LoaiMayBay, SoGheLoaiA, SoGheLoaiB)
VALUES
    ('MB001', N'Boeing 747', 20, 80),
    ('MB002', N'Airbus A320', 30, 70),
    ('MB003', N'Boeing 787', 40, 60),
    ('MB004', N'Airbus A330', 35, 65),
    ('MB005', N'Embraer E190', 20, 80),
    ('MB006', N'Boeing 737', 25, 75),
    ('MB007', N'Airbus A380', 80, 120),
    ('MB008', N'Boeing 777', 60, 140);

INSERT INTO CHONGOI (MaGhe, TinhTrang, LoaiGhe, GiaGhe, MaMayBay)
VALUES
    ('1A001', 0, N'Loại A', 9000000, 'MB001'),
    ('1A002', 1, N'Loại A', 9000000, 'MB001'),
    ('1B001', 0, N'Loại B', 1200000, 'MB001'),
	('1B002', 1, N'Loại B', 1200000, 'MB001'),

    ('2A001', 0, N'Loại A', 8500000, 'MB002'),
    ('2A002', 1, N'Loại A', 8500000, 'MB002'),
    ('2B001', 0, N'Loại B', 1100000, 'MB002'),
	('2B002', 1, N'Loại B', 1100000, 'MB002'),

    ('3A001', 0, N'Loại A', 7000000, 'MB003'),
    ('3A002', 1, N'Loại A', 7000000, 'MB003'),
    ('3B001', 0, N'Loại B', 1200000, 'MB003'),
	('3B002', 0, N'Loại B', 1200000, 'MB003'),

    ('4A001', 0, N'Loại A', 8000000, 'MB004'),
    ('4A002', 1, N'Loại A', 8000000, 'MB004'),
    ('4B001', 0, N'Loại B', 1300000, 'MB004'),
	('4B002', 1, N'Loại B', 1300000, 'MB004'),

    ('5A001', 0, N'Loại A', 9000000, 'MB005'),
    ('5A002', 1, N'Loại A', 9000000, 'MB005'),
    ('5B001', 0, N'Loại B', 1400000, 'MB005'),
	('5B002', 0, N'Loại B', 1400000, 'MB005'),

    ('6A001', 0, N'Loại A', 8000000, 'MB006'),
    ('6A002', 1, N'Loại A', 8000000, 'MB006'),
    ('6B001', 1, N'Loại B', 1500000, 'MB006'),
	('6B002', 0, N'Loại B', 1500000, 'MB006'),

    ('7A001', 0, N'Loại A', 9500000, 'MB007'),
    ('7A002', 1, N'Loại A', 9500000, 'MB007'),
    ('7B001', 0, N'Loại B', 1600000, 'MB007'),
	('7B002', 1, N'Loại B', 1600000, 'MB007'),

    ('8A001', 1, N'Loại A', 8000000, 'MB008'),
    ('8A002', 1, N'Loại A', 8000000, 'MB008'),
    ('8B001', 0, N'Loại B', 1700000, 'MB008'),
    ('8B002', 0, N'Loại B', 1700000, 'MB008');

-- Thêm dữ liệu cho bảng CHUYENBAY
INSERT INTO CHUYENBAY (MaChuyenBay, NgayBay, ThoiGianBay, ThoiGianDenDuKien, GioKhoiHanh, MaTuyenBay, MaMayBay)
VALUES
    ('CB001', '2023-10-05', '02:30:00', '10:30:00', '08:00:00', 'TB1', 'MB001'),
    ('CB002', '2023-10-06', '02:00:00', '12:30:00', '10:30:00', 'TB2', 'MB002'),
    ('CB003', '2023-10-07', '02:15:00', '14:15:00', '12:00:00', 'TB3', 'MB003'),
    ('CB004', '2023-10-08', '03:00:00', '17:30:00', '14:30:00', 'TB4', 'MB004'),
    ('CB005', '2023-10-09', '02:30:00', '18:30:00', '16:00:00', 'TB5', 'MB005'),
    ('CB006', '2023-10-09', '04:00:00', '22:30:00', '18:30:00', 'TB6', 'MB006'),
    ('CB007', '2023-10-11', '02:20:00', '22:20:00', '20:00:00', 'TB7', 'MB007'),
    ('CB008', '2023-10-12', '04:30:00', '18:00:00', '13:30:00', 'TB8', 'MB008');

-- Thêm dữ liệu cho bảng KHACHHANG
INSERT INTO KHACHHANG (CCCD, HoTen, Gioitinh, SDT, NgaySinh, Email)
VALUES
    ('079095123456', N'Nguyễn Văn A', N'Nam', '0123456789', '1995-01-15', 'nguyenvana@email.com'),
    ('089303016700', N'Phạm Thị B', N'Nữ','0987654321', '2003-03-20', 'phamthib@email.com'),
    ('066088129476', N'Trần Văn C', N'Nam','0369852147', '1988-07-10', 'tranvanc@email.com'),
    ('022192946357', N'Lê Thị D', N'Nữ','0901234567', '1992-11-05', 'lethid@email.com'),
    ('093098004561', N'Huỳnh Văn E', N'Nam','0765432198', '1998-02-25', 'huynhvan@email.com'),
    ('044197901234', N'Võ Thị F', N'Nữ','0587654321', '1997-09-12', 'vothif@email.com'),
    ('080085123456', N'Đặng Văn G', N'Nam','0987123456', '1985-05-30', 'dangvang@email.com'),
    ('064191234567', N'Mai Thị H', N'Nữ','0369852147', '1991-03-18', 'maithih@email.com'),
    ('082087456789', N'Lý Văn I', N'Nam','0909876543', '1987-12-06', 'lyvani@email.com'),
    ('038300567890', N'Phan Thị K', N'Nữ','0765432198', '2000-08-22', 'phanthik@email.com');

INSERT INTO NHANVIEN (MaNV, CCCD, TenNV, NgaySinh, GioiTinh, SDT, DiaChi)
VALUES
    ('NV001', '089090678901', N'Nguyễn Văn An', '1990-03-15', N'Nam', '0901234567', N'123 Đường ABC, Quận 1, TP.HCM'),
    ('NV002', '019185789012', N'Trần Thị Bình', '1985-05-20', N'Nữ', '0987654321', N'456 Đường XYZ, Quận 2, TP.HCM'),
    ('NV003', '054092890123', N'Lê Văn Cường', '1992-08-10', N'Nam', '0123456789', N'789 Đường MNO, Quận 3, TP.HCM'),
    ('NV004', '034188901234', N'Phạm Thị Dung', '1988-12-25', N'Nữ', '0765432109', N'101 Đường LMN, Quận 4, TP.HCM'),
    ('NV005', '020093012345', N'Huỳnh Văn Hòa', '1993-04-05', N'Nam', '0888888888', N'202 Đường DEF, Quận 5, TP.HCM'),
	('NV006', '077187123456', N'Trần Thị Kim', '1987-06-30', N'Nữ', '0777777777', N'303 Đường GHI, Quận 6, TP.HCM'),
    ('NV007', '060091234567', N'Võ Minh Luân', '1991-10-12', N'Nam', '0333333333', N'404 Đường JKL, Quận 7, TP.HCM'),
    ('NV008', '075186345678', N'Nguyễn Thị Mai', '1986-02-18', N'Nữ', '0555555555', N'505 Đường OPQ, Quận 8, TP.HCM'),
    ('NV009', '001094456789', N'Trần Văn Nam', '1994-07-08', N'Nam', '0444444444', N'606 Đường RST, Quận 9, TP.HCM'),
    ('NV010', '079189567890', N'Phạm Thị Ngọc', '1989-09-03', N'Nữ', '0666666666', N'707 Đường UVW, Quận 10, TP.HCM');

INSERT INTO PHANQUYEN (MaNV, TaiKhoan, MatKhau, UyQuyen)
VALUES
    ('NV001', N'Admin', '123456', 1),
    ('NV002', N'NV002', '123456789', 0),
    ('NV003', N'NV003', '123456789', 0),
    ('NV004', N'NV004', '123456789', 0),
    ('NV005', N'NV005', '123456789', 0),
    ('NV006', N'NV006', '123456789', 0),
    ('NV007', N'NV007', '123456789', 0),
    ('NV008', N'NV008', '123456789', 0),
    ('NV009', N'NV009', '123456789', 0),
    ('NV010', N'NV010', '123456789', 0);

-- Thêm dữ liệu vào bảng THONGTINGIAODICH
INSERT INTO THONGTINGIAODICH (MaGiaoDich, NgayDat, MaChuyenBay, MaGhe, CCCD)
VALUES
    ('GD001', '2023-10-01', 'CB001', '1A002', '079095123456'),
    ('GD002', '2023-10-02', 'CB002', '2A002', '089303016700'),
    ('GD003', '2023-10-03', 'CB003', '3A002', '066088129476'),
    ('GD004', '2023-10-04', 'CB004', '4B002', '022192946357'),
    ('GD005', '2023-10-05', 'CB005', '5A002', '093098004561'),
    ('GD006', '2023-10-06', 'CB006', '6B001', '044197901234'),
    ('GD007', '2023-10-07', 'CB007', '7B001', '080085123456'),
    ('GD008', '2023-10-08', 'CB008', '8A001', '064191234567'),
    ('GD009', '2023-10-09', 'CB001', '1B002', '082087456789'),
    ('GD010', '2023-10-10', 'CB002', '2B002', '038300567890');

INSERT INTO HOADON (MaHoaDon, MaGiaoDich, NgayLap, ThanhTien, CCCD, MaNV)
VALUES
    ('HD001', 'GD001', '2023-10-01', 9000000, '079095123456', 'NV001'),
    ('HD002', 'GD002', '2023-10-02', 8500000, '089303016700', 'NV002'),
    ('HD003', 'GD003', '2023-10-03', 7000000, '066088129476', 'NV003'),
    ('HD004', 'GD004', '2023-10-04', 1300000, '022192946357', 'NV004'),
    ('HD005', 'GD005', '2023-10-05', 9000000, '093098004561', 'NV005'),
    ('HD006', 'GD006', '2023-10-06', 1500000, '044197901234', 'NV006'),
    ('HD007', 'GD007', '2023-10-07', 1600000, '080085123456', 'NV007'),
    ('HD008', 'GD008', '2023-10-08', 8000000, '064191234567', 'NV008'),
    ('HD009', 'GD009', '2023-10-09', 1200000, '082087456789', 'NV009'),
    ('HD010', 'GD010', '2023-10-10', 1100000, '038300567890', 'NV010');

-- Thêm dữ liệu cho bảng VECHUYENBAY
INSERT INTO VECHUYENBAY (MaVe, NgayTaoVe, MaHoaDon)
VALUES
    ('VE001', '2023-10-01', 'HD001'),
    ('VE002', '2023-10-02', 'HD002'),
    ('VE003', '2023-10-03', 'HD003'),
    ('VE004', '2023-10-04', 'HD004'),
    ('VE005', '2023-10-05', 'HD005'),
    ('VE006', '2023-10-06', 'HD006'),
	('VE007', '2023-10-07', 'HD007'),
    ('VE008', '2023-10-08', 'HD008'),
    ('VE009', '2023-10-09', 'HD009'),
    ('VE010', '2023-10-10', 'HD010');

