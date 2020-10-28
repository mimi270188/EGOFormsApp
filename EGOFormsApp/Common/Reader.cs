using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace EGOFormsApp.Common
{
    public static class Reader
    {

        public static void ImportExcel(FrmSetting _FrmSetting, string fileName)
        {
            EGOEntities EGOEntities = new EGOEntities();
            _FrmSetting.label1.Text = "Suppression des tables";
            Database.Drop();
            _FrmSetting.label1.Text = "Création des tables";
            Database.Create();
            List<ExcelModel> ExcelModels = CreateExcelObject(_FrmSetting, fileName);
            _FrmSetting.label1.Text = "Insertion des données";
            CreatePerson(ExcelModels, EGOEntities, _FrmSetting);
        }

        private static void CreatePerson(List<ExcelModel> _ExcelModel, EGOEntities _EGOEntities, FrmSetting _FrmSetting)
        {
            _FrmSetting.progressBar.Value = 0;
            _FrmSetting.progressBar.Maximum = _ExcelModel.Count;
            int i = 0;

            try
            {
                foreach (var ExcelModel in _ExcelModel)
                {
                    i++;
                    _FrmSetting.label1.Text = "Création de l'adhérent:" + ExcelModel.NOM + " " + ExcelModel.PRENOM + i + "/" + _ExcelModel.Count;
                    _FrmSetting.label1.Refresh();
                    _FrmSetting.progressBar.Value = i;
                    _FrmSetting.progressBar.Refresh();

                    FAMILY Family;
                    if (!_EGOEntities.FAMILY.Any(x => x.LASTNAME == ExcelModel.NOM && x.ZIPCODE == ExcelModel.CP))
                    {
                        Family = CreateFamily(ExcelModel, _EGOEntities);
                    }
                    else
                    {
                        Family = _EGOEntities.FAMILY.First(x => x.LASTNAME == ExcelModel.NOM && x.ZIPCODE == ExcelModel.CP);
                    }

                    PERSON Person = new PERSON();
                    Person.FAMILYID = Family.FAMILYID;
                    Person.LASTNAME = ExcelModel.NOM.ToUpper();
                    Person.FIRSTNAME = ExcelModel.PRENOM.ToUpper();
                    Person.BIRTHDATE = ExcelModel.NEELE;
                    Person.HOURLYRATE = 0;

                    _EGOEntities.PERSON.Add(Person);

                    GYMGROUP GymGroup;
                    if (!_EGOEntities.GYMGROUP.Any(x => x.GYMGROUPNAME == ExcelModel.GROUPE))
                    {
                        GymGroup = CreateGymGroup(ExcelModel, _EGOEntities);
                    }
                    else
                    {
                        GymGroup = _EGOEntities.GYMGROUP.First(x => x.GYMGROUPNAME == ExcelModel.GROUPE);
                    }

                    PERSON_GYMGROUP Person_GymGroup = new PERSON_GYMGROUP();
                    Person_GymGroup.GYMGROUPID = GymGroup.GYMGROUPID;
                    Person_GymGroup.PERSONID = Person.PERSONID;
                    Person_GymGroup.KINDID = 1;

                    _EGOEntities.PERSON_GYMGROUP.Add(Person_GymGroup);

                    if (!_EGOEntities.PHONE.Any(x => x.FAMILYID == Family.FAMILYID && x.PHONENUMBER == ExcelModel.TELEPHONE))
                    {
                        PHONE Phone = new PHONE();
                        Phone.FAMILYID = Family.FAMILYID;
                        Phone.PHONENUMBER = ExcelModel.TELEPHONE;
                        _EGOEntities.PHONE.Add(Phone);
                    }

                    if (!_EGOEntities.PHONE.Any(x => x.FAMILYID == Family.FAMILYID && x.PHONENUMBER == ExcelModel.PORTABLE))
                    {
                        PHONE Phone = new PHONE();
                        Phone.FAMILYID = Family.FAMILYID;
                        Phone.PHONENUMBER = ExcelModel.PORTABLE;
                        _EGOEntities.PHONE.Add(Phone);
                    }

                    DOCUMENT Document;
                    if (ExcelModel.FICHE)
                    {
                        Document = new DOCUMENT();
                        Document.DOCUMENTTYPEID = 1;
                        Document.PERSONID = Person.PERSONID;
                        Document.DOCUMENTYEAR = Common.CurrentStartYear();
                        _EGOEntities.DOCUMENT.Add(Document);
                    }
                    if (ExcelModel.AUTPAR)
                    {
                        Document = new DOCUMENT();
                        Document.DOCUMENTTYPEID = 2;
                        Document.PERSONID = Person.PERSONID;
                        Document.DOCUMENTYEAR = Common.CurrentStartYear();
                        _EGOEntities.DOCUMENT.Add(Document);
                    }
                    if (ExcelModel.PHOTO)
                    {
                        Document = new DOCUMENT();
                        Document.DOCUMENTTYPEID = 3;
                        Document.PERSONID = Person.PERSONID;
                        Document.DOCUMENTYEAR = Common.CurrentStartYear();
                        _EGOEntities.DOCUMENT.Add(Document);
                    }
                    if (ExcelModel.CM)
                    {
                        Document = new DOCUMENT();
                        Document.DOCUMENTTYPEID = 4;
                        Document.PERSONID = Person.PERSONID;
                        Document.DOCUMENTYEAR = Common.CurrentStartYear();
                        _EGOEntities.DOCUMENT.Add(Document);
                    }

                    PAYMENT Payment;
                    if (ExcelModel.ECH1MONTANT != 0)
                    {
                        Payment = new PAYMENT();
                        if (ExcelModel.ECH1NUMCHEQUE != 0)
                        {
                            Payment.PAYMENTTYPEID = 2;
                        }
                        else
                        {
                            Payment.PAYMENTTYPEID = 1;
                        }
                        Payment.FAMILYID = Family.FAMILYID;
                        Payment.GYMYEAR = Common.CurrentStartYear();
                        Payment.PAYMENTDATE = DateTime.ParseExact("30/09/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Payment.CHECKNUMBER = ExcelModel.ECH1NUMCHEQUE;
                        Payment.AMOUNT = ExcelModel.ECH1MONTANT;
                        _EGOEntities.PAYMENT.Add(Payment);
                    }
                    if (ExcelModel.ECH2MONTANT != 0)
                    {
                        Payment = new PAYMENT();
                        if (ExcelModel.ECH2NUMCHEQUE != 0)
                        {
                            Payment.PAYMENTTYPEID = 2;
                        }
                        else
                        {
                            Payment.PAYMENTTYPEID = 1;
                        }
                        Payment.FAMILYID = Family.FAMILYID;
                        Payment.GYMYEAR = Common.CurrentStartYear();
                        Payment.PAYMENTDATE = DateTime.ParseExact("30/11/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Payment.CHECKNUMBER = ExcelModel.ECH2NUMCHEQUE;
                        Payment.AMOUNT = ExcelModel.ECH2MONTANT;
                        _EGOEntities.PAYMENT.Add(Payment);
                    }
                    if (ExcelModel.ECH3MONTANT != 0)
                    {
                        Payment = new PAYMENT();
                        if (ExcelModel.ECH3NUMCHEQUE != 0)
                        {
                            Payment.PAYMENTTYPEID = 2;
                        }
                        else
                        {
                            Payment.PAYMENTTYPEID = 1;
                        }
                        Payment.FAMILYID = Family.FAMILYID;
                        Payment.GYMYEAR = Common.CurrentStartYear();
                        Payment.PAYMENTDATE = DateTime.ParseExact("28/02/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Payment.CHECKNUMBER = ExcelModel.ECH3NUMCHEQUE;
                        Payment.AMOUNT = ExcelModel.ECH3MONTANT;
                        _EGOEntities.PAYMENT.Add(Payment);
                    }
                    if (ExcelModel.ECH4MONTANT != 0)
                    {
                        Payment = new PAYMENT();
                        if (ExcelModel.ECH4NUMCHEQUE != 0)
                        {
                            Payment.PAYMENTTYPEID = 2;
                        }
                        else
                        {
                            Payment.PAYMENTTYPEID = 1;
                        }
                        Payment.FAMILYID = Family.FAMILYID;
                        Payment.GYMYEAR = Common.CurrentStartYear();
                        Payment.PAYMENTDATE = DateTime.ParseExact("30/04/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Payment.CHECKNUMBER = ExcelModel.ECH4NUMCHEQUE;
                        Payment.AMOUNT = ExcelModel.ECH4MONTANT;
                        _EGOEntities.PAYMENT.Add(Payment);
                    }
                    if (ExcelModel.COTISLICENCE != 0)
                    {
                        Payment = new PAYMENT();

                        Payment.PAYMENTTYPEID = 2;
                        Payment.FAMILYID = Family.FAMILYID;
                        Payment.GYMYEAR = Common.CurrentStartYear();
                        Payment.PAYMENTDATE = DateTime.ParseExact("28/09/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Payment.CHECKNUMBER = ExcelModel.ECH4NUMCHEQUE;
                        Payment.AMOUNT = ExcelModel.COTISLICENCE;
                        _EGOEntities.PAYMENT.Add(Payment);
                    }

                    if (!ExcelModel.Nouvelle)
                    {
                        DISCOUNT Discount = new DISCOUNT();
                        Discount.FAMILYID = Family.FAMILYID;
                        Discount.DISCOUNTYEAR = Common.CurrentStartYear();
                        Discount.DESCRIPTION = "Cotisation";
                        Discount.AMOUNT = 35;

                        _EGOEntities.DISCOUNT.Add(Discount);

                        Discount = new DISCOUNT();
                        Discount.FAMILYID = Family.FAMILYID;
                        Discount.DISCOUNTYEAR = Common.CurrentStartYear();
                        Discount.DESCRIPTION = "Ancienneté";
                        Discount.AMOUNT = ExcelModel.REDUCANCIEN;

                        _EGOEntities.DISCOUNT.Add(Discount);
                    }

                    _EGOEntities.SaveChanges();
                }

                _FrmSetting.label1.Text = "Création des réductions familiales";
                CreateFamilyDiscount(_EGOEntities);
                _EGOEntities.SaveChanges();
                _FrmSetting.label1.Text = "Fin";
                _FrmSetting.progressBar.Value = 0;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        private static void CreateFamilyDiscount(EGOEntities _EGOEntities)
        {
            List<FAMILY> Familys = _EGOEntities.FAMILY.ToList();

            foreach (var Family in Familys)
            {
                if (Family.PERSON.Count > 1)
                {
                    DISCOUNT Discount = new DISCOUNT();
                    Discount.FAMILYID = Family.FAMILYID;
                    Discount.DISCOUNTYEAR = Common.CurrentStartYear();
                    Discount.DESCRIPTION = "Réduction familiale";
                    Discount.AMOUNT = 10;

                    _EGOEntities.DISCOUNT.Add(Discount);
                }
            }
        }
        
        private static FAMILY CreateFamily(ExcelModel _ExcelModel, EGOEntities _EGOEntities)
        {
            FAMILY Family = new FAMILY();
            Family.LASTNAME = _ExcelModel.NOM.ToUpper();
            Family.ADDRESS = _ExcelModel.ADRESSE;
            Family.ZIPCODE = _ExcelModel.CP;
            Family.CITY = _ExcelModel.VILLE;
            Family.EMAIL = _ExcelModel.EMAIL;

            _EGOEntities.FAMILY.Add(Family);

            return Family;
        }
        private static GYMGROUP CreateGymGroup(ExcelModel _ExcelModel, EGOEntities _EGOEntities)
        {
                GYMGROUP GymGroup = new GYMGROUP();
                GymGroup.GYMGROUPNAME = _ExcelModel.GROUPE;
                GymGroup.NUMBEROFHOURS = 0;
                GymGroup.GYMGROUPYEAR = Common.CurrentStartYear();
                GymGroup.YEARPRICE = _ExcelModel.RGLTDUTT;

                _EGOEntities.GYMGROUP.Add(GymGroup);

            return GymGroup;
        }

        private static List<ExcelModel> CreateExcelObject(FrmSetting _FrmSetting, string fileName)
        {
            List<ExcelModel> ExcelModels = new List<ExcelModel>();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[2];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            _FrmSetting.progressBar.Value = 0;
            _FrmSetting.progressBar.Maximum = rowCount;

            for (int i = 2; i <= rowCount; i++)
            {
                _FrmSetting.label1.Text = "Lecture du fichier excel - " + i + "/" + rowCount;
                _FrmSetting.progressBar.Value = i;
                _FrmSetting.progressBar.Refresh();
                ExcelModel ExcelModel = new ExcelModel();
                int col = 1;
                ExcelModel.GROUPE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.RGLTDUTT = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.REDUCANCIEN = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.NOM = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.PRENOM = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.NEELE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? DateTime.ParseExact(xlRange.Cells[i, col].Value.ToString().Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture) : new DateTime();
                col++;
                ExcelModel.ADRESSE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.CP = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.VILLE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.TELEPHONE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.PORTABLE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.EMAIL = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;
                col++;
                ExcelModel.FICHE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() == "X" ? true : false;
                col++;
                ExcelModel.AUTPAR = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() == "X" ? true : false;
                col++;
                ExcelModel.CM = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() == "X" ? true : false;
                col++;
                ExcelModel.PHOTO = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() == "X" ? true : false;
                col++;
                ExcelModel.Nouvelle = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() == "X" ? true : false;
                col++;
                ExcelModel.RGLTDU = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                col++;
                ExcelModel.ECH1NUMCHEQUE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToInt32(xlRange.Cells[i, col].Value.ToString()) : Convert.ToInt32(0);
                col++;
                ExcelModel.ECH1MONTANT = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.ECH2NUMCHEQUE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToInt32(xlRange.Cells[i, col].Value.ToString().Replace(",", ".")) : Convert.ToInt32(0);
                col++;
                ExcelModel.ECH2MONTANT = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.ECH3NUMCHEQUE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToInt32(xlRange.Cells[i, col].Value.ToString()) : Convert.ToInt32(0);
                col++;
                ExcelModel.ECH3MONTANT = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.ECH4NUMCHEQUE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToInt32(xlRange.Cells[i, col].Value.ToString()) : Convert.ToInt32(0);
                col++;
                ExcelModel.ECH4MONTANT = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.COTISLICENCE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.MONTANTPAYE = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.ECART = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.REDUC = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value != null && xlRange.Cells[i, col].Value.ToString() != string.Empty ? Convert.ToSingle(xlRange.Cells[i, col].Value.ToString()) : Convert.ToSingle(0);
                col++;
                ExcelModel.Remarque = xlRange.Cells[i, col] != null && xlRange.Cells[i, col].Value != null ? xlRange.Cells[i, col].Value.ToString() : string.Empty;

                ExcelModels.Add(ExcelModel);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return ExcelModels;
        }
        private class ExcelModel
        {
            public string GROUPE { get; set; }
            public float RGLTDUTT { get; set; }
            public float REDUCANCIEN { get; set; }
            public string NOM { get; set; }
            public string PRENOM { get; set; }
            public DateTime NEELE { get; set; }
            public string ADRESSE { get; set; }
            public string CP { get; set; }
            public string VILLE { get; set; }
            public string TELEPHONE { get; set; }
            public string PORTABLE { get; set; }
            public string EMAIL { get; set; }
            public bool FICHE { get; set; }
            public bool AUTPAR { get; set; }
            public bool CM { get; set; }
            public bool PHOTO { get; set; }
            public bool Nouvelle { get; set; }
            public float RGLTDU { get; set; }
            public int NBRDECHEQUE { get; set; }
            public int ECH1NUMCHEQUE { get; set; }
            public float ECH1MONTANT { get; set; }
            public int ECH2NUMCHEQUE { get; set; }
            public float ECH2MONTANT { get; set; }
            public int ECH3NUMCHEQUE { get; set; }
            public float ECH3MONTANT { get; set; }
            public int ECH4NUMCHEQUE { get; set; }
            public float ECH4MONTANT { get; set; }
            public float COTISLICENCE { get; set; }
            public float MONTANTPAYE { get; set; }
            public float ECART { get; set; }
            public float REDUC { get; set; }
            public string Remarque { get; set; }
        }        
    }
}