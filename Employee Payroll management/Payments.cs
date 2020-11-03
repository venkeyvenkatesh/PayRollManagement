using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_management
{
   public class Payments
    {
        public int id
        {
            get;
            set;

        }
        public decimal basicPay
        {
            get;
            set;
        }
        public decimal deductions
        {
            get;
            set;
        }
        public decimal taxable_pay
        {
            get;
            set;
        }
        public decimal tax
        {
            get;
            set;
        }
        public decimal net_pay
        {
            get;
            set;
        }
    }
}
