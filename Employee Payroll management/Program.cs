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



        }
    }
}

        
    
