using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace EGOFormsApp.ViewModel
{
    class PersonKindSearchView
    {
        public PersonKindSearchView(PERSON_KIND personkind)
        {
            this.PERSON_KIND_ID = personkind.PERSON_KIND_ID;
            this.KINDNAME = personkind.KIND.KINDNAME;
        }

        public PersonKindSearchView(List<PERSON_KIND> personkinds)
        {
            this.PersonKindSearchViews = new List<PersonKindSearchView>();
            foreach (var personkind in personkinds)
            {
                PersonKindSearchView personkindSearchView = new PersonKindSearchView(personkind);
                this.PersonKindSearchViews.Add(personkindSearchView);
            }
        }
        public int PERSON_KIND_ID { get; set; }
        public string KINDNAME { get; set; }
        public List<PersonKindSearchView> PersonKindSearchViews { get; set; }

    }
}
