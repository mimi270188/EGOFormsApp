using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.Model
{
    public class ReportDateOfPayment
    {
        public string LASTNAME { get; set; }
        public int GYMYEAR { get; set; }
        public System.DateTime PAYMENTDATE { get; set; }
        public Nullable<int> CHECKNUMBER { get; set; }
        public float AMOUNT { get; set; }
    }
}
