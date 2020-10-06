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
        void CreateEditForm(Form frm, Type type);
        void SearchFrom(Form frm);
    }
}
