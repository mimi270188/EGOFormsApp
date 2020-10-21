DROP TABLE TRANSLATION
DROP TABLE PERSON_GYMGROUP
DROP TABLE GYMGROUP
DROP TABLE PHONE
DROP TABLE DISCOUNT
DROP TABLE DOCUMENT
DROP TABLE PAYMENT
DROP TABLE PAYMENTTYPE
DROP TABLE DOCUMENTTYPE
DROP TABLE PERSON_KIND
DROP TABLE PERSON
DROP TABLE KIND
DROP TABLE FAMILY

DELETE FROM FAMILY
DELETE FROM KIND
DELETE FROM PERSON
DELETE FROM PHONE
DELETE FROM GYMGROUP
DELETE FROM PERSON_GYMGROUP
DELETE FROM PAYMENTTYPE
DELETE FROM PAYMENT
DELETE FROM DOCUMENTTYPE
DELETE FROM DOCUMENT
DELETE FROM DISCOUNT
DELETE FROM PERSON_KIND
DELETE FROM TRANSLATION

SELECT * FROM FAMILY
SELECT * FROM KIND
SELECT * FROM PERSON
SELECT * FROM PHONE
SELECT * FROM GYMGROUP
SELECT * FROM PERSON_GYMGROUP
SELECT * FROM PAYMENTTYPE
SELECT * FROM PAYMENT
SELECT * FROM DOCUMENTTYPE
SELECT * FROM DOCUMENT
SELECT * FROM DISCOUNT
SELECT * FROM PERSON_KIND
SELECT * FROM TRANSLATION

CREATE TABLE TRANSLATION(
TRANSLATIONKEY		VARCHAR(25)         NOT NULL    PRIMARY KEY	,
WORDS               VARCHAR(150)        NOT NULL				,
LANG				VARCHAR(5)			NOT NULL
)

CREATE TABLE KIND(
KINDID				INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
KINDNAME            VARCHAR(25)         NOT NULL				
);

CREATE TABLE FAMILY(
FAMILYID			INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
LASTNAME            VARCHAR(25)         NOT NULL				,
ADDRESS             VARCHAR(100)        NOT NULL				,
ZIPCODE             VARCHAR(10)         NOT NULL				,
CITY                VARCHAR(50)         NOT NULL				,
EMAIL               VARCHAR(150)        NULL					,
);

CREATE TABLE DISCOUNT(
DISCOUNTID			INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
FAMILYID            INT					NOT NULL				,
DISCOUNTYEAR		INT                 NOT NULL				,
DESCRIPTION         VARCHAR(150)        NULL					,
AMOUNT				REAL                NOT NULL				,
CONSTRAINT fk_DISCOUNT_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
);

CREATE TABLE PERSON(
PERSONID			INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
FAMILYID            INT					NOT NULL				,
LASTNAME			VARCHAR(25)         NOT NULL				,
FIRSTNAME           VARCHAR(25)         NOT NULL				,
BIRTHDATE           DATE				NULL					,
HOURLYRATE          REAL				NULL					,
CONSTRAINT fk_PERSON_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
);

CREATE TABLE PERSON_KIND(
PERSON_KIND_ID		INT IDENTITY(1,1)   NOT NULL	PRIMARY KEY	,
PERSONID            INT					NOT NULL				,
KINDID				INT                 NOT NULL				,
CONSTRAINT fk_PERSON_KIND_PERSON FOREIGN KEY(PERSONID) REFERENCES PERSON(PERSONID),
CONSTRAINT fk_PERSON_KIND_KIND FOREIGN KEY(KINDID) REFERENCES KIND(KINDID),
CONSTRAINT u_PERSON_KIND UNIQUE(PERSONID, KINDID)
);

CREATE TABLE PHONE(
PHONEID				INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
FAMILYID            INT					NOT NULL				,
PHONENUMBER			VARCHAR(25)         NOT NULL				,
CONSTRAINT fk_PHONE_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
);

CREATE TABLE GYMGROUP(
GYMGROUPID			INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
GYMGROUPNAME        VARCHAR(150)         NOT NULL				,
NUMBEROFHOURS       REAL				NOT NULL				,
GYMGROUPYEAR		INT                 NOT NULL				,
YEARPRICE           REAL				NOT NULL				
);

CREATE TABLE PERSON_GYMGROUP(
PERSON_GYMGROUP_ID	INT IDENTITY(1,1)   NOT NULL	PRIMARY KEY	,
PERSONID            INT					NOT NULL				,
GYMGROUPID			INT                 NOT NULL				,
CONSTRAINT fk_PERSON_GYMGROUP_PERSON FOREIGN KEY(PERSONID) REFERENCES PERSON(PERSONID),
CONSTRAINT fk_PERSON_GYMGROUP_GYMGROUP FOREIGN KEY(GYMGROUPID) REFERENCES GYMGROUP(GYMGROUPID),
CONSTRAINT u_PERSON_GYMGROUP UNIQUE(PERSONID, GYMGROUPID)
);

CREATE TABLE PAYMENTTYPE(
PAYMENTTYPEID		INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
NAME                VARCHAR(25)         NOT NULL
);

CREATE TABLE PAYMENT(
PAYMENTID			INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
PAYMENTTYPEID       INT					NOT NULL				,
FAMILYID			INT                 NOT NULL				,
GYMYEAR             INT					NOT NULL				,
PAYMENTDATE			DATE                NOT NULL				,
CHECKNUMBER         INT					NULL					,
AMOUNT              REAL				NOT NULL				,
CONSTRAINT fk_PAYMENT_PAYMENTTYPE FOREIGN KEY(PAYMENTTYPEID) REFERENCES PAYMENTTYPE(PAYMENTTYPEID),
CONSTRAINT fk_PAYMENT_FAMILY FOREIGN KEY(FAMILYID) REFERENCES FAMILY(FAMILYID)
);

CREATE TABLE DOCUMENTTYPE(
DOCUMENTTYPEID		INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
DOCUMENTNAME            VARCHAR(50)     NOT NULL				,
MADATORY                SMALLINT		NOT NULL
);

CREATE TABLE DOCUMENT(
DOCUMENTID			INT IDENTITY(1,1)   NOT NULL    PRIMARY KEY	,
DOCUMENTTYPEID      INT					NOT NULL				,
PERSONID			INT                 NOT NULL				,
DOCUMENTYEAR		INT					NOT NULL				,
CONSTRAINT fk_DOCUMENT_DOCUMENTTYPE FOREIGN KEY(DOCUMENTTYPEID) REFERENCES DOCUMENTTYPE(DOCUMENTTYPEID),
CONSTRAINT fk_DOCUMENT_PERSON FOREIGN KEY(PERSONID) REFERENCES PERSON(PERSONID)
);

INSERT INTO KIND VALUES ('SUBSCRIBER')
INSERT INTO KIND VALUES ('COACH')

INSERT INTO DOCUMENTTYPE VALUES('Fiche d''information', 1)
INSERT INTO DOCUMENTTYPE VALUES('Autorisation parentale', 1)
INSERT INTO DOCUMENTTYPE VALUES('Photo', 1)
INSERT INTO DOCUMENTTYPE VALUES('Certificat médical', 1)

INSERT INTO PAYMENTTYPE VALUES ('ESPECE')
INSERT INTO PAYMENTTYPE VALUES ('CHEQUE')


INSERT TRANSLATION VALUES(N'ADDRESS', N'Adresse', N'FR')
INSERT TRANSLATION VALUES(N'AMOUNT', N'Montant', N'FR')
INSERT TRANSLATION VALUES(N'BIRTHDATE', N'Date de naissance', N'FR')
INSERT TRANSLATION VALUES(N'CHECKNUMBER', N'Numéro de chèque', N'FR')
INSERT TRANSLATION VALUES(N'CITY', N'Ville', N'FR')
INSERT TRANSLATION VALUES(N'COACH', N'Coach', N'FR')
INSERT TRANSLATION VALUES(N'DESCRIPTION', N'Description', N'FR')
INSERT TRANSLATION VALUES(N'DISCOUNTYEAR', N'Année', N'FR')
INSERT TRANSLATION VALUES(N'EMAIL', N'Email', N'FR')
INSERT TRANSLATION VALUES(N'Enregistrer', N'Enregistrer', N'FR')
INSERT TRANSLATION VALUES(N'FAMILYNAME', N'Famille', N'FR')
INSERT TRANSLATION VALUES(N'FIRSTNAME', N'Prénom', N'FR')
INSERT TRANSLATION VALUES(N'GYMYEAR', N'Année', N'FR')
INSERT TRANSLATION VALUES(N'HOURLYRATE', N'Taux horaire', N'FR')
INSERT TRANSLATION VALUES(N'LASTNAME', N'Nom', N'FR')
INSERT TRANSLATION VALUES(N'PAYMENTDATE', N'Date d''encaissement', N'FR')
INSERT TRANSLATION VALUES(N'PAYMENTTYPENAME', N'Moyen de paiment', N'FR')
INSERT TRANSLATION VALUES(N'PHONENUMBER', N'Téléphone', N'FR')
INSERT TRANSLATION VALUES(N'Rechercher', N'Rechercher', N'FR')
INSERT TRANSLATION VALUES(N'SUBSCRIBER', N'Adhérent', N'FR')
INSERT TRANSLATION VALUES(N'ZIPCODE', N'Code postal', N'FR')

INSERT INTO GYMGROUP VALUES ('4 pattes (24 à 30 mois) - Samedi - Nathalie', 0, 2020, 120)
INSERT INTO GYMGROUP VALUES ('Babys Gym (2016 - 2017) - Samedi - Nathalie', 0, 2020, 150)
INSERT INTO GYMGROUP VALUES ('Babys Gym (2016-2017) - Mercredi - Nathalie', 0, 2020, 150)
INSERT INTO GYMGROUP VALUES ('Loisirs Jeudi  (2007/2008/2009)  Camille 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Jeudi  (2009/2010/2011)  Claire 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Lundi  (2008/2009/2010)  Roxane 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Lundi  (2010/2011/2012)  Elena 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Mardi  (2009/2010/2011)  Adeline 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Mardi  (2011/2012/2013)  Morgane et Florine 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Mercredi  (2009/2010/2011)  Camille 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Mercredi  (2009/2010/2011)  Cécile 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Mercredi  (2012/2013)  Camille 16h30 18h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Mercredi  (2012/2013)  Marion 16h30 18h30', 0, 2020, 193)
INSERT INTO GYMGROUP VALUES ('Loisirs Vendredi  (2011/2012/2013)  Coraline 18h30 20h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Loisirs Vendredi  (2011/2012/2013)  Roxane 18h30 20h30', 0, 2020, 193)
INSERT INTO GYMGROUP VALUES ('N4 11+ Mathilde', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N5 11-18 Amande Anne-So', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N6 11-15 Charlotte', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N6 11-18 Charlotte', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N6 7-12 Amande Anne-So', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N7 11 + Andréa Laurélaine', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N7 11-15 Salomé', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N7 7-10 Amande Anne-So', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N7 7-12 Laura', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N8 11-15 Amande Laurélaine', 0, 2020, 310)
INSERT INTO GYMGROUP VALUES ('N8 11-15 Andréa Laurélaine', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('N8 7-10 Cécile', 0, 2020, 293)
INSERT INTO GYMGROUP VALUES ('Petits gyms (2014 - 2015) - Mardi-Nathalie', 0, 2020, 165)
INSERT INTO GYMGROUP VALUES ('Petits gyms (2014 - 2015) - Mercredi - Nathalie', 0, 2020, 165)
INSERT INTO GYMGROUP VALUES ('Petits gyms (2014 - 2015) - Samedi - Nathalie', 0, 2020, 165)
INSERT INTO GYMGROUP VALUES ('Pré-compétition Mercredi Anne-Sophie 16h30 18h30', 0, 2020, 210)
INSERT INTO GYMGROUP VALUES ('Super Mums - Mercredi - Anne So', 0, 2020, 160)

SET IDENTITY_INSERT FAMILY ON;
INSERT INTO FAMILY ([FAMILYID] ,[LASTNAME],[ADDRESS],[ZIPCODE],[CITY],[EMAIL]) 
VALUES
(0, '', '','','','')
SET IDENTITY_INSERT FAMILY OFF;
INSERT INTO FAMILY VALUES ('VALLADEAU', '83 RU VIEILLE SAINT MARTIN','95800','COURDIMANCHE','francketmelanie@gmail.com')
INSERT INTO FAMILY VALUES ('NAMOUNE', '37 rue de la Jeunesse','95640','Brignancourt','megane.malleret.95@gmail.com')
INSERT INTO FAMILY VALUES ('LOUREIRO', '','','','')
INSERT INTO FAMILY VALUES ('LE JEHAN', '6 rue Jean Sébastien Bach','95520','Osny','yann.lj@orange.fr')
INSERT INTO FAMILY VALUES ('FRAPPART', '15 ter avenue de la Muette','95520','Osny','nat0804@hotmail.fr')
INSERT INTO FAMILY VALUES ('FOUCAULT', '13 rue de Berval','95810','Grisy les Plâtres','solene_roux@yahoo.fr')
INSERT INTO FAMILY VALUES ('FELGUEIRAS', '12 clos de la Roseraie','95800','Cergy','m.coralie@hotmail.fr')
INSERT INTO FAMILY VALUES ('DOUAL', '12 rue Tillard','95810','Berville','tchoung-tioud@hotmail.com')
INSERT INTO FAMILY VALUES ('DOLLFUS', '13 rue du Chat Noir','95490','Vauréal','mel.lesourd@gmail.com')
INSERT INTO FAMILY VALUES ('DE OLIVEIRA GARCIA', '33 rue des Pinsons','95610','Eragny','marcia.gatti@outlook.fr')
INSERT INTO FAMILY VALUES ('CORNIGLION-ALTOT', '79 RUE DU GRILLON','95610','Eragny','lolatot@gmail.com')
INSERT INTO FAMILY VALUES ('BESSON PAPIN', '7 rue des Plantes','95520','Osny','charlotte.papin0@gmail.com')
INSERT INTO FAMILY VALUES ('VASSEUR-Léger', '1 rue Paul Roth','95520','Osny','jeffetalice@gmail.com')
INSERT INTO FAMILY VALUES ('TRAZZINI', '12 ter avenue des Bruyères','95520','Osny','virginie.casa@gmail.com')
INSERT INTO FAMILY VALUES ('TOPENOT', '6 rue de la Croisette','95300','Herouville-en-Vexin','jn.topenot@gmail.com')
INSERT INTO FAMILY VALUES ('ROCHER', '56 rue Saint Jean','95520','Osny','florinefournier@yahoo.fr')
INSERT INTO FAMILY VALUES ('JELY', '6 bis rue de Cergy','95520','Osny','ynagaa@yahoo.fr')
INSERT INTO FAMILY VALUES ('JEANNET-GRANDIERE', '35 rue de l''Abreuvoir','95490','Vauréal','')
INSERT INTO FAMILY VALUES ('Jeannet', '10 RUE ANDRE PARRAIN','95800','COURDIMANCHE','')
INSERT INTO FAMILY VALUES ('GRANAT', '6 rue des Sablons','95650','Génicoourt','jessicamaze@hotmail.fr')
INSERT INTO FAMILY VALUES ('FREYERMUTH', '16 rue du Parouset','95650','Génicourt','celinemet@free.fr')
INSERT INTO FAMILY VALUES ('DUPRESSOIR', '31 allée du Moulin','95650','Boissy-l''Aillerie','alexandra.dupressoir@sede.fr')
INSERT INTO FAMILY VALUES ('DELVINCOURT', '5 rue de Triel','95000','Boisemont','sabrina_bigot@hotmail.fr')
INSERT INTO FAMILY VALUES ('ALAOUI', '9 rue de Moscou','95520','Osny','samour1202@hotmail.fr')
INSERT INTO FAMILY VALUES ('AARASS', '14 rue Paul Verlaine','95520','Osny','aarhaz@hotmail.fr')
INSERT INTO FAMILY VALUES ('ORZECHOWSKI', '7 allée des Dahlias','95520','Osny','isabelle.orzechowski@gmail.com')
INSERT INTO FAMILY VALUES ('Moradel Rouquette', '23 chemin Dupuis Vert','95000','Cergy','elodie.rqt@gmail.com')
INSERT INTO FAMILY VALUES ('LEFEVRE', '14 rue de Berval','95810','Grisy les Plâtres','maillardaudrey@hotmail.fr')
INSERT INTO FAMILY VALUES ('LALMY', '30 ru du Moulinard','95520','Osny','geraldine.iziquel@laposte.net')
INSERT INTO FAMILY VALUES ('KAMARA', '6 résidence du Moulin Vert','95520','Osny','leleer.ludivine@live.fr')
INSERT INTO FAMILY VALUES ('GALLET', '62 versant de la Ravinière','95520','Osny','bertin.elodie@yahoo.fr')
INSERT INTO FAMILY VALUES ('DOYEN', '9 rue de la Sellerie','95300','Pontoise','maryz112@hotmail.com')
INSERT INTO FAMILY VALUES ('DE BEER', '18 ter rue du Val','95650','Courcelles/Viosne','debeer_christophe@neuf.fr')
INSERT INTO FAMILY VALUES ('Cottereau', '14 rue Blaise-Pascal','95520','Osny','sabine.cottereau@sfr.fr')
INSERT INTO FAMILY VALUES ('Bellardant', '6 bis rue du Vauvarois','95520','Osny','delphine.zghoudi95@gmail.com')
INSERT INTO FAMILY VALUES ('ANES', '27 bis avenue du Moulinard','95520','Osny','zouheir.anes@gmail.com')
INSERT INTO FAMILY VALUES ('YILMAZ', '6 rue de Génicourt','95520','Osny','marlour@gmail.com')
INSERT INTO FAMILY VALUES ('OSMANE', '13 rue Paul Roth','95520','Osny','fatiosmane@aol.com')
INSERT INTO FAMILY VALUES ('MONSIRE', '18 rue du Four à Chaux','95650','Boissy l''Aillerie','monsire.delphine@gmail.com')
INSERT INTO FAMILY VALUES ('ESSID', '36 rue de Cergy','95520','Osny','zessid@yahoo.fr')
INSERT INTO FAMILY VALUES ('DUTAILLY', '4 résidence du Colombier','95830','Cormeilles en Vexin','luciedutailly@yahoo.fr')
INSERT INTO FAMILY VALUES ('D''ALEXIS', '11 allée de la Tuilerie','95640','Marines','d-alexis.lucilla@orange.fr')
INSERT INTO FAMILY VALUES ('CALATROIA', '11 rue du Muguet','95520','Osny','celinecalatroia@gmail.com')
INSERT INTO FAMILY VALUES ('BRITO', '1 chemin du Marais','95520','osny','lionel.brito@live.fr')
INSERT INTO FAMILY VALUES ('MATHIALAKAN', '','','','')
INSERT INTO FAMILY VALUES ('ZEZUKA', '20 rue andré et Maurice Guesnier','95420','Magny-en-vexin','sly69vert@hotmail.fr')
INSERT INTO FAMILY VALUES ('MAILLARD', '23 résidence du Clos','78700','Conflans St Honorine','kenzo95300@hotmail.fr')
INSERT INTO FAMILY VALUES ('LORIOT', '19 rue du Clos du Plateau','95520','Osny','seb1981paris@hotmail.fr')
INSERT INTO FAMILY VALUES ('Jeannet', '','95140','LE HEAULME','')
INSERT INTO FAMILY VALUES ('HOZLMANN', '','','','')
INSERT INTO FAMILY VALUES ('BOUKONO', '30 rue des Voyageurs','95800','Cergy','eugeniesanier@gmail.com')
INSERT INTO FAMILY VALUES ('BIJAQUI', '23 rue de la Gleurie','95640','Bréançon','christelle.guenier@free.fr')
INSERT INTO FAMILY VALUES ('ABAJOU', '27 BIS RUE DE CERGY','95520','OSNY','z.lachgar@hotmail.fr')
INSERT INTO FAMILY VALUES ('PEDRONI', '10 A rue de l''Escalier','95520','Osny','enzotina95@gmail.com')
INSERT INTO FAMILY VALUES ('NIEL', '6 sente des Relais','95520','Osny','kadiniel@icloud.com')
INSERT INTO FAMILY VALUES ('MOHAMED', '8 rue William Thornley','95520','Osny','thaju@hotmail.fr')
INSERT INTO FAMILY VALUES ('JUSTINO', '40 bis rue Nationale','95490','Vauréal','elodiebeyres@hotmail.com')
INSERT INTO FAMILY VALUES ('HORRILLO', '7 crète de la Ravinière','95520','Osny','lilou95370@hotmail.fr')
INSERT INTO FAMILY VALUES ('DOGAN', '11 bis rue Jean Jaures','95520','Osny','muratdogan3@msn.com')
INSERT INTO FAMILY VALUES ('BOUDACHE', '14 rue Jean Jaures','95520','Osny','boudachemarie@gmail.com')
INSERT INTO FAMILY VALUES ('Valétudie', '22 RUE DES CYTISES','95520','OSNY','jmvaletudie@hotmail.fr')
INSERT INTO FAMILY VALUES ('TALHAOUI', '20 C plateau des Bruyères','95520','Osny','imenetalhaoui81@gmail.com')
INSERT INTO FAMILY VALUES ('ROZIER', '1 résidence de la Remoucheuse','95830','Cormeilles en Vexin','carole.rozier@live.fr')
INSERT INTO FAMILY VALUES ('RIBEIRO MATINS', '28 rue de l''Eglise','95750','Chars','audreyh@live.fr')
INSERT INTO FAMILY VALUES ('HERLEMONT', '21A CHEMIN DE MONTGEROULT','95520','OSNY','ninieblonde@hotmail.fr')
INSERT INTO FAMILY VALUES ('CHABBERT', '4 rue Paul Roth','95520','Osny','poninfo@wanadoo.fr')
INSERT INTO FAMILY VALUES ('BURET', '49 rue du Cèdre','95520','Osny','barros.aurelie@neuf.fr')
INSERT INTO FAMILY VALUES ('BRUNOT-­PASZYK', '5 bis rue des Bois Queris','95810','Grisy les Plâtres','m.paszyk@gmail.cm')
INSERT INTO FAMILY VALUES ('ROBERT', '5 rue des Arpeges','95800','Cergy','stephanierobert95800@gmail.com')
INSERT INTO FAMILY VALUES ('REMILLIER', '22 rue Paul Roth','95520','Osny','stphremillier@free.fr')
INSERT INTO FAMILY VALUES ('NIEPOROWSKI', '25 rue du Cedre','95520','Osny','cecilehavel@gmail.com')
INSERT INTO FAMILY VALUES ('MONTOUSSE', '32 bis rue de Livilliers','95520','Osny','sev.stef@free.fr')
INSERT INTO FAMILY VALUES ('LAJEUNE', '14 rue des tulipes','95520','Osny','houyere.myriam@hotmail.fr')
INSERT INTO FAMILY VALUES ('JAILLANT', '4 le clos Saint Jean','95520','Osny','emmanuelletorbey@yahoo.fr')
INSERT INTO FAMILY VALUES ('GRANCHER', '11 le Clos de la Ferme','95640','Santeuil','helene_crepin@orange.fr')
INSERT INTO FAMILY VALUES ('FERREIRA DE LIMA', '9 allée de Giverny','95540','Méry/Oise','jennifer_ferreira12@hotmailfr')
INSERT INTO FAMILY VALUES ('BURILLON', '4 le clos de la ferme','95640','Santeuil','kathleen.rainsard@laposte.net')
INSERT INTO FAMILY VALUES ('TROCME', '29 rue du Cedre','95520','Osny','isaguillaume22@orange.fr')
INSERT INTO FAMILY VALUES ('RUSCASSIER', '57 rue de Marines','95520','Osny','sy-dev@hotmail.fr')
INSERT INTO FAMILY VALUES ('JOLY-­ROUX', '13 rue de Berval','95810','Grisy les Plâtres','solene_roux@yahoo.fr')
INSERT INTO FAMILY VALUES ('GUEGUEN', '53 rue de Livilliers','95520','Osny','carole.niobe@free.fr')
INSERT INTO FAMILY VALUES ('FIDELIN', '5 impasse de Bouvreuils','95520','Osny','dardelfidelin@gmail.com')
INSERT INTO FAMILY VALUES ('EYMERE', '43 rue des Patis','95520','Osny','mimi242008@hotmail.fr')
INSERT INTO FAMILY VALUES ('CAPRON', '6 rue du Heaulmes','95640','Marines','maud.almecija@gmail.com')
INSERT INTO FAMILY VALUES ('BENATIA', '10 impasse le Titien','95520','Osny','maguy.benatia@gmail.com')
INSERT INTO FAMILY VALUES ('ALVES DE SA', '4 bis rue Le Château','95830','Cormeilles en Vexin','melanie.favchtein@yahoo.fr')
INSERT INTO FAMILY VALUES ('AHMED', '58 rue du Petit Sol','95800','Cergy','moni180904@gmail.com')
INSERT INTO FAMILY VALUES ('TRUFFERT', '42 rue du Buisson Prunelle','95800','Cergy','nath.ocana@free.fr')
INSERT INTO FAMILY VALUES ('TEYROL', '4 allée des Champs','95830','Cormeilles en Vexin','ducy28@live.fr')
INSERT INTO FAMILY VALUES ('PEANA-­Louvet', '20 rue Albert Schweitzer','95450','Ableiges','riccardo.rkc@gmail.com')
INSERT INTO FAMILY VALUES ('LE THOMAS', '26 rue des Roses','95520','Osny','pauline.lethomas@orange.Fr')
INSERT INTO FAMILY VALUES ('CIARD-­POTHIN', '3 chemin de l''Isle','95810','Epiais-RHUS','jessica.ciard@gmail.com')
INSERT INTO FAMILY VALUES ('FRESQUET', '8 SENTE DES RELAIS','95520','OSNY','famille.fresquet.95@gmail.com')
INSERT INTO FAMILY VALUES ('PINCEMIN', '60 rue Mozart','95520','Osny','pincemin.estelle@oange.fr')
INSERT INTO FAMILY VALUES ('NIAKATE', '1 rue de la Justice Brune','95000','Cergy','niakatefatoumata89@gmail.com')
INSERT INTO FAMILY VALUES ('MACALOU', '4 rue de la Justice Mauve','95000','Cergy','niakatefatoumata89@gmail.com')
INSERT INTO FAMILY VALUES ('LATOUCHE GRINE', '13 rue des charres','95520','Osny','fadgrine@gmail.com')
INSERT INTO FAMILY VALUES ('FONTANA', '6 résidence du Moulin Vert','95520','Osny','fontana.patrick95@yahoo.fr')
INSERT INTO FAMILY VALUES ('DECAUX', '87 ter rue Saint Jean','95520','Osny','sab.goncalvessg@gmail.com')
INSERT INTO FAMILY VALUES ('CONSTANT', '5 place Jean Jaures','95520','Osny','fannygalindo7@gmail.com')
INSERT INTO FAMILY VALUES ('ALRAMMAH', '5 rue Jean Jaures','95520','Osny','sukharevasasha@yahoo.com')
INSERT INTO FAMILY VALUES ('HOFFMANN', '4 RUE DE SANTEUIL','95640','Marines','sandranicolas95580@gmail.com')
INSERT INTO FAMILY VALUES ('TOUBAL', '32 rue Richard Strauss','95520','Osny','virgdefi@hotmail.com')
INSERT INTO FAMILY VALUES ('MELOTTI', '7 rue Paul Roth','95520','Osny','cmelotti@orange.fr')
INSERT INTO FAMILY VALUES ('LECOMTE', '24 rue de Gisors','95750','Chars','sandylecomtechars@hotmail.com')
INSERT INTO FAMILY VALUES ('GERARDIN', '15 ter avenue de la Muette','95520','Osny','nat0804@hotmail.fr')
INSERT INTO FAMILY VALUES ('ESTEVES FREIRE', '31 rue Robinet','95520','Osny','rim.esteves@gmail.com')
INSERT INTO FAMILY VALUES ('BRULU Houanen', '1 b rue du Clos Fleuri','95520','Osny','lesly280@hotmail.com')
INSERT INTO FAMILY VALUES ('ALLART DOSSA', '52 rue des Genevriers','95800','Cergy','pat.dossa@gmail.com')
INSERT INTO FAMILY VALUES ('YAHIAOUI', '39 rue des Bois','95520','Osny','')
INSERT INTO FAMILY VALUES ('TALIBI', '42 rue de Livilliers','95520','Osny','faria.maryline@yahoo.fr')
INSERT INTO FAMILY VALUES ('MENDANHA MOQUET', '10 rue du Vauvarois','95520','Osny','moquet.celine@gmail.com')
INSERT INTO FAMILY VALUES ('Depuille', '6 rue de Cergy','95520','Osny','marie.depuille9@gmail.com')
INSERT INTO FAMILY VALUES ('DELABROSSE', '8 rue Charles Karoux','95520','Osny','covenad@hotmail.com')
INSERT INTO FAMILY VALUES ('CHEVALLIER/NIVELET', '1 chemin de la Cavée','95830','Fremecourt','raphkillianelyna@gmail.com')
INSERT INTO FAMILY VALUES ('CAZOTTES', '25 rue Mozart','95520','Osny','dewilde.celine@gmail.com')
INSERT INTO FAMILY VALUES ('BENABBAS', '27 bis avenue du Moulinard','95520','Osny','zouheir.anes@gmail.com')
INSERT INTO FAMILY VALUES ('LAHSSINI', '206 chaussée Jules Cesar','95520','Osny','')
INSERT INTO FAMILY VALUES ('Lachkar', '33 rue du Vauvarois','95520','Osny','raikia.lachkar@gmail.com')
INSERT INTO FAMILY VALUES ('DENIS', '40 sente de la Mortagne','95310','Saint Ouen l''Aumone','guivard.carine@gmail.com')
INSERT INTO FAMILY VALUES ('CHINAPAH', '24 rue du Réservoir','95520','Osny','aswimi.vimen@gmail.com')
INSERT INTO FAMILY VALUES ('CARAMELO', '212 chaussée Jules Cesar','95520','Osny','valerie.caramelo@gmail.com')
INSERT INTO FAMILY VALUES ('BOUKHALFA', '25 rue des Cytises','95520','Osny','kboukhalfa@hotmail.fr')
INSERT INTO FAMILY VALUES ('AUBE', '3 rue Pasteur','95520','Osny','aliishamaywen95@outlook.fr')
INSERT INTO FAMILY VALUES ('ROBERT', '32 rue du docteur Laennec','95520','Osny','babou-974@live.fr')
INSERT INTO FAMILY VALUES ('MIRANDA-­MONTENEGRO', '13 plateau de la Ravinière','95520','Osny','joana-alexandra-miranda@hotmail.com')
INSERT INTO FAMILY VALUES ('MABROUK', '27 rue de Cergy','95520','Osny','maessa2006@yahoo.fr')
INSERT INTO FAMILY VALUES ('HIEYTE', '1 bis impasse de laTour','95650','Cormeilles en Vexin','sophie.dutilh@gmail.com')
INSERT INTO FAMILY VALUES ('DUJARDIN', '2 Terasse de la Raviniere','95520','Osny','dujardin.jean-michel@orange.fr')
INSERT INTO FAMILY VALUES ('DIALLO', 'Résidence Les Pâtis','95520','Osny','charlenepapegay@yahoo.fr')
INSERT INTO FAMILY VALUES ('DERRADJ', '12 rue de la Mare','95300','Ennery','sihamderradj@hotmail.fr')
INSERT INTO FAMILY VALUES ('SICOT', '17 rue Gambetta','95300','Pontoise','mlsicot@gmail.com')
INSERT INTO FAMILY VALUES ('Lecanu', '','','','')
INSERT INTO FAMILY VALUES ('Gomes', '10 rue W. Amadeus Mozard','95520','OSNY','manurm95@free.fr')
INSERT INTO FAMILY VALUES ('FRAS', '8 rue Ambroise Paré','95520','Osny','vero.savel@libertysurf.fr')
INSERT INTO FAMILY VALUES ('DROUET', '51 rue du quai Polhus','95300','Pontoise','celine.fieulaine75@gmail.com')
INSERT INTO FAMILY VALUES ('Bourse', '16 Allée Victor Hugo','95520','OSNY','geraldine.bourse@free.fr')
INSERT INTO FAMILY VALUES ('REBEYROL', '','','','')
INSERT INTO FAMILY VALUES ('VORISEK', '24 rue des genévriers','95800','Cergy','s.vorisek@hotmail.fr')
INSERT INTO FAMILY VALUES ('VIGNAUD', '34 rue de Marines','95520','OSNY','maud.marguerie@gmail.com')
INSERT INTO FAMILY VALUES ('STEINHAUSER SIEGWALD', '2 RUE DES DAMES GILLES','95490','Vauréal','soniasteinhauser@hotmail.com')
INSERT INTO FAMILY VALUES ('PERROT', '2 rue de l''Escalier','95830','OSNY','isc.perrot@wanadoo.fr')
INSERT INTO FAMILY VALUES ('Bredel', '25 RUE FLEURY','95800','COURDIMANCHE','bobsr@wannadoo.fr')
INSERT INTO FAMILY VALUES ('Bailliet', '14 rue de gency','95520','OSNY','pascale.brodin@laposte.net')
INSERT INTO FAMILY VALUES ('Abie Resende', '26 RESIDENCE DU VAUVAROIS','95520','OSNY','rccatarina@hotmail.fr')
INSERT INTO FAMILY VALUES ('Malassis', '12 Résidence du Colombier  ','95830','Cormeilles en Vexin','aemalassis@gmail.com')
INSERT INTO FAMILY VALUES ('LUSZACK', '26 AVENUE DE LA MUETTE','95520','OSNY','anacunha@hotmail.fr')
INSERT INTO FAMILY VALUES ('JOUALIN', '5 Chemin des bœufs','95480','Perrelaye','peggy_girin@yahoo.fr')
INSERT INTO FAMILY VALUES ('GUITTON', '10 bis rue du jardin de la motte ','95520','OSNY','annabouvet@hotmail.fr')
INSERT INTO FAMILY VALUES ('GHAOUI', '26 Route d''Ableiges','95520','OSNY','isabelle.gomez1972@gmail.com')
INSERT INTO FAMILY VALUES ('Tavares', '5 Terasse de la raviniere','95520','Osny','mt.isabel@yahoo.fr')
INSERT INTO FAMILY VALUES ('PERROT', '2 rue de l''Escalier','95520','OSNY','isc.perrot@wanadoo.fr')
INSERT INTO FAMILY VALUES ('Jeouit', '120 RUE DE LIVILLIERS','95520','OSNY','malika.cher78@outlook.com')
INSERT INTO FAMILY VALUES ('DELBARRE', '1 RUE CLOS CHAMPARD','95300','HEROUVILLE','dorotheedaumont1@gmail.com')
INSERT INTO FAMILY VALUES ('JEANNET', '44 AVENUE GAVROCHE','95490','Vauréal','elodie.ozanne@gmail.com')
INSERT INTO FAMILY VALUES ('Cortes', '56 rue de la belle saison ','95490','VAUREAL ','ndayana@hotmail.fr')
INSERT INTO FAMILY VALUES ('ARRIMANE', '25 rue des Tarraches','95280','Jouy le Moutier','illia95@hotmail.com')
INSERT INTO FAMILY VALUES ('André', '12 rue de l''Harmonie','95490','VAUREAL ','celine95490@gmail.com')
INSERT INTO FAMILY VALUES ('Alves', '35 avenue du moulinard','95520','OSNY','josechris1@hotmail.fr')
INSERT INTO FAMILY VALUES ('ROULANCE', '2B chemin de la cavée','95830','Frémécourt','aureliefaria@wanadoo.fr')
INSERT INTO FAMILY VALUES ('HERBAUT', '56 chaussée Jules Cesar','95520','Osny','fannys1980@msn.com')
INSERT INTO FAMILY VALUES ('GIRARD', '56 chaussée Jules Cesar','95520','Osny','vince.girard@live.fr')
INSERT INTO FAMILY VALUES ('FRABOULET', '28 rue des Roses','95520','OSNY','fraboulet@noos.fr')
INSERT INTO FAMILY VALUES ('Dodier', '1 RUE JACQUES PREVERT','95520','OSNY','sebastien.dodier@orange.fr')
INSERT INTO FAMILY VALUES ('ANSENE', '1 rue des Passiflores','95520','OSNY','jhjifat@gmail.com')
INSERT INTO FAMILY VALUES ('TALON', '8 rue des mésanges','95750','Chars','HTALON@hotmail.fr')
INSERT INTO FAMILY VALUES ('SOW', '6 RUE DE LA VALLEE','95520','OSNY','sowhamidou4782@gmail.com')
INSERT INTO FAMILY VALUES ('Ndohi', '67 rue de Marines','95520','Osny','orlainda@gmail.com')
INSERT INTO FAMILY VALUES ('Le Berre Souchet', '18 rue de la l''œuf','95650','NESLES LA VALLEE','evalebret@gmail.com')
INSERT INTO FAMILY VALUES ('Bigot', '93 ru Curie','95830','Cormeilles en Vexin','maleas95@gmail.com')
INSERT INTO FAMILY VALUES ('Weber', '5 allée des champs','95830','Cormeilles en Vexin','sandrine,basilis@cegetel,net')
INSERT INTO FAMILY VALUES ('REZZOUKI', '5 chemin de Bazancourt','95830','Cormeilles en Vexin','rezzouki.marion@orange.fr')
INSERT INTO FAMILY VALUES ('RAGHOUMANDAN', '5 rue Jacques Fournier','95830','Cormeilles en Vexin','didooroz2@yahoo.fr')
INSERT INTO FAMILY VALUES ('GUSTAVE', '65 RUE BOULEVARD DES CHASSEURS','95800','COURDIMANCHE','ophelie.695@hotmail.com')
INSERT INTO FAMILY VALUES ('FARLOUBEIX', '50 RUE ANDRE ET MAURICE GUESNIER','95420','Magny-en-vexin','cristelle0808@yahoo.fr')
INSERT INTO FAMILY VALUES ('BOURDELET', '9 RUE DES ARPEGES','95800','Pontoise','laurence.coulanges@icloud.com')
INSERT INTO FAMILY VALUES ('KORIMBOCCUS', '55 RUE DE LA PARABOLE','95800','CERGY','nonocelya@gmail.com')
INSERT INTO FAMILY VALUES ('Mbengono', '4 allée des acacias','95800','Cergy','alicehebrard@yahoo.fr')
INSERT INTO FAMILY VALUES ('Francillette', '5 rue de la fraternité','95520','OSNY','nadidja_chanfé@yaoo.fr')
INSERT INTO FAMILY VALUES ('El Mouaddine', '5 avenue des bruyères','95520','OSNY','celine_menendez@hotmail.com')
INSERT INTO FAMILY VALUES ('DUDOUS', '39 rue de la boucle à parir','95520','OSNY','dudousv@gmail.com')
INSERT INTO FAMILY VALUES ('DA FONSECA CORREIA', '1 RUE DE LA FRATERNITE','95520','OSNY','')
INSERT INTO FAMILY VALUES ('Backer', '1 bis rue du muguet','95520','Osny','dominique.backer@wanadoo.fr')
INSERT INTO FAMILY VALUES ('HEDHLI', '7 RUE PHILESS FOGG','95800','CERGY','hedhli1@yahoo.fr')
INSERT INTO FAMILY VALUES ('VIEVILLE', '17 RUE DE GENERAL LECLERC','95520','Cormeilles en Vexin','noemie.ribier@yahoo.fr')
INSERT INTO FAMILY VALUES ('SEDJARI', '29 BIS RUE DU CHEMIN DE FER','95800','CERGY','aicha.sedjari@laposte.net')
INSERT INTO FAMILY VALUES ('Capon', '1 chemin de bretagne','95810','EPIAIS-RHUS','Catherine.capon69@gmail.com')
INSERT INTO FAMILY VALUES ('Boutigny', '19 BIS RUE JEAN JAURES','95450','US','aurelie.boutigny@free.fr')
INSERT INTO FAMILY VALUES ('ABABSA', '32 RUE DE LIVILLIERS','95520','OSNY','n.ababsa@yahoo.fr')
INSERT INTO FAMILY VALUES ('POMA', '21 rue de la république','95650','Boissy l''Aillerie','laetitia.poma@sfr.fr')
INSERT INTO FAMILY VALUES ('JUNG', '12 AVENUE DES BRUYERES','95520','OSNY','bouchrasab@msn.com')
INSERT INTO FAMILY VALUES ('EL GHYAM', '3 centre de la raviniere','95520','Osny','anassera21@hotmail.com')
INSERT INTO FAMILY VALUES ('De Meulemeester', '27 résidence du colombier','95830','Cormeilles en Vexin','sophie.domurado@live.fr')
INSERT INTO FAMILY VALUES ('Chighini Florez', '12 Terasse de la Raviniere','95520','Osny','romain.chighini@gmail.com')
INSERT INTO FAMILY VALUES ('Arnoux', '2 chemin de la cavée','95830','Frémécourt','narcoline@hotmail.fr')
INSERT INTO FAMILY VALUES ('VERMONT', '6 rue Aristide Briand','95520','Osny','vincent18777643@gmail.com')
INSERT INTO FAMILY VALUES ('TAILHAN', '2 impasse des Iles','95520','Osny','laetitiatailhan@yahoo.fr')
INSERT INTO FAMILY VALUES ('MENDES DE SOUSA', '1 rue Pacifique','95520','Osny','sylviemds@hotmail.fr')
INSERT INTO FAMILY VALUES ('JEAN-THEODORE', '56 c chaussée Jules César','95520','Osny','clylou@orange.fr')
INSERT INTO FAMILY VALUES ('FORIR', '8 rue Pasteur','95520','Osny','marion.rodriguez78@laposte.net')
INSERT INTO FAMILY VALUES ('Cadiou', '27 rue de Livilliers','95520','Osny','s.1105@hotmail.fr')
INSERT INTO FAMILY VALUES ('ARMEL', '39 rue de Livilliers','95520','Osny','aupalaisdelareine@yahoo.fr')
INSERT INTO FAMILY VALUES ('Tavares Monteiro', '5 terrasse de la Ravinière','95520','Osny','')
INSERT INTO FAMILY VALUES ('MICHAUD', '20 bis rue du plateau des Bruyères','95520','Osny','moreau.rachelle@yahoo.fr')
INSERT INTO FAMILY VALUES ('Mahoukou', '13 bis chemin de Montgeroult','95520','Osny','nastasiapilorgetboulanger@gmail.com')
INSERT INTO FAMILY VALUES ('LUGUET', '2 passage d''Adrienne','95800','Cergy','madjovine@gmail.com')
INSERT INTO FAMILY VALUES ('Hoefferlin', 'Chemin de Courcelles','95650','Puisseux Pontoise','benedicte.vercel@gmail.com')
INSERT INTO FAMILY VALUES ('HAUTEMANIERE', '1 résidence du Moulin Vert','95520','Osny','tendance2@yahoo.fr')
INSERT INTO FAMILY VALUES ('GUENFOUD', '29 pente de la ravinière','95520','OSNY','celine.corradini@orange.fr')
INSERT INTO FAMILY VALUES ('GIUDICELLI', '24 rue Jean Jaures','95520','Osny','giudicelli.gerard@gmail.com')
INSERT INTO FAMILY VALUES ('EL MOUKADDAM-NOIZET', '34 A rue du Docteur Laennec','95520','Osny','margot.noizet@gmail.com')
INSERT INTO FAMILY VALUES ('Coelho Da Costa', '2 place des Graviers','95650','Montgeroult','christelleflorin@free.fr')
INSERT INTO FAMILY VALUES ('BARAKATE', '13 rue William Thornley','95520','Osny','ait_zahara.meriam@orange.fr')
INSERT INTO FAMILY VALUES ('WUEST', '8 rue des Crocus','95490','Vauréal','jerome.wuest@sfr.fr')
INSERT INTO FAMILY VALUES ('VILANT', '24 rue du Brabant','95490','Vauréal','orhorea@gmail.com')
INSERT INTO FAMILY VALUES ('THEVENOT', '2 rue de la Groux','95650','Courcelles/Viosne','virginie.beaslay@free.fr')
INSERT INTO FAMILY VALUES ('SEMSOUN', '36 rue de Montgeroult','95520','Osny','najima.bani@gmail.com')
INSERT INTO FAMILY VALUES ('MONSIRE ', '18 rue du Four à Chaux','95650','Boissy l''Aillerie','monsire.delphine@gmail.com')
INSERT INTO FAMILY VALUES ('LO', '74 rue de Livilliers','95520','Osny','tinetine_82@hotmail.fr')
INSERT INTO FAMILY VALUES ('LEGER', '29 résidence le Colombier','95830','Cormeilles en Vexin','benewinc@yahoo.fr')
INSERT INTO FAMILY VALUES ('LEFRANC', '20 rue Albert Schweitzer','95450','Ableiges','heloise8@msn.com')
INSERT INTO FAMILY VALUES ('LAMBIN', '11 avenue des Bruyères','95520','Osny','coralie.rioni@gmail.com')
INSERT INTO FAMILY VALUES ('GROSY', '18 rue Jean Jaures','95520','Osny','audreyle95@hotmail.fr')
INSERT INTO FAMILY VALUES ('GENTE', '8 impasse des Capucines','95520','Osny','j.gente@live.fr')
INSERT INTO FAMILY VALUES ('GAROT', '5 résidence des Saules','95830','Fremecourt','sabine.garot@gmail.com')
INSERT INTO FAMILY VALUES ('GARABOEUF', '31 rue du Maréchal Foch','95640','Marines','melanie.portier_95@gmail.com')
INSERT INTO FAMILY VALUES ('BRESILLON', '15 rue Richard Strauss','95520','Osny','tiphanie.lamybresillion@gmail.com')
INSERT INTO FAMILY VALUES ('AZAOUI', '37 avenue des Genottes','95800','Cergy','morgane.mombrun@gmail.com')
INSERT INTO FAMILY VALUES ('Tavares-­Monteiro', '5 Terasse de la raviniere','95520','Osny','mt.isabel@yahoo.fr')
INSERT INTO FAMILY VALUES ('ROCHARD', '9 rue du Pas de Saint Christophe','95800','Cergy','melisse.gel@gmail.com')
INSERT INTO FAMILY VALUES ('ROCHA', '3 rue Camille Pissarro','95520','Osny','jublochot@gmail.com')
INSERT INTO FAMILY VALUES ('DEHIERE', '16 bis rue de la Fontaine d''Ascot','95420','Clery en vexin','gaoul_95_6@hotmail.com')
INSERT INTO FAMILY VALUES ('De Meulemeester', '12 terrasses de la Ravinière','95520','Osny','vanessa.florez@wanadoo.fr')
INSERT INTO FAMILY VALUES ('Billonnet Vieira', '35 allée du Moulin','95650','Boissy l''Aillerie','sicilia.vieira@gmail.com')
INSERT INTO FAMILY VALUES ('Barbey', '21 b chemin de Montgeroult','95520','Osny','ludivine444@hotmail.fr')
INSERT INTO FAMILY VALUES ('ARRIMANE', '','','','')
INSERT INTO FAMILY VALUES ('Ait-­Said Ribeiro', '2 impasse de la grande cours','95490','Vauréal','stefribeiro@hotmail.fr')
INSERT INTO FAMILY VALUES ('POMA', '4 rue Maurice Ravel','95450','Ableiges','laetitia.poma@sfr.fr')
INSERT INTO FAMILY VALUES ('MARGUERI', '34 rue de Marines','95520','OSNY','maud.marguerie@gmail.com')
INSERT INTO FAMILY VALUES ('CREPIN', '11 le Clos de la Ferme','95640','Santeuil','')
INSERT INTO FAMILY VALUES ('BOUTELOUP', '65 boulevard des Chasseurs','95800','Courdimanche','aphelie_695@hotmail.com')

INSERT INTO PERSON VALUES (0, 'VALLADEAU', 'Emma', convert(DATE, '27/04/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'NAMOUNE', 'Adem', convert(DATE, '22/09/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'LOUREIRO', 'Baptiste', convert(DATE, '21/10/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'LE JEHAN', 'Maëlyne', convert(DATE, '19/11/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'FRAPPART', 'Sacha', convert(DATE, '22/04/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'FRAPPART', 'Jade', convert(DATE, '01/03/2019', 103),0)
INSERT INTO PERSON VALUES (0, 'FOUCAULT', 'Camille', convert(DATE, '07/11/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'FELGUEIRAS', 'Marina', convert(DATE, '16/06/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'DOUAL', 'Livio', convert(DATE, '30/04/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'DOLLFUS', 'Léa', convert(DATE, '19/10/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'DE OLIVEIRA GARCIA', 'Maé', convert(DATE, '29/01/2019', 103),0)
INSERT INTO PERSON VALUES (0, 'CORNIGLION-ALTOT', 'Juliann', convert(DATE, '18/09/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'BESSON PAPIN', 'Tifenn', convert(DATE, '04/07/2018', 103),0)
INSERT INTO PERSON VALUES (0, 'VASSEUR-Léger', 'Raphaël', convert(DATE, '13/01/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'VASSEUR-Léger', 'Julia', convert(DATE, '13/01/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'TRAZZINI', 'Lilou', convert(DATE, '10/11/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'TOPENOT', 'Baptiste', convert(DATE, '15/02/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'ROCHER', 'Héloïse', convert(DATE, '05/10/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'JELY', 'Amandine', convert(DATE, '20/10/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'JEANNET-GRANDIERE', 'Lucas', convert(DATE, '10/08/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'Jeannet', 'Mahé', convert(DATE, '01/04/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'GRANAT', 'Rose', convert(DATE, '16/12/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'FREYERMUTH', 'Raphaël', convert(DATE, '17/05/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'FELGUEIRAS', 'Alycia', convert(DATE, '07/03/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'DUPRESSOIR', 'Chloé', convert(DATE, '07/03/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'DOLLFUS', 'Chloé', convert(DATE, '17/03/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'DELVINCOURT', 'Jade', convert(DATE, '10/01/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'ALAOUI', 'Ayline', convert(DATE, '29/06/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'AARASS', 'Aliya', convert(DATE, '07/08/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'ORZECHOWSKI', 'Emma', convert(DATE, '26/02/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'Moradel Rouquette', 'Gabriel', convert(DATE, '21/09/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'Moradel Rouquette', 'Liam', convert(DATE, '21/09/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'LEFEVRE', 'Romy', convert(DATE, '11/01/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'LALMY', 'Constance', convert(DATE, '02/06/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'KAMARA', 'Djadenn', convert(DATE, '13/04/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'GALLET', 'Charlie', convert(DATE, '31/07/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'DOYEN', 'Lucas', convert(DATE, '20/10/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'DE BEER', 'Elise', convert(DATE, '07/08/2017', 103),0)
INSERT INTO PERSON VALUES (0, 'Cottereau', 'Ugo', convert(DATE, '28/01/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'Bellardant', 'Kamylia', convert(DATE, '26/06/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'ANES', 'Léa', convert(DATE, '05/02/2016', 103),0)
INSERT INTO PERSON VALUES (0, 'YILMAZ', 'Gülsüm', convert(DATE, '26/08/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'OSMANE', 'Yasmine', convert(DATE, '26/10/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'MONSIRE', 'Justine', convert(DATE, '15/12/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'ESSID', 'Nayla', convert(DATE, '25/06/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'DUTAILLY', 'Alice', convert(DATE, '22/01/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'D''ALEXIS', 'Lucila', convert(DATE, '08/12/2007', 103),0)
INSERT INTO PERSON VALUES (0, 'CALATROIA', 'Elia', convert(DATE, '13/07/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'BRITO', 'Eva', convert(DATE, '16/11/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'MATHIALAKAN', 'Sayanna', convert(DATE, '00/01/1900', 103),0)
INSERT INTO PERSON VALUES (0, 'ZEZUKA', 'Lou-­Ann', convert(DATE, '09/08/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'MAILLARD', 'Eléohan', convert(DATE, '09/02/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'LORIOT', 'Léa', convert(DATE, '07/12/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'Jeannet', 'Naëla', convert(DATE, '01/11/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'HOZLMANN', 'Louise', convert(DATE, '14/12/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'BOUKONO', 'Maëlys', convert(DATE, '09/06/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'BIJAQUI', 'Camille', convert(DATE, '02/09/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'ABAJOU', 'Naïla', convert(DATE, '29/07/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'PEDRONI', 'Tina', convert(DATE, '05/10/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'NIEL', 'Lou-­Ann', convert(DATE, '04/12/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'MOHAMED', 'Shafiya', convert(DATE, '27/10/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'JUSTINO', 'Lucia', convert(DATE, '03/07/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'HORRILLO', 'Lylia', convert(DATE, '08/07/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'DOGAN', 'YELDA', convert(DATE, '25/07/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'DOGAN', 'LEYLA', convert(DATE, '25/07/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'BOUDACHE', 'SARA', convert(DATE, '25/04/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'Valétudie', 'Lizzye', convert(DATE, '11/03/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'TALHAOUI', 'Imène', convert(DATE, '21/07/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'ROZIER', 'Emilie', convert(DATE, '17/03/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'RIBEIRO MATINS', 'Nina', convert(DATE, '03/07/1905', 103),0)
INSERT INTO PERSON VALUES (0, 'HERLEMONT', 'Célia', convert(DATE, '13/12/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'CHABBERT', 'Mathilde', convert(DATE, '26/03/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'BURET', 'Anya', convert(DATE, '06/08/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'BRUNOT-­PASZYK', 'Sarah', convert(DATE, '15/07/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'ROBERT', 'Emmy', convert(DATE, '03/07/1905', 103),0)
INSERT INTO PERSON VALUES (0, 'REMILLIER', 'Sarah', convert(DATE, '08/09/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'NIEPOROWSKI', 'Lily-­Rose', convert(DATE, '18/05/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'MONTOUSSE', 'Clara', convert(DATE, '08/11/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'LAJEUNE', 'Cloé', convert(DATE, '23/12/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'JAILLANT', 'Brune', convert(DATE, '03/01/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'GRANCHER', 'Louise', convert(DATE, '24/10/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'FERREIRA DE LIMA', 'Océanne', convert(DATE, '22/06/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'BURILLON', 'Naomi', convert(DATE, '11/08/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'TROCME', 'Estelle', convert(DATE, '08/02/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'RUSCASSIER', 'Maelle', convert(DATE, '05/03/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'JOLY-­ROUX', 'Anaëlle', convert(DATE, '30/08/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'GUEGUEN', 'Eloïse', convert(DATE, '13/12/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'FIDELIN', 'Maëlane', convert(DATE, '05/06/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'EYMERE', 'Eléanor', convert(DATE, '28/09/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'CAPRON', 'Héloïse', convert(DATE, '06/07/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'BOUKONO', 'Nelya', convert(DATE, '30/01/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'BENATIA', 'Hana', convert(DATE, '22/01/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'ALVES DE SA', 'Ilana', convert(DATE, '15/10/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'AHMED', 'Ambre', convert(DATE, '15/01/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'TRUFFERT', 'Elisa', convert(DATE, '28/09/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'TRUFFERT', 'Célia', convert(DATE, '28/09/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'TEYROL', 'Maëla', convert(DATE, '21/09/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'PEANA-­Louvet', 'Manuela', convert(DATE, '24/11/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'LE THOMAS', 'Léane', convert(DATE, '30/10/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'COTTEREAU', 'Kelia', convert(DATE, '01/05/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'CIARD-­POTHIN', 'Shereen', convert(DATE, '12/09/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'FRESQUET', 'Charline', convert(DATE, '11/06/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'PINCEMIN', 'Hanaé', convert(DATE, '17/11/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'NIAKATE', 'Aïcha', convert(DATE, '12/12/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'MACALOU', 'Kamissa', convert(DATE, '18/11/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'LATOUCHE GRINE', 'Sveltana', convert(DATE, '26/06/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'FONTANA', 'Amel', convert(DATE, '28/05/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'DECAUX', 'Kassandra', convert(DATE, '10/04/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'CONSTANT', 'Victorine', convert(DATE, '18/09/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'ALRAMMAH', 'Mayya', convert(DATE, '02/11/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'HOFFMANN', 'Mélyne', convert(DATE, '13/09/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'TOUBAL', 'Nejia', convert(DATE, '01/06/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'MELOTTI', 'Pauline', convert(DATE, '28/07/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'LECOMTE', 'Cataleya', convert(DATE, '28/03/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'LATOUCHE GRINE', 'Inna', convert(DATE, '09/10/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'HORRILLO', 'Nina', convert(DATE, '24/06/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'GERARDIN', 'Eva', convert(DATE, '19/05/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'ESTEVES FREIRE', 'Neïla', convert(DATE, '09/03/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'BRULU Houanen', 'Maëlys', convert(DATE, '12/01/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'ALLART DOSSA', 'Roxane', convert(DATE, '22/11/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'YAHIAOUI', 'Hana', convert(DATE, '23/02/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'TALIBI', 'Alya', convert(DATE, '12/09/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'MENDANHA MOQUET', 'Alicia', convert(DATE, '13/06/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'Depuille', 'Sheïna', convert(DATE, '09/12/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'DELABROSSE', 'Elise', convert(DATE, '06/01/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'CHEVALLIER/NIVELET', 'Elyna', convert(DATE, '04/02/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'CAZOTTES', 'Lynette', convert(DATE, '20/01/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'BENABBAS', 'Maria', convert(DATE, '28/03/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'LAHSSINI', 'Assia', convert(DATE, '11/11/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'Lachkar', 'Naïla', convert(DATE, '25/09/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'Lachkar', 'Sirine', convert(DATE, '22/02/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'GALLET', 'Aimy', convert(DATE, '01/03/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'DENIS', 'Malou', convert(DATE, '10/01/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'CHINAPAH', 'Tessa', convert(DATE, '05/07/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'CARAMELO', 'Victoria', convert(DATE, '15/02/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'BOUKHALFA', 'Yasmine', convert(DATE, '21/07/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'AUBE', 'Maywen', convert(DATE, '29/11/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'ROBERT', 'Lana', convert(DATE, '01/07/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'MIRANDA-­MONTENEGRO', 'Ana-­Carolina', convert(DATE, '15/12/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'MABROUK', 'Taissire', convert(DATE, '07/02/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'HIEYTE', 'Clémence', convert(DATE, '05/06/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'DUPRESSOIR', 'Enora', convert(DATE, '29/11/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'DUJARDIN', 'Eloïse', convert(DATE, '30/12/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'DIALLO', 'Lilya', convert(DATE, '01/12/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'DERRADJ', 'Sarah', convert(DATE, '14/10/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'SICOT', 'CHIARA', convert(DATE, '28/01/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'Lecanu', 'Andréa', convert(DATE, '14/12/1998', 103),0)
INSERT INTO PERSON VALUES (0, 'Gomes', 'Alexandra', convert(DATE, '31/07/2003', 103),0)
INSERT INTO PERSON VALUES (0, 'FRAS', 'Adèle', convert(DATE, '03/04/2003', 103),0)
INSERT INTO PERSON VALUES (0, 'DROUET', 'MORGANE', convert(DATE, '20/12/2002', 103),0)
INSERT INTO PERSON VALUES (0, 'Bourse', 'Coraline', convert(DATE, '04/01/2004', 103),0)
INSERT INTO PERSON VALUES (0, 'REBEYROL', 'EMMA', convert(DATE, '00/01/1900', 103),0)
INSERT INTO PERSON VALUES (0, 'VORISEK', 'LALIE', convert(DATE, '10/07/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'VIGNAUD', 'FLORINNE', convert(DATE, '02/07/2004', 103),0)
INSERT INTO PERSON VALUES (0, 'STEINHAUSER SIEGWALD', 'SUZANNE', convert(DATE, '04/09/2007', 103),0)
INSERT INTO PERSON VALUES (0, 'PERROT', 'Clémence', convert(DATE, '16/11/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Bredel', 'SOLENN', convert(DATE, '19/08/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Bailliet', 'Lucille', convert(DATE, '18/07/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'Abie Resende', 'Maelys', convert(DATE, '30/06/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'SICOT', 'Maya', convert(DATE, '04/11/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Malassis', 'Nais', convert(DATE, '05/10/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'LUSZACK', 'MANON', convert(DATE, '05/10/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'JOUALIN', 'ELYNN', convert(DATE, '14/11/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'GUITTON', 'LOLA', convert(DATE, '20/11/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'GHAOUI', 'EMMA', convert(DATE, '24/09/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Chabbert', 'Manon', convert(DATE, '19/01/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Tavares', 'Suelly', convert(DATE, '06/04/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'PERROT', 'Chloé', convert(DATE, '28/12/2003', 103),0)
INSERT INTO PERSON VALUES (0, 'NIEL', 'Zoé', convert(DATE, '23/09/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'Jeouit', 'Imene', convert(DATE, '29/11/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'FRAS', 'Zélie', convert(DATE, '03/04/2003', 103),0)
INSERT INTO PERSON VALUES (0, 'Dujardin', 'Sarah', convert(DATE, '05/11/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'DELBARRE', 'Mélyne', convert(DATE, '06/03/2005', 103),0)
INSERT INTO PERSON VALUES (0, 'JEANNET', 'VALENTINE', convert(DATE, '28/10/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'DOUAL', 'Louna', convert(DATE, '03/04/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'Cortes', 'Nuralya', convert(DATE, '17/03/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'ARRIMANE', 'JANNAH', convert(DATE, '14/03/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'André', 'Anais', convert(DATE, '19/12/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'Alves', 'Alycia', convert(DATE, '12/04/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'ROULANCE', 'MARYLOU', convert(DATE, '07/04/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'HERBAUT', 'MORGANE', convert(DATE, '21/09/2004', 103),0)
INSERT INTO PERSON VALUES (0, 'GIRARD', 'EMI', convert(DATE, '12/07/2004', 103),0)
INSERT INTO PERSON VALUES (0, 'FRABOULET', 'ESTELLE', convert(DATE, '01/11/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'Dodier', 'Margaux', convert(DATE, '15/03/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'ANSENE', 'JESSIE', convert(DATE, '28/07/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'TALON', 'SOPHIE', convert(DATE, '18/02/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'SOW', 'HOULEYE', convert(DATE, '09/11/2007', 103),0)
INSERT INTO PERSON VALUES (0, 'Ndohi', 'Maelys', convert(DATE, '20/05/2007', 103),0)
INSERT INTO PERSON VALUES (0, 'Le Berre Souchet', 'Maelys', convert(DATE, '24/10/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'Bigot', 'Manon', convert(DATE, '06/11/2007', 103),0)
INSERT INTO PERSON VALUES (0, 'Weber', 'Célia', convert(DATE, '05/04/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'REZZOUKI', 'SARAH', convert(DATE, '20/06/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'RAGHOUMANDAN', 'SORALYNE', convert(DATE, '24/01/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'MORADEL ROUQUETTE', 'FADE', convert(DATE, '02/10/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'GUSTAVE', 'LEA', convert(DATE, '19/11/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'FARLOUBEIX', 'LYZ', convert(DATE, '15/03/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'BOURDELET', 'Méline', convert(DATE, '02/01/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'KORIMBOCCUS', 'Célya', convert(DATE, '27/04/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'Mbengono', 'Kymia', convert(DATE, '11/11/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'Francillette', 'Malyza', convert(DATE, '20/06/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'El Mouaddine', 'Nawelle', convert(DATE, '24/05/2010', 103),0)
INSERT INTO PERSON VALUES (0, 'DUDOUS', 'ELINA', convert(DATE, '02/10/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'DA FONSECA CORREIA', 'PRISCILLA', convert(DATE, '20/03/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'Backer', 'Lola', convert(DATE, '12/11/2008', 103),0)
INSERT INTO PERSON VALUES (0, 'HEDHLI', 'EMMA', convert(DATE, '05/08/2007', 103),0)
INSERT INTO PERSON VALUES (0, 'VIEVILLE', 'Zoé', convert(DATE, '03/05/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'SEDJARI', 'SALMA', convert(DATE, '22/08/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Capon', 'Lou', convert(DATE, '20/04/2006', 103),0)
INSERT INTO PERSON VALUES (0, 'Boutigny', 'Lou', convert(DATE, '09/11/2003', 103),0)
INSERT INTO PERSON VALUES (0, 'ABABSA', 'JANNA', convert(DATE, '04/11/2009', 103),0)
INSERT INTO PERSON VALUES (0, 'VALLADEAU', 'Eloise', convert(DATE, '26/08/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'POMA', 'MANON', convert(DATE, '02/10/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'JUNG', 'ALIYAH', convert(DATE, '25/11/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'EL GHYAM', 'RANIA', convert(DATE, '04/03/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'De Meulemeester', 'Sasha', convert(DATE, '18/04/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'Chighini Florez', 'Léane', convert(DATE, '28/11/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'Arnoux', 'Apolline', convert(DATE, '02/04/2011', 103),0)
INSERT INTO PERSON VALUES (0, 'VERMONT', 'Lyza', convert(DATE, '20/02/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'TAILHAN', 'Ambre', convert(DATE, '21/07/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'MENDES DE SOUSA', 'Diana', convert(DATE, '11/01/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'JEAN-THEODORE', 'Déborah', convert(DATE, '20/02/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'FORIR', 'Angelina', convert(DATE, '06/06/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'DECAUX', 'Iris', convert(DATE, '16/07/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'Cadiou', 'Joyce', convert(DATE, '17/03/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'ARMEL', 'Hanna', convert(DATE, '21/01/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Tavares Monteiro', 'Aliya', convert(DATE, '10/09/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'MICHAUD', 'Abigaïl', convert(DATE, '08/03/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Mahoukou', 'Léna', convert(DATE, '18/05/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'LUGUET', 'Jade', convert(DATE, '18/06/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'LE THOMAS', 'Emy', convert(DATE, '10/09/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Hoefferlin', 'Ombeline', convert(DATE, '04/11/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'HAUTEMANIERE', 'Eva', convert(DATE, '25/08/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'GUENFOUD', 'Lya', convert(DATE, '16/10/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'GIUDICELLI', 'Mia', convert(DATE, '03/04/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'EL MOUKADDAM-NOIZET', 'Melyne', convert(DATE, '24/08/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'DELABROSSE', 'Sophie', convert(DATE, '01/06/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Coelho Da Costa', 'Luna', convert(DATE, '15/07/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'BARAKATE', 'Jinane', convert(DATE, '24/02/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'YAHIAOUI', 'Héla', convert(DATE, '16/02/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'WUEST', 'Anna', convert(DATE, '10/04/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'VILANT', 'Alicia', convert(DATE, '01/06/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'THEVENOT', 'Eléonor', convert(DATE, '04/02/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'SEMSOUN', 'Leïna', convert(DATE, '23/10/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'ROCHER', 'Auriane', convert(DATE, '27/10/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'MONSIRE ', 'Soline', convert(DATE, '26/08/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'LO', 'Jade', convert(DATE, '13/01/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'LEGER', 'Pauline', convert(DATE, '10/02/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'LEFRANC', 'Lola', convert(DATE, '27/01/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'LAMBIN', 'Chloé', convert(DATE, '22/03/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'GROSY', 'Maëly', convert(DATE, '03/09/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'GENTE', 'Syrine', convert(DATE, '31/03/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'GAROT', 'Louna', convert(DATE, '22/06/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'GARABOEUF', 'Roméo', convert(DATE, '26/05/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'DOGAN', 'Eda', convert(DATE, '25/12/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'DE BEER', 'Léna', convert(DATE, '14/03/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'BRESILLON', 'Louise', convert(DATE, '09/01/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'AZAOUI', 'Safiya', convert(DATE, '28/03/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'AARASS', 'Anissa', convert(DATE, '15/01/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Tavares-­Monteiro', 'Ilyana', convert(DATE, '06/02/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'ROCHARD', 'Lya', convert(DATE, '23/01/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'ROCHA', 'Manon', convert(DATE, '08/04/2015', 103),0)
INSERT INTO PERSON VALUES (0, 'HOEFFERLIN', 'Chloé', convert(DATE, '22/10/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'DEHIERE', 'Elina', convert(DATE, '21/04/2012', 103),0)
INSERT INTO PERSON VALUES (0, 'De Meulemeester', 'Lou', convert(DATE, '24/10/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'De Meulemeester', 'Andréa', convert(DATE, '00/01/1900', 103),0)
INSERT INTO PERSON VALUES (0, 'Billonnet Vieira', 'Aléanor', convert(DATE, '18/01/2013', 103),0)
INSERT INTO PERSON VALUES (0, 'BIJAQUI', 'Léa', convert(DATE, '14/03/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Barbey', 'Lalie', convert(DATE, '01/04/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'ARRIMANE', 'Jihane', convert(DATE, '07/06/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'Ait-­Said Ribeiro', 'Ava', convert(DATE, '27/01/2014', 103),0)
INSERT INTO PERSON VALUES (0, 'REZZOUKI', 'Marion', convert(DATE, '25/01/1982', 103),0)
INSERT INTO PERSON VALUES (0, 'POMA', 'Laêtitita', convert(DATE, '00/01/1900', 103),0)
INSERT INTO PERSON VALUES (0, 'MARGUERI', 'Maud', convert(DATE, '00/01/1900', 103),0)
INSERT INTO PERSON VALUES (0, 'DOUAL', 'Cécile', convert(DATE, '30/07/1981', 103),0)
INSERT INTO PERSON VALUES (0, 'CREPIN', 'Hélène', convert(DATE, '04/03/1982', 103),0)
INSERT INTO PERSON VALUES (0, 'Chighini Florez', 'Vanessa', convert(DATE, '00/01/1900', 103),0)
INSERT INTO PERSON VALUES (0, 'BOUTELOUP', 'Claire', convert(DATE, '07/04/1990', 103),0)
