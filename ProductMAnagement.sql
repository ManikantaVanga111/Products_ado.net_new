create database ProductManagement
use ProductManagement
create table product(
productid int identity primary key,
productname varchar(20),
productdescription varchar(20),
Quantity int,
Price int
)
select * from product
