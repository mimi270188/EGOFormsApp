using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.ViewModel.Phone
{
    class PhoneSearchView
    {
        public PhoneSearchView(PHONE phone)
        {
            this.PHONENUMBER = phone.PHONENUMBER;
        }
        public PhoneSearchView(List<PHONE> phones)
        {
            this.PhoneSearchViews = new List<PhoneSearchView>();
            foreach (var phone in phones)
            {
                PhoneSearchView phoneSearchView = new PhoneSearchView(phone);
                this.PhoneSearchViews.Add(phoneSearchView);
            }
        }
        public string PHONENUMBER { get; set; }
        public List<PhoneSearchView> PhoneSearchViews { get; set; }

    }
}
