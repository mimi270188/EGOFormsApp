using DAL;
using EGOFormsApp.Common;
using EGOFormsApp.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGOFormsApp
{
    public partial class FrmReport : Form
    {
        public FrmReport(string reportName)
        {
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            switch (reportName)
            {
                case "EGOFormsApp.Reports.ReportDocuments.rdlc":
                    bindingSource.DataSource = GetReportDocuments();
                    break;
                case "EGOFormsApp.Reports.ReportPayments.rdlc":
                    bindingSource.DataSource = GetReportPayments();
                    break;
                default:
                    break;
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", bindingSource);
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportEmbeddedResource = reportName;
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            var setup = reportViewer.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            reportViewer.SetPageSettings(setup);
            reportViewer.Refresh();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
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

    }
}
