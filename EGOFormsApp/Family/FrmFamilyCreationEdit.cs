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
using EGOFormsApp._Phone;
using EGOFormsApp.Person;
using EGOFormsApp.ViewModel.Person;
using EGOFormsApp.ViewModel.Phone;

namespace EGOFormsApp.Family
{
    public partial class FrmFamilyCreationEdit : Form
    {
        public bool _isUpdating = false;
        private FAMILY _family;

        public FrmFamilyCreationEdit(string FrmName = "Famille")
        {
            InitializeComponent();
            this.Text = FrmName;
        }

        public FrmFamilyCreationEdit(FAMILY family, string FrmName = "Famille")
        {
            InitializeComponent();
            _family = family;
            this.Text = FrmName;
            textBoxAddress.Text = family.ADDRESS;
            textBoxCity.Text = family.CITY;
            textBoxEmail.Text = family.EMAIL;
            textBoxLastName.Text = family.LASTNAME;
            textBoxZipCode.Text = family.ZIPCODE;

            DataGridViewRefresh(family);
        }

        private void buttonSaveFamily_Click(object sender, EventArgs e)
        {
            try
            {
                FAMILY family = new FAMILY();
                List<PHONE> phones = new List<PHONE>();
                EGOEntities egoEntities = new EGOEntities();

                family.ADDRESS = textBoxAddress.Text;
                family.CITY = textBoxCity.Text;
                family.EMAIL = textBoxEmail.Text;
                family.LASTNAME = textBoxLastName.Text;
                family.ZIPCODE = textBoxZipCode.Text;

                egoEntities.FAMILY.Add(family);

                _family = family;

                egoEntities.SaveChanges();

                MessageBox.Show("Enregistrer");
                CleanAllTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            var currentTextBox = sender as TextBox;
            currentTextBox.SelectionStart = currentTextBox.TextLength;
        }
        private void CleanAllTextBox()
        {
            textBoxAddress.Text = string.Empty;
            textBoxCity.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxZipCode.Text = string.Empty;
        }

        private void buttonPersonAdd_Click(object sender, EventArgs e)
        {
            FrmPersonCreationEdit frmPersonCreationEdit = new FrmPersonCreationEdit("Personne - Création");
            frmPersonCreationEdit.ShowDialog();
            EGOEntities egoEntities = new EGOEntities();
            _family.PERSON = egoEntities.PERSON.Where(x => x.FAMILYID == _family.FAMILYID).ToList();
            DataGridViewRefresh(_family);
        }

        private void DataGridViewRefresh(FAMILY family)
        {
            PersonSearchView personSearchView = new PersonSearchView(family.PERSON.ToList());
            dataGridViewPerson.DataSource = personSearchView.PersonSearchViews;

            PhoneSearchView phoneSearchView = new PhoneSearchView(family.PHONE.ToList());
            dataGridViewPhone.DataSource = phoneSearchView.PhoneSearchViews;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmPersonCreationEdit frmPersonCreationEdit = new FrmPersonCreationEdit(_family.PERSON.ToList()[dataGridViewPerson.CurrentCell.RowIndex], "Personne - Modification");
            frmPersonCreationEdit.ShowDialog();
        }

        private void buttonPhoneAdd_Click(object sender, EventArgs e)
        {
            FrmPhoneCreationEdit frmPhoneCreationEdit = new FrmPhoneCreationEdit(_family, "Téléphone - Modification");
            frmPhoneCreationEdit.ShowDialog();
        }
    }
}
