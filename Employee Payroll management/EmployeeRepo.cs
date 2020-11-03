using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Employee_Payroll_management
{
    class EmployeeRepo
    {
        public static string connectionString = "Data Source = (LocalDb)\\VenkeyServer;Initial Catalog = myPayrollDB; Integrated Security = True";
        static SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee(string query)
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (connection)
                {
                    // string query = @"select * from Employee_payroll";
                    //  string query= @"select* from Employee_payroll where start_Date between CAST('2019-01-01' as date) and GETDATE()";
                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader dr = cnd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.id = dr.GetInt32(0);
                            employeePayroll.name = dr.GetString(1);
                            employeePayroll.startDate = dr.GetDateTime(2);
                            employeePayroll.gender = Convert.ToChar(dr.GetString(3));
                            employeePayroll.Address = dr.GetString(4);
                            employeePayroll.phoneNumber = dr.GetString(5);

                            Console.WriteLine(employeePayroll.id + "  " + employeePayroll.name + "  " + employeePayroll.startDate + "  " + employeePayroll.gender + "  " + employeePayroll.Address + "  " + employeePayroll.phoneNumber);
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No DAta found");
                    }
                    dr.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool addEmpoyee(EmployeePayroll employee)
        {
            try
            {

                using (connection)
                {

                    SqlCommand cnd = new SqlCommand("SpAddEmployeeDetails", connection);
                    cnd.CommandType = CommandType.StoredProcedure;
                    cnd.Parameters.AddWithValue("@EmpName", employee.name);
                    cnd.Parameters.AddWithValue("@StartDate", employee.startDate);
                    cnd.Parameters.AddWithValue("@Gender", employee.gender);
                    cnd.Parameters.AddWithValue("@Address", employee.Address);
                    cnd.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                    connection.Open();

                    var result = cnd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateEmployeeSalary()
        {
            try
            {
                //EmployeePayroll employeePayroll = new EmployeePayroll();
                using (connection)
                {
                    string query = @"update payments set net_pay=47000 where id=(select id from Employee_payroll where name='venkey'); ";
                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();

                    // this.connection.Open();
                    var result = cnd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        Console.WriteLine("Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No record found for the given firstName");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();

            }
        }


        public bool UpdateEmployeeSalaryUsingStoredProcedure(string name, double salary)
        {
            try
            {

                using (connection)
                {

                    SqlCommand cnd = new SqlCommand("sp_UpdateSalary", connection);
                    cnd.CommandType = CommandType.StoredProcedure;
                    cnd.Parameters.AddWithValue("@salary", salary);
                    cnd.Parameters.AddWithValue("@name", name);

                    connection.Open();

                    var result = cnd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetAllSalaries()
        {
            try
            {
                Payments payments = new Payments();
                using (connection)
                {
                    string query = @"select * from payments";
                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader dr = cnd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("Id" + " " + "Basic_pay" + " " + "Deductions" + " " + "Taxable_Pay" + " " + "Tax" + " " + "Net_pay" + "\n");
                        while (dr.Read())
                        {
                            payments.id = dr.GetInt32(0);
                            payments.basicPay = dr.GetDecimal(1);
                            payments.deductions = dr.GetDecimal(2);
                            payments.taxable_pay = dr.GetDecimal(3);
                            payments.tax = dr.GetDecimal(4);
                            payments.net_pay = dr.GetDecimal(5);


                            Console.WriteLine(payments.id + "  " + payments.basicPay + "  " + payments.deductions + "  " + payments.taxable_pay + " " + payments.tax + "  " + payments.net_pay);
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No DAta found");
                    }
                    dr.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public void OperationOnSalaries(string query)
        {
            try
            {
                Payments payments = new Payments();
                using (connection)
                {

                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader dr = cnd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetString(0)+"  "+dr.GetDecimal(1));
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }


        }
    }
}
