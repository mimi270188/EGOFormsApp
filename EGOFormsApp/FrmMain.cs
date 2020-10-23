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

        private void ResetPanels()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            panel4.Controls.Clear();
            panel5.Controls.Clear();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetting FrmSetting = new FrmSetting();
            this.Text = "Espoirs Gymniques d'Osny - Configuration";
            FrmSetting.ShowDialog();
        }

        private void documentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = GetReportDocuments();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", bindingSource);
            frmReport.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            frmReport.reportViewer.LocalReport.ReportEmbeddedResource = "EGOFormsApp.Reports.ReportDocuments.rdlc";
            frmReport.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            var setup = frmReport.reportViewer.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            frmReport.reportViewer.SetPageSettings(setup);
            frmReport.reportViewer.Refresh();
            frmReport.ShowDialog();
        }

        private List<ReportDocument> GetReportDocuments()
        {
            List<ReportDocument> ReportDocuments = new List<ReportDocument>();
            EGOEntities egoEntities = new EGOEntities();
            List<PERSON> persons = egoEntities.PERSON.ToList();
            List<DOCUMENTTYPE> documentTypes = egoEntities.DOCUMENTTYPE.ToList();
            List<GYMGROUP> gymGroups = egoEntities.GYMGROUP.ToList();
            int GYMGROUPYEAR = Reader.CurrentStartYear();

            foreach (var person in persons)
            {
                if (!person.DOCUMENT.Any(x => x.DOCUMENTTYPEID == 1))
                {
                    ReportDocument ReportDocument = new ReportDocument();
                    ReportDocument.DOCUMENTNAME = documentTypes.First(x => x.DOCUMENTTYPEID == 1).DOCUMENTNAME;
                    ReportDocument.GYMGROUPNAME = person.PERSON_GYMGROUP.Select(x => x.GYMGROUP).First(x => x.GYMGROUPYEAR == GYMGROUPYEAR).GYMGROUPNAME;
                    ReportDocument.PERSONFIRSTNAME = person.FIRSTNAME;
                    ReportDocument.PERSONLASTNAME = person.LASTNAME;

                    ReportDocuments.Add(ReportDocument);
                }
                if (!person.DOCUMENT.Any(x => x.DOCUMENTTYPEID == 2))
                {
                    ReportDocument ReportDocument = new ReportDocument();
                    ReportDocument.DOCUMENTNAME = documentTypes.First(x => x.DOCUMENTTYPEID == 2).DOCUMENTNAME;
                    ReportDocument.GYMGROUPNAME = person.PERSON_GYMGROUP.Select(x => x.GYMGROUP).First(x => x.GYMGROUPYEAR == GYMGROUPYEAR).GYMGROUPNAME;
                    ReportDocument.PERSONFIRSTNAME = person.FIRSTNAME;
                    ReportDocument.PERSONLASTNAME = person.LASTNAME;

                    ReportDocuments.Add(ReportDocument);
                }
                if (!person.DOCUMENT.Any(x => x.DOCUMENTTYPEID == 3))
                {
                    ReportDocument ReportDocument = new ReportDocument();
                    ReportDocument.DOCUMENTNAME = documentTypes.First(x => x.DOCUMENTTYPEID == 3).DOCUMENTNAME;
                    ReportDocument.GYMGROUPNAME = person.PERSON_GYMGROUP.Select(x => x.GYMGROUP).First(x => x.GYMGROUPYEAR == GYMGROUPYEAR).GYMGROUPNAME;
                    ReportDocument.PERSONFIRSTNAME = person.FIRSTNAME;
                    ReportDocument.PERSONLASTNAME = person.LASTNAME;

                    ReportDocuments.Add(ReportDocument);
                }
                if (!person.DOCUMENT.Any(x => x.DOCUMENTTYPEID == 4))
                {
                    ReportDocument ReportDocument = new ReportDocument();
                    ReportDocument.DOCUMENTNAME = documentTypes.First(x => x.DOCUMENTTYPEID == 4).DOCUMENTNAME;
                    ReportDocument.GYMGROUPNAME = person.PERSON_GYMGROUP.Select(x => x.GYMGROUP).First(x => x.GYMGROUPYEAR == GYMGROUPYEAR).GYMGROUPNAME;
                    ReportDocument.PERSONFIRSTNAME = person.FIRSTNAME;
                    ReportDocument.PERSONLASTNAME = person.LASTNAME;

                    ReportDocuments.Add(ReportDocument);
                }
            }


            return ReportDocuments;
        }

        private void paiementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = GetReportPayments();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", bindingSource);
            frmReport.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            frmReport.reportViewer.LocalReport.ReportEmbeddedResource = "EGOFormsApp.Reports.ReportPayments.rdlc";
            frmReport.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            var setup = frmReport.reportViewer.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            frmReport.reportViewer.SetPageSettings(setup);
            frmReport.reportViewer.Refresh();
            frmReport.ShowDialog();
        }

        private List<ReportPayment> GetReportPayments()
        {
            List<ReportPayment> reportPayments = new List<ReportPayment>();
            EGOEntities egoEntities = new EGOEntities();
            List<FAMILY> familys = egoEntities.FAMILY.ToList().OrderBy(x => x.LASTNAME).ToList();
            int year = Reader.CurrentStartYear();
            float contribution = 0;
            if (egoEntities.CONTRIBUTION.Any(x => x.GYMYEAR == year))
            {
                contribution = egoEntities.CONTRIBUTION.First(x => x.GYMYEAR == year).AMOUNT;
            }

            foreach (var family in familys)
            {
                ReportPayment reportPayment = new ReportPayment();

                float PAID = family.PAYMENT.Where(x => x.GYMYEAR == year).Sum(x => x.AMOUNT);
                float RECEIVABLE = (family.PERSON.SelectMany(x => x.PERSON_GYMGROUP).Select(x => x.GYMGROUP).Where(x => x.GYMGROUPYEAR == year).Sum(x => x.YEARPRICE) + contribution) - family.DISCOUNT.Sum(x => x.AMOUNT);
                float REMAININGBALANCE = RECEIVABLE - PAID;

                if (REMAININGBALANCE != 0)
                {
                    reportPayment.LASTNAME = family.LASTNAME;
                    reportPayment.ZIPCODE = family.ZIPCODE;
                    reportPayment.ADDRESS = family.ADDRESS;
                    reportPayment.RECEIVABLE = RECEIVABLE;
                    reportPayment.PAID = PAID;
                    reportPayment.REMAININGBALANCE = REMAININGBALANCE;
                
                    reportPayments.Add(reportPayment);
                }
            }


            return reportPayments;
        }

    }
}
