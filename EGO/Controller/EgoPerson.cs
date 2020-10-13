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
    class EgoPerson : EgoObject
    {
        public EgoPerson()
        {
            this._type = typeof(PERSON);
        }
    }
}
