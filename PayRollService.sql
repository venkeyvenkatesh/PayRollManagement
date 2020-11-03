--UC1 Create Database
create database myPayrollDB

--UC2 creaete a table
create table Employee_payroll(

id int NOT NULL identity(1,1) PRIMARY KEY,
name VARCHAR(50) NOT NULL,
salary DECIMAL(10,2) NOT NULL,
start_Date DATETIME NOT NULL ) ;

--UC3 Insert the data into database
insert into Employee_payroll values('venkey',50000,'2020-10-18');

insert into Employee_payroll values('Rajesh',35000,'2019-03-26');

insert into Employee_payroll values('Kajal',23000,'2019-04-09');
insert into Employee_payroll values('Rashmi',70000,'2018-05-11');

--UC4 Retrieve all the data from the table
select * from Employee_payroll;


--UC5.1 Salary of particualr employee

select gender from Employee_payroll where name='Rajesh';

--UC5.2 Details of employee in a particualr date range

select * from Employee_payroll where start_Date between CAST('2019-01-01' as date) and GETDATE();


--UC6.1 Add the gender column to the table 
alter table Employee_payroll add gender varchar(2)  not null default  'M' ;

--UC6.2 update the gender based on their name
update Employee_payroll set gender='F' where name in ('Kajal','Rashmi');


--UC7 find Sum Avg Min and Max salaries 
select gender,sum(salary) as SumOfSalaries from Employee_payroll group by(gender);
select gender,avg(salary) as AvgOfSalaries from Employee_payroll group by(gender);
select gender,max(salary) as MaxOfSalary from Employee_payroll group by(gender);
select gender,min(salary) as MinSalary from Employee_payroll group by(gender);

select gender,count(*) as NumberOfPeople from Employee_payroll group by gender;



--exec sp_help Table_name to view the table structure



select * from Employee_payroll;

--UC8 adding phonenumber empaddress and department columns to existing table


alter table Employee_payroll add
empAdress varchar(120) not null default 'MUMBAI';

alter table Employee_payroll add
phoneNumber varchar(20) ;

alter table Employee_payroll add
department varchar(255) not null default 'communication';


EXEC sp_RENAME 'Employee_payroll.salary', 'basicPay', 'COLUMN';

--UC9 Adding deductions,taxable pay ,tax and net_pay to existing table
alter table Employee_payroll add deductions decimal(10,2) not null default 0.0;

alter table Employee_payroll add taxable_pay decimal(10,2) not null default 0.0;

alter table Employee_payroll add tax decimal(10,2) not null default 0.0;

alter table Employee_payroll add net_pay decimal(10,2) not null default 0.0;

select * from Employee_payroll;

--UC 10 adding same perso working in different department to cause redundancy
insert Employee_payroll values('Rashmi',70000,'2018-05-11','F',NULL,'MUMBAI','software',0,0,0,0);


select * from Employee_payroll;

             
--UC 11 create a new table employee department and department table


--creating Department table to store the dept id and dept name;
create table DEPARTMENT(DeptId int primary key,DeptName varchar(100));


select * from DEPARTMENT;
insert into DEPARTMENT VALUES(100,'communication');
INSERT INTO DEPARTMENT VALUES(101,'software');
INSERT INTO DEPARTMENT VALUES(102,'testing');


--creating employee department table to store employee id,dept id
create table Employee_department (id int, DeptId int ,Primary key(id,DeptId));

insert into Employee_department values(1,100);
insert into Employee_department values(2,100);
insert into Employee_department values(3,100);
insert into Employee_department values(4,100);
insert into Employee_department values(4,101);

select * from Employee_department;

--sp_help Employee_payroll

select * from Employee_payroll;

delete from Employee_payroll where id=6;
alter table Employee_payroll drop column department;

select a.name,c.DeptName from 
Employee_payroll a inner join Employee_department b on a.id=b.id 
 inner join DEPARTMENT c on b.DeptId=c.DeptId ;

select * from Employee_payroll;

--UC12 Ensure all the operations working fine

select a.name,a.start_Date,a.gender,
a.empAddress,c.DeptName from 
Employee_payroll a inner join Employee_department b on a.id=b.id 
 inner join DEPARTMENT c on b.DeptId=c.DeptId where c.DeptName='communication';


 select a.name,a.start_Date,a.gender,
a.empAddress,c.DeptName from 
Employee_payroll a inner join Employee_department b on a.id=b.id 
 inner join DEPARTMENT c on b.DeptId=c.DeptId where c.DeptName='software';


 --creating payments table to store the details about payments
 create table payments (id int,basicPay DECIMAL(10,2) NOT NULL,deductions decimal(10,2) not null default 0.0,taxable_pay decimal(10,2) not null default 0.0,
tax decimal(10,2) not null default 0.0, net_pay decimal(10,2) not null default 0.0);

select * from payments;

alter table Employee_payroll drop column basicPay,empAdress,deductions,taxable_pay,tax,net_pay;

select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender ;

select a.gender,avg(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender;

select a.gender,max(b.net_pay)MaxOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender;

select a.gender,min(b.net_pay)MinOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender;



