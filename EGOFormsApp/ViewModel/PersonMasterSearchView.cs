using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class PersonMasterSearchView
    {
        public PersonMasterSearchView(PERSON person)
        {
            this.PERSONID = person.PERSONID;
            this.LASTNAME = person.LASTNAME;
            this.FIRSTNAME = person.FIRSTNAME;
            this.BIRTHDATE = person.BIRTHDATE;
        }

        public PersonMasterSearchView(List<PERSON> persons)
        {
            this.PersonSearchViews = new List<PersonMasterSearchView>();
            foreach (var person in persons)
            {
                PersonMasterSearchView personSearchView = new PersonMasterSearchView(person);
                this.PersonSearchViews.Add(personSearchView);
            }
        }
        public int PERSONID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public List<PersonMasterSearchView> PersonSearchViews { get; set; }

    }
}
