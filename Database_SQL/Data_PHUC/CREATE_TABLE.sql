create database QUANLYCHUYENBAY
go
use QUANLYCHUYENBAY
go
create table SANBAY(
MaSanBay varchar(20) primary key not null,
TenSanBay nvarchar(45) not null,
ViTri nvarchar(50) not null
)
go

create table TUYENBAY(
MaTuyenBay varchar(20) primary key not null,
SANBAYDI_MaSanBay varchar(20) REFERENCES SANBAY(MaSanBay),
SANBAYDEN_MaSanBay varchar(20) REFERENCES SANBAY(MaSanBay),
SANBAYTRUNGGIAN_MaSanBay varchar(20) REFERENCES SANBAY(MaSanBay)
)
go

create table NHANVIEN(
MaNV varchar(20) primary key not null,
CMND varchar(20) not null,
TenNV nvarchar(45),
GioiTinh nvarchar(20),
NgaySinh date,
SDT  varchar(20),
Diachi nvarchar(100)
)
go
------
create table TAIKHOAN(
 TenTaiKhoan varchar(20) primary key not null,
 MatKhau varchar (20) not null,
 ID_NhanVien varchar(20) references NHANVIEN(MaNV) null,
 PHANLOAI varchar(20)
)
go
create table KHACHHANG(
CMND varchar(20) primary key not null,
TenKH nvarchar(45),
SDT  varchar(20),
GioiTinh   nvarchar(20),
Diachi nvarchar(100),
NgaySinh date
)
go

create table MAYBAY(
MaMayBay varchar(20) primary key not null,
LoaiMayBay nvarchar(45),
SoGhe int
)
go

CREATE TABLE CHUYENBAY(
MaChuyenBay varchar(20) PRIMARY KEY not null,
NgayBay Date,
GioKhoiHanh TIME,
ThoiGianBay TIME,
ThoiGianDuKienDen TIME,
SoGheHang1 INT,
SoGheHang2 INT,
TUYENBAY_MaTuyenBay varchar(20) REFERENCES TUYENBAY(MaTuyenBay),
MaMayBay varchar(20) references MAYBAY(MaMayBay)
------Chuyến bay đã bỏ Khối lượng
)
go
CREATE TABLE HANGVE(
MaHangVe varchar(30) PRIMARY KEY not null,
VECHUYENBAY varchar(20) REFERENCES CHUYENBAY(MaChuyenBay), -- ví dụ như tuyến tân sơn nhất nội bài ,
KhoiLuongToiDa int, -----Thêm Khối Lượng tối đa vào HangVe
DonGia Money
)
go


CREATE TABLE PHIEUDATCHO(
MaPhieu varchar(20) PRIMARY KEY not null,
ThoiGianDat DATETIME,
SoGhe varchar(5),
HangGhe varchar(5),
CHUYENBAY_MaChuyenBay varchar(20) REFERENCES CHUYENBAY(MaChuyenBay),
KHACHHANG_CMND varchar(20) REFERENCES KHACHHANG(CMND),
MAHANGVE varchar(30) REFERENCES HANGVE(MaHangVe),
)
GO


CREATE TABLE HOADON(
MaHD varchar(20) PRIMARY KEY not null,
MaPhieuDatCho varchar(20) references PHIEUDATCHO(MaPhieu),
ThanhTien MONEY,
NgayLap DATETIME,
NHANVIEN_MaNV varchar(20) REFERENCES NHANVIEN(MaNV),
KHACHHANG_CMND varchar(20) REFERENCES KHACHHANG(CMND)
)
go

CREATE TABLE VECHUYENBAY(
MaVeChuyenBay varchar(20)PRIMARY KEY not null,
CHUYENBAY_MaChuyenBay varchar(20) REFERENCES CHUYENBAY(MaChuyenBay),
SoLuongVe int,
TinhTrangVe nvarchar(10),
)

create table SoGhe(
MaGhe varchar(20) primary key,
PhanLoai int,
MaHangGhe varchar (20)
)