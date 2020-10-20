﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CreationTablesSql
    {
        //        DROP TABLE KIND
        //        DROP TABLE PERSON
        //DROP TABLE FAMILY
        //DROP TABLE PHONE
        //DROP TABLE GYMGROUP
        //DROP TABLE PERSON_GYMGROUP
        //DROP TABLE PAYMENTTYPE
        //DROP TABLE PAYMENT
        //DROP TABLE DOCUMENTTYPE
        //DROP TABLE DOCUMENT
        //DROP TABLE DISCOUNT
        //DROP TABLE PERSON_KIND
        //DROP TABLE TRANSLATION

        //DELETE FROM FAMILY
        //DELETE FROM KIND
        //DELETE FROM PERSON
        //DELETE FROM PHONE
        //DELETE FROM GYMGROUP
        //DELETE FROM PERSON_GYMGROUP
        //DELETE FROM PAYMENTTYPE
        //DELETE FROM PAYMENT
        //DELETE FROM DOCUMENTTYPE
        //DELETE FROM DOCUMENT
        //DELETE FROM DISCOUNT
        //DELETE FROM PERSON_KIND
        //DELETE FROM TRANSLATION

        //SELECT* FROM FAMILY
        //SELECT* FROM KIND
        //SELECT* FROM PERSON
        //SELECT* FROM PHONE
        //SELECT* FROM GYMGROUP
        //SELECT* FROM PERSON_GYMGROUP
        //SELECT* FROM PAYMENTTYPE
        //SELECT* FROM PAYMENT
        //SELECT* FROM DOCUMENTTYPE
        //SELECT* FROM DOCUMENT
        //SELECT* FROM DISCOUNT
        //SELECT* FROM PERSON_KIND
        //SELECT* FROM TRANSLATION

//        INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'ADDRESS', N'Adresse')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'AMOUNT', N'Montant')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'BIRTHDATE', N'Date de naissance')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'CHECKNUMBER', N'Numéro de chèque')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'CITY', N'Ville')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'COACH', N'Coach')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'DESCRIPTION', N'Description')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'DISCOUNTYEAR', N'Année')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'EMAIL', N'Email')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'Enregistrer', N'Enregistrer')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'FAMILYNAME', N'Famille')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'FIRSTNAME', N'Prénom')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'GYMYEAR', N'Année')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'HOURLYRATE', N'Taux horaire')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'LASTNAME', N'Nom')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'PAYMENTDATE', N'Date d''encaissement')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'PAYMENTTYPENAME', N'Moyen de paiment')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'PHONENUMBER', N'Téléphone')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'Rechercher', N'Rechercher')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'SUBSCRIBER', N'Adhérent')
//GO
//INSERT[dbo].[TRANSLATION]
//        ([TRANSLATIONKEY], [WORDS]) VALUES(N'ZIPCODE', N'Code postal')
//GO

        //INSERT INTO KIND VALUES
        //('SUBSCRIBER'),
        //('COACH')

        //INSERT INTO DOCUMENTTYPE VALUES
        //('Fiche d''information', 1),
        //('Autorisation parentale', 1),
        //('Photo', 1),
        //('Certificat médical', 1)

        //INSERT INTO PAYMENTTYPE VALUES
        //('ESPECE'),
        //('CHEQUE')

        //INSERT INTO GYMGROUP VALUES
        //('N7 Amande', 2.5, 2020, 193),
        //('N7 Anne-So', 2.5, 2020, 210)

        //CREATE TABLE TRANSLATION(
        //TRANSLATIONKEY VARCHAR(25)         NOT NULL    PRIMARY KEY,
        //WORDS               VARCHAR(150)        NOT NULL
        //)

        //CREATE TABLE KIND(
        //KINDID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //KINDNAME            VARCHAR(25)         NOT NULL				
        //);

        //        CREATE TABLE FAMILY(
        //        FAMILYID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //LASTNAME            VARCHAR(25)         NOT NULL,
        //ADDRESS             VARCHAR(100)        NOT NULL,
        //ZIPCODE             VARCHAR(10)         NOT NULL,
        //CITY                VARCHAR(50)         NOT NULL,
        //EMAIL               VARCHAR(150)        NULL													,
        //);

        //CREATE TABLE DISCOUNT(
        //DISCOUNTID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //FAMILYID            INT NOT NULL												,
        //DISCOUNTYEAR INT                 NOT NULL,
        //DESCRIPTION         VARCHAR(150)        NULL													,
        //AMOUNT REAL                NOT NULL,
        //CONSTRAINT fk_DISCOUNT_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
        //);

        //CREATE TABLE PERSON(
        //PERSONID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //FAMILYID            INT NOT NULL												,
        //LASTNAME VARCHAR(25)         NOT NULL,
        //FIRSTNAME           VARCHAR(25)         NOT NULL,
        //BIRTHDATE           DATE NULL,
        //HOURLYRATE          REAL NULL,
        //CONSTRAINT fk_PERSON_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
        //);

        //CREATE TABLE PERSON_KIND(
        //PERSON_KIND_ID INT IDENTITY(1,1)   NOT NULL,
        //PERSONID            INT NOT NULL																		,
        //KINDID INT                 NOT NULL,
        //PRIMARY KEY(PERSON_KIND_ID)                                                                             ,
        //CONSTRAINT fk_PERSON_KIND_PERSON FOREIGN KEY(PERSONID) REFERENCES PERSON(PERSONID)                      ,
        //CONSTRAINT fk_PERSON_KIND_KIND FOREIGN KEY(KINDID) REFERENCES KIND(KINDID)                              ,
        //CONSTRAINT u_PERSON_KIND UNIQUE(PERSONID, KINDID)
        //);

        //CREATE TABLE PHONE(
        //PHONEID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //FAMILYID            INT NOT NULL																		,
        //PHONENUMBER VARCHAR(25)         NOT NULL,
        //CONSTRAINT fk_PHONE_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
        //);

        //CREATE TABLE GYMGROUP(
        //GYMGROUPID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //GYMGROUPNAME        VARCHAR(50)         NOT NULL,
        //NUMBEROFHOURS       REAL NOT NULL																		,
        //GYMGROUPYEAR INT                 NOT NULL,
        //YEARPRICE           REAL NOT NULL				
        //);

        //CREATE TABLE PERSON_GYMGROUP(
        //PERSON_GYMGROUP_ID INT IDENTITY(1,1)   NOT NULL,
        //PERSONID            INT NOT NULL																		,
        //GYMGROUPID INT                 NOT NULL,
        //PRIMARY KEY(PERSON_GYMGROUP_ID)                                                                         ,
        //CONSTRAINT fk_PERSON_GYMGROUP_PERSON FOREIGN KEY(PERSONID) REFERENCES PERSON(PERSONID)                  ,
        //CONSTRAINT fk_PERSON_GYMGROUP_GYMGROUP FOREIGN KEY(GYMGROUPID) REFERENCES GYMGROUP(GYMGROUPID)          ,
        //CONSTRAINT u_PERSON_GYMGROUP UNIQUE(PERSONID, GYMGROUPID)
        //);

        //CREATE TABLE PAYMENTTYPE(
        //PAYMENTTYPEID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //NAME                VARCHAR(25)         NOT NULL
        //);

        //        CREATE TABLE PAYMENT(
        //        PAYMENTID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //        PAYMENTTYPEID       INT NOT NULL																		,
        //FAMILYID INT                 NOT NULL,
        //GYMYEAR             INT NOT NULL																		,
        //PAYMENTDATE DATE                NOT NULL,
        //CHECKNUMBER         INT NULL,
        //AMOUNT              REAL NOT NULL																		,
        //CONSTRAINT fk_PAYMENT_PAYMENTTYPE FOREIGN KEY(PAYMENTTYPEID) REFERENCES PAYMENTTYPE(PAYMENTTYPEID)      ,
        //CONSTRAINT fk_PAYMENT_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
        //);

        //CREATE TABLE DOCUMENTTYPE(
        //DOCUMENTTYPEID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //DOCUMENTNAME            VARCHAR(50)         NOT NULL,
        //MADATORY                SMALLINT NOT NULL
        //);

        //CREATE TABLE DOCUMENT(
        //DOCUMENTID INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY,
        //DOCUMENTTYPEID      INT NOT NULL																		,
        //PERSONID INT                 NOT NULL,
        //DOCUMENTYEAR        INT NOT NULL																		,
        //CONSTRAINT fk_DOCUMENT_DOCUMENTTYPE FOREIGN KEY(DOCUMENTTYPEID) REFERENCES DOCUMENTTYPE(DOCUMENTTYPEID) ,
        //CONSTRAINT fk_DOCUMENT_PERSON FOREIGN KEY(PERSONID) REFERENCES PERSON(PERSONID)
        //);
    }
}
