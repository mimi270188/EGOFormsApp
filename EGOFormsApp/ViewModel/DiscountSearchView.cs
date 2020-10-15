using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class DiscountSearchView
    {
        public DiscountSearchView(DISCOUNT discount)
        {
            this.DISCOUNTID = discount.DISCOUNTID;
            this.DISCOUNTYEAR = discount.DISCOUNTYEAR;
            this.DESCRIPTION = discount.DESCRIPTION;
            this.AMOUNT = discount.AMOUNT;
        }

        public DiscountSearchView(List<DISCOUNT> discounts)
        {
            this.DiscountSearchViews = new List<DiscountSearchView>();
            foreach (var discount in discounts)
            {
                DiscountSearchView discountSearchView = new DiscountSearchView(discount);
                this.DiscountSearchViews.Add(discountSearchView);
            }
        }
        public int DISCOUNTID { get; set; }
        public int DISCOUNTYEAR { get; set; }
        public string DESCRIPTION { get; set; }
        public float AMOUNT { get; set; }
        public List<DiscountSearchView> DiscountSearchViews { get; set; }

    }
}
