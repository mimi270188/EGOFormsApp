using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace GymApp.ViewModel
{
    class FamilySearchView
    {
        public FamilySearchView(FAMILY family)
        {
            this.FAMILYID = family.FAMILYID;
            this.LASTNAME = family.LASTNAME;
            this.ADDRESS = family.ADDRESS;
            this.ZIPCODE = family.ZIPCODE;
            this.CITY = family.CITY;
            this.EMAIL = family.EMAIL;
        }

        public FamilySearchView(List<FAMILY> familys)
        {
            this.FamilySearchViews = new List<FamilySearchView>();
            foreach (var family in familys)
            {
                FamilySearchView familySearchView = new FamilySearchView(family);
                this.FamilySearchViews.Add(familySearchView);
            }
        }

        public int FAMILYID { get; set; }
        public string LASTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public string CITY { get; set; }
        public string EMAIL { get; set; }
        public List<FamilySearchView> FamilySearchViews { get; set; }
    }
}
