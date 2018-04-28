-- -----------------------------------------------------------------------------
--             Génération d'une base de données pour
--                      Oracle Version 10g XE
--                        
-- -----------------------------------------------------------------------------
--      Projet : MaisonDesLigues
--      Auteur : Benoît ROCHE
--      Date de dernière modification : 9/01/2013 11:32:40
-- -----------------------------------------------------------------------------

-- -----------------------------------------------------------------------------
--      Partie 2: Création de l'utilisateur MDLEF qui sera aussi le propriétaire
-- 		des objets : tables, index, procédures
--
--		Ce script doit être exécuté par un l'utilisateur MDLEF
--		(celui qui vient d'être créé dans le script creer_user)
--- -----------------------------------------------------------------------------

-- -----------------------------------------------------------------------------
--       SUPPRESSION DES TABLES
-- 

DROP TABLE PAIEMENT CASCADE CONSTRAINTS;
DROP TABLE PARTICIPANT CASCADE CONSTRAINTS;
DROP TABLE ATELIER CASCADE CONSTRAINTS;
DROP TABLE BENEVOLE CASCADE CONSTRAINTS;
DROP TABLE CONTENUHEBERGEMENT CASCADE CONSTRAINTS;
DROP TABLE DATENUITE CASCADE CONSTRAINTS;
DROP TABLE DATEBENEVOLAT CASCADE CONSTRAINTS;
DROP TABLE HOTEL CASCADE CONSTRAINTS;
DROP TABLE INTERVENANT CASCADE CONSTRAINTS;
DROP TABLE LICENCIE CASCADE CONSTRAINTS;
DROP TABLE RESTAURATION CASCADE CONSTRAINTS;
DROP TABLE VACATION CASCADE CONSTRAINTS;
DROP TABLE CATEGORIECHAMBRE CASCADE CONSTRAINTS;
DROP TABLE QUALITE CASCADE CONSTRAINTS;
DROP TABLE THEME CASCADE CONSTRAINTS;
DROP TABLE PARTICIPER CASCADE CONSTRAINTS;
DROP TABLE INSCRIRE CASCADE CONSTRAINTS;
DROP TABLE PROPOSER CASCADE CONSTRAINTS;
DROP TABLE ETREPRESENT CASCADE CONSTRAINTS;
DROP TABLE INCLUREACCOMPAGNANT CASCADE CONSTRAINTS;
DROP TABLE STATUT CASCADE CONSTRAINTS;
DROP TABLE PARAMETRES CASCADE CONSTRAINTS;

-- -----------------------------------------------------------------------------
--       CREATION ET SUPPRESSION DES SEQUENCES
-- 
drop sequence  SEQQUALITE;
create sequence SEQQUALITE
  increment by 1
  start with 1;

drop sequence  SEQPAIEMENT;
create sequence SEQPAIEMENT
  increment by 1
  start with 1;


drop sequence  SEQATELIER;
create sequence SEQATELIER
  increment by 1
  start with 1;


drop sequence  SEQPARTICIPANT;
create sequence SEQPARTICIPANT
  increment by 1
  start with 1;
  
  
  
drop sequence SEQRESTAURATION ;
create sequence SEQRESTAURATION
  increment by 1
  start with 1; 

  
drop sequence SEQDATEBENEVOLAT ;
create sequence SEQDATEBENEVOLAT
  increment by 1
  start with 1;

drop sequence SEQDATENUITE ;
create sequence SEQDATENUITE
  increment by 1
  start with 1;  
-- -----------------------------------------------------------------------------
--       CREATION ET SUPPRESSION DES TABLES
--
   
-- -----------------------------------------------------------------------------
--       TABLE : PAIEMENT
-- -----------------------------------------------------------------------------

CREATE TABLE PAIEMENT
   (
    ID NUMBER(4)  NOT NULL,
    IDLICENCIE NUMBER(4)  NOT NULL,
    MONTANTCHEQUE NUMBER(6,2)  NOT NULL,
    NUMEROCHEQUE NUMBER(7)  NOT NULL,
    TYPEPAIEMENT CHAR(4) 
      DEFAULT 'Insc' NOT NULL   CHECK (TYPEPAIEMENT IN ('Tout', 'Insc', 'Acco')),
      CONSTRAINT PK_PAIEMENT PRIMARY KEY (ID)  
   ) ;
COMMENT ON COLUMN PAIEMENT.ID
     IS 'identifant de l''hébergement';

COMMENT ON COLUMN PAIEMENT.IDLICENCIE
     IS 'identifiant du participant';

COMMENT ON COLUMN PAIEMENT.MONTANTCHEQUE
     IS 'obligatoire pour un licencié';

COMMENT ON COLUMN PAIEMENT.NUMEROCHEQUE
     IS 'obligatoire pour un licencié';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE PAIEMENT
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_PAIEMENT_LICENCIE
     ON PAIEMENT (IDLICENCIE ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : PARTICIPANT
-- -----------------------------------------------------------------------------

CREATE TABLE PARTICIPANT
   (
    ID NUMBER(4)  NOT NULL,
    NOMPARTICIPANT VARCHAR2(40)  NOT NULL,
    PRENOMPARTICIPANT VARCHAR2(40)  NOT NULL,
    ADRESSEPARTICIPANT1 VARCHAR2(60)  NOT NULL,
    ADRESSEPARTICIPANT2 VARCHAR2(60)  NULL,
    CPPARTICIPANT CHAR(5)  NOT NULL,
    VILLEPARTICIPANT VARCHAR2(50)  NOT NULL,
    TELPARTICIPANT CHAR(15)  NULL,
    MAILPARTICIPANT VARCHAR2(60)  NULL,
	  DATEINSCRIPTION DATE DEFAULT SYSDATE NOT NULL,
    DATEENREGISTREMENTARRIVEE DATE  NULL,
    CLEWIFI CHAR(24)  NULL,
    CONSTRAINT PK_PARTICIPANT PRIMARY KEY (ID)  
   ) ;
COMMENT ON COLUMN PARTICIPANT.ID
     IS 'identifiant du participant';

COMMENT ON COLUMN PARTICIPANT.DATEENREGISTREMENTARRIVEE
     IS 'Date et heure à laqielle le participant arrive aux assises';

COMMENT ON COLUMN PARTICIPANT.CLEWIFI
     IS 'si le participant veut une clé wifi, on la génère et on la sauvegarde.';

-- -----------------------------------------------------------------------------
--       TABLE : ATELIER
-- -----------------------------------------------------------------------------

CREATE TABLE ATELIER
   (
    ID NUMBER(5)  NOT NULL   ,
    LIBELLEATELIER VARCHAR2(50)  NOT NULL,
    NBPLACESMAXI NUMBER(3) 
      DEFAULT 40 NOT NULL, 
      CONSTRAINT PK_ATELIER PRIMARY KEY (ID)  
   ) ;
COMMENT ON COLUMN ATELIER.ID
     IS 'Identifiant d''un atelier';

-- -----------------------------------------------------------------------------
--       TABLE : BENEVOLE
-- -----------------------------------------------------------------------------

CREATE TABLE BENEVOLE
   (
    IDBENEVOLE NUMBER(4)  NOT NULL,
	NUMEROLICENCE NUMBER(12)  NULL,
    DATENAISSANCE DATE  NOT NULL,
	CONSTRAINT PK_BENEVOLE PRIMARY KEY (IDBENEVOLE)
   ) ;
COMMENT ON COLUMN BENEVOLE.IDBENEVOLE
     IS 'identifiant du participant';

-- -----------------------------------------------------------------------------
--       TABLE : CONTENUHEBERGEMENT
-- -----------------------------------------------------------------------------

CREATE TABLE CONTENUHEBERGEMENT
   (
    IDPARTICIPANT NUMBER(4)  NOT NULL,
    NUMORDRE NUMBER(1)  NOT NULL,
    CODEHOTEL CHAR(4)  NOT NULL,
    IDCATEGORIE CHAR(1)  NOT NULL,
    IDDATEARRIVEENUITEE NUMBER(3)  NOT NULL,
    CONSTRAINT PK_CONTENUHEBERGEMENT PRIMARY KEY (IDPARTICIPANT, NUMORDRE)  
   ) ;
COMMENT ON COLUMN CONTENUHEBERGEMENT.IDPARTICIPANT
     IS 'identifiant du participant. Ne peut être l''identifiant d''un bénévole';

COMMENT ON COLUMN CONTENUHEBERGEMENT.CODEHOTEL
     IS 'Identifiant de l''hôtel';

COMMENT ON COLUMN CONTENUHEBERGEMENT.IDCATEGORIE
     IS 'Identifiant de la catégorie';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE CONTENUHEBERGEMENT
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_CONTENUHEBERGEMENT_HOTEL
     ON CONTENUHEBERGEMENT (CODEHOTEL ASC)
    ;

CREATE  INDEX I_FK_CONTENUHEBERGEMENT_CATEGO
     ON CONTENUHEBERGEMENT (IDCATEGORIE ASC)
    ;

CREATE  INDEX I_FK_CONTENUHEBERGEMENT_DATENU
     ON CONTENUHEBERGEMENT (IDDATEARRIVEENUITEE ASC)
    ;

CREATE  INDEX I_FK_CONTENUHEBERGEMENT_PARTIC
     ON CONTENUHEBERGEMENT (IDPARTICIPANT ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : DATENUITE
-- -----------------------------------------------------------------------------

CREATE TABLE DATENUITE
   (
    ID NUMBER(3) NOT NULL,
	DATEARRIVEENUITEE DATE  NOT NULL,
  CONSTRAINT PK_DATENUITE PRIMARY KEY (ID)  
   ) ;
COMMENT ON TABLE DATENUITE
     IS 'date d''arrivée hotel pour une nuit';

-- -----------------------------------------------------------------------------
--       TABLE : DATEBENEVOLAT
-- -----------------------------------------------------------------------------

CREATE TABLE DATEBENEVOLAT
   (
    ID NUMBER(3) NOT NULL,
	DATEBENEVOLAT DATE  NOT NULL,
   CONSTRAINT PK_DATEBENEVOLAT PRIMARY KEY (ID)  
   ) ;
-- -----------------------------------------------------------------------------
--       TABLE : HOTEL
-- -----------------------------------------------------------------------------

CREATE TABLE HOTEL
   (
    CODEHOTEL CHAR(4)  NOT NULL,
    NOMHOTEL VARCHAR(50)  NOT NULL,
    ADRESSEHOTEL1 VARCHAR2(128)  NOT NULL,
    ADRESSEHOTEL2 VARCHAR2(128)  NULL,
    CPHOTEL CHAR(5)  NOT NULL,
    VILLEHOTEL VARCHAR2(50)  NOT NULL,
    TELHOTEL CHAR(15)  NOT NULL,
    MAILHOTEL VARCHAR2(80)  NOT NULL,
    CONSTRAINT PK_HOTEL PRIMARY KEY (CODEHOTEL)  
   ) ;
COMMENT ON COLUMN HOTEL.CODEHOTEL
     IS 'Identifiant de l''hôtel';

-- -----------------------------------------------------------------------------
--       TABLE : INTERVENANT
-- -----------------------------------------------------------------------------

CREATE TABLE INTERVENANT
   (
    IDINTERVENANT NUMBER(4)  NOT NULL,
    IDATELIER NUMBER(5)  NOT NULL   CHECK (IDATELIER BETWEEN 1 AND 6),
    IDSTATUT CHAR(3) NOT NULL,
    CONSTRAINT PK_INTERVENANT PRIMARY KEY (IDINTERVENANT)  
   ) ;
COMMENT ON COLUMN INTERVENANT.IDINTERVENANT
     IS 'identifiant du participant';

COMMENT ON COLUMN INTERVENANT.IDATELIER
     IS 'Identifiant d''un atelier';


-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE INTERVENANT
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_INTERVENANT_ATELIER
     ON INTERVENANT (IDATELIER ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : LICENCIE
-- -----------------------------------------------------------------------------

CREATE TABLE LICENCIE
   (
    IDLICENCIE NUMBER(4)  NOT NULL,
    IDQUALITE NUMBER(2)  NULL,
    NUMEROLICENCE NUMBER(12)  NOT NULL,
	CONSTRAINT PK_LICENCIE PRIMARY KEY (IDLICENCIE)  
   ) ;
COMMENT ON COLUMN LICENCIE.IDLICENCIE
     IS 'identifiant du participant';

COMMENT ON COLUMN LICENCIE.IDQUALITE
     IS 'identifiant de qualité';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE LICENCIE
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_LICENCIE_QUALITE
     ON LICENCIE (IDQUALITE ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : RESTAURATION
-- -----------------------------------------------------------------------------

CREATE TABLE RESTAURATION
   (
    IDRESTAURATION NUMBER(1)  NOT NULL,
    DATERESTAURATION DATE  NOT NULL,
    TYPEREPAS CHAR(4)  NOT NULL   CHECK (TYPEREPAS IN ('midi', 'soir')),
    CONSTRAINT PK_RESTAURATION PRIMARY KEY (IDRESTAURATION)  
   ) ;
-- -----------------------------------------------------------------------------
--       TABLE : VACATION
-- -----------------------------------------------------------------------------

CREATE TABLE VACATION
   (
    IDATELIER NUMBER(5)  NOT NULL   CHECK (IDATELIER BETWEEN 1 AND 6),
    NUMERO NUMBER(1)  NOT NULL,
    HEUREDEBUT DATE  NOT NULL,
    HEUREFIN DATE  NOT NULL,
    CONSTRAINT PK_VACATION PRIMARY KEY (IDATELIER, NUMERO)  
   ) ;
COMMENT ON COLUMN VACATION.IDATELIER
     IS 'Identifiant d''un atelier';

COMMENT ON COLUMN VACATION.NUMERO
     IS 'identifiant de la session de 1 à 5';

COMMENT ON COLUMN VACATION.HEUREDEBUT
     IS 'Format date heure, doit inclure date ET heure de début';

COMMENT ON COLUMN VACATION.HEUREFIN
     IS 'Format date heure, doit inclure date ET heure de fin';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE VACATION
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_VACATION_ATELIER
     ON VACATION (IDATELIER ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : CATEGORIECHAMBRE
-- -----------------------------------------------------------------------------

CREATE TABLE CATEGORIECHAMBRE
   (
    ID CHAR(1)  NOT NULL,
    LIBELLECATEGORIE VARCHAR2(20)  NOT NULL,
    CONSTRAINT PK_CATEGORIECHAMBRE PRIMARY KEY (ID)  
   ) ;
COMMENT ON COLUMN CATEGORIECHAMBRE.ID
     IS 'Identifiant de la catégorie';

-- -----------------------------------------------------------------------------
--       TABLE : QUALITE
-- -----------------------------------------------------------------------------

CREATE TABLE QUALITE
   (
    ID NUMBER(2)  NOT NULL,
    LIBELLEQUALITE VARCHAR2(50)  NOT NULL,
    CONSTRAINT PK_QUALITE PRIMARY KEY (ID)  
   ) ;
COMMENT ON COLUMN QUALITE.ID
     IS 'identifiant de qualité';

-- -----------------------------------------------------------------------------
--       TABLE : THEME
-- -----------------------------------------------------------------------------

CREATE TABLE THEME
   (
    IDATELIER NUMBER(5)  NOT NULL   CHECK (IDATELIER BETWEEN 1 AND 6),
    NUMERO NUMBER(1)  NOT NULL   CHECK (NUMERO BETWEEN 1 AND 6),
    LIBELLETHEME VARCHAR2(80)  NOT NULL,
    CONSTRAINT PK_THEME PRIMARY KEY (IDATELIER, NUMERO)  
   ) ;
COMMENT ON COLUMN THEME.IDATELIER
     IS 'Identifiant d''un atelier';

COMMENT ON COLUMN THEME.NUMERO
     IS 'Numéro du thème à l''intérieur d''un atelier';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE THEME
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_THEME_ATELIER
     ON THEME (IDATELIER ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : PARTICIPER
-- -----------------------------------------------------------------------------

CREATE TABLE PARTICIPER
   (
    IDLICENCIE NUMBER(4)  NOT NULL,
    IDATELIER NUMBER(5)  NOT NULL   CHECK (IDATELIER BETWEEN 1 AND 6),
    NUMERO NUMBER(1)  NOT NULL,
    CONSTRAINT PK_PARTICIPER PRIMARY KEY (IDATELIER, NUMERO, IDLICENCIE)  
   ) ;
COMMENT ON COLUMN PARTICIPER.IDLICENCIE
     IS 'identifiant du participant';

COMMENT ON COLUMN PARTICIPER.IDATELIER
     IS 'Identifiant d''un atelier';

COMMENT ON COLUMN PARTICIPER.NUMERO
     IS 'identifiant de la session de 1 à 5';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE PARTICIPER
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_PARTICIPER_VACATION
     ON PARTICIPER (IDATELIER ASC, NUMERO ASC)
    ;

CREATE  INDEX I_FK_PARTICIPER_INSCRIRE
     ON PARTICIPER (IDLICENCIE ASC, IDATELIER ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : INSCRIRE
-- -----------------------------------------------------------------------------

CREATE TABLE INSCRIRE
   (
    IDPARTICIPANT NUMBER(4)  NOT NULL,
    IDATELIER NUMBER(5)  NOT NULL   CHECK (IDATELIER BETWEEN 1 AND 6),
    CONSTRAINT PK_INSCRIRE PRIMARY KEY (IDPARTICIPANT, IDATELIER)  
   ) ;
COMMENT ON COLUMN INSCRIRE.IDPARTICIPANT
     IS 'identifiant du participant';

COMMENT ON COLUMN INSCRIRE.IDATELIER
     IS 'Identifiant d''un atelier';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE INSCRIRE
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_INSCRIRE_LICENCIE
     ON INSCRIRE (IDPARTICIPANT ASC)
    ;

CREATE  INDEX I_FK_INSCRIRE_ATELIER
     ON INSCRIRE (IDATELIER ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : PROPOSER
-- -----------------------------------------------------------------------------

CREATE TABLE PROPOSER
   (
    CODEHOTEL CHAR(4)  NOT NULL,
    IDCATEGORIE CHAR(1)  NOT NULL,
    TARIFNUITE NUMBER(6,2)  NOT NULL,
    CONSTRAINT PK_PROPOSER PRIMARY KEY (CODEHOTEL, IDCATEGORIE)  
   ) ;
COMMENT ON COLUMN PROPOSER.CODEHOTEL
     IS 'Identifiant de l''hôtel';

COMMENT ON COLUMN PROPOSER.IDCATEGORIE
     IS 'Identifiant de la catégorie';

COMMENT ON COLUMN PROPOSER.TARIFNUITE
     IS 'tarif de la nuité pour les assises';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE PROPOSER
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_PROPOSER_HOTEL
     ON PROPOSER (CODEHOTEL ASC)
    ;

CREATE  INDEX I_FK_PROPOSER_CATEGORIECHAMBRE
     ON PROPOSER (IDCATEGORIE ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : ETREPRESENT
-- -----------------------------------------------------------------------------

CREATE TABLE ETREPRESENT
   (
    IDBENEVOLE NUMBER(4)  NOT NULL,
    IDDATEPRESENT NUMBER(3)   NOT NULL,
    CONSTRAINT PK_ETREPRESENT PRIMARY KEY (IDBENEVOLE, IDDATEPRESENT)  
   ) ;
COMMENT ON COLUMN ETREPRESENT.IDBENEVOLE
     IS 'identifiant du participant';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE ETREPRESENT
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_ETREPRESENT_BENEVOLE
     ON ETREPRESENT (IDBENEVOLE ASC)
    ;

CREATE  INDEX I_FK_ETREPRESENT_DATEBENEVOLAT
     ON ETREPRESENT (IDDATEPRESENT ASC)
    ;

-- -----------------------------------------------------------------------------
--       TABLE : INCLUREACCOMPAGNANT
-- -----------------------------------------------------------------------------

CREATE TABLE INCLUREACCOMPAGNANT
   (
    IDRESTAURATION NUMBER(1)  NOT NULL,
    IDLICENCIE NUMBER(4)  NOT NULL,
    CONSTRAINT PK_INCLUREACCOMPAGNANT PRIMARY KEY (IDRESTAURATION, IDLICENCIE)  
   ) ;
COMMENT ON COLUMN INCLUREACCOMPAGNANT.IDLICENCIE
     IS 'identifiant du participant';

-- -----------------------------------------------------------------------------
--       INDEX DE LA TABLE INCLUREACCOMPAGNANT
-- -----------------------------------------------------------------------------

CREATE  INDEX I_FK_INCLUREACCOMPAGNANT_RESTA
     ON INCLUREACCOMPAGNANT (IDRESTAURATION ASC)
    ;

CREATE  INDEX I_FK_INCLUREACCOMPAGNANT_LICEN
     ON INCLUREACCOMPAGNANT (IDLICENCIE ASC)
    ;


   
-- -----------------------------------------------------------------------------
--       TABLE : STATUT
-- -----------------------------------------------------------------------------

CREATE TABLE STATUT
   (
    ID CHAR(3) NOT NULL,
    LIBELLESTATUT VARCHAR2(30)  NOT NULL,
    CONSTRAINT PK_STATUT PRIMARY KEY (ID)  
   ) ;      
-- -----------------------------------------------------------------------------
--       TABLE : PARAMETRES
-- -----------------------------------------------------------------------------

CREATE TABLE PARAMETRES
   (
    NOMDDL VARCHAR2(60)  NOT NULL,
    ADRUE1 VARCHAR2(60)  NOT NULL,
    ADRUE2 VARCHAR2(60)   NULL,
    CP CHAR(5)  NOT NULL,
    VILLE VARCHAR2(60)  NOT NULL,
    TEL CHAR(15)  NOT NULL,
    FAX CHAR(15)  NOT NULL,
    MAIL VARCHAR2(60)  NOT NULL,
    TARIFINSCRIPTION NUMBER(6,2)  NOT NULL,
    TARIFREPASACCOMPAGNANT NUMBER(5,2)  NOT NULL,
	DUREE integer default 0 not null,
	NBATELIERMAX integer default 0 not null,
	constraint ckc_parametres_duree check(duree >=0),
	constraint ckc_parametres_nbateliermax check(nbateliermax >=0)
   ) ;
   
   
-- -----------------------------------------------------------------------------
--       CREATION DES REFERENCES DE TABLE
-- -----------------------------------------------------------------------------


ALTER TABLE PAIEMENT ADD (
     CONSTRAINT FK_PAIEMENT_LICENCIE
          FOREIGN KEY (IDLICENCIE)
               REFERENCES LICENCIE (IDLICENCIE))   ;

ALTER TABLE BENEVOLE ADD (
     CONSTRAINT FK_BENEVOLE_PARTICIPANT
          FOREIGN KEY (IDBENEVOLE)
               REFERENCES PARTICIPANT (ID)
                    ON DELETE CASCADE
)   ;

ALTER TABLE CONTENUHEBERGEMENT ADD (
     CONSTRAINT FK_CONTENUHEBERGEMENT_HOTEL
          FOREIGN KEY (CODEHOTEL)
               REFERENCES HOTEL (CODEHOTEL))   ;

ALTER TABLE CONTENUHEBERGEMENT ADD (
     CONSTRAINT FK_CONTENUHEBERGEMENT_CATEGORI
          FOREIGN KEY (IDCATEGORIE)
               REFERENCES CATEGORIECHAMBRE (ID))   ;

ALTER TABLE CONTENUHEBERGEMENT ADD (
     CONSTRAINT FK_CONTENUHEBERGEMENT_DATENUIT
          FOREIGN KEY (IDDATEARRIVEENUITEE)
               REFERENCES DATENUITE (ID))   ;

ALTER TABLE CONTENUHEBERGEMENT ADD (
     CONSTRAINT FK_CONTENUHEBERGEMENT_PARTICIP
          FOREIGN KEY (IDPARTICIPANT)
               REFERENCES PARTICIPANT (ID))   ;

ALTER TABLE INTERVENANT ADD (
     CONSTRAINT FK_INTERVENANT_PARTICIPANT
          FOREIGN KEY (IDINTERVENANT)
               REFERENCES PARTICIPANT (ID)
                    ON DELETE CASCADE
)   ;

ALTER TABLE INTERVENANT ADD (
     CONSTRAINT FK_INTERVENANT_ATELIER
          FOREIGN KEY (IDATELIER)
               REFERENCES ATELIER (ID))   ;

ALTER TABLE LICENCIE ADD (
     CONSTRAINT FK_LICENCIE_QUALITE
          FOREIGN KEY (IDQUALITE)
               REFERENCES QUALITE (ID))   ;

ALTER TABLE LICENCIE ADD (
     CONSTRAINT FK_LICENCIE_PARTICIPANT
          FOREIGN KEY (IDLICENCIE)
               REFERENCES PARTICIPANT (ID)
                    ON DELETE CASCADE
)   ;

ALTER TABLE VACATION ADD (
     CONSTRAINT FK_VACATION_ATELIER
          FOREIGN KEY (IDATELIER)
               REFERENCES ATELIER (ID))   ;

ALTER TABLE THEME ADD (
     CONSTRAINT FK_THEME_ATELIER
          FOREIGN KEY (IDATELIER)
               REFERENCES ATELIER (ID))   ;

ALTER TABLE PARTICIPER ADD (
     CONSTRAINT FK_PARTICIPER_VACATION
          FOREIGN KEY (IDATELIER, NUMERO)
               REFERENCES VACATION (IDATELIER, NUMERO)
                    ON DELETE CASCADE
)   ;

ALTER TABLE PARTICIPER ADD (
     CONSTRAINT FK_PARTICIPER_INSCRIRE
          FOREIGN KEY (IDLICENCIE, IDATELIER)
               REFERENCES INSCRIRE (IDPARTICIPANT, IDATELIER))   ;

ALTER TABLE INSCRIRE ADD (
     CONSTRAINT FK_INSCRIRE_LICENCIE
          FOREIGN KEY (IDPARTICIPANT)
               REFERENCES LICENCIE (IDLICENCIE)
                    ON DELETE CASCADE
)   ;

ALTER TABLE INSCRIRE ADD (
     CONSTRAINT FK_INSCRIRE_ATELIER
          FOREIGN KEY (IDATELIER)
               REFERENCES ATELIER (ID)
                    ON DELETE CASCADE
)   ;

ALTER TABLE PROPOSER ADD (
     CONSTRAINT FK_PROPOSER_HOTEL
          FOREIGN KEY (CODEHOTEL)
               REFERENCES HOTEL (CODEHOTEL)
                    ON DELETE CASCADE
)   ;

ALTER TABLE PROPOSER ADD (
     CONSTRAINT FK_PROPOSER_CATEGORIECHAMBRE
          FOREIGN KEY (IDCATEGORIE)
               REFERENCES CATEGORIECHAMBRE (ID)
                    ON DELETE CASCADE
)   ;

ALTER TABLE ETREPRESENT ADD (
     CONSTRAINT FK_ETREPRESENT_BENEVOLE
          FOREIGN KEY (IDBENEVOLE)
               REFERENCES BENEVOLE (IDBENEVOLE)
                    ON DELETE CASCADE
)   ;

ALTER TABLE ETREPRESENT ADD (
     CONSTRAINT FK_ETREPRESENT_DATEBENEVOLAT
          FOREIGN KEY (IDDATEPRESENT)
               REFERENCES DATEBENEVOLAT (ID)
                    ON DELETE CASCADE
)   ;

ALTER TABLE INCLUREACCOMPAGNANT ADD (
     CONSTRAINT FK_INCLUREACCOMPAGNANT_RESTAUR
          FOREIGN KEY (IDRESTAURATION)
               REFERENCES RESTAURATION (IDRESTAURATION)
                    ON DELETE CASCADE
)   ;

ALTER TABLE INCLUREACCOMPAGNANT ADD (
     CONSTRAINT FK_INCLUREACCOMPAGNANT_LICENCI
          FOREIGN KEY (IDLICENCIE)
               REFERENCES LICENCIE (IDLICENCIE)
                    ON DELETE CASCADE
)   ;



ALTER TABLE INTERVENANT ADD (
     CONSTRAINT FK_INTERVENANT_STATUT
          FOREIGN KEY (IDSTATUT)
               REFERENCES STATUT (ID)
)   ;

-- -----------------------------------------------------------------------------
--                LES VUES
-- -----------------------------------------------------------------------------
create or replace view VRESTAURATION01 as
select IDRESTAURATION ID, to_char(daterestauration, 'Day dd Month YYYY','NLS_DATE_LANGUAGE = FRENCH') || '  ' ||typerepas as libelle
from RESTAURATION;

--
-- Cette vue VDATENUITE01 va permettre de choisir les dates où un participant peut arriverà l'hotel
create or replace view VDATENUITE01 as
select id, to_char(DATEARRIVEENUITEE, 'Day dd Month YYYY','NLS_DATE_LANGUAGE = FRENCH')as libelle
from DATENUITE;

--
-- Cette vue VHOTEL01 va permettre de remplir la combobox du choix d'hotel du composant nuité
create or replace view VHOTEL01 as
select codehotel as id, nomhotel as libelle
from hotel;

--
-- Cette vue VCATEGORIECHAMBRE01 va permettre de remplir la combobox du choix de la catégorie de la chambre du composant nuité
create or replace view VCATEGORIECHAMBRE01 as
select id , libellecategorie as libelle
from categoriechambre;

-- -----------------------------------------------------------------------------
--                FIN DE GENERATION
-- -----------------------------------------------------------------------------
