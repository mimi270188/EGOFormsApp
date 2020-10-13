using DAL;
using EGO.Container;
using EGO.Controller;
using EGO.View.Family;
using EGO.View.GymGroup;
using EGO.View.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemPerson_Click(object sender, EventArgs e)
        {
            this.Text = "Espoirs Gymniques d'Osny - Adhérents";
            panel1.Controls.Clear();
            FrmPerson frmPerson = new FrmPerson() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.panel1.Controls.Add(frmPerson);

            this.Text = "Espoirs Gymniques d'Osny - Adhérents";
            panel2.Controls.Clear();
            FrmGymGroup frmGymGroup = new FrmGymGroup() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.panel2.Controls.Add(frmGymGroup);
            frmPerson._dataUpdated += DataUpdatedPerson;

            frmPerson.Show();
            frmGymGroup.Show();
        }

        public static void DataUpdatedPerson(PERSON person, Form frmMain)
        {
            Panel panel2 = frmMain.Controls.OfType<Panel>().First(x => x.Name == "panel2");
            panel2.Controls.Clear();
            FrmGymGroup frmGymGroup = new FrmGymGroup(person) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            panel2.Controls.Add(frmGymGroup);
            frmGymGroup.Show();
        }

        private void ToolStripMenuItemFamily_Click(object sender, EventArgs e)
        {
            this.Text = "Espoirs Gymniques d'Osny - Famille";
            panel1.Controls.Clear();
            FrmFamily frmFamily = new FrmFamily() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.panel1.Controls.Add(frmFamily);
            frmFamily.Show();
        }

        private void ToolStripMenuItemGymGroup_Click(object sender, EventArgs e)
        {
            this.Text = "Espoirs Gymniques d'Osny - Groupe";
            panel1.Controls.Clear();
            FrmGymGroup gymGroup = new FrmGymGroup() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.panel1.Controls.Add(gymGroup);
            gymGroup.Show();
        }
    }
}
