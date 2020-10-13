﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.ViewModel.Group
{
    class GymGroupSearchView
    {
        public GymGroupSearchView(GYMGROUP gymGroup)
        {
            this.GYMGROUPNAME = gymGroup.GYMGROUPNAME;
            this.NUMBEROFHOURS = gymGroup.NUMBEROFHOURS;
            this.GYMYEAR = gymGroup.GYMGROUPYEAR;
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

        public string GYMGROUPNAME { get; set; }
        public float NUMBEROFHOURS { get; set; }
        public int GYMYEAR { get; set; }
        public float YEARPRICE { get; set; }
        public List<GymGroupSearchView> GymGroupSearchViews { get; set; }
    }
}
