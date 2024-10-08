create database assetmanagement

use assetmanagement

create table Employees(employee_id int identity(1,1) primary key,
[name] varchar(50) not null,
department varchar(30) not null,
email varchar(255),
pwd varchar(30))

create table assets(asset_id int identity(1,1) primary key,
[name] varchar(100) not null,
[type] varchar(20) not null,
serial_num varchar(10) unique not null,
purchase_date date,
[location] varchar(100),
[status] varchar(100) check(status in('in use','decommissioned','under maintainence')) not null,
owner_id int,
foreign key(owner_id) references Employees(employee_id))

SELECT con.name AS ConstraintName
FROM sys.check_constraints con
JOIN sys.tables t ON con.parent_object_id = t.object_id
WHERE t.name = 'assets' AND con.definition LIKE '%status%';

ALTER TABLE assets
DROP CONSTRAINT CK__assets__status__4AB81AF0;

ALTER TABLE assets
ADD CONSTRAINT chk_asset_status
CHECK (status IN ('in use', 'decommissioned', 'under maintenance', 'available'));
SELECT * FROM assets
WHERE status NOT IN ('in use', 'decommissioned', 'under maintenance', 'available');

UPDATE assets
SET status = 'decommissioned' -- or another valid status
WHERE status NOT IN ('in use', 'decommissioned', 'under maintenance', 'available');

ALTER TABLE assets
ADD CONSTRAINT chk_asset_status
CHECK (status IN ('in use', 'decommissioned', 'under maintenance', 'available'));

create table maintenance(maintenance_id int identity(1,1) primary key,
asset_id int,
maintenance_date date,
[description] varchar(max),
cost decimal(8,2) not null,
foreign key(asset_id) references assets(asset_id))

create table asset_allocations(allocation_id int identity(1,1) primary key,
asset_id int,
employee_id int,
allocation_date date,
return_date date,
foreign key (asset_id) references assets(asset_id),
foreign key(employee_id) references Employees(employee_id))

ALTER TABLE asset_allocations
ADD CONSTRAINT DF_return_date DEFAULT 'Not returned' FOR return_date;

alter table asset_allocations
add constraint df_allocation_date default 'No allocation date present' for allocation_date

create table reservations(reservation_id int identity(1,1) primary key,
asset_id int,
employee_id int,
reservation_date date not null,
[start_date] date not null,
[end_date] date not null,
[status] varchar(50) check([status] in ('pending','approved','canceled')) default 'pending',
foreign key (asset_id) references assets(asset_id),
foreign key(employee_id) references Employees(employee_id))

select * from Employees
select * from assets
select * from asset_allocations
select * from maintenance
select * from reservations

delete from assets where asset_id=25
delete from asset_allocations where allocation_id=1005;

--data for employees
Insert into Employees([name],department,email,pwd) 
values('Subham Kumar','Technical','sk@gmail.com','12345'),
('Rahul Prasad','Finance','rp@gmail.com','12346'),
('Faraz Ayub','Technical',null,null),
('Saurabh S','Analytics','sa@gmail.com','54321'),
('Subham Singh','Sales','ss@gmail.com',null)

--data for assets
Insert into assets([name],[type],serial_num,purchase_date,[location],[status],owner_id)
values('Laptop', 'Electronics', 'LAP12345', '2023-01-15', 'Branch Office', 'under maintainence', 1),
('Desktop', 'Electronics', 'DESK6789', '2022-11-10', 'HQ', 'in use', 2),
('Printer','Electronics','PRN90876','2021-06-05','Branch Office', 'decommissioned', 3),
('Company Car', 'Vehicle','CAR54678','2020-09-20','HQ', 'under maintainence', 4),
('Desk','Furniture','DK546790','2024-09-15','HQ','in use',5)

--data for maintenance
Insert into maintenance(asset_id,maintenance_date,[description],cost)
values(4,'2024-09-22','Replaced Battery',1000.00),
(5,'2023-12-23','Changed RAM configurations',500.00),
(6,'2024-01-01','Catridge Changed',250.00),
(7,'2022-11-15','Engine Oil Changed',2750.00),
(7,'2024-09-15','Tyres replaced',10000.00)


--data for asset allocation
insert into asset_allocations(asset_id,employee_id,allocation_date,return_date)
values(4,1,'2023-01-16','2024-09-15'),
(5,2,'2022-11-11',null),
(6,3,'2021-06-06','2023-12-26'),
(7,4,'2020-09-21','2022-11-01'),
(7,4,'2022-12-15','2024-09-14'),
(8,5,'2024-09-16',null)

--data for reservation
insert into reservations(asset_id,employee_id,reservation_date,[start_date],[end_date],status)
values(4,5,'2024-09-17','2024-11-05','2025-02-27','approved'),
(5,4,'2024-08-15','2024-10-06','2025-01-31','canceled'),
(6,1,'2024-07-30','2024-09-16','2024-12-03','pending'),
(7,3,'2024-09-30','2024-11-30','2024-12-12','pending'),
(4,2,'2024-11-10','2024-11-15','2025-03-28','canceled')



select * from Employees
select * from assets
select * from asset_allocations
select * from maintenance
select * from reservations

select * from assets where status!='in use'

ALTER TABLE asset_allocations
DROP CONSTRAINT FK__asset_all__asset__5441852A;

ALTER TABLE asset_allocations
ADD CONSTRAINT FK__asset_all__asset__5441852A
FOREIGN KEY (asset_id) REFERENCES assets(asset_id) ON DELETE CASCADE;

ALTER TABLE maintenance
DROP CONSTRAINT FK__maintenan__asset__5165187F;

ALTER TABLE maintenance
ADD CONSTRAINT FK__maintenan__asset__5165187F
FOREIGN KEY (asset_id) REFERENCES assets(asset_id) ON DELETE CASCADE;


ALTER TABLE reservations
DROP CONSTRAINT FK__reservati__asset__5BE2A6F2;

ALTER TABLE reservations
ADD CONSTRAINT FK__reservati__asset__5BE2A6F2
FOREIGN KEY (asset_id) REFERENCES assets(asset_id) ON DELETE CASCADE;

update assets set status='in use',owner_id='4' where asset_id=14