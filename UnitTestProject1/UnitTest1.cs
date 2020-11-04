using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design;
using Employee_Payroll_management;
using System.Collections.Generic;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        //UC3 Update salary based on name
        //  [TestMethod]
        public void UpdateSalaryForAGivenEmployee()
        {
            EmployeeRepo repo = new EmployeeRepo();

            Payments payments = repo.UpdateEmployeeSalary();
            decimal expected = 43500;
            decimal actual = payments.net_pay;
            Assert.AreEqual(expected, actual);

        }

        //UC4 Update salary using stored procedure
        //  [TestMethod]
        public void UpdateSalaryUsingStoredProcedure()
        {

            EmployeeRepo repo = new EmployeeRepo();
            Payments payments = repo.UpdateEmployeeSalaryUsingStoredProcedure("venkey", 43540);
            decimal expected = 43540;
            decimal actual = payments.net_pay;
            Assert.AreEqual(expected, actual);
        }


        //UC5 Employees joined after certain date
          [TestMethod]
        public void EmployeesJoinedAfterCertainDate()
        {
            EmployeeRepo repo = new EmployeeRepo();
            string query = @"select* from Employee_payroll where start_Date between CAST('2020-01-01' as date) and GETDATE()";
            List<EmployeePayroll> list = repo.GetAllEmployee(query);
            string actual1 = list[0].name;
            string expected1 = "venkey";
            string actual2 = list[1].name;
            string expected2 = "Dhoni";


            int length = 2;
            int actualLength = list.Count;
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(length, actualLength);

        }

       



    }

}
