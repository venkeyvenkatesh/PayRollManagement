using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design;
using Employee_Payroll_management;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //  [TestMethod]
        public void UpdateSalaryForAGivenEmployee()
        {
            EmployeeRepo repo = new EmployeeRepo();

            Payments payments = repo.UpdateEmployeeSalary();
            decimal expected = 43500;
            Assert.AreEqual(expected, payments.net_pay);

        }


       // [TestMethod]
        public void UpdateSalaryUsingStoredProcedure()
        {

            EmployeeRepo repo = new EmployeeRepo();
            decimal actual = repo.UpdateEmployeeSalaryUsingStoredProcedure("venkey", 43540);
            decimal expected = 43540;

            Assert.AreEqual(expected, actual);
        }






    }

}
