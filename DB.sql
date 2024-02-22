Create Database MyStock

Create table Cars 
(CarID int primary key, 
CarName varchar(50) not null, 
Manufacturer varchar(50) not null, 
Price money not null, 
ReleaseYear int not null)

Insert into Cars (CarID, CarName, Manufacturer, Price, ReleaseYear)
values 
(1, 'Accord', 'Honda Motor Company', 24970, 2021),
(3, 'Clarity', 'Honda Motor Company', 33400, 2021),
(4, 'BMW 8 Series', 'BMW', 85000, 2021),
(5, 'Audi A6', 'Audi', 14000, 2020);

Declare @CarID int
Declare @CarName varchar(50)
Declare @Manufacturer varchar(50)
Declare @Price money
Declare @ReleaseYear int

select * from Cars