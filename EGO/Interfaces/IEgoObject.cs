using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.Interfaces
{
    interface IEgoObject
    {
        Type _type { get; set; }
        void CreateEditForm(Form frm, EGOEntities _egoEntities, object obj = null);
    }
}
