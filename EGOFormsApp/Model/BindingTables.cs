using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGOFormsApp.Model
{
    public class BindingTables
    {
        public BindingTables(string _materObjectName, string _slaveObjectName)
        {
            MasterObjectName = _materObjectName;
            SlaveObjectName = _slaveObjectName;
        }
        public string MasterObjectName { get; set; }
        public string SlaveObjectName { get; set; }
    }
}
