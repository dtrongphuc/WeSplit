CREATE TABLE CHUYENDI
(
	MACD INT NOT NULL  IDENTITY,
	TENCD NVARCHAR(100),
	TRANGTHAI INT,
	NGAYDI DATE,
	NGAYKT DATE,
	DODAI INT,

	CONSTRAINT PK_CHUYENDI
	PRIMARY KEY(MACD)
)

CREATE TABLE THANHVIEN
(
	MATV INT NOT NULL IDENTITY,
	MACD INT,
	HOTEN NVARCHAR(50),
	NHATKY NVARCHAR(MAX),
	SDT VARCHAR(15),
	TRANGTHAI INT,
	

	CONSTRAINT PK_THANHVIEN
	PRIMARY KEY(MATV,MACD)
)

CREATE TABLE DIADIEM
(
	MADD INT NOT NULL IDENTITY,
	MACD INT,
	STT INT,
	TENDD NVARCHAR(50),

	CONSTRAINT PK_DIADIEM
	PRIMARY KEY(MADD,MACD,STT)
)

CREATE TABLE HINHANH
(
	MACD INT,
	HINHANH VARCHAR(100),
)

CREATE TABLE THUCHI
(
	MATV INT,
	MACD INT,
	TENKHOANCHI NVARCHAR(100),
	TIEN INT,
	

	CONSTRAINT PK_THUCHI
	PRIMARY KEY(MACD,TENKHOANCHI)
)

ALTER TABLE THANHVIEN ADD CONSTRAINT FK_THANHVIEN_CHUYENDI FOREIGN KEY(MACD) REFERENCES CHUYENDI(MACD)

ALTER TABLE DIADIEM ADD CONSTRAINT FK_DIADIEM_CHUYENDI FOREIGN KEY (MACD) REFERENCES CHUYENDI(MACD)

ALTER TABLE HINHANH ADD CONSTRAINT FK_HINHANH_CHUYENDI FOREIGN KEY(MACD) REFERENCES CHUYENDI(MACD)

ALTER TABLE THUCHI ADD CONSTRAINT FK_THUCHI_CHUYENDI FOREIGN KEY (MACD) REFERENCES CHUYENDI(MACD)

ALTER TABLE THUCHI ADD CONSTRAINT FK_THUCHI_THANHVIEN FOREIGN KEY (MATV,MACD) REFERENCES THANHVIEN(MATV,MACD)

--ALTER TABLE CHUYENDI ALTER COLUMN TENCD NVARCHAR(100)
drop table THUCHI
ALTER TABLE THUCHI DROP CONSTRAINT FK_THUCHI_THANHVIEN

-- CHUYENDI
INSERT INTO CHUYENDI
VALUES



( N'NHỮNG NGÀY LỂ TUYỆT VỜI , MỘT CUNG ĐƯỜNG TUYỆT ĐẸP VĨNH HY - KHÁNH SƠN - TÀ GỤ !', 0, '04/30/2020', '05/03/2020',585),
(
	N'Trong lòng Huế - Những ngày trước cách ly', 0, '02/24/2020', '02/28/2020', 930
),
(
	N'Một cung đường tuyệt đẹp VĨNH HY - KHÁNH SƠN - TÀ GỤ', 1, '07/13/2020', NULL, 834
)
GO
SELECT IDENT_CURRENT('CHUYENDI') AS SOLUONG
-- THANHVIEN
INSERT INTO THANHVIEN
VALUES
( 3, N'Nguyễn Hữu Thọ')



(
	1, N'Quyền Thiên Ân', '', '0355593654',0
),
(
	1, N'Diệp Khánh Quỳnh',
	N'Cuối tháng 2 mình đặt vé đi Huế. Nước ngoài đã không được đi, mà mấy hôm nữa tình hình căng thẳng thêm cũng chết, thôi thì Việt Nam còn đang an toàn, ta liều mình đi nốt 1 chuyến rồi về đóng cửa cách ly cũng được. Thế là rủ thêm 1 vài đứa bạn, khăn gói quả mướp, lên đường thôi…!!!',
	'0755579367',0
),
(
	1, N'Lê Cẩm Nhung', '', '0755514431',0
),
(
	1, N'Phan Mạnh Thắng',
	N'Ở Huế cần lưu ý một việc, người dân Huế ăn uống rất sớm nên các bạn muốn ăn ngon phải theo giờ ăn của người dân ở đây mới ăn ngon được.',
	'0755514431',1
),
(
	2, N'Vĩnh Nguyên Khang', '', '0955587770', 0
),
(
	2, N'Bùi Ðức Cường', '', '0355549118', 0
),
(
	2, N'Lý Gia Bình',
	N'Mọi người đang đổ xô lên Đà Lạt , riêng nhóm mình cứ thẳng hướng Phan Thiết thôi ! Chào mọi người nhé .. Ha... ha , vậy mình đã may mắn khi lựa chọn quốc lộ 1A ...'
	, '0355549118', 1
),
(
	2, N'Lê Bảo Toàn', '', '0906559365', 0
),
(
	2, N'Kiều Ý Lan', '0755594992', '0906559365', 0
),
(
	2, N'Trần Hà Mi', '0355560855', '0355533264', 0
)
GO

-- DIA DIEM
INSERT INTO DIADIEM
VALUES
(
	1, 1, N'Homestay The Purple Hue'
),
(
	1, 2, N'Đại Nội'
),
(
	1, 3, N'Lăng Tự Đức'
),
(
	1, 4, N'Lăng Minh Mạng'
),
(
	2, 1, N'Vĩnh Hy'
),
(
	2, 2, N'Khánh Sơn'
),
(
	2, 3, N'Tà Gụ'
)
GO

-- HINH ANH
INSERT INTO HINHANH
VALUES
( 1, '/Resource/Images/1_1.png' ),
( 1, '/Resource/Images/1_2.jpg' ),
( 1, '/Resource/Images/1_3.jpg' ),
( 1, '/Resource/Images/1_4.jpg' ),
( 1, '/Resource/Images/1_5.jpg' ),
( 1, '/Resource/Images/1_6.jpg' ),
( 1, '/Resource/Images/1_7.jpg' ),
( 1, '/Resource/Images/1_8.jpg' ),
( 1, '/Resource/Images/1_9.jpg' ),
( 1, '/Resource/Images/1_10.png' ),
( 2, '/Resource/Images/2_1.png' ),
( 2, '/Resource/Images/2_2.jpg' ),
( 2, '/Resource/Images/2_3.jpg' ),
( 2, '/Resource/Images/2_4.jpg' ),
( 2, '/Resource/Images/2_5.jpg' ),
( 2, '/Resource/Images/2_6.jpg' ),
( 2, '/Resource/Images/2_7.jpg' ),
( 2, '/Resource/Images/2_8.jpg' ),
( 2, '/Resource/Images/2_9.jpg' ),
( 2, '/Resource/Images/2_10.png' )
GO

-- THU CHI
INSERT INTO THUCHI
VALUES
--(
--	4, 1, N'Ăn sáng', 80000
--),
--(
--	4, 1, N'Ăn trưa', 80000
--),
--(
--	4, 1, N'Ăn tối', 120000
--),
--(
--	1, 1, N'Đặt xe', 40000
--),
--(
--	4, 1, N'Thuê Homestay', 2000000
--),
(7, 2, N'Áo mưa', 400000),
(7, 2, N'Ăn sáng', 320000),
(7, 2, N'Ăn trưa', 480000),
(7, 2, N'Ăn tối', 270000),
--(3, 2, N'Uống cafe', 300000),
(6, 2, N'Thuê xe', 240000)
GO
SELECT*FROM THUCHI

DELETE FROM THUCHI WHERE MACD =2
select* from chuyendi
select* from thanhvien
select * from thuchi
select* from hinhanh
SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.TRANGTHAI=1 AND TV.TRANGTHAI=1
SELECT TC.*,TV.HOTEN FROM THUCHI AS TC JOIN THANHVIEN AS TV ON TC.MATV = TV.MATV AND TC.MACD = TV.MACD WHERE TC.MACD =1

SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.MACD=1
GROUP BY CD.MACD,CD.TENCD,CD.TRANGTHAI,CD.NGAYKT,CD.NGAYDI,CD.DODAI,TV.HOTEN

SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD 

SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.TRANGTHAI=0 AND TV.TRANGTHAI=1

UPDATE CHUYENDI SET TRANGTHAI = 1 , NGAYKT = '07/16/2020' WHERE MACD = 1

SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.TRANGTHAI=1 AND TV.TRANGTHAI=1

SELECT TC.*,TV.HOTEN,TV.SDT FROM THUCHI AS TC RIGHT JOIN THANHVIEN AS TV ON TC.MATV = TV.MATV AND TC.MACD = TV.MACD WHERE TC.MACD =1

SELECT TV.MACD,TV.MATV,TV.HOTEN,TV.SDT,TC.TENKHOANCHI,TC.TIEN FROM THANHVIEN AS TV LEFT JOIN THUCHI AS TC ON TV.MATV=TC.MATV AND TV.MACD = TC.MACD WHERE TV.MACD=1

SELECT * FROM THUCHI
SELECT * FROM THANHVIEN