use QUANLYCHUYENBAY3
go
---------------CHUYENBAY---------------
--PROC Thêm Chuyến Bay
create proc ThemChuyenBay
@MaChuyenBay char(20) ,@NgayBay Date ,@GioKhoiHanh TIME ,@ThoiGianBay TIME ,@ThoiGianDuKienDen TIME ,@SoGheHang1 INT ,@SoGheHang2 INT ,@TUYENBAY_MaTuyenBay char(20) ,@MaMayBay CHAR(20)
as
begin
	if exists (select * from CHUYENBAY where MaChuyenBay=@MaChuyenBay)
		begin
			print N'THÊM CHUYENBAY KHÔNG THÀNH CÔNG, DO TRÙNG MACHUYENBAY'
		end
	else
		begin
			if exists (select * from TUYENBAY where MaTuyenBay =@TUYENBAY_MaTuyenBay)
				begin 
				if exists (select * from MAYBAY where MaMayBay = @MaMayBay)
					begin
						print N'THÊM CHUYENBAY THÀNH CÔNG'
						insert into CHUYENBAY values(@MaChuyenBay,@NgayBay,@GioKhoiHanh,@ThoiGianBay,@ThoiGianDuKienDen,@SoGheHang1,@SoGheHang2,@TUYENBAY_MaTuyenBay,@MaMayBay)
					end
				else print N'THÊM CHUYENBAY KHÔNG THÀNH CÔNG, DO KHÔNG TỒN TẠI MaMayBay'
				end
			else print N'THÊM CHUYENBAY KHÔNG THÀNH CÔNG, DO KHÔNG TỒN TẠI TUYENBAY'
		end
end
go
--PROC Chỉnh sửa CHUYENBAY
create proc ChinhSuaChuyenBay
@MaChuyenBay char(20) ,@NgayBay Date ,@GioKhoiHanh TIME ,@ThoiGianBay TIME ,@ThoiGianDuKienDen TIME ,@SoGheHang1 INT ,@SoGheHang2 INT ,@TUYENBAY_MaTuyenBay char(20) ,@MaMayBay CHAR(20)
as
begin
	if exists (select * from CHUYENBAY where MaChuyenBay =@MaChuyenBay)
		begin
			if exists (select * from TUYENBAY where MaTuyenBay =@TUYENBAY_MaTuyenBay)
				begin 
				if exists (select * from MAYBAY where MaMayBay = @MaMayBay)
					begin
						update CHUYENBAY
						set
						NgayBay = @NgayBay,
						GioKhoiHanh = @GioKhoiHanh,
						ThoiGianBay = @ThoiGianBay,
						ThoiGianDuKienDen = @ThoiGianDuKienDen,
						SoGheHang1 = @SoGheHang1,
						SoGheHang2 = @SoGheHang2,
						TUYENBAY_MaTuyenBay = @TUYENBAY_MaTuyenBay,
						MaMayBay = @MaMayBay
						where MaChuyenBay = @MaChuyenBay
						print N'CẬP NHẬT THÀNH CÔNG'
					end
				else 
				begin
					print N'CẬP NHẬT KHÔNG THÀNH CÔNG, MAMAYBAY KHÔNG TỒN TẠI'
				end
				end
			else 
			begin
				print N'CHỈNH SỬA KHÔNG THÀNH CÔNG, MATUYENBAY KHÔNG TỒN TẠI!'
			end
		end			
	else 
		begin 
			print N'CHỈNH SỬA KHÔNG THÀNH CÔNG, MACHUYENBAY KHÔNG TỒN TẠI'
		end
end
go
--PROC Xóa CHUYENBAY
create proc XoaChuyenBay
@MaChuyenBay char(20)
as 
begin
	if exists(select * from CHUYENBAY where MaChuyenBay =@MaChuyenBay)
		begin
			print N'XOÁ THÀNH CÔNG'
			delete CHUYENBAY where MaChuyenBay=@MaChuyenBay
		end
	else 
		begin 
			print N'KHÔNG XÓA ĐƯỢC, MACHUYENBAY KHÔNG TỒN TẠI'
		end
end
go