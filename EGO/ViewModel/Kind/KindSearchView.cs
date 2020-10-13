using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.ViewModel.Kind
{
    class KindSearchView
    {
        public KindSearchView(KIND kind)
        {
            this.KINDNAME = kind.KINDNAME;
        }

        public KindSearchView(List<KIND> kinds)
        {
            this.KindSearchViews = new List<KindSearchView>();
            foreach (var kind in kinds)
            {
                KindSearchView kindSearchView = new KindSearchView(kind);
                this.KindSearchViews.Add(kindSearchView);
            }
        }

        public string KINDNAME { get; set; }

        public List<KindSearchView> KindSearchViews { get; set; }
    }
}
