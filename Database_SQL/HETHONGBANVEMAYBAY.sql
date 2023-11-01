create database HETHONGBANVEMAYBAY9
go

use HETHONGBANVEMAYBAY9
go

create table SANBAY (
	MaSanBay varchar(15) primary key,
	TenSanBay nvarchar(30) not null,
	ViTri nvarchar(30) not null
)
go
create table TUYENBAY (
	MaTuyenBay varchar(15) primary key,
	TenTuyenBay nvarchar(50) not null
)
go
create table TUYENBAY_SANBAY(
	MaTuyenBay varchar(15) references TUYENBAY(MaTuyenBay),
	MaSanBayKhoiHanh varchar(15) not null,
	MaSanBayDen varchar(15) not null,
	foreign key (MaSanBayKhoiHanh) references SANBAY(MaSanBay),
	foreign key (MaSanBayDen) references SANBAY(MaSanBay),
	primary key (MaTuyenBay,MaSanBayKhoiHanh,MaSanBayDen)
)
go
create table MAYBAY (
	MaMayBay varchar(15) primary key,
	LoaiMayBay nvarchar(20) not null,
	SoGheLoaiA int,
	SoGheLoaiB int
)
go
create table CHONGOI (
    MaGhe varchar(5) primary key,
    TinhTrang bit,
    LoaiGhe nvarchar(20) not null,
    GiaGhe int not null,
    MaMayBay varchar(15) references MAYBAY(MaMayBay)
)
go
create table CHUYENBAY (
	MaChuyenBay varchar(15) primary key,
	NgayBay date not null,
	ThoiGianBay time,
	ThoiGianDenDuKien time,
	GioKhoiHanh time not null,
	MaTuyenBay varchar(15) references TUYENBAY(MaTuyenBay),
	MaMayBay varchar(15) references MAYBAY(MaMayBay)
)
go
create table KHACHHANG (
	CCCD varchar(12) primary key check (len(CCCD)=12),
	HoTen nvarchar(30) not null,
	GioiTinh nvarchar(5) not null,
	SDT varchar(10) not null check (len(SDT)=10),
	NgaySinh date not null,
	Email varchar(30)
)
go
create table NHANVIEN (
	MaNV varchar(10) primary key,
	CCCD varchar(12) not null check (len(CCCD)=12),
	TenNV nvarchar(30) not null,
	NgaySinh date not null,
	GioiTinh nvarchar(5) not null,
	SDT varchar(10) not null check (len(SDT)=10),
	DiaChi nvarchar(60) not null
)

create table PHANQUYEN (
	MaNV varchar(10) not null,
	TaiKhoan varchar(30) not null,
	MatKhau varchar(30) not null,
	UyQuyen bit not null,
	primary key (MaNV, TaiKhoan),
	foreign key (MaNV) references NHANVIEN(MaNV)
)
go
create table THONGTINGIAODICH (
    MaGiaoDich varchar(15) primary key,
    NgayDat DATE not null,
    MaChuyenBay varchar(15) not null,
    MaGhe varchar(5) not null,
    CCCD varchar(12) not null check (len(CCCD)=12),
	is_deleted bit not null default 0,
    foreign key (MaChuyenBay) references CHUYENBAY(MaChuyenBay),
    foreign key (MaGhe) references CHONGOI(MaGhe),
    foreign key (CCCD) references KHACHHANG(CCCD)
)
go
create table HOADON (
	MaHoaDon varchar(15) primary key,
	MaGiaoDich varchar(15) unique,
	NgayLap date not null,
	ThanhTien int,
    is_deleted bit  not null default 0,
	CCCD varchar(12) references KHACHHANG(CCCD),
	MaNV varchar(10) references NHANVIEN(MaNV),
	foreign key (MaGiaoDich) references THONGTINGIAODICH(MaGiaoDich)
)
go
go

create table VECHUYENBAY (
	MaVe varchar(15) primary key,
	NgayTaoVe date,
	MaHoaDon varchar(15) references HOADON(MaHoaDon),
	is_deleted bit not null default 0
)
go
--------------------
ALTER TABLE CHONGOI
ADD machuyenbay varchar(15) DEFAULT NULL,
FOREIGN KEY (machuyenbay) REFERENCES  CHUYENBAY(MaChuyenBay);
select * from CHONGOI

-- Thêm cột TrangThaiLamViec kiểu bit với giá trị mặc định là 1 vào bảng NHANVIEN
ALTER TABLE NHANVIEN
ADD TrangThaiLamViec bit

