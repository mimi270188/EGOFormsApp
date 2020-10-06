using DAL;
using EGOFormsApp.ViewModel.Group;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp.Group
{
    public partial class FrmGroupSearch : Form
    {
        public FrmGroupSearch(string FrmName = "Groupe")
        {
            InitializeComponent();
            this.Text = FrmName;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DataGridViewRefresh((int)numericUpDownGymYear.Value);
        }

        private void DataGridViewRefresh(int gymYear)
        {
            EGOEntities egoEntities = new EGOEntities();
            List<GYMGROUP> gymGroups;
            if (gymYear == 0)
            {
                gymGroups = egoEntities.GYMGROUP.ToList();
            }
            else
            {
                gymGroups = egoEntities.GYMGROUP.Where(x => x.GYMYEAR == gymYear).ToList();
            }
            GymGroupSearchView gymGroupSearchView = new GymGroupSearchView(gymGroups);
            dataGridViewGymGroup.DataSource = gymGroupSearchView.GymGroupSearchViews;
        }
    }
}
