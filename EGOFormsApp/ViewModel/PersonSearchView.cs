using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class PersonSearchView
    {
        public PersonSearchView(PERSON person)
        {
            this.PERSONID = person.PERSONID;
            this.LASTNAME = person.LASTNAME;
            this.FIRSTNAME = person.FIRSTNAME;
            this.BIRTHDATE = person.BIRTHDATE;
            this.HOURLYRATE = person.HOURLYRATE;
        }

        public PersonSearchView(List<PERSON> persons)
        {
            this.PersonSearchViews = new List<PersonSearchView>();
            foreach (var person in persons)
            {
                PersonSearchView personSearchView = new PersonSearchView(person);
                this.PersonSearchViews.Add(personSearchView);
            }
        }
        public int PERSONID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public Nullable<float> HOURLYRATE { get; set; }
        public List<PersonSearchView> PersonSearchViews { get; set; }

    }
}
