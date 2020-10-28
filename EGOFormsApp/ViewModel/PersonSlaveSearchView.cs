using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class PersonSlaveSearchView
    {
        public PersonSlaveSearchView(PERSON person, int _currentStartYear)
        {
            this.PERSONID = person.PERSONID;
            this.LASTNAME = person.LASTNAME;
            this.FIRSTNAME = person.FIRSTNAME;
            this.BIRTHDATE = person.BIRTHDATE;
            this.GYMGROUPNAME = person.PERSON_GYMGROUP.Select(x => x.GYMGROUP).First(x => x.GYMGROUPYEAR == _currentStartYear).GYMGROUPNAME;
            this.YEARPRICE = person.PERSON_GYMGROUP.Select(x => x.GYMGROUP).First(x => x.GYMGROUPYEAR == _currentStartYear).YEARPRICE;
        }

        public PersonSlaveSearchView(List<PERSON> persons, int _currentStartYear)
        {
            this.PersonSlaveSearchViews = new List<PersonSlaveSearchView>();
            foreach (var person in persons)
            {
                PersonSlaveSearchView personSlaveSearchView = new PersonSlaveSearchView(person, _currentStartYear);
                this.PersonSlaveSearchViews.Add(personSlaveSearchView);
            }
        }
        public int PERSONID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string GYMGROUPNAME { get; set; }
        public float YEARPRICE { get; set; }
        public List<PersonSlaveSearchView> PersonSlaveSearchViews { get; set; }

    }
}
