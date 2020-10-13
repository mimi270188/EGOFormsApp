using DAL;
using EGO.Container;
using EGO.View.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.Controller
{
    class EgoDocument : EgoObject
    {
        public EgoDocument()
        {
            this._type = typeof(DOCUMENT);
        }
    }
}
