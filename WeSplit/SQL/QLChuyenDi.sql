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











-- CHUYENDI
INSERT INTO CHUYENDI
VALUES
(N'Thành phố Hồ Chí Minh phượt Hà Giang, những ngọn núi hùng vĩ', 0, '10/12/2019', '10/20/2019', 2010),
(N'Du lịch Phú Yên theo một cách hoàn toàn mới!', 0, '03/11/2020', '03/15/2020', 573),
(N'Mộc Châu - Tà Xùa - Yên Bái - Sapa - Hà Giang - Ninh Bình: đi xong về lấy chồng', 0, '08/03/2019', '08/10/2019', 275)
GO
SELECT IDENT_CURRENT('CHUYENDI') AS SOLUONG
-- THANHVIEN
INSERT INTO THANHVIEN
VALUES
(   4, N'Nguyễn Bảo Nam',
    N'Mình đã có lịch trình chi tiết và cung đường rồi. Bạn nào thích thì tham gia team ạ. Hiện có vé máy bay giá ok ạ.',
    '0255986589', 1),
(   4, N'Trần Quang Khải', '', '09065225685', 0),
(   4, N'Trần Trung Quốc', '', '09065225685', 0),
(   4, N'Trần Quang Cao', '', '09025595685', 0),
(   4, N'Cao Khải Hoàng', '', '09062546685', 0),

(   5, N'Nguyễn Hùng Ngọc Trung Kiên',
    N'Mình vượt qua đèo Cả để đến với địa phận Phú Yên. Có thể nói, view nhìn từ đèo Cả thật là tuyệt vời, khung cảnh hùng vĩ từ ngọn đèo cả nhìn xuống vùng biển Vũng Rô, mới thấy quang cảnh thật đẹp làm sao. Từ đây, bạn có thể thấy được đường tàu lửa chạy qua đèo Cả, trông đẹp mắt làm sao.',
    '0935625589', 1),
(   5, N'Bùi Lê Quang', '', '09065222256', 0),
(   5, N'Trần Trung Trực', '', '0236288915', 0),
(   5, N'Cao Tây Nguyên', '', '0125688958', 0),
(   5, N'Khải Mã Hoàng', '', '090625685', 0),

(   6, N'Châu Ngọc Ngọc',
    N'Nói về sông Đà, hồi học cấp 3 mình bị ám ảnh lắm, vì suốt ngày phải phân tích bài "người lái đò sông Đà" của ông Nguyễn Tuân "Bờ sông hoang dại như đôi bờ tiền sử, bở sông hồn nhiên như một nỗi niềm cổ tích tuổi xưa". Mấy đoạn chèo thuyền vượt thác thì đúng xuất sắc rồi, nhưng mình chẳng nhớ gì về đoạn này.
Ngày mình đi sông Đà phẳng lặng như mặt gương, trong xanh màu nước, bên trên là mây trời, bình yên lắm',
    '0935644458', 1),
(   6, N'Hà Thị Mỹ Châu', '', '0906335688', 0),
(   6, N'Nguyễn Thị Anh Thư', '', '0236214458', 0),
(   6, N'Tô Quách Hiếu', '', '0255958993', 0),
(   6, N'Trần Thị Bảo Yến', '', '0956808956', 0)
GO

-- DIA DIEM
INSERT INTO DIADIEM
VALUES
--Get Start
(
	4, 1, N'Tp Nha Trang'
),
(
	4, 2, N'Tp Quy Nhơn'
),
(
	4, 3, N'Tp Huế'
),
(
	4, 4, N'Đà Nẵng'
),
(
	4, 5, N'Tp Hải Phòng'
),
(
	4, 6, N'Thủ đô Hà Nội'
),

(
	5, 1, N'Biển Mũi Né'
),
(
	5, 2, N'Phan Rang - Tháp Chàm'
),
(
	5, 3, N'Tp Cam Ranh'
),
(
	5, 4, N'Phú Yên'
),

(
	6, 1, N'SG-HN-Hòa Bình-Mộc Châu'
),
(
	6, 2, N'Mộc Châu - Tà Xùa'
),
(
	6, 3, N'Tà Xùa - Yên Bái'
),
(
	6, 4, N'Yên Bái - Sapa'
),
(
	6, 5, N'Sapa - Hà Giang'
),
(
	6, 6, N'Hà Giang - Đồng Văn'
),
(
	6, 7, N'Đồng Văn - Hà Giang - Hà Nội'
),
(
	6, 8, N'Hà Nội - Ninh Bình - SG'
)
GO

-- HINH ANH
INSERT INTO HINHANH
VALUES

( 4, '/Resource/Images/HCM-HaGiang_1.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_2.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_3.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_4.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_5.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_6.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_7.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_8.jpg' ),
( 4, '/Resource/Images/HCM-HaGiang_9.jpg' ),


( 5, '/Resource/Images/HCM-PhuYen_1.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_2.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_3.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_4.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_5.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_6.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_7.jpg' ),
( 5, '/Resource/Images/HCM-PhuYen_8.jpg' ),

( 6, '/Resource/Images/MocChau-NinhBinh_1.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_2.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_3.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_4.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_5.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_6.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_7.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_8.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_9.jpg' ),
( 6, '/Resource/Images/MocChau-NinhBinh_10.jpg' )
GO

-- THU CHI
INSERT INTO THUCHI
VALUES

(12, 4, N'Ăn Vặt', 200000),
(12, 4, N'Ăn sáng', 500000),
(12, 4, N'Ăn trưa', 480000),
(12, 4, N'Ăn tối', 400000),
(13, 4, N'Dụng cụ đi phượt', 500000),

(17, 5, N'Ăn Vặt', 200000),
(17, 5, N'Ăn sáng', 500000),
(17, 5, N'Ăn trưa', 480000),
(17, 5, N'Ăn tối', 400000),
(18, 5, N'Phụ Kiện đi biển', 200000),
(16, 5, N'Kem chống nắng, dưỡng da', 200000),
(16, 5, N'Thuê Khách Sạn', 200000),

(21, 6, N'Ăn Vặt', 200000),
(21, 6, N'Ăn sáng', 500000),
(25, 6, N'Ăn trưa', 480000),
(21, 6, N'Ăn tối', 400000),
(22, 6, N'Phụ Kiện đi biển', 200000),
(22, 6, N'Nước uống dọc đường, đổ xăng', 200000),
(21, 6, N'Kem chống nắng, dưỡng da', 200000),
(21, 6, N'Thuê Khách sạn', 200000)
GO




INSERT INTO CHUYENDI
VALUES
(N'Về miền sông nước Cửu Long, 1 vòng An Giang - Đi qua vùng Thất Sơn huyền bí', 1, '07/18/2020', '', 771)

INSERT INTO THANHVIEN
VALUES
(8, N'Tiêu Tuấn Minh', '', '0555511083', 0),
(8, N'Mai Ðức Thành', '', '0955561456', 1),
(8, N'Quách Diệu Linh', '', '0955581547', 0),
(8, N'Ngô Tuệ Nhi', '', '0855567792', 0),
(8, N'Giang Chấn Phong', '', '0855551069', 0),
(8, N'Nguyễn Ðức Bảo', '', '0355540270', 0),
(8, N'Nguyễn Hồng Hạnh', '', '0355521815', 0)

INSERT INTO DIADIEM
VALUES
(8, 1, N'TP Thủ Dầu Một'),
(8, 2, N'Cầu Phú Cường'),
(8, 3, N'Tỉnh Lộ 8'),
(8, 4, N'Tt Củ Chi'),
(8, 5, N'Tỉnh Lộ 823'),
(8, 6, N'Tỉnh Lộ 823'),
(8, 7, N'Tt Hậu Nghĩa'),
(8, 8, N'Tỉnh Lộ 842'),
(8, 9, N'Phà Châu Giang'),
(8, 10, N'TP Châu Đốc')

INSERT INTO HINHANH
VALUES
(8, '/Resource/Images/7_1.jpg'),
(8, '/Resource/Images/7_2.jpg'),
(8, '/Resource/Images/7_3.jpg'),
(8, '/Resource/Images/7_4.jpg'),
(8, '/Resource/Images/7_5.jpg'),
(8, '/Resource/Images/7_6.jpg'),
(8, '/Resource/Images/7_7.jpg'),
(8, '/Resource/Images/7_8.jpg'),
(8, '/Resource/Images/7_9.jpg'),
(8, '/Resource/Images/7_10.jpg'),
(8, '/Resource/Images/7_11.jpg'),
(8, '/Resource/Images/7_12.jpg')

INSERT INTO THUCHI
VALUES
(27, 8, N'Ăn sáng', 400000),
(28, 8, N'Ăn trưa', 520000),
(28, 8, N'Ăn tối', 670000),
(28, 8, N'Đổ xăng', 33000),
(30, 8, N'Câu cá', 200000)








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

SELECT * FROM THANHVIEN WHERE MACD=1 AND HOTEN=N'Quyền Thiên Ân'

update chuyendi set trangthai=0 where macd=2
update chuyendi set trangthai=0 where macd=6

SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.TRANGTHAI=1 AND TV.TRANGTHAI=1