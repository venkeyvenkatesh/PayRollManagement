create procedure sp_UpdateSalary
@salary decimal(10,2),
@name varchar(30)
as
begin
  update payments set payments.net_pay=@salary from payments p 
  inner join Employee_payroll e on p.id=e.id 
 where e.name=@name;
 select name,net_pay from payments p inner join Employee_payroll e on p.id=e.id where name=@name;
end