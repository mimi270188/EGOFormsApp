using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.ViewModel
{
    class GymGroupSearchView
    {
        public GymGroupSearchView(GYMGROUP gymGroup)
        {
            this.GYMGROUPID = gymGroup.GYMGROUPID;
            this.GYMGROUPNAME = gymGroup.GYMGROUPNAME;
            this.NUMBEROFHOURS = gymGroup.NUMBEROFHOURS;
            this.GYMGROUPYEAR = gymGroup.GYMGROUPYEAR;
            this.YEARPRICE = gymGroup.YEARPRICE;
        }

        public GymGroupSearchView(List<GYMGROUP> gymGroups)
        {
            this.GymGroupSearchViews = new List<GymGroupSearchView>();
            foreach (var gymGroup in gymGroups)
            {
                GymGroupSearchView gymGroupSearchView = new GymGroupSearchView(gymGroup);
                this.GymGroupSearchViews.Add(gymGroupSearchView);
            }
        }

        public int GYMGROUPID { get; set; }
        public string GYMGROUPNAME { get; set; }
        public float NUMBEROFHOURS { get; set; }
        public int GYMGROUPYEAR { get; set; }
        public float YEARPRICE { get; set; }
        public List<GymGroupSearchView> GymGroupSearchViews { get; set; }
    }
}
