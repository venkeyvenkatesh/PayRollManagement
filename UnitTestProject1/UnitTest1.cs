using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Design;
using Employee_Payroll_management;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenNameAndSlaryUpdateSalaty()
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.UpdateEmployeeSalaryUsingStoredProcedure("venkey", 46700);

             
            
        }
    }
}
