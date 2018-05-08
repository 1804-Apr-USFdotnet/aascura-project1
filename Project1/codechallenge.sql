USE code_challenge;
GO

CREATE TABLE [Products] 
( ID INT PRIMARY KEY IDENTITY(0,1)
, [Name] VARCHAR(32) NOT NULL
, Price FLOAT NOT NULL
);

CREATE TABLE [Customers] 
( ID INT PRIMARY KEY IDENTITY(0,1)
, Firstname VARCHAR(32) NOT NULL
, Lastname VARCHAR(32)
, Cardnumber CHAR(12) NOT NULL
);

CREATE TABLE [Orders]
( ID INT PRIMARY KEY IDENTITY(0,1)
, ProductID INT FOREIGN KEY REFERENCES Products(ID)
, CustomerID INT FOREIGN KEY REFERENCES Customers(ID)
);

INSERT INTO Customers (Firstname, Lastname, Cardnumber) VALUES
('John', 'Doe', '000000000000' ),
('Jane', 'Doe', '111111111111' ),
('Jann', 'Lee', '123456789012' )
;

INSERT INTO Products ( [Name], Price) VALUES
( 'Giant Robot', 999999.99),
( 'Laptop', 549.83),
( 'Jeans', 37.48)
;

INSERT INTO Orders (CustomerID, ProductID) VALUES 
(1, 1),
(2, 2),
(3, 3)
;

INSERT INTO Products ( [Name], Price ) VALUES ('iPhone', 200.00);

INSERT INTO Customers (Firstname, Lastname, Cardnumber) VALUES ('Tina', 'Smith', '098765432109');

INSERT INTO Orders (CustomerID, ProductID) VALUES
( (SELECT ID FROM Customers WHERE Firstname = 'Tina' AND Lastname = 'Smith')
, (SELECT ID FROM Products WHERE [Name] = 'iPhone')
);

SELECT o.ID, o.CustomerID, o.ProductID FROM Orders o INNER JOIN (SELECT ID FROM Customers c WHERE Firstname = 'Tina' AND Lastname = 'Smith') sq ON o.CustomerID = sq.ID;

SELECT p.Price FROM Products p WHERE p.Name = 'iPhone';

SELECT SUM(sq.Price) FROM Orders o INNER JOIN (SELECT p.ID, p.Price FROM Products p WHERE p.Name = 'iPhone') sq ON o.ProductID = sq.ID;

UPDATE Products
SET Price = 250.00 WHERE [Name] = 'iPhone';