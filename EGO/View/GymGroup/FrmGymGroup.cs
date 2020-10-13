using DAL;
using System;
using EGO.Controller;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGO.Container;
using EGO.ViewModel.Group;

namespace EGO.View.GymGroup
{
    public partial class FrmGymGroup : Form
    {
        private EgoObject _egoGymGroup = new EgoGymGroup();
        private EGOEntities _egoEntities;
        private List<GYMGROUP> _gymGroups;
        public FrmGymGroup(PERSON person = null)
        {
            InitializeComponent();
            numericUpDownGymGroupYear.Value = DateTime.Now.Year;
            _egoEntities = new EGOEntities();
            RefreshDataGridView(person);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Création";
            frm.Height = 600;
            frm.Width = 600;
            _egoGymGroup.CreateEditForm(frm, _egoEntities);
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                _egoEntities.GYMGROUP.Remove(_gymGroups[dataGridView1.CurrentCell.RowIndex]);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Form frm = new Form();
                frm.Text = "Modification";
                frm.Height = 600;
                frm.Width = 600;
                _egoGymGroup.CreateEditForm(frm, _egoEntities, _gymGroups[dataGridView1.CurrentCell.RowIndex]);
                frm.ShowDialog();
            }
            RefreshDataGridView();
        }

        private void RefreshDataGridView(PERSON person = null)
        {
            if (person == null)
            {
                _gymGroups = _egoEntities.GYMGROUP.Where(x => x.GYMGROUPNAME.Contains(textBoxGymGroupName.Text) & x.GYMGROUPYEAR == numericUpDownGymGroupYear.Value).ToList();
            }
            else
            {
                List<int> groupIdPerson = person.PERSON_GYMGROUP.Select(x => x.GYMGROUPID).ToList();
                _gymGroups = _egoEntities.GYMGROUP.Where(x => groupIdPerson.Contains(x.GYMGROUPID)).ToList();
            }
            GymGroupSearchView gymGroupSearchView = new GymGroupSearchView(_gymGroups);
            dataGridView1.DataSource = gymGroupSearchView.GymGroupSearchViews;
        }

        private void buttonBind_Click(object sender, EventArgs e)
        {
            FrmGymGroupBind frmGymGroupBind = new FrmGymGroupBind();
            frmGymGroupBind.Text = "Liaison";
            frmGymGroupBind.Height = 600;
            frmGymGroupBind.Width = 600;
            frmGymGroupBind.ShowDialog();
        }
    }
}
