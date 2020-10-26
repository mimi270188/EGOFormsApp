using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class CoachSearchView
    {
        public CoachSearchView(PERSON person)
        {
            this.PERSONID = person.PERSONID;
            this.LASTNAME = person.LASTNAME;
            this.FIRSTNAME = person.FIRSTNAME;
            this.BIRTHDATE = person.BIRTHDATE;
            this.HOURLYRATE = person.HOURLYRATE;
        }

        public CoachSearchView(List<PERSON> persons)
        {
            this.CoachSearchViews = new List<CoachSearchView>();
            foreach (var person in persons)
            {
                CoachSearchView coachSearchView = new CoachSearchView(person);
                this.CoachSearchViews.Add(coachSearchView);
            }
        }
        public int PERSONID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<float> HOURLYRATE { get; set; }
        public string GYMGROUPNAME { get; set; }
        public int GYMGROUPYEAR { get; set; }
        public List<CoachSearchView> CoachSearchViews { get; set; }

    }
}
