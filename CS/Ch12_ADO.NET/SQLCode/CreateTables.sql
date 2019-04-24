DROP TABLE Products
GO
DROP TABLE Categories
GO

CREATE TABLE Categories
 ( CategoryID integer not null primary key
 , CategoryName nchar(20) not null
 )
GO

CREATE TABLE Products
 ( ProductID integer not null primary key
 , ProductName nchar(20) not null
 , CategoryID integer not null 
 , CONSTRAINT XXX foreign key (CategoryID) references Categories(CategoryID)
 )
GO

