using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_management
{
    public class EmployeePayroll
    {

        public int id {
            get; 
            set; 
        }
        public string name {
            get; 
            set;
        }
        public DateTime startDate
        {
            get;
            set;
        }
        public char gender
        {
            get; 
            set;
        }
        public string Address
        { 
            get;
            set; 
        }
        public string phoneNumber
        { 
            get; 
            set; 
        }

        public EmployeePayroll()
        {
            
        }
        public EmployeePayroll(int id,string name,DateTime startDate,char gender,string address,string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.startDate = startDate;
            this.gender = gender;
            this.Address = address;
            this.phoneNumber = phoneNumber;
        }
    }
}
