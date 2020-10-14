using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace GymApp1.ViewModel
{
    class PaymentSearchView
    {
        public PaymentSearchView(PAYMENT payment)
        {
            this.PAYMENTID = payment.PAYMENTID;
            this.PAYMENTTYPENAME = payment.PAYMENTTYPE.NAME;
            this.FAMILYNAME = payment.FAMILY.LASTNAME;
            this.GYMYEAR = payment.GYMYEAR;
            this.PAYMENTDATE = payment.PAYMENTDATE;
            this.CHECKNUMBER = payment.CHECKNUMBER;
            this.AMOUNT = payment.AMOUNT;
        }

        public PaymentSearchView(List<PAYMENT> payments)
        {
            this.PaymentSearchViews = new List<PaymentSearchView>();
            foreach (var payment in payments)
            {
                PaymentSearchView paymentSearchView = new PaymentSearchView(payment);
                this.PaymentSearchViews.Add(paymentSearchView);
            }
        }
        public int PAYMENTID { get; set; }
        public string PAYMENTTYPENAME { get; set; }
        public string FAMILYNAME { get; set; }
        public int GYMYEAR { get; set; }
        public System.DateTime PAYMENTDATE { get; set; }
        public Nullable<int> CHECKNUMBER { get; set; }
        public float AMOUNT { get; set; }
        public List<PaymentSearchView> PaymentSearchViews { get; set; }

    }
}
