--DROP DATABASE BTL_WF
--go

CREATE DATABASE BTL_WF 
GO

USE BTL_WF
go

create table Author(
	AuthorID nvarchar(20) primary key,
	AuthorName nvarchar(100) unique,
	Note nvarchar(200)
)

create table Category(
	CategoryID nvarchar(20) primary key,
	CategoryName nvarchar(100) unique
)

create table PublishingCompany(
	PubCompanyID nvarchar(20) primary key,
	PubCompanyName nvarchar(150) unique,
	Address nvarchar(50),
	Email nvarchar(50)
)

create table Book(
	BookID nvarchar(20) primary key,
	BookName nvarchar(100) unique,
	AuthorID nvarchar(20) foreign key references Author(AuthorID),
	CategoryID nvarchar(20) foreign key references Category(CategoryID),
	PubCompanyID nvarchar(20) foreign key references PublishingCompany(PubCompanyID),
	PublishingYear datetime
)

create table LibraryCard(
	CardID nvarchar(20) primary key,
	DateBegin datetime,
	DateEnd datetime,
	Note nvarchar(200)
)

create table Reader(
	ReaderID nvarchar(20) primary key,
	ReaderName nvarchar(100) unique,
	Address nvarchar(50),
	CardID nvarchar(20) foreign key references LibraryCard(CardID)
)

create table Borrow(
	BorrowID nvarchar(20) primary key,
	CardID nvarchar(20) foreign key references LibraryCard(CardID),
	BookID nvarchar(20) foreign key references Book(BookID),
	DateBorrow datetime
)

create table Pay(
	BorrowID nvarchar(20) foreign key references Borrow(BorrowID),
	Note nvarchar(200),
	Payment bit
)

insert into Author(AuthorID, AuthorName, Note)
values('A001',N'Haruki Murakami',N'Tác giả'),
('A002',N'Nguyễn Nhật Ánh',N'Tác giả')
go

insert into Category(CategoryID, CategoryName)
values('C001',N'Trinh thám'),
('C002',N'Tình cảm')
go

insert into PublishingCompany(PubCompanyID, PubCompanyName, Address, Email)
values('P001',N'Nxb Kim Đồng', N'Thanh Xuân - Hà Nội', 'nxbkimdong@gmail.com'),
('P002' ,N'Nxb Trẻ', N'Thanh Xuân - Hà Nội', 'nxbtre@gmail.com')
go

insert into Book(BookID, BookName, AuthorID, CategoryID, PubCompanyID, PublishingYear)
values('B001',N'Rừng Nauy', 'A001', 'C002', 'P001', 2021-09-21),
('B002' ,N'Chế độ ăn trường thọ', 'A001', 'C002', 'P001', 2022-01-11),
('B003' ,N'Cho tôi xin vé đi tuổi thơ', 'A002', 'C002', 'P002', 2019-02-21),
('B004' ,N'Mắt biếc', 'A002', 'C002', 'P002', 2020-12-05),
('B005' ,N'Tôi thấy hoa vàng trên cỏ xanh', 'A002', 'C002', 'P002', 2022-06-23),
('B006' ,N'Kafka bên bờ biển', 'A001', 'C001', 'P001', 2018-05-13),
('B007' ,N'Biên niên ký chim vặn dây cót', 'A001', 'C001', 'P001', 2020-08-11),
('B008' ,N'1Q84', 'A001', 'C001', 'P002', 2021-09-12),
('B009' ,N'Cuộc săn cừu hoang', 'A001', 'C001', 'P001', 2019-11-01),
('B010' ,N'Sau nửa đêm', 'A001', 'C001', 'P001', 2022-06-09)
go

insert into LibraryCard(CardID, DateBegin, DateEnd, Note)
values('LC001',2022-05-30, 2022-07-30, N'Ghi chú'),
('LC002' , 2022-07-28, 2022-09-30, N'Ghi chú')
go

insert into Reader(ReaderID, ReaderName, Address, CardID)
values('R001',N'Đỗ Đức Nhật', N'Thanh Xuân - Hà Nội', 'LC001'),
('R002' ,N'Đàm Bá Bằng', N'Thanh Xuân - Hà Nội', 'LC002')
go

CREATE TRIGGER borrow_tri ON Borrow AFTER INSERT AS INSERT Pay (BorrowID, Note, Payment) SELECT BorrowID, N'Ghi chú', 0 FROM inserted
go

insert into Borrow(BorrowID, CardID, BookID,  DateBorrow)
values('BR001','LC002', 'B001', 2022-07-15),
('BR002','LC002', 'B005', 2022-07-15),
('BR003','LC002', 'B002', 2022-07-15),
('BR004','LC002', 'B003', 2022-07-15),
('BR005' ,N'LC001', 'B009', 2022-06-30),
('BR006' ,N'LC001', 'B010', 2022-06-30),
('BR007' ,N'LC001', 'B008', 2022-06-30)
go

select * from Author
select * from Category
select * from PublishingCompany
select * from Book
select * from LibraryCard
select * from Reader
select * from Borrow
select * from Pay