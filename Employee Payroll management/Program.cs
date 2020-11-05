using System;

namespace Employee_Payroll_management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();

            //UC2 get all the employee Details

            //string query = @"select * from Employee_payroll";
            //repo.GetAllEmployee(query);

            //Insert some record into employee table

            EmployeePayroll employee = new EmployeePayroll();
            employee.name = "Dhoni";
            employee.startDate = Convert.ToDateTime("2020-10-01");
            employee.gender = 'M';
            employee.Address = "DELHI";
            employee.phoneNumber = "+91 9866528888";

            //  repo.addEmpoyee(employee);

            //Update Salary of an employee using Sql Query

            //  repo.UpdateEmployeeSalary();

            // repo.UpdateEmployeeSalaryUsingStoredProcedure("venkey", 43540);

            //Get the employees who joined after certain date range
            //string query = @"select* from Employee_payroll where start_Date between CAST('2020-01-01' as date) and GETDATE()";
            //repo.GetAllEmployee(query);


            //  string query = @"select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            //    string query = @"select a.gender,avg(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender";
            //string query = @"select a.gender,max(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            // string query = @"select a.gender,min(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            //repo.OperationOnSalaries(query);

            //  repo.GetAllSalaries();

            repo.DeleteAnEmployee();


        }
    }
}

        
    
