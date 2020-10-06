using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using EGOFormsApp.ViewModel.Family;

namespace EGOFormsApp.Family
{
    public partial class FrmFamilySearch : Form
    {
        public string FrmName = string.Empty;
        private List<FAMILY> familys = new List<FAMILY>();
        public FrmFamilySearch(string FrmName = "Famille")
        {
            InitializeComponent();
            this.Text = FrmName;
            dataGridView1.Visible = false;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FamilySearchView familySearchView;
            EGOEntities egoEntities = new EGOEntities();

            familys = egoEntities.FAMILY.Where(x => x.LASTNAME.Contains(textBoxLastName.Text)).ToList();
            familySearchView = new FamilySearchView(familys);

            dataGridView1.DataSource = familySearchView.FamilySearchViews;
            dataGridView1.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                dataGridView1.Visible = false;
                FrmFamilyCreationEdit frmFamilyCreationEdit = new FrmFamilyCreationEdit(familys[dataGridView1.CurrentCell.RowIndex], "Famille - Modification") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.pContainerFamilySearch.Controls.Add(frmFamilyCreationEdit);
                frmFamilyCreationEdit.Show();
        }
    }
}
