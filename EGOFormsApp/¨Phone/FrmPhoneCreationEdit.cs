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

namespace EGOFormsApp._Phone
{
    public partial class FrmPhoneCreationEdit : Form
    {
        private FAMILY _family;
        public FrmPhoneCreationEdit(FAMILY family, string FrmName = "Téléphone")
        {
            InitializeComponent();
            this.Text = FrmName;
            _family = family;
        }

        private void buttonPhoneAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EGOEntities egoEntities = new EGOEntities();
                PHONE phone = new PHONE();

                phone.FAMILYID = _family.FAMILYID;
                phone.PHONENUMBER = textBoxPhoneNumber.Text;

                egoEntities.PHONE.Add(phone);
                egoEntities.SaveChanges();

                MessageBox.Show("Enregistrer");

                textBoxPhoneNumber.Text = string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
