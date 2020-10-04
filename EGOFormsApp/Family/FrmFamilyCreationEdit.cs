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
using EGOFormsApp.Person;
using EGOFormsApp.ViewModel.Person;

namespace EGOFormsApp.Family
{
    public partial class FrmFamilyCreationEdit : Form
    {
        public bool isUpdating = false;
        private FAMILY family;
        public FrmFamilyCreationEdit(string FrmName = "Famille")
        {
            InitializeComponent();

            this.Text = FrmName;
            //textBoxAddress.Text = "35 RUE DE L ABREUVOIR";
            //textBoxCity.Text = "VAUREAL";
            //textBoxEmail.Text = "grandiere.michael@hotmail.fr";
            //textBoxLastName.Text = "GRANDIERE";
            //textBoxZipCode.Text= "95490";
            //textBoxPhone1.Text = "06.37.80.38.12";
            //textBoxPhone2.Text = "06.16.15.85.79";
        }

        public FrmFamilyCreationEdit(FAMILY _family, string FrmName = "Famille")
        {
            InitializeComponent();
            family = _family;
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
                FAMILY _family = new FAMILY();
                List<PHONE> phones = new List<PHONE>();
                EGOEntities egoEntities = new EGOEntities();

                _family.ADDRESS = textBoxAddress.Text;
                _family.CITY = textBoxCity.Text;
                _family.EMAIL = textBoxEmail.Text;
                _family.LASTNAME = textBoxLastName.Text;
                _family.ZIPCODE = textBoxZipCode.Text;

                egoEntities.FAMILY.Add(_family);

                family = _family;

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
            FrmPersonCreationEdit frmPersonCreationEdit = new FrmPersonCreationEdit(family);
            frmPersonCreationEdit.ShowDialog();
            EGOEntities egoEntities = new EGOEntities();
            family.PERSON = egoEntities.PERSON.Where(x => x.FAMILYID == family.FAMILYID).ToList();
            DataGridViewRefresh(family);
        }

        private void DataGridViewRefresh(FAMILY family)
        {
            PersonSearchView personSearchView = new PersonSearchView(family.PERSON.ToList());
            dataGridView1.DataSource = personSearchView.PersonSearchViews;
        }
    }
}
