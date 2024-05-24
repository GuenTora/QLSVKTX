create database QLSV
use QLSV

create table SinhVien(
	MaSV char(8) primary key ,
	HoTen nvarchar(100) not null,
	NgaySinh date,
	GioiTinh nvarchar(3),
	CCCD char(12) not null unique,
	DiaChi nvarchar(100),
	SDT char(10) unique,
	MaPhong nvarchar(5) ,
	MaToa nvarchar(5),
	anh image,
	duyet bit
)

create table QuanLy(
	MaQL nvarchar(5) primary key,
	HoTen nvarchar(100) not null,
	MaToaQL nvarchar(5) not null,
	ChucVu nvarchar(30) not null
)



create table TaiKhoan (
	TaiKhoan nvarchar(100) primary key,
	MatKhau nvarchar(100)not null,
	CapBac int not null
)


create table Toa(
	MaToa nvarchar(5) primary key ,
	TenToa nvarchar(100) not null,
	GioiTinh nvarchar(3) not null
)


create table Phong(
	MaPhong nvarchar(5) primary key ,
	LoaiPhong nvarchar(10) not null,
	MaToa nvarchar(5) not null,
	SoNguoiDaO int not null
)


create table LoaiPhong(
	MaLoaiPhong nvarchar(10) primary key ,
	TenLoaiPhong nvarchar(30) not null,
	SoNguoi nvarchar(3) not null,
	GiaPhong float not null,
	GiaDV float not null
)

create table SuKienDatPhong(
    MaSK INT PRIMARY KEY identity,
    MaPhong NVARCHAR(5) NOT NULL,
    MaSV CHAR(8) NOT NULL,
    MaToa NVARCHAR(5) ,
    SoKy int NOT NULL,
    NgayNhanPhong DATE NOT NULL,
    NgayTraPhong date,
	SoTien float
)



create table TienDien(
	MaPhong nvarchar(5) ,
	Thang int check (Thang > 0 AND Thang <= 12),
	SoDienDauThang int not null,
	SoDienCuoiThang int not null,
	TienDien float
	primary key(MaPhong,Thang)
)

create table TienNuoc(
	MaPhong nvarchar(5) ,
	Thang int check (Thang > 0 AND Thang <= 12),
	SoNuocDauThang int not null,
	SoNuocCuoiThang int not null,
	TienNuoc float
	primary key(MaPhong,Thang)
)

create table HoaDonDN(
	MaHD int primary key,
	MaPhong nvarchar(5) not null,
	Thang int not null check (Thang > 0 AND Thang <= 12),
	TongTien float not null,
	TrangThai bit not null
)
create table KyLuat (
	MaKL char(5) primary key,
	MaSV char(8),
	MaToa nvarchar(5),
	LoaiViPham nvarchar(20),
	NgayKL date
)

create table GiaHan (
    MaSV CHAR(8) primary key,
    SoKy int NOT NULL,
	duyet bit
)

insert into QuanLy values('QL00A','Duong','A','Quan Ly')
insert into QuanLy values('QL00B','Nguyen','B','Quan Ly')
insert into QuanLy values('QL00C','Bang','C','Quan Ly')
insert into QuanLy values('QL00D','Bong','D','Quan Ly')


insert into TaiKhoan values ('QL00A','QL00A',1);
insert into TaiKhoan values ('QL00B','QL00B',1);
insert into TaiKhoan values ('QL00C','QL00C',1);
insert into TaiKhoan values ('QL00D','QL00D',1);

insert into Toa values ('A','Toa A', 'nam'),
						('B','Toa B', 'nu'),
						('C','Toa C', 'nam'),
						('D','Toa D','nu')

insert into Phong values('A-01','P-8SV','A',0),
						('A-02','P-8SV','A',0),
						('A-03','P-8SV','A',0),
						('B-01','P-6SV','B',0),
						('B-02','P-6SV','B',0),
						('B-03','P-6SV','B',0),
						('C-01','P-4SV','C',0),
						('C-02','P-4SV-DV1','C',0),
						('C-03','P-4SV-DV2','C',0),
						('D-01','P-2SV','D',0),
						('D-02','P-2SV-DV1','D',0),
						('D-03','P-2SV-DV2','D',0)

insert into LoaiPhong values ('P-8SV','Phong 8 SV',8,180000,0),
							('P-6SV','Phong 6 SV',6,240000,0),
							('P-4SV','Phong 4 SV',4,650000,0),
							('P-4SV-DV1','Phong 4 SV co May Lanh',4,650000,240000),
							('P-4SV-DV2','Phong 4 SV day du thiet bi',4,650000,420000),
							('P-2SV','Phong 2',2,1250000,0),
							('P-2SV-DV1','Phong 2 co May Lanh',2,1250000,420000),
							('P-2SV-DV2','Phong 2 co day du thiet bi',2,1250000,1240000)

--foreignKey
ALTER TABLE SinhVien ADD FOREIGN KEY(MaPhong) REFERENCES Phong(MaPhong)
ALTER TABLE SinhVien ADD FOREIGN KEY(MaToa) REFERENCES Toa(MaToa)
ALTER TABLE QuanLy ADD FOREIGN KEY(MaToaQL) REFERENCES Toa(MaToa)
ALTER TABLE Phong ADD FOREIGN KEY(MaToa) REFERENCES Toa(MaToa)
ALTER TABLE Phong ADD FOREIGN KEY(LoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong)
ALTER TABLE SuKienDatPhong ADD FOREIGN KEY(MaPhong) REFERENCES Phong(MaPhong)
ALTER TABLE SuKienDatPhong ADD FOREIGN KEY(MaSV) REFERENCES SinhVien(MaSV)
ALTER TABLE SuKienDatPhong ADD FOREIGN KEY(MaToa) REFERENCES Toa(MaToa)
ALTER TABLE HoaDonDN ADD FOREIGN KEY(MaPhong) REFERENCES Phong(MaPhong)
ALTER TABLE KyLuat ADD FOREIGN KEY(MaSV) REFERENCES SinhVien(MaSV)
ALTER TABLE KyLuat ADD FOREIGN KEY(MaToa) REFERENCES Toa(MaToa)
ALTER TABLE HoaDonDN ADD FOREIGN KEY(MaPhong,Thang) REFERENCES TienDien(MaPhong,Thang) 
ALTER TABLE HoaDonDN ADD FOREIGN KEY(MaPhong,Thang) REFERENCES TienNuoc(MaPhong,Thang) 
ALTER TABLE TienDien ADD FOREIGN KEY(MaPhong) REFERENCES Phong(MaPhong)
ALTER TABLE TienNuoc ADD FOREIGN KEY(MaPhong) REFERENCES Phong(MaPhong)

CREATE LOGIN  QL00A   WITH PASSWORD = 'QL00A';
CREATE USER  QL00A   FOR LOGIN  QL00A ; 

CREATE LOGIN  QL00B   WITH PASSWORD = 'QL00B';
CREATE USER  QL00B   FOR LOGIN  QL00B ; 

CREATE LOGIN  QL00C   WITH PASSWORD = 'QL00C';
CREATE USER  QL00C   FOR LOGIN  QL00C ; 

USE QLSV
GO
CREATE ROLE QL;
GRANT Select, Insert, Update,Delete on SinhVien  to QL
GRANT Select, Insert, Update,Delete on QuanLy  to QL;
GRANT Select, Insert, Update,Delete on HoaDonDN  to QL;
GRANT Select, Insert, Update,Delete on KyLuat  to QL;
GRANT Select, Insert, Update,Delete on Phong  to QL;
GRANT Select, Insert, Update,Delete on SuKienDatPhong  to QL;
GRANT Select, Insert, Update,Delete on TaiKhoan  to QL;
GRANT Select, Insert, Update,Delete on TienDien  to QL;
GRANT Select, Insert, Update,Delete on TienNuoc  to QL;
GRANT EXECUTE TO QL;
GRANT EXECUTE ON USP_ThemHoaDonNuoc TO QL;
GRANT EXECUTE ON UTP_CapNhatSinhVien TO QL;
GRANT EXECUTE ON USP_ThemHoaDonDien TO QL;
GRANT SELECT ON XemBangSinhVien TO QL;

EXEC sp_addrolemember QL, QL00A;
EXEC sp_addrolemember QL, QL00B;
EXEC sp_addrolemember QL, QL00C;
EXEC sp_addrolemember QL, QL00D;

------------------------------------------------------------------------------------------------------------------------------------------
--FUNCTION
create function TinhTienSKDP(@MaPhong nvarchar(10))
returns int
as
begin
	Declare @SoTien1 float , @SoTien2 float
	select @SoTien1 = GiaPhong,@SoTien2 = GiaDV from phong inner join LoaiPhong on phong.LoaiPhong = LoaiPhong.MaLoaiPhong 
	where phong.MaPhong = @MaPhong
	declare @SoTien3 float = @SoTien1 + @SoTien2
	return @SoTien3
end

------------------------------------------------------------------------------------------------------------------------------------------
alter FUNCTION XemBangSinhVien(@Toa nvarchar(5))
RETURNS table	
AS
return(
    select * from SinhVien where MaToa = @Toa and duyet = 1
);

------------------------------------------------------------------------------------------------------------------------------------------
create FUNCTION KiemTraSoLuong(@MaSV char(8))
RETURNS int
AS
begin
	Declare @count int
    select @count = count(*) from SinhVien where MaSV = @MaSV
	RETURN @count
end;

------------------------------------------------------------------------------------------------------------------------------------------
create FUNCTION tinhsodiennuoc(@so1 int, @so2 int)
RETURNS int
AS
begin
	declare @so int = @so2 -@so1
	return @so
end
------------------------------------------------------------------------------------------------------------------------------------------
create FUNCTION laysonguoitrongphong(@maphong nvarchar(5))
RETURNS int
AS
begin
	declare @count int
	select @count = SoNguoiDaO from Phong where @maphong =MaPhong
	return @count
end
------------------------------------------------------------------------------------------------------------------------------------------
--PROC
create proc USP_GiaHanHopDongSV
@mssv nvarchar(10),
@soky int
as
begin
		declare @count int
		select @count = count(*) from GiaHan where MaSV = @mssv
		if(@count=0)
			insert into GiaHan values(@mssv,@soky,0)
		else
		begin
			raiserror('Đã đăng ký gia hạn',16,2)
			rollback
		end
end
------------------------------------------------------------------------------------------------------------------------------------------
create proc USP_TimKiemHopDongTheoSV
@mssv nvarchar(10)
as
begin
		select * from SuKienDatPhong where MaSV = @mssv
end

USP_TimKiemHopDongTheoSV '20142481'
------------------------------------------------------------------------------------------------------------------------------------------
create proc UTP_XemHoaDonSV
@maphong nvarchar(5), 
@thang int 
as
begin
		declare @count int
		select @count = count(*) from HoaDonDN where Thang = @thang and @maphong = @maphong
		if(@count = 0)
		begin
			raiserror('Not Found',16,3)
			rollback
		end
		else
		begin
			declare @songuoidao int = dbo.laysonguoitrongphong(@maphong)
			select MaHD,MaPhong,Thang,TongTien/@songuoidao as TongTien,TrangThai from HoaDonDN where Thang = @thang and MaPhong = @maphong
		end
end

------------------------------------------------------------------------------------------------------------------------------------------
UTP_XemHoaDonSV 'A-01' , 10

create proc UTP_SuaSVDoSvThucHien
@HoTen nvarchar(50),
@ngaysinh date,
@gioitinh nchar(3),
@cccd char(12),
@diachi nvarchar(100),
@sdt char(10),
@anh image,
@MaSV char(8)
as
begin
	UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, CCCD = @cccd, DiaChi = @diachi, SDT = @sdt,anh = @anh WHERE MaSV = @MaSV
end
------------------------------------------------------------------------------------------------------------------------------------------
create proc USP_ThemHoaDonNuoc
	@MaPhong nvarchar(5) ,
	@Thang int,
	@SoNuocDauThang int,
	@SoNuocCuoiThang int

as
if (@SoNuocCuoiThang >@SoNuocDauThang)
begin
	declare @TongTien int = dbo.tinhsodiennuoc(@SoNuocDauThang,@SoNuocCuoiThang)
	if(@TongTien <= 10)
		insert into TienNuoc values(@MaPhong,@Thang,@SoNuocDauThang,@SoNuocCuoiThang,@TongTien*5973)
	else if(@TongTien >  10 and  @TongTien <= 20)
		insert into TienNuoc values(@MaPhong,@Thang,@SoNuocDauThang,@SoNuocCuoiThang,(@TongTien-10)*7052 + 10*5973)
	else if(@TongTien > 20 and  @TongTien <= 30)
		insert into TienNuoc values(@MaPhong,@Thang,@SoNuocDauThang,@SoNuocCuoiThang,(@TongTien-20)*8669+ 10*7052 + 10*5973)
	else if(@TongTien > 30)
		insert into TienNuoc values(@MaPhong,@Thang,@SoNuocDauThang,@SoNuocCuoiThang,(@TongTien-30)*15925+10*8669+ 10*7052 + 10*5973)
end
else
	begin
		raiserror('insert fail',16,4)
		rollback
	end

------------------------------------------------------------------------------------------------------------------------------------------
create proc USP_ThemHoaDonDien
	@MaPhong nvarchar(5) ,
	@Thang int,
	@SoDienDauThang int,
	@SoDienCuoiThang int
as
if (@SoDienCuoiThang > @SoDienDauThang)
begin
	declare @TongTien int = dbo.tinhsodiennuoc(@SoDienDauThang,@SoDienCuoiThang)
	if(@TongTien <= 50)
		insert into TienDien values(@MaPhong,@Thang,@SoDienDauThang,@SoDienCuoiThang,@TongTien*1678)
	else if(@TongTien > 50 and  @TongTien <= 100)
		insert into TienDien values(@MaPhong,@Thang,@SoDienDauThang,@SoDienCuoiThang,(@TongTien-50)*1734 + 50 * 1678)
	else if(@TongTien > 100 and  @TongTien <= 200)
		insert into TienDien values(@MaPhong,@Thang,@SoDienDauThang,@SoDienCuoiThang,(@TongTien-100)*2014 + 50 * 1678+ 50* 1734)
	else if(@TongTien > 200 and  @TongTien <= 300)
		insert into TienDien values(@MaPhong,@Thang,@SoDienDauThang,@SoDienCuoiThang,(@TongTien-200)*2536 + 50 * 1678+ 50* 1734+ 100* 2014)
	else if(@TongTien > 301 and  @TongTien <= 400)
		insert into TienDien values(@MaPhong,@Thang,@SoDienDauThang,@SoDienCuoiThang,(@TongTien-300)*2834 + 50 * 1678+ 50* 1734+ 100* 2014 + 100 * 2536)
	else if(@TongTien > 400)
		insert into TienDien values(@MaPhong,@Thang,@SoDienDauThang,@SoDienCuoiThang,(@TongTien-400)*2927 + 50 * 1678+ 50* 1734+ 100* 2014 + 100 * 2536 + 100 * 2834)
end
else
	begin
		raiserror('khong hop le',16,5)
		rollback
	end


------------------------------------------------------------------------------------------------------------------------------------------
create proc UTP_CapNhatSinhVien
@MaSV char(8),
	@HoTen nvarchar(100),
	@NgaySinh date,
	@GioiTinh char(3),
	@CCCD char(12) ,
	@DiaChi nvarchar(100),
	@SDT char(10),
	@MaPhong nvarchar(5) ,
	@MaToa nvarchar(5) 
as
begin
	declare @count1 int, @count2 int
		select @count1 = LoaiPhong.SoNguoi, @count2 = phong.SoNguoiDaO from phong inner join LoaiPhong on phong.LoaiPhong = LoaiPhong.MaLoaiPhong 
		where phong.MaPhong = @MaPhong
		if(@count2 < @count1)
			update SinhVien set MaSV= @MaSV, HoTen = @HoTen, NgaySinh =@NgaySinh,GioiTinh = @GioiTinh,CCCD = @CCCD,DiaChi = @DiaChi,SDT =@SDT,MaPhong = @MaPhong,MaToa = @MaToa where MaSV= @MaSV 
end

------------------------------------------------------------------------------------------------------------------------------------------
create proc UTP_ThemSinhVien
@MaSV char(8),
@HoTen nvarchar(100), 
@NgaySinh date,
@GioiTinh nvarchar(3),
@CCCD char(12),
@DiaChi nvarchar(100),
@SDT char(10) ,
@MaToa nvarchar(5),
@MaPhong nvarchar(5) ,
@SoKy int,
@anh image
as
begin

	declare @count int ;
	select @count = dbo.KiemTraSoLuong(@MaSV)
	if(@count = 0)
	begin
		declare @count1 int, @count2 int
		select @count1 = LoaiPhong.SoNguoi, @count2 = phong.SoNguoiDaO from phong inner join LoaiPhong on phong.LoaiPhong = LoaiPhong.MaLoaiPhong 
		where phong.MaPhong = @MaPhong
		if(@count2 < @count1)
		begin
			insert into SinhVien values (@MaSV,@HoTen,@NgaySinh,@GioiTinh,@CCCD,@DiaChi,@SDT,@MaPhong,@MaToa,@anh,0)
			insert into SuKienDatPhong(MaPhong,MaSV,MaToa,SoKy,NgayNhanPhong) values (@MaPhong,@MaSV,@MaToa,@SoKy,getdate())
		end
	end	
	else
	begin
		raiserror('insert fail',16,6)
		rollback
	end
end


------------------------------------------------------------------------------------------------------------------------------------------
--Các trigger
alter trigger UTG_SuaSKDatPhong
on sukiendatphong after update
as
begin
	declare @Maphong nvarchar(30),@MaSV char(30)
	select @Maphong = MaPhong,@MaSV = MaSV from inserted
	declare @SoTien3 float = dbo.TinhTienSKDP(@Maphong)
	update SuKienDatPhong set NgayTraPhong = DATEADD(MONTH, soky * 4 ,GETDATE()), SoTien = @SoTien3 * SoKy where MaSV = @MaSV
	delete GiaHan where MaSV = @MaSV
end



------------------------------------------------------------------------------------------------------------------------------------------
alter trigger UTG_ThemSinhVien
on SinhVien after update
as
begin
	declare @mssv char(8), @MaPhong nvarchar(5),@duyet bit = 0,@duyet1 bit = 0
	select @duyet1=duyet from deleted
	select @mssv = MaSV,@MaPhong = MaPhong,@duyet=duyet from inserted 
	if(@duyet != @duyet1)
	begin
		insert into TaiKhoan values (@mssv,@mssv,0)
		update Phong set SoNguoiDaO = SoNguoiDaO + 1 where @MaPhong = MaPhong
		DECLARE @Query NVARCHAR(MAX);
		SET @Query = 'CREATE LOGIN SV' +@mssv + ' WITH PASSWORD = ''' + @mssv +'''';
		EXEC sys.sp_executesql @Query
		SET @Query = 'CREATE USER SV' + @mssv+ ' FOR LOGIN SV' + @mssv ;
		print @Query
		EXEC sys.sp_executesql @Query
		SET @Query = 'GRANT Select, Insert, Update on SinhVien to SV' + @mssv 
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select, Insert, Update on Phong to SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select, Insert, Update on SuKienDatPhong to SV' + @mssv 
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select, Insert, Update on TaiKhoan to SV' + @mssv 
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select on TienDien to SV' + @mssv  
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select on TienNuoc to SV' + @mssv 
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select on KyLuat to SV' + @mssv 
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT Select, Insert, Update on HoaDonDN to SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON USP_TimKiemHopDongTheoSV TO SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON UTP_SuaSVDoSvThucHien TO SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON UTP_XemHoaDonSV TO SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON USP_GiaHanHopDongSV TO SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON UTP_XemKyLoat TO SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON dbo.TimSoTienTheoKy TO SV' + @mssv
			EXEC sys.sp_executesql @Query
		SET @Query ='GRANT EXECUTE ON UTP_XemThanhVien TO SV' + @mssv
			EXEC sys.sp_executesql @Query		
	end
end
------------------------------------------------------------------------------------------------------------------------------------------
alter trigger UTG_XoaSinhVien
on SinhVien INSTEAD OF delete
as
begin
	declare @mssv char(10), @MaPhong nvarchar(10)
	select @mssv = MaSV, @MaPhong = MaPhong from deleted
	DECLARE @username varchar(15) = 'SV'+ @mssv

		DECLARE @sql varchar(100)
		DECLARE @SessionID INT;
		SELECT @SessionID = session_id
		FROM sys.dm_exec_sessions
		WHERE login_name = @username;
		IF @SessionID IS NOT NULL
		BEGIN
			SET @sql = 'kill ' + Convert(NVARCHAR(20), @SessionID)
			exec(@sql)
			END
			 BEGIN TRANSACTION;
			 BEGIN TRY
		 		delete from SuKienDatPhong where MaSV = @mssv
				delete from GiaHan where MaSV = @mssv
				delete from SinhVien where MaSV = @mssv
				delete from TaiKhoan where TaiKhoan = @mssv
				update Phong set SoNguoiDaO = SoNguoiDaO - 1 where @MaPhong = MaPhong
		--
				SET @sql = 'DROP USER SV'+ @username
				exec (@sql)
				--
				SET @sql = 'DROP LOGIN SV'+ @username
				exec (@sql)
				--
				delete from TaiKhoan where TaiKhoan = @mssv
		END TRY
		BEGIN CATCH
				DECLARE @err NVARCHAR(MAX)
				SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
				RAISERROR(@err, 16, 1)
				ROLLBACK TRANSACTION;
				THROW;
		END CATCH
		 COMMIT TRANSACTION;
end
------------------------------------------------------------------------------------------------------------------------------------------
alter trigger UTG_ThemSKDatPhong
on sukiendatphong after insert
as
begin
	declare @Maphong nvarchar(30),@MaSV char(30)
	select @Maphong = MaPhong,@MaSV = MaSV from inserted
	
	declare @SoTien3 float = dbo.TinhTienSKDP(@Maphong)
	update SuKienDatPhong set NgayTraPhong = DATEADD(MONTH, soky * 4 ,GETDATE()), SoTien = @SoTien3 * SoKy where MaSV = @MaSV
end
------------------------------------------------------------------------------------------------------------------------------------------
create trigger UTG_ThemHoaDon
on HoaDonDN after insert
as
begin
	declare @TienDien float, @MaPhong nvarchar(5)
	declare @TienNuoc float,@Thang int
	
	select @MaPhong = MaPhong,@Thang = Thang  from inserted
	select @TienDien =TienDien from TienDien Where MaPhong = @MaPhong and Thang = @Thang
	select @TienNuoc =TienNuoc from TienNuoc Where MaPhong = @MaPhong and Thang = @Thang
	declare @TongTien float = @TienDien + @TienNuoc

	Update HoaDonDN set TongTien = @TongTien where MaPhong = @MaPhong and Thang = @Thang

end
------------------------------------------------------------------------------------------------------------------------------------------
create trigger UTG_GiaHan
on GiaHan after update
as
begin
	declare @mssv char(8),@duyet bit = 0, @duyet1 bit = 0,@soky int
	select @duyet1 = duyet from deleted
	select @duyet = duyet,@mssv = MaSV,@soky = soky from inserted 
	if(@duyet != @duyet1)
	begin
		update SuKienDatPhong set SoKy = SoKy + @soky where MaSV = @mssv
	end
end
------------------------------------------------------------------------------------------------------------------------------------------
--view
create view USV_HOPDONG as
select MaSV,MaPhong,NgayNhanPhong,NgayTraPhong,soky,SoTien from SuKienDatPhong

------------------------------------------------------------------------------------------------------------------------------------------
create view USV_HOPDONGBoiAdmin as
select Matoa,MaSV,MaPhong,SoTien from SuKienDatPhong
select * from USV_HOPDONGBoiAdmin

------------------------------------------------------------------------------------------------------------------------------------------
create view USV_SinhVien as
select MaSV,MaPhong,MaToa  from SinhVien

------------------------------------------------------------------------------------------------------------------------------------------
create view USV_Toa as 
select * from Toa

------------------------------------------------------------------------------------------------------------------------------------------
UPDATE SinhVien SET HoTen = N'Dương1', NgaySinh = '2002-1-6', GioiTinh = 'Nam', CCCD = '123456789101', DiaChi = 'HonDAT', SDT = '1234567891' WHERE MaSV = '20142481'


UPDATE SinhVien SET HoTen = N'Dương', NgaySinh = '2002-1-6', GioiTinh = 'Nam', CCCD = '123456789103', DiaChi = 'HonDAT', SDT = '1234567893',anh = '',duyet=1 WHERE MaSV = '20142481'
UTP_ThemSinhVien '20142481',N'Dương','2002-1-6','Nam','123456789101','HonDAT','1234567891','A','A-01','1',''
USP_InsertElectricityBill 'A',1,10,50

Delete from SinhVien where MaSV ='20142481'



select *  from USV_Toa 

usv_toa

USP_ThemHoaDonDien 'A-02',1,1,20
USP_ThemHoaDonNuoc 'A-02',1,1,22

USP_ThemHoaDonDien 'B-01',1,1,50
USP_ThemHoaDonNuoc 'B-01',1,1,50

USP_ThemHoaDonDien 'C-01',2,1,30
USP_ThemHoaDonNuoc 'C-01',2,1,35

insert into HoaDonDN values(3,'A-02',1,0,0)
insert into HoaDonDN values(2,'B-01',1,0,0)
insert into HoaDonDN values(4,'C-01',2,0,0)



