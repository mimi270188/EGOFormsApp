using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.Model
{
    public class ReportPayment
    {
        public string LASTNAME { get; set; }
        public string ZIPCODE { get; set; }
        public string ADDRESS { get; set; }
        public float PAID { get; set; }
        public float RECEIVABLE { get; set; }
        public float REMAININGBALANCE { get; set; }
    }
}
