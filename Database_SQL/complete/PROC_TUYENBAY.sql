use QUANLYCHUYENBAY3
go
create proc ThemTuyenbay
@MaTuyenBay char(20) ,@SANBAYDI_MaSanBay char(20) ,@SANBAYDEN_MaSanBay char(20) ,@SANBAYTRUNGGIAN_MaSanBay char(20)
as
begin
	if exists(select * from TUYENBAY where MaTuyenBay = @MaTuyenBay)
		begin
			print N'THÊM TUYENBAY KHÔNG THÀNH CÔNG, MaTuyenBay BỊ TRÙNG'
		end
	else
		begin
			if exists(select * from SANBAY where MaSanBay = @SANBAYDEN_MaSanBay)
				begin
					if exists (select * from SANBAY where MaSanBay =@SANBAYDI_MaSanBay)
						begin
							if exists (select * from SANBAY where MaSanBay = @SANBAYTRUNGGIAN_MaSanBay)
								begin
									print N'Thêm TUYENBAY Thành Công'
									insert TUYENBAY values(@MaTuyenBay,@SANBAYDI_MaSanBay,@SANBAYDEN_MaSanBay,@SANBAYTRUNGGIAN_MaSanBay)				
								end
							
							else if (@SANBAYTRUNGGIAN_MaSanBay is null)	
								begin
								print N'THÊM TUYENBAY THÀNH CÔNG'
									insert TUYENBAY values(@MaTuyenBay,@SANBAYDI_MaSanBay,@SANBAYDEN_MaSanBay,@SANBAYTRUNGGIAN_MaSanBay)				
								end
							else
								begin
									print N'THÊM TUYENBAY KHÔNG THÀNH CÔNG, MASANBAY KHÔNG TỒN TẠI'
								end 
						end
					else 
						begin
							print N'THÊM TUYENBAY KHÔNG THÀNH CÔNG, MASANBAY KHÔNG TỒN TẠI'
						end
				end
			else 
				begin
					print N'THÊM TUYENBAY KHÔNG THÀNH CÔNG, MASANBAY KHÔNG TỒN TẠI'
				end
		end
end 
go
--PROC Sửa TUYENBAY
create proc SuaTuyenBay
@MaTuyenBay char(20) ,@SANBAYDI_MaSanBay char(20) ,@SANBAYDEN_MaSanBay char(20) ,@SANBAYTRUNGGIAN_MaSanBay char(20)
as 
begin

	if exists(select * from TUYENBAY where MaTuyenBay = @MaTuyenBay)
	begin
			if exists(select * from SANBAY where MaSanBay = @SANBAYDEN_MaSanBay)
				begin
					if exists (select * from SANBAY where MaSanBay =@SANBAYDI_MaSanBay)
						begin
							if exists (select * from SANBAY where MaSanBay = @SANBAYTRUNGGIAN_MaSanBay)
								begin
									print N'CHỈNH SỬA TUYENBAY THÀNH CÔNG'
									update TUYENBAY
									set
									SANBAYDI_MaSanBay = @SANBAYDI_MaSanBay,
									SANBAYDEN_MaSanBay =@SANBAYDEN_MaSanBay,
									SANBAYTRUNGGIAN_MaSanBay = @SANBAYTRUNGGIAN_MaSanBay
									where MaTuyenBay = @MaTuyenBay		
								end
							
							else if (@SANBAYTRUNGGIAN_MaSanBay is null)	
								begin
								print N'CHỈNH SỬA TUYENBAY THÀNH CÔNG'
									update TUYENBAY
									set
									SANBAYDI_MaSanBay = @SANBAYDI_MaSanBay,
									SANBAYDEN_MaSanBay =@SANBAYDEN_MaSanBay,
									SANBAYTRUNGGIAN_MaSanBay = @SANBAYTRUNGGIAN_MaSanBay
									where MaTuyenBay = @MaTuyenBay		
								end
							else
								begin
									print N'CHỈNH SỬA TUYENBAY KHÔNG THÀNH CÔNG, MASANBAY KHÔNG TỒN TẠI'
								end 
						end
					else 
						begin
							print N'CHỈNH SỬA TUYENBAY KHÔNG THÀNH CÔNG, MASANBAY KHÔNG TỒN TẠI'
						end
				end
			else 
				begin
					print N'CHỈNH SỬA TUYENBAY KHÔNG THÀNH CÔNG, MASANBAY KHÔNG TỒN TẠI'
				end
		end
	else
		begin
			print N'CHỈNH SỬA TUYENBAY KHÔNG THÀNH CÔNG, MATUYENBAY KHÔNG TỒN TẠI'
		end
end
go
--PROC Xoá TUYENBAY
create proc XoaTuyenBay
@MaTuyenBay char(20)
as
begin
	if exists (select * from TUYENBAY where MaTuyenBay = @MaTuyenBay)
		begin
			print N'XOÁ TUYENBAY THÀNH CÔNG'
			delete TUYENBAY where MaTuyenBay = @MaTuyenBay
		end
	else 
		begin
			print N'XÓA TUYENBAY KHÔNG THÀNH CÔNG, MATUYENAY KHÔNG TỒN TẠI'
		end
end
go