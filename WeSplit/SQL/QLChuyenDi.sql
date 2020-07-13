﻿CREATE TABLE CHUYENDI
(
	MACD INT NOT NULL  IDENTITY,
	TENCD NVARCHAR(50),
	TRANGTHAI BIT,
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
	TRANGTHAI BIT,
	

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

drop table THUCHI
ALTER TABLE THUCHI DROP CONSTRAINT FK_THUCHI_CHUYENDI

-- CHUYENDI
INSERT INTO CHUYENDI
VALUES
(
	N'Trong lòng Huế - Những ngày trước cách ly', 0, '02/24/2020', '02/28/2020', 930
)
GO

-- THANHVIEN
INSERT INTO THANHVIEN
VALUES
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
( 1, '/Resource/Images/1_10.png' )
GO

-- THU CHI
INSERT INTO THUCHI
VALUES
(
	4, 1, N'Ăn sáng', 80000
),
(
	4, 1, N'Ăn trưa', 80000
),
(
	4, 1, N'Ăn tối', 120000
),
(
	1, 1, N'Đặt xe', 40000
),
(
	4, 1, N'Thuê Homestay', 2000000
)
GO