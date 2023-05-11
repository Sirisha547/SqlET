create database ExpenseTracker

use ExpenseTracker

create table Transactions
(
Transaction_id int identity primary key,
Title varchar(50),
Descrp varchar(100),
Amount int,
Dates Date
)



select * from Transactions
select sum(amount) as balance from Transactions