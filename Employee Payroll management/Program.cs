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

            string query = @"select * from Employee_payroll";
            repo.GetAllEmployee(query);



            //Insert some record into employee table

            //EmployeePayroll employee = new EmployeePayroll();
            //employee.name = "Dhoni";
            //employee.startDate = Convert.ToDateTime("2020-10-01");
            //employee.gender = 'M';
            //employee.Address = "DELHI";
            //employee.phoneNumber = "+91 9866528888";
            // repo.addEmpoyee(employee);













            //EmployeePayroll employee1 = new EmployeePayroll();

            //employee1.name = "Mithali";
            //employee1.startDate = Convert.ToDateTime("2029-02-01");
            //employee1.gender = 'F';
            //employee1.Address = "BANGALORE";
            //employee1.phoneNumber = "+91 8500500964";


            //  repo.addEmpoyee(employee1);

















            //UC3 Update the salary based on name

            //  repo.UpdateEmployeeSalary();






            //UC4 Update Salary using special procedure

            //    repo.UpdateEmployeeSalaryUsingStoredProcedure("venkey", 46700);




            //  repo.GetAllSalaries();

            //UC5 Get the employees joined in a given range....

            //string query = @"select* from Employee_payroll where start_Date between CAST('2020-01-01' as date) and GETDATE()";
            //   repo.GetAllEmployee(query);


            //string query = @"select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            //  string query = @"select a.gender,avg(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender";
            //string query = @"select a.gender,max(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            // string query = @"select a.gender,min(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            //  repo.OperationOnSalaries(query);

        }
    }
}

        
    
