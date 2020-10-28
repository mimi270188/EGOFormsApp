using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.ViewModel
{
    class GymGroupPersonSearchView
    {
        public GymGroupPersonSearchView(PERSON_GYMGROUP gymGroupPerson)
        {
            this.PERSON_GYMGROUP_ID = gymGroupPerson.PERSON_GYMGROUP_ID;
            this.LASTNAME = gymGroupPerson.PERSON.LASTNAME;
            this.FIRSTNAME = gymGroupPerson.PERSON.FIRSTNAME;
            this.BIRTHDATE = gymGroupPerson.PERSON.BIRTHDATE;
            this.HOURLYRATE = gymGroupPerson.PERSON.HOURLYRATE;
            this.KINDNAME = gymGroupPerson.KIND.KINDNAME;
        }

        public GymGroupPersonSearchView(List<PERSON_GYMGROUP> gymGroupPersons)
        {
            this.GymGroupPersonSearchViews = new List<GymGroupPersonSearchView>();
            foreach (var gymGroupPerson in gymGroupPersons)
            {
                GymGroupPersonSearchView gymGroupPersonSearchView = new GymGroupPersonSearchView(gymGroupPerson);
                this.GymGroupPersonSearchViews.Add(gymGroupPersonSearchView);
            }
        }

        public int PERSON_GYMGROUP_ID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<float> HOURLYRATE { get; set; }
        public string CITY { get; set; }
        public string KINDNAME { get; set; }
        public List<GymGroupPersonSearchView> GymGroupPersonSearchViews { get; set; }
    }
}
