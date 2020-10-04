using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp.Family
{
    public partial class FrmFamily : Form
    {
        public FrmFamily()
        {
            InitializeComponent();
        }

        private void créationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFamilyCreationEdit frmFamilyCreationEdit = new FrmFamilyCreationEdit("Famille - Création") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pContainerFamily.Controls.Add(frmFamilyCreationEdit);
            frmFamilyCreationEdit.Show();
        }

        private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFamilySearch frmFamilySearch = new FrmFamilySearch() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmFamilySearch.FrmName = "Famille - Recherche";
            this.pContainerFamily.Controls.Add(frmFamilySearch);
            frmFamilySearch.Show();
        }
    }
}
