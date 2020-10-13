using EGO.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Reflection;

namespace EGO.Controller
{
    class EgoFamily : EgoObject
    {
        public EgoFamily()
        {
            this._type = typeof(FAMILY);
        }
    }
}
