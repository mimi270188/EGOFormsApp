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
    public partial class FrmGroup : Form
    {
        public FrmGroup()
        {
            InitializeComponent();
        }

        private void créationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGroupCreationEdit frmGroupCreationEdit = new FrmGroupCreationEdit("Groupe - Création") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pContainerGroup.Controls.Add(frmGroupCreationEdit);
            frmGroupCreationEdit.Show();
        }

        private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGroupSearch frmGroupSearch = new FrmGroupSearch("Groupe - Recherche") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pContainerGroup.Controls.Add(frmGroupSearch);
            frmGroupSearch.Show();
        }
    }
}
