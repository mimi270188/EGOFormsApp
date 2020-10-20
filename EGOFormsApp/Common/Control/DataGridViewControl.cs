using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp.Common.Control
{
    public static class DataGridViewControl
    {
        public static void SetHeaderName(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderText = Translation.GetByKey(column.HeaderText);
            }
        }
    }
}
