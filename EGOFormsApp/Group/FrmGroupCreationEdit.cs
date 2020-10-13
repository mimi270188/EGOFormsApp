using DAL;
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
    public partial class FrmGroupCreationEdit : Form
    {
        GYMGROUP _gymGroup;
        public bool _isUpdating = false;

        public FrmGroupCreationEdit(string FrmName = "Groupe")
        {
            InitializeComponent();
            this.Text = FrmName;
        }

        public FrmGroupCreationEdit(GYMGROUP gymGroup, string FrmName = "Groupe")
        {
            InitializeComponent();
            this.Text = FrmName;
            _isUpdating = true;
            _gymGroup = gymGroup;

            textBoxGroupName.Text = gymGroup.GYMGROUPNAME;
            numericUpDownGymYear.Value = gymGroup.GYMGROUPYEAR;
            numericUpDownNumberOfHours.Value = (decimal)gymGroup.NUMBEROFHOURS;
            numericUpDownYearPrice.Value = (decimal)gymGroup.YEARPRICE;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                EGOEntities egoEntities = new EGOEntities();
                GYMGROUP gymGroup = new GYMGROUP();

                gymGroup.GYMGROUPNAME = textBoxGroupName.Text;
                gymGroup.GYMGROUPYEAR = (int)numericUpDownGymYear.Value;
                gymGroup.NUMBEROFHOURS = (float)numericUpDownNumberOfHours.Value;
                gymGroup.YEARPRICE = (float)numericUpDownYearPrice.Value;

                if (!_isUpdating)
                {
                    egoEntities.GYMGROUP.Add(gymGroup);
                }
                
                egoEntities.SaveChanges();

                MessageBox.Show("Enregistrer");
                CleanAllControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CleanAllControls()
        {
            textBoxGroupName.Text = string.Empty;
            numericUpDownGymYear.Value = 0;
            numericUpDownNumberOfHours.Value = 0;
            numericUpDownYearPrice.Value = 0;
        }
    }
}
