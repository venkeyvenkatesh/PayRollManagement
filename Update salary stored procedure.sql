create procedure sp_UpdateSalary
@salary decimal(10,2),
@name varchar(30)
as
begin
  update payments set net_pay=@salary where id=(select id from Employee_payroll where name=@name);
end