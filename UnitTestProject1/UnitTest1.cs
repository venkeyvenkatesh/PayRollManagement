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
      //   [TestMethod]
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
        //UC6 Operation on Salaries

        //Getting gender wise salaries 
        [TestMethod]

        public void GetTheGenderWiseSumOfSalaries()
        {
            EmployeeRepo repo = new EmployeeRepo();
            string query = @"select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            Dictionary<string, decimal> dictionary = repo.OperationOnSalaries(query);

            decimal actualSumFemale = dictionary["F"];
            decimal expectedSumFemale = 65000;


            decimal actualSumMale = dictionary["M"];
            decimal expectedSumMale = 153490;

            Assert.AreEqual(expectedSumFemale, actualSumFemale);
            Assert.AreEqual(expectedSumMale, actualSumMale);
        }

        //Getiing gender wise avg of salaries
       //   [TestMethod]
        public void GetTheGenderWiseAvgOfSalaries()
        {
            EmployeeRepo repo = new EmployeeRepo();
            string query = @"select a.gender,avg(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            Dictionary<string, decimal> dictionary = repo.OperationOnSalaries(query);

            decimal actualAvgFemale = dictionary["F"];
            decimal expectedAvgFemale = 32500;


            decimal actualAvgMale = dictionary["M"];
            decimal expectedAvgMale = 38372.5M;

            Assert.AreEqual(expectedAvgFemale, actualAvgFemale);
            Assert.AreEqual(expectedAvgMale, actualAvgMale);
        }

      





    }

}
