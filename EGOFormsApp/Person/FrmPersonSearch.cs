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
using EGOFormsApp.ViewModel.Person;

namespace EGOFormsApp.Person
{
    public partial class FrmPersonSearch : Form
    {
        private List<PERSON> persons = new List<PERSON>();
        private FAMILY family;
        public FrmPersonSearch(FAMILY _family)
        {
            family = _family;
            InitializeComponent();
            PersonSearchView personSearchView;
            EGOEntities egoEntities = new EGOEntities();

            persons = egoEntities.PERSON.Where(x => x.FAMILYID == family.FAMILYID).ToList();
            personSearchView = new PersonSearchView(persons);

            dataGridView1.DataSource = personSearchView.PersonSearchViews;
            dataGridView1.Visible = true;
        }

        public FrmPersonSearch()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void FrmPersonSearch_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PersonSearchView personSearchView;
            EGOEntities egoEntities = new EGOEntities();

            persons = egoEntities.PERSON.Where(x => x.FAMILY.LASTNAME.Contains(textBoxLastName.Text) && x.FIRSTNAME.Contains(textBoxFirstName.Text)).ToList();
            personSearchView = new PersonSearchView(persons);

            dataGridView1.DataSource = personSearchView.PersonSearchViews;
            dataGridView1.Visible = true;
        }
    }
}
