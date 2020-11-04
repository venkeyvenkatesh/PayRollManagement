create procedure SpAddEmployeeDetails
  @EmpName varchar(100),
  @StartDate date,
  @Gender varchar(1),
  @Address varchar(100),
  @phoneNumber varchar(20)

as 
begin
set xact_abort on;
begin try
begin transaction;
  insert into Employee_payroll values(@EmpName,@StartDate,@Gender,@Address,@phoneNumber);
  
  declare @id int 
  set @id = (select top 1 id from Employee_payroll order by 1 desc)
  insert into payments values(@id,34500,300,34200,420,31450)

  select * from payments where id=@id;
  commit transaction;
  end try
  begin catch
  select ERROR_NUMBER() as errorNumber,ERROR_MESSAGE() as errorMessage;
  if(XACT_STATE()=-1)
  begin
  PRINT N'The transaction is uncommittable...rolling back'
  Rollback transaction;
  end;
  if(XACT_STATE()=1)
  BEGIN 
  print N'The transaction is committable....commiting '
  commit transaction
  end
  end catch
  
end