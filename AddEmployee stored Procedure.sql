create procedure SpAddEmployeeDetails
  @EmpName varchar(100),
  @StartDate date,
  @Gender varchar(1),
  @Address varchar(100),
  @phoneNumber varchar(20)

as 
begin
  insert into Employee_payroll values(@EmpName,@StartDate,@Gender,@Address,@phoneNumber)
end