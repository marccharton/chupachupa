/*
     Database name : Chupachupa-Database
     Project : ChupaChupa
     Auteur : Sasuke
     Last modification date : 24/10/2014 15:37:29
 ----------------------------------------------------------------------------
*/

/* -----------------------------------------------------------------------------
      CLEAN EXISTING Chupachupa-Database
----------------------------------------------------------------------------- */

USE master
go

IF EXISTS (select * from sys.databases where name='ChupaChupa-Database')
BEGIN
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'USERRSSITEM'))
  BEGIN
    alter table USERRSSITEM DROP CONSTRAINT FK_USERRSSITEM_USER
    alter table USERRSSITEM DROP CONSTRAINT FK_USERRSSITEM_RSSITEM
    drop table USERRSSITEM
    PRINT 'Delete USERRSSITEM'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'CATEGORYRSSCHANNEL'))
  BEGIN
    alter table CATEGORYRSSCHANNEL DROP CONSTRAINT FK_CATEGORYRSSCHANNEL_CATEGORY
    alter table CATEGORYRSSCHANNEL DROP CONSTRAINT FK_CATEGORYRSSCHANNEL_RSSCHANNEL 
    drop table CATEGORYRSSCHANNEL
    PRINT 'Delete CATEGORYRSSCHANNEL'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'USERRSSCHANNEL'))
  BEGIN
    alter table USERRSSCHANNEL DROP CONSTRAINT FK_USERRSSCHANNEL_USER
    alter table USERRSSCHANNEL DROP CONSTRAINT FK_USERRSSCHANNEL_RSSCHANNEL
    drop table USERRSSCHANNEL
    PRINT 'Delete USERRSSCHANNEL'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSITEMRSSCATEGORY'))
  BEGIN
    alter table RSSITEMRSSCATEGORY DROP CONSTRAINT FK_RSSITEMRSSCATEGORY_RSSITEM
    alter table RSSITEMRSSCATEGORY DROP CONSTRAINT FK_RSSITEMRSSCATEGORY_RSSCATEGORY
    drop table RSSITEMRSSCATEGORY
    PRINT 'Delete RSSITEMRSSCATEGORY'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSCHANNELSKIPDAYS'))
  BEGIN
    alter table RSSCHANNELSKIPDAYS DROP CONSTRAINT FK_RSSCHANNELSKIPDAYS_SKIPDAYS
    alter table RSSCHANNELSKIPDAYS DROP CONSTRAINT FK_RSSCHANNELSKIPDAYS_RSSCHANNEL
    drop table RSSCHANNELSKIPDAYS
    PRINT 'Delete RSSCHANNELSKIPDAYS'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSCHANNELSKIPHOURS'))
  BEGIN
    alter table RSSCHANNELSKIPHOURS DROP CONSTRAINT FK_RSSCHANNELSKIPHOURS_SKIPHOURS
    alter table RSSCHANNELSKIPHOURS DROP CONSTRAINT FK_RSSCHANNELSKIPHOURS_RSSCHANNEL
    drop table RSSCHANNELSKIPHOURS
    PRINT 'Delete RSSCHANNELSKIPHOURS'
  END
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'SOURCE'))
  BEGIN
    alter table SOURCE DROP CONSTRAINT FK_SOURCE_RSSITEM
    drop table "SOURCE"
    PRINT 'Delete SOURCE'
  END 
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'ENCLOSURE'))
  BEGIN
    alter table ENCLOSURE DROP CONSTRAINT FK_ENCLOSURE_RSSITEM
    drop table "ENCLOSURE"
    PRINT 'Delete ENCLOSURE'
  END 
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSITEM'))
  BEGIN
    alter table RSSITEM DROP CONSTRAINT FK_RSSITEM_RSSCHANNEL
    alter table RSSITEM DROP CONSTRAINT FK_RSSITEM_SOURCE
    alter table RSSITEM DROP CONSTRAINT FK_RSSITEM_ENCLOSURE
    drop table RSSITEM
    PRINT 'Delete RSSITEM'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'IMAGE'))
  BEGIN
    alter table IMAGE DROP CONSTRAINT FK_IMAGE_RSSCHANNEL
    drop table "IMAGE"
    PRINT 'Delete IMAGE'
  END
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'TEXTINPUT'))
  BEGIN
    alter table TEXTINPUT DROP CONSTRAINT FK_TEXTINPUT_RSSCHANNEL
    drop table "TEXTINPUT"
    PRINT 'Delete TEXTINPUT'
  END
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'CLOUD'))
  BEGIN
    alter table CLOUD DROP CONSTRAINT FK_CLOUD_RSSCHANNEL
    drop table "CLOUD"
    PRINT 'Delete CLOUD'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'SKIPDAYS'))
  BEGIN
    drop table "SKIPDAYS"
    PRINT 'Delete SKIPDAYS'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'SKIPHOURS'))
  BEGIN
    drop table "SKIPHOURS"
    PRINT 'Delete SKIPHOURS'
  END
  
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSCHANNELRSSCATEGORY'))
  BEGIN
    alter table RSSCHANNELRSSCATEGORY DROP CONSTRAINT FK_RSSCHANNELRSSCATEGORY_RSSCATEGORY
    alter table RSSCHANNELRSSCATEGORY DROP CONSTRAINT FK_RSSCHANNELRSSCATEGORY_RSSCHANNEL
    drop table RSSCHANNELRSSCATEGORY
    PRINT 'Delete RSSCHANNELRSSCATEGORY'
  END
  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSCHANNEL'))
  BEGIN
    alter table RSSCHANNEL DROP CONSTRAINT FK_RSSCHANNEL_IMAGE
    alter table RSSCHANNEL DROP CONSTRAINT FK_RSSCHANNEL_TEXTINPUT
    alter table RSSCHANNEL DROP CONSTRAINT FK_RSSCHANNEL_CLOUD
    drop table "RSSCHANNEL"
    PRINT 'Delete RSSCHANNEL'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'RSSCATEGORY'))
  BEGIN
    drop table "RSSCATEGORY"
    PRINT 'Delete RSSCATEGORY'
  END

  
  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'USER'))
  BEGIN
    drop table "USER"
    PRINT 'Delete USER'
  END

  IF (EXISTS (SELECT * 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = 'CATEGORY'))
  BEGIN
	alter table CATEGORYUSERCHANNEL DROP CONSTRAINT FK_CATEGORY_USER
    drop table "CATEGORY"
    PRINT 'Delete CATEGORY'
  END
  drop database "ChupaChupa-Database"
  PRINT 'Drop ChupaChupa-Database'
END

/* -----------------------------------------------------------------------------
      OPEN DATABASE Chupachupa-Database
----------------------------------------------------------------------------- */

create database "Chupachupa-Database"
go

use "Chupachupa-Database"
go

/* -----------------------------------------------------------------------------
      TABLE : USER
----------------------------------------------------------------------------- */

create table "USER"
  (
     IDUSER bigint not null IDENTITY,
     LOGINMAIL varchar(255) not null,
     PASSWORD varchar(255) not null,
     OAUTHTOKEN varchar(255) null,
     constraint PK_USER primary key (IDUSER)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSCATEGORY
----------------------------------------------------------------------------- */

create table RSSCATEGORY
  (
     IDRSSCATEGORY bigint not null IDENTITY,
     NAME varchar(64) not null,
     "DOMAIN" varchar(128) null,
     constraint PK_RSSCATEGORY primary key (IDRSSCATEGORY)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSCHANNEL
----------------------------------------------------------------------------- */

create table RSSCHANNEL
  (
     IDRSSCHANNEL bigint not null IDENTITY,
     IDCLOUD bigint null,
	 IDTEXTINPUT bigint null,
	 IDIMAGE bigint null,
     RSSLINK varchar(512) not null,
     TITLE varchar(128) not null,
     LINK varchar(512) not null,
     DESCRIPTION varchar(512) not null,
     "LANGUAGE" varchar(32) null,
     COPYRIGHT varchar(64) null,
     MANAGINGEDITOR varchar(64) null,
     WEBMASTER varchar(64) null,
     PUBDATE datetime null,
     LASTBUILDDATE datetime null,
     GENERATOR varchar(64) null,
     DOCS varchar(128) null,
     TTL int null,
     RATING varchar(32) null,
     constraint PK_RSSCHANNEL primary key (IDRSSCHANNEL)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : IMAGE
----------------------------------------------------------------------------- */

create table IMAGE
  (
     IDIMAGE bigint not null IDENTITY,
     URL varchar(512) not null,
     TITLE varchar(128) not null,
     LINK varchar(512) not null,
     DESCRIPTION varchar(512) null,
     WIDTH int null,
     HEIGHT int null,
     constraint PK_IMAGE primary key (IDIMAGE)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : TEXTINPUT
----------------------------------------------------------------------------- */

create table TEXTINPUT
  (
     IDTEXTINPUT bigint not null IDENTITY,
     TITLE varchar(128) not null,
     DESCRIPTION varchar(512) not null,
     NAME varchar(64) not null,
     LINK varchar(512) not null,
     constraint PK_TEXTINPUT primary key (IDTEXTINPUT)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : CLOUD
----------------------------------------------------------------------------- */

create table CLOUD
  (
     IDCLOUD bigint not null IDENTITY,
     "DOMAIN" varchar(128) not null,
     PORT int not null,
     "PATH" varchar(128) not null,
     REGISTERPROCEDURE varchar(32) not null,
     PROTOCOL varchar(32) not null,
     constraint PK_CLOUD primary key (IDCLOUD)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : SKIPHOURS
----------------------------------------------------------------------------- */

create table SKIPHOURS
  (
     IDSKIPHOURS bigint not null IDENTITY,
     "HOUR" smallint not null,
     constraint PK_SKIPHOURS primary key (IDSKIPHOURS)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSCHANNELSKIPHOURS
----------------------------------------------------------------------------- */

create table RSSCHANNELSKIPHOURS
  (
     IDSKIPHOURS bigint not null,
     IDRSSCHANNEL bigint not null,
     constraint PK_RSSCHANNELSKIPHOURS primary key (IDSKIPHOURS, IDRSSCHANNEL)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : SKIPDAYS
----------------------------------------------------------------------------- */

create table SKIPDAYS
  (
     IDSKIPDAYS bigint not null IDENTITY,
     "DAY" varchar(32) not null,
     constraint PK_SKIPDAYS primary key (IDSKIPDAYS)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSCHANNELSKIPDAYS
----------------------------------------------------------------------------- */

create table RSSCHANNELSKIPDAYS
  (
     IDSKIPDAYS bigint not null,
     IDRSSCHANNEL bigint not null,
     constraint PK_RSSCHANNELSKIPDAYS primary key (IDSKIPDAYS, IDRSSCHANNEL)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSCHANNELRSSCATEGORY
----------------------------------------------------------------------------- */

create table RSSCHANNELRSSCATEGORY
  (
     IDRSSCATEGORY bigint not null,
     IDRSSCHANNEL bigint not null,
     constraint PK_RSSCHANNELRSSCATEGORY primary key (IDRSSCATEGORY, IDRSSCHANNEL)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSITEM
----------------------------------------------------------------------------- */

create table RSSITEM
  (
     IDRSSITEM bigint not null IDENTITY,
     IDRSSCHANNEL bigint not null,
     IDSOURCE bigint null,
     IDENCLOSURE bigint null,
     TITLE varchar(128) not null,
     LINK varchar(512) not null,
     DESCRIPTION varchar(512) not null,
     AUTHOR varchar(64) null,
     COMMENTS varchar(256) null,
     GUID varchar(512) null,
     PUBDATE datetime null,
     constraint PK_RSSITEM primary key (IDRSSITEM)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : SOURCE
----------------------------------------------------------------------------- */

create table SOURCE
  (
     IDSOURCE bigint not null IDENTITY,
     URL varchar(512) not null,
     constraint PK_SOURCE primary key (IDSOURCE)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : ENCLOSURE
----------------------------------------------------------------------------- */

create table ENCLOSURE
  (
     IDENCLOSURE bigint not null IDENTITY,
     URL varchar(512) not null,
     "LENGTH" bigint not null,
     "TYPE" varchar(64) not null,
     constraint PK_ENCLOSURE primary key (IDENCLOSURE)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : RSSITEMRSSCATEGORY
----------------------------------------------------------------------------- */

create table RSSITEMRSSCATEGORY
  (
     IDRSSCATEGORY bigint not null,
     IDRSSITEM bigint not null,
     constraint PK_RSSITEMRSSCATEGORY primary key (IDRSSCATEGORY, IDRSSITEM)
  ) 
go


/* -----------------------------------------------------------------------------
      TABLE : CATEGORY
----------------------------------------------------------------------------- */

create table CATEGORY
  (
     IDCATEGORY bigint not null IDENTITY,
	 IDUSER bigint not null,
     NAME varchar(64) not null,
     constraint PK_CATEGORY primary key (IDCATEGORY)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : CATEGORYRSSCHANNEL
----------------------------------------------------------------------------- */

create table CATEGORYRSSCHANNEL
  (
     IDCATEGORY bigint not null,
     IDRSSCHANNEL bigint not null,
     constraint PK_CATEGORYRSSCHANNEL primary key (IDCATEGORY, IDRSSCHANNEL)
  ) 
go


/* -----------------------------------------------------------------------------
      TABLE : USERRSSITEM
----------------------------------------------------------------------------- */

create table USERRSSITEM
  (
     IDUSER bigint not null,
     IDRSSITEM bigint not null,
     constraint PK_USERRSSITEM primary key (IDUSER, IDRSSITEM)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : USERRSSCHANNEL
----------------------------------------------------------------------------- */

create table USERRSSCHANNEL
  (
     IDUSER bigint not null,
     IDRSSCHANNEL bigint not null,
     constraint PK_USERRSSCHANNEL primary key (IDUSER, IDRSSCHANNEL)
  ) 
go

/* -----------------------------------------------------------------------------
      CONSTRAINT ON TABLES
----------------------------------------------------------------------------- */

alter table RSSCHANNEL 
     add constraint FK_RSSCHANNEL_IMAGE foreign key (IDIMAGE) 
               references IMAGE (IDIMAGE)
go

alter table RSSCHANNEL 
     add constraint FK_RSSCHANNEL_TEXTINPUT foreign key (IDTEXTINPUT) 
               references TEXTINPUT (IDTEXTINPUT)
go

alter table RSSCHANNEL 
     add constraint FK_RSSCHANNEL_CLOUD foreign key (IDCLOUD) 
               references CLOUD (IDCLOUD)
go


alter table RSSITEM 
     add constraint FK_RSSITEM_RSSCHANNEL foreign key (IDRSSCHANNEL) 
               references RSSCHANNEL (IDRSSCHANNEL)
go

alter table RSSITEM 
     add constraint FK_RSSITEM_SOURCE foreign key (IDSOURCE) 
               references SOURCE (IDSOURCE)
go

alter table RSSITEM 
     add constraint FK_RSSITEM_ENCLOSURE foreign key (IDENCLOSURE) 
               references ENCLOSURE (IDENCLOSURE)
go

alter table RSSITEMRSSCATEGORY 
     add constraint FK_RSSITEMRSSCATEGORY_RSSCATEGORY foreign key (IDRSSCATEGORY) 
               references RSSCATEGORY (IDRSSCATEGORY)
go

alter table RSSITEMRSSCATEGORY 
     add constraint FK_RSSITEMRSSCATEGORY_RSSITEM foreign key (IDRSSITEM) 
               references RSSITEM (IDRSSITEM)
go

alter table RSSCHANNELSKIPDAYS 
     add constraint FK_RSSCHANNELSKIPDAYS_SKIPDAYS foreign key (IDSKIPDAYS) 
               references SKIPDAYS (IDSKIPDAYS)
go

alter table RSSCHANNELSKIPDAYS 
     add constraint FK_RSSCHANNELSKIPDAYS_RSSCHANNEL foreign key (IDRSSCHANNEL) 
               references RSSCHANNEL (IDRSSCHANNEL)
go

alter table RSSCHANNELRSSCATEGORY 
     add constraint FK_RSSCHANNELRSSCATEGORY_RSSCATEGORY foreign key (IDRSSCATEGORY) 
               references RSSCATEGORY (IDRSSCATEGORY)
go

alter table RSSCHANNELRSSCATEGORY 
     add constraint FK_RSSCHANNELRSSCATEGORY_RSSCHANNEL foreign key (IDRSSCHANNEL) 
               references RSSCHANNEL (IDRSSCHANNEL)
go

alter table RSSCHANNELSKIPHOURS 
     add constraint FK_RSSCHANNELSKIPHOURS_SKIPHOURS foreign key (IDSKIPHOURS) 
               references SKIPHOURS (IDSKIPHOURS)
go

alter table RSSCHANNELSKIPHOURS 
     add constraint FK_RSSCHANNELSKIPHOURS_RSSCHANNEL foreign key (IDRSSCHANNEL) 
               references RSSCHANNEL (IDRSSCHANNEL)
go

alter table USERRSSITEM 
     add constraint FK_USERRSSITEM_USER foreign key (IDUSER) 
               references "USER" (IDUSER)
go

alter table USERRSSITEM 
     add constraint FK_USERRSSITEM_RSSITEM foreign key (IDRSSITEM) 
               references RSSITEM (IDRSSITEM)
go

alter table USERRSSCHANNEL 
     add constraint FK_USERRSSCHANNEL_USER foreign key (IDUSER) 
               references "USER" (IDUSER)
go

alter table USERRSSCHANNEL 
     add constraint FK_USERRSSCHANNEL_RSSCHANNEL foreign key (IDRSSCHANNEL) 
               references RSSCHANNEL (IDRSSCHANNEL)
go

alter table CATEGORY 
     add constraint FK_CATEGORY_USER foreign key (IDUSER) 
               references "USER" (IDUSER)
go

alter table CATEGORYRSSCHANNEL 
     add constraint FK_CATEGORYRSSCHANNEL_CATEGORY foreign key (IDCATEGORY) 
               references CATEGORY (IDCATEGORY)
go

alter table CATEGORYRSSCHANNEL 
     add constraint FK_CATEGORYRSSCHANNEL_RSSCHANNEL foreign key (IDRSSCHANNEL) 
               references RSSCHANNEL (IDRSSCHANNEL)
go


/* -----------------------------------------------------------------------------
      GRANTING ACCESS TO DATABASE
----------------------------------------------------------------------------- */
use master
go

if  exists (select * from master.dbo.syslogins where name = N'ChupachupaAdmin')
drop LOGIN ChupachupaAdmin

create LOGIN ChupachupaAdmin with PASSWORD = 'Chupachupa47', DEFAULT_DATABASE = "Chupachupa-Database"
go

use "Chupachupa-Database"
go

create user ChupachupaAdmin for LOGIN ChupachupaAdmin
go

exec sp_addrolemember 'db_owner', 'ChupachupaAdmin'
go

/* -----------------------------------------------------------------------------
      INSERTING DATA INTO TABLES
----------------------------------------------------------------------------- */

SET IDENTITY_INSERT "USER" ON
go

insert into "USER" (IDUSER, LOGINMAIL, "PASSWORD", OAUTHTOKEN) values (1, 'test-user@epitech.eu', '7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b', ''),
(2, 'bastien.minarie-pagnier@epitech.eu', '7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b', ''),
(3, 'jeremy.seita@epitech.eu', '7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b', ''),
(7, 'florian.guiho@epitech.eu', '7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b', ''),
(47, 'marc.charton@epitech.eu', '7f765abdcc37c2725cb454b3e98b98c4cea813cea3226751229ca7e9fceb4a2b', '')

SET IDENTITY_INSERT "USER" OFF
go

SET IDENTITY_INSERT "CATEGORY" ON
go

insert into "CATEGORY" (IDCATEGORY, NAME, IDUSER) values (1, 'Heu qu''est ce que tu fous la toi!', 2),
(2, 'Informatique', 47),
(3, 'Divers', 47),
(4, 'Geek', 47),
(5, 'Tunning', 7),
(6, 'News', 1),
(7, 'Sports', 2)
go

SET IDENTITY_INSERT "CATEGORY" OFF
go	

/*SET IDENTITY_INSERT "RSSCHANNEL" ON
go
insert into RSSCHANNEL (IDRSSCHANNEL, TITLE, URLLINK, "DESCRIPTION") values (1, 'L''Equipe.fr Actu Tennis', 'http://www.lequipe.fr', 'L''Equipe.fr, Toute l''actualité du tennis')
go
SET IDENTITY_INSERT "RSSCHANNEL" OFF
go
*/


/*
 -----------------------------------------------------------------------------
               END OF SCRIPT
 -----------------------------------------------------------------------------
*/

