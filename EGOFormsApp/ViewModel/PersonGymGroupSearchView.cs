using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.ViewModel
{
    class PersonGymGroupSearchView
    {
        public PersonGymGroupSearchView(PERSON_GYMGROUP personGymGroup)
        {
            this.PERSON_GYMGROUP_ID = personGymGroup.PERSON_GYMGROUP_ID;
            this.GYMGROUPNAME = personGymGroup.GYMGROUP.GYMGROUPNAME;
            this.NUMBEROFHOURS = personGymGroup.GYMGROUP.NUMBEROFHOURS;
            this.GYMGROUPYEAR = personGymGroup.GYMGROUP.GYMGROUPYEAR;
            this.YEARPRICE = personGymGroup.GYMGROUP.YEARPRICE;
        }

        public PersonGymGroupSearchView(List<PERSON_GYMGROUP> personGymGroups)
        {
            this.PersonGymGroupSearchViews = new List<PersonGymGroupSearchView>();
            foreach (var personGymGroup in personGymGroups)
            {
                PersonGymGroupSearchView personGymGroupSearchView = new PersonGymGroupSearchView(personGymGroup);
                this.PersonGymGroupSearchViews.Add(personGymGroupSearchView);
            }
        }

        public int PERSON_GYMGROUP_ID { get; set; }
        public string GYMGROUPNAME { get; set; }
        public float NUMBEROFHOURS { get; set; }
        public int GYMGROUPYEAR { get; set; }
        public float YEARPRICE { get; set; }
        public List<PersonGymGroupSearchView> PersonGymGroupSearchViews { get; set; }
    }
}
