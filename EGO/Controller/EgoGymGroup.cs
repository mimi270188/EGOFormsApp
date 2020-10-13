using DAL;
using EGO.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.Controller
{
    class EgoGymGroup : EgoObject
    {
        public EgoGymGroup()
        {
            this._type = typeof(GYMGROUP);
        }
    }
}
