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
using EGOFormsApp.Model;
using EGOFormsApp.Common;
using Microsoft.Reporting.WinForms;

namespace EGOFormsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPanels();
            this.Text = "Espoirs Gymniques d'Osny - Famille";
            MasterObject<FAMILY> _masterObjectFamily = new MasterObject<FAMILY>(this);
        }


        private void PersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPanels();
            this.Text = "Espoirs Gymniques d'Osny - Adhérent";
            MasterObject<PERSON> _masterObjectPerson = new MasterObject<PERSON>(this);
        }
        private void GroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPanels();
            this.Text = "Espoirs Gymniques d'Osny - Groupe";
            MasterObject<GYMGROUP> _masterObjectPerson = new MasterObject<GYMGROUP>(this);
        }


        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetting FrmSetting = new FrmSetting();
            this.Text = "Espoirs Gymniques d'Osny - Configuration";
            FrmSetting.ShowDialog();
        }

        private void ResetPanels()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            panel4.Controls.Clear();
            panel5.Controls.Clear();
        }

        private void MissingDocumentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmReport frmReport = new FrmReport("EGOFormsApp.Reports.ReportDocuments.rdlc");
            frmReport.Show();
            Cursor.Current = Cursors.Default;
        }

        private void MissingPaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmReport frmReport = new FrmReport("EGOFormsApp.Reports.ReportPayments.rdlc");
            frmReport.Show(this);
            Cursor.Current = Cursors.Default;
        }

        private void DateOfPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmReport frmReport = new FrmReport("EGOFormsApp.Reports.ReportDateOfPayments.rdlc");
            frmReport.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
