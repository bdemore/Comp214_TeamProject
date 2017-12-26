USE master
GO

/*
 * CREATE SYSTEM DATABASE.
 */
IF (NOT EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE NAME = N'Comp229_TeamAssign'))
BEGIN
	CREATE DATABASE Comp229_TeamAssign
END
ELSE
BEGIN
	DROP DATABASE Comp229_TeamAssign
	CREATE DATABASE Comp229_TeamAssign
END
GO

USE Comp229_TeamAssign
GO

/*
 * CREATE SYSTEM TABLES.
 */
IF (NOT EXISTS(SELECT 1 FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'dbo.TBUB_PUBLISHERS') AND OBJECTPROPERTY(ID, N'IsTable') = 1))
BEGIN
	CREATE TABLE TBUB_PUBLISHERS (
		PUBLISHER_ID
			DECIMAL(6, 0)
			PRIMARY KEY
			CLUSTERED
			NOT NULL
			IDENTITY
	,	PUBLISHER_NAME
			VARCHAR(64)
			NOT NULL
	,	PUBLISHER_CREATE_DATE
			DATETIME2
			NOT NULL
			DEFAULT SYSDATETIME()
	)
END

IF (NOT EXISTS(SELECT 1 FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'dbo.TBUB_AUTHORS') AND OBJECTPROPERTY(ID, N'IsTable') = 1))
BEGIN
	CREATE TABLE TBUB_AUTHORS (
		AUTHOR_ID
			DECIMAL(10, 0)
			PRIMARY KEY
			CLUSTERED
			NOT NULL
			IDENTITY
	,	AUTHOR_NAME
			VARCHAR(128)
			NOT NULL
	,	AUTHOR_CREATE_DATE
			DATETIME2
			NOT NULL
			DEFAULT SYSDATETIME()
	)
END

IF (NOT EXISTS(SELECT 1 FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'dbo.TBUB_CATEGORIES') AND OBJECTPROPERTY(ID, N'IsTable') = 1))
BEGIN
	CREATE TABLE TBUB_CATEGORIES (
		CATEGORY_ID
			DECIMAL(4, 0)
			PRIMARY KEY
			CLUSTERED
			NOT NULL
			IDENTITY
	,	CATEGORY_NAME
			VARCHAR(64)
			NOT NULL
			UNIQUE
	,	CATEGORY_CREATE_DATE
			DATETIME2
			NOT NULL
			DEFAULT SYSDATETIME()
	)
END

IF (NOT EXISTS(SELECT 1 FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'dbo.TBUB_BOOKS') AND OBJECTPROPERTY(ID, N'IsTable') = 1))
BEGIN
	CREATE TABLE TBUB_BOOKS (
		BOOK_ISBN
			DECIMAL(13, 0)
			PRIMARY KEY
			CLUSTERED
			NOT NULL
	,	BOOK_TITLE
			VARCHAR(128)
			NOT NULL
	,	BOOK_DESCRIPTION
			VARCHAR(2048)
	,	BOOK_PUBLICATION_DATE
			DATE
			NOT NULL
	,	BOOK_EDITION
			DECIMAL(2, 0)
			NOT NULL
	,	BOOK_IS_AVAILABLE
			BIT
			NOT NULL
	,	BOOK_QUANTITY_AVAILABLE
			DECIMAL(3, 0)
			NOT NULL
	,	BOOK_IMG_URL_01
			VARCHAR(255)
			NOT NULL
	,	BOOK_IMG_URL_02
			VARCHAR(255)
	,	BOOK_IMG_URL_03
			VARCHAR(255)
	,	BOOK_IMG_URL_04
			VARCHAR(255)
	,	BOOK_IMG_URL_05
			VARCHAR(255)
	,	BOOK_CREATE_DATE
			DATETIME2
			NOT NULL
			DEFAULT SYSDATETIME()
	,	BOOK_REMOVE_DATE
			DATETIME2
	,	BOOK_LAST_UPDATE_DATE
			DATETIME2
	,	PUBLISHER_ID
			DECIMAL(6, 0)
			NOT NULL
			CONSTRAINT FK_PUBLISHERS__PUBLISHER_ID
				FOREIGN KEY REFERENCES TBUB_PUBLISHERS(PUBLISHER_ID)
	)
END

IF (NOT EXISTS(SELECT 1 FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'dbo.TBUB_BOOKS_AUTHORS') AND OBJECTPROPERTY(ID, N'IsTable') = 1))
BEGIN
	CREATE TABLE TBUB_BOOKS_AUTHORS (
		BOOK_ISBN
			DECIMAL(13, 0)
			NOT NULL
			CONSTRAINT FK_BOOKS_AUTORS__BOOKS___BOOK_ISBN
				FOREIGN KEY REFERENCES TBUB_BOOKS(BOOK_ISBN)
	,	AUTHOR_ID
			DECIMAL(10, 0)
			NOT NULL
			CONSTRAINT FK_BOOKS_AUTORS__AUTHORS___AUTHOR_ID
				FOREIGN KEY REFERENCES TBUB_AUTHORS(AUTHOR_ID)
	,	CONSTRAINT PK_BOOKS_AUTHORS__BOOK_ISBN__AUTHOR_ID
			PRIMARY KEY CLUSTERED(BOOK_ISBN, AUTHOR_ID)
			
	)
END
GO

IF (NOT EXISTS(SELECT 1 FROM dbo.sysobjects WHERE ID = OBJECT_ID(N'dbo.TBUB_BOOKS_CATEGORIES') AND OBJECTPROPERTY(ID, N'IsTable') = 1))
BEGIN
	CREATE TABLE TBUB_BOOKS_CATEGORIES (
		BOOK_ISBN
			DECIMAL(13, 0)
			NOT NULL
			CONSTRAINT FK_BOOKS_CATEGORIES__BOOKS___BOOK_ISBN
				FOREIGN KEY REFERENCES TBUB_BOOKS(BOOK_ISBN)
	,	CATEGORY_ID
			DECIMAL(4, 0)
			NOT NULL
			CONSTRAINT FK_BOOKS_CATEGORIES__CATEGORIES___CATEGORY_ID
				FOREIGN KEY REFERENCES dbo.TBUB_CATEGORIES(CATEGORY_ID)
	,	CONSTRAINT PK_BOOKS_CATEGORIES__BOOK_ISBN__CATEGORY_ID
			PRIMARY KEY CLUSTERED(BOOK_ISBN, CATEGORY_ID)
			
	)
END
GO

/*
 * CREATE INDEXES.
 */
IF (NOT EXISTS(SELECT 1 FROM sys.indexes WHERE NAME = N'IX_BOOKS__BOOK_TITLE' AND OBJECT_ID = OBJECT_ID(N'dbo.TBUB_BOOKS')))
BEGIN
	CREATE INDEX IX_BOOKS__BOOK_TITLE ON TBUB_BOOKS(BOOK_TITLE)
END

IF (NOT EXISTS(SELECT 1 FROM sys.indexes WHERE NAME = N'IX_BOOKS__PUBLISHER_ID' AND OBJECT_ID = OBJECT_ID(N'dbo.TBUB_BOOKS')))
BEGIN
	CREATE INDEX IX_BOOKS__PUBLISHER_ID ON dbo.TBUB_BOOKS(PUBLISHER_ID)
END
GO

/*
 * Inserting Data.
 */
INSERT INTO TBUB_CATEGORIES(CATEGORY_NAME) VALUES(N'Fantasy')
INSERT INTO TBUB_CATEGORIES(CATEGORY_NAME) VALUES(N'Magic')

INSERT INTO TBUB_AUTHORS(AUTHOR_NAME) VALUES(N'J. K. Rowling')

INSERT INTO TBUB_PUBLISHERS(PUBLISHER_NAME) VALUES(N'Bloomsbury Children''s Books')

INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408845646, N'Harry Potter and the Philosopher''s Stone',
	N'Prepare to be spellbound by Jim Kay''s dazzling depiction of the wizarding world and much loved characters in this full-colour illustrated hardback edition of the nation''s favourite children''s book – Harry Potter and the Philosopher''s Stone. Brimming with rich detail and humour that perfectly complements J.K. Rowling''s timeless classic, Jim Kay''s glorious illustrations will captivate fans and new readers alike.',
	'2015-10-06', 1, 1, 10, N'https://images-na.ssl-images-amazon.com/images/I/51sTwK7kBxL._AA218_.jpg', 1)
INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408845653, N'Harry Potter and the Chamber of Secrets',
	N'Prepare to be spellbound by Jim Kay''s dazzling full-colour illustrations in this stunning new edition of J.K. Rowling''s Harry Potter and the Chamber of Secrets. Breathtaking scenes, dark themes and unforgettable characters await inside this fully illustrated edition. With paint, pencil and pixels, award-winning illustrator Jim Kay conjures the wizarding world as we have never seen it before. Fizzing with magic and brimming with humour, this inspired reimagining will captivate fans and new readers alike, as Harry and his friends, now in their second year at Hogwarts School of Witchcraft and Wizardry, seek out a legendary chamber and the deadly secret that lies at its heart.',
	'2016-10-04', 1, 1, 10, N'https://images-na.ssl-images-amazon.com/images/I/61+abdOC5gL._AA218_.jpg', 1)
INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408845660, N'Harry Potter and the Prisoner of Azkaban',
	N'An extraordinary creative achievement by an extraordinary talent, Jim Kay''s inspired reimagining of J.K. Rowling''s classic series has captured a devoted following worldwide. This stunning new fully illustrated edition of Harry Potter and the Prisoner of Azkaban brings more breathtaking scenes and unforgettable characters – including Sirius Black, Remus Lupin and Professor Trelawney. With paint, pencil and pixels, Kay conjures the wizarding world as we have never seen it before. Fizzing with magic and brimming with humour, this full-colour edition will captivate fans and new readers alike as Harry, now in his third year at Hogwarts School of Witchcraft and Wizardry, faces Dementors, death omens and, of course, danger.',
	'2017-10-03', 1, 1, 10, N'https://images-na.ssl-images-amazon.com/images/I/617HC+dtBOL._AA218_.jpg', 1)
INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408890769, N'Harry Potter - A History of Magic: The Book of the Exhibition',
	N'Harry Potter: A History of Magic is the official book of the exhibition, a once-in-a-lifetime collaboration between Bloomsbury, J.K. Rowling and the brilliant curators of the British Library. It promises to take readers on a fascinating journey through the subjects studied at Hogwarts School of Witchcraft and Wizardry - from Alchemy and Potions classes through to Herbology and Care of Magical Creatures.',
	'2017-10-20', 1, 1, 10, N'https://images-na.ssl-images-amazon.com/images/I/61Lo-+FBs+L._AA218_.jpg', 1)

INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408845646, 1)
INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408845653, 1)
INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408845660, 1)
INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408890769, 1)

INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845646, 1)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845646, 2)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845653, 1)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845653, 2)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845660, 1)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845660, 2)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408890769, 1)
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408890769, 2)
