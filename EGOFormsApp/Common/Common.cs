using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.Common
{
    public static class Common
    {
        public static int CurrentStartYear()
        {
            if (DateTime.Now.Month > 8)
            {
                return DateTime.Now.Year;
            }
            else
            {
                return DateTime.Now.Year - 1;
            }
        }
    }
}
