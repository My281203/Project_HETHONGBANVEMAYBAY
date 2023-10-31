use QUANLYCHUYENBAY3
go
create procedure DOIMATKHAU 
@tenTaiKhoan char(20),@matKhau char(20),@matKhauMoi char(20),@matKhauMoiNL char(20)
as
begin
	if(@tenTaiKhoan = '' or @matKhau='' or @matKhauMoi='' or @matKhauMoiNL='')
	begin
		print N'Vui lòng nhập đủ thông tin!'
	end
	else
	begin
	if exists(select *from TAIKHOAN where TenTaiKhoan=@tenTaiKhoan and MatKhau=@matKhau)
		begin
			if(@matKhauMoi=@matKhauMoiNL)
				begin
					update TAIKHOAN set MatKhau=@matKhauMoi where TenTaiKhoan=@tenTaiKhoan
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
create procedure SHOWINFORMATION
@tenTaiKhoan char(20)
as
	begin
		select TAIKHOAN.TenTaiKhoan,TAIKHOAN.MatKhau,TAIKHOAN.PHANLOAI,NHANVIEN.TenNV FROM NHANVIEN FULL OUTER JOIN
 TAIKHOAN on NHANVIEN.MaNV=TAIKHOAN.ID_NhanVien where TAIKHOAN.TenTaiKhoan=@tenTaiKhoan 
	end
go
CREATE PROC THONGKE
@d1 datetime, @d2 datetime
as
begin
	select NgayLap,sum(ThanhTien) AS TongTien from HOADON where NgayLap>=@d1 and NgayLap<=@d2 group by NgayLap
end