
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2020 15:10:11
-- Generated from EDMX file: C:\Users\jovan\Desktop\IzdavackaKuca\IzdavackaKuca\ModelIzdavackaKuca.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IzdavackaKuca];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_IzdajeNagrada_Izdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IzdajeNagrada] DROP CONSTRAINT [FK_IzdajeNagrada_Izdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_IzdajeNagrada_Nagrada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IzdajeNagrada] DROP CONSTRAINT [FK_IzdajeNagrada_Nagrada];
GO
IF OBJECT_ID(N'[dbo].[FK_KnjigaIzdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdajes] DROP CONSTRAINT [FK_KnjigaIzdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_KnjigaKategorija_Kategorija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KnjigaKategorija] DROP CONSTRAINT [FK_KnjigaKategorija_Kategorija];
GO
IF OBJECT_ID(N'[dbo].[FK_KnjigaKategorija_Knjiga]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KnjigaKategorija] DROP CONSTRAINT [FK_KnjigaKategorija_Knjiga];
GO
IF OBJECT_ID(N'[dbo].[FK_KnjigaRecenzija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recenzijas] DROP CONSTRAINT [FK_KnjigaRecenzija];
GO
IF OBJECT_ID(N'[dbo].[FK_KnjizaraIzdaje_Izdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KnjizaraIzdaje] DROP CONSTRAINT [FK_KnjizaraIzdaje_Izdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_KnjizaraIzdaje_Knjizara]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KnjizaraIzdaje] DROP CONSTRAINT [FK_KnjizaraIzdaje_Knjizara];
GO
IF OBJECT_ID(N'[dbo].[FK_KriticarRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kriticars] DROP CONSTRAINT [FK_KriticarRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_KriticarRecenzija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recenzijas] DROP CONSTRAINT [FK_KriticarRecenzija];
GO
IF OBJECT_ID(N'[dbo].[FK_OdeljenjeIzdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdajes] DROP CONSTRAINT [FK_OdeljenjeIzdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_OdeljenjeRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks] DROP CONSTRAINT [FK_OdeljenjeRadnik];
GO
IF OBJECT_ID(N'[dbo].[FK_PisacDogadjaj_Dogadjaj]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PisacDogadjaj] DROP CONSTRAINT [FK_PisacDogadjaj_Dogadjaj];
GO
IF OBJECT_ID(N'[dbo].[FK_PisacDogadjaj_Pisac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PisacDogadjaj] DROP CONSTRAINT [FK_PisacDogadjaj_Pisac];
GO
IF OBJECT_ID(N'[dbo].[FK_PisacKnjiga_Knjiga]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PisacKnjiga] DROP CONSTRAINT [FK_PisacKnjiga_Knjiga];
GO
IF OBJECT_ID(N'[dbo].[FK_PisacKnjiga_Pisac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PisacKnjiga] DROP CONSTRAINT [FK_PisacKnjiga_Pisac];
GO
IF OBJECT_ID(N'[dbo].[FK_PisacRadnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pisacs] DROP CONSTRAINT [FK_PisacRadnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dogadjajs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dogadjajs];
GO
IF OBJECT_ID(N'[dbo].[IzdajeNagrada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IzdajeNagrada];
GO
IF OBJECT_ID(N'[dbo].[Izdajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Izdajes];
GO
IF OBJECT_ID(N'[dbo].[Kategorijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategorijas];
GO
IF OBJECT_ID(N'[dbo].[KnjigaKategorija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KnjigaKategorija];
GO
IF OBJECT_ID(N'[dbo].[Knjigas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Knjigas];
GO
IF OBJECT_ID(N'[dbo].[KnjizaraIzdaje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KnjizaraIzdaje];
GO
IF OBJECT_ID(N'[dbo].[Knjizaras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Knjizaras];
GO
IF OBJECT_ID(N'[dbo].[Kriticars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kriticars];
GO
IF OBJECT_ID(N'[dbo].[Nagradas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nagradas];
GO
IF OBJECT_ID(N'[dbo].[Odeljenjes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odeljenjes];
GO
IF OBJECT_ID(N'[dbo].[PisacDogadjaj]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PisacDogadjaj];
GO
IF OBJECT_ID(N'[dbo].[PisacKnjiga]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PisacKnjiga];
GO
IF OBJECT_ID(N'[dbo].[Pisacs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pisacs];
GO
IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[Recenzijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recenzijas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Odeljenjes'
CREATE TABLE [dbo].[Odeljenjes] (
    [OdeljenjeId] int  NOT NULL,
    [ImeOsnivaca] nvarchar(max)  NOT NULL,
    [PrezimeOsnivaca] nvarchar(max)  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Mesto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Broj] int  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [Pib] nvarchar(max)  NOT NULL,
    [DatumOsnivanja] datetime  NOT NULL
);
GO

-- Creating table 'Dogadjajs'
CREATE TABLE [dbo].[Dogadjajs] (
    [DogadjajId] int  NOT NULL,
    [Mesto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Broj] int  NOT NULL,
    [BrojMesta] int  NOT NULL,
    [Tip] nvarchar(max)  NOT NULL,
    [Posveceno] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Nagradas'
CREATE TABLE [dbo].[Nagradas] (
    [NagradaId] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [NovcanaNagrada] int  NOT NULL,
    [Drzavna] bit  NOT NULL
);
GO

-- Creating table 'Recenzijas'
CREATE TABLE [dbo].[Recenzijas] (
    [RecenzijaId] int  NOT NULL,
    [Ocena] int  NOT NULL,
    [BrojStrana] int  NOT NULL,
    [KnjigaKnjigaId] int  NOT NULL,
    [Kriticar_Jmbg] bigint  NOT NULL
);
GO

-- Creating table 'Knjigas'
CREATE TABLE [dbo].[Knjigas] (
    [KnjigaId] int  NOT NULL,
    [BrojPoglavlja] int  NOT NULL,
    [BrojStrana] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Kategorijas'
CREATE TABLE [dbo].[Kategorijas] (
    [KategorijaId] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [KnjizevniRod] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Knjizaras'
CREATE TABLE [dbo].[Knjizaras] (
    [KnjizaraId] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Mesto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Broj] int  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [Pib] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [Jmbg] bigint  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Plata] int  NOT NULL,
    [Mesto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Broj] int  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [OdeljenjeOdeljenjeId] int  NOT NULL
);
GO

-- Creating table 'Izdajes'
CREATE TABLE [dbo].[Izdajes] (
    [KnjigaKnjigaId] int  NOT NULL,
    [OdeljenjeOdeljenjeId] int  NOT NULL,
    [Knjiga_KnjigaId] int  NOT NULL
);
GO

-- Creating table 'Pisacs'
CREATE TABLE [dbo].[Pisacs] (
    [Jmbg] bigint  NOT NULL
);
GO

-- Creating table 'Kriticars'
CREATE TABLE [dbo].[Kriticars] (
    [Jmbg] bigint  NOT NULL
);
GO

-- Creating table 'Korisniks'
CREATE TABLE [dbo].[Korisniks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KnjigaKategorija'
CREATE TABLE [dbo].[KnjigaKategorija] (
    [Knjigas_KnjigaId] int  NOT NULL,
    [Kategorijas_KategorijaId] int  NOT NULL
);
GO

-- Creating table 'IzdajeNagrada'
CREATE TABLE [dbo].[IzdajeNagrada] (
    [Izdajes_KnjigaKnjigaId] int  NOT NULL,
    [Izdajes_OdeljenjeOdeljenjeId] int  NOT NULL,
    [Nagradas_NagradaId] int  NOT NULL
);
GO

-- Creating table 'KnjizaraIzdaje'
CREATE TABLE [dbo].[KnjizaraIzdaje] (
    [Knjizaras_KnjizaraId] int  NOT NULL,
    [Izdajes_KnjigaKnjigaId] int  NOT NULL,
    [Izdajes_OdeljenjeOdeljenjeId] int  NOT NULL
);
GO

-- Creating table 'PisacKnjiga'
CREATE TABLE [dbo].[PisacKnjiga] (
    [Pisacs_Jmbg] bigint  NOT NULL,
    [Knjigas_KnjigaId] int  NOT NULL
);
GO

-- Creating table 'PisacDogadjaj'
CREATE TABLE [dbo].[PisacDogadjaj] (
    [Pisacs_Jmbg] bigint  NOT NULL,
    [Dogadjajs_DogadjajId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OdeljenjeId] in table 'Odeljenjes'
ALTER TABLE [dbo].[Odeljenjes]
ADD CONSTRAINT [PK_Odeljenjes]
    PRIMARY KEY CLUSTERED ([OdeljenjeId] ASC);
GO

-- Creating primary key on [DogadjajId] in table 'Dogadjajs'
ALTER TABLE [dbo].[Dogadjajs]
ADD CONSTRAINT [PK_Dogadjajs]
    PRIMARY KEY CLUSTERED ([DogadjajId] ASC);
GO

-- Creating primary key on [NagradaId] in table 'Nagradas'
ALTER TABLE [dbo].[Nagradas]
ADD CONSTRAINT [PK_Nagradas]
    PRIMARY KEY CLUSTERED ([NagradaId] ASC);
GO

-- Creating primary key on [RecenzijaId] in table 'Recenzijas'
ALTER TABLE [dbo].[Recenzijas]
ADD CONSTRAINT [PK_Recenzijas]
    PRIMARY KEY CLUSTERED ([RecenzijaId] ASC);
GO

-- Creating primary key on [KnjigaId] in table 'Knjigas'
ALTER TABLE [dbo].[Knjigas]
ADD CONSTRAINT [PK_Knjigas]
    PRIMARY KEY CLUSTERED ([KnjigaId] ASC);
GO

-- Creating primary key on [KategorijaId] in table 'Kategorijas'
ALTER TABLE [dbo].[Kategorijas]
ADD CONSTRAINT [PK_Kategorijas]
    PRIMARY KEY CLUSTERED ([KategorijaId] ASC);
GO

-- Creating primary key on [KnjizaraId] in table 'Knjizaras'
ALTER TABLE [dbo].[Knjizaras]
ADD CONSTRAINT [PK_Knjizaras]
    PRIMARY KEY CLUSTERED ([KnjizaraId] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [KnjigaKnjigaId], [OdeljenjeOdeljenjeId] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [PK_Izdajes]
    PRIMARY KEY CLUSTERED ([KnjigaKnjigaId], [OdeljenjeOdeljenjeId] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Pisacs'
ALTER TABLE [dbo].[Pisacs]
ADD CONSTRAINT [PK_Pisacs]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Kriticars'
ALTER TABLE [dbo].[Kriticars]
ADD CONSTRAINT [PK_Kriticars]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Id] in table 'Korisniks'
ALTER TABLE [dbo].[Korisniks]
ADD CONSTRAINT [PK_Korisniks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Knjigas_KnjigaId], [Kategorijas_KategorijaId] in table 'KnjigaKategorija'
ALTER TABLE [dbo].[KnjigaKategorija]
ADD CONSTRAINT [PK_KnjigaKategorija]
    PRIMARY KEY CLUSTERED ([Knjigas_KnjigaId], [Kategorijas_KategorijaId] ASC);
GO

-- Creating primary key on [Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId], [Nagradas_NagradaId] in table 'IzdajeNagrada'
ALTER TABLE [dbo].[IzdajeNagrada]
ADD CONSTRAINT [PK_IzdajeNagrada]
    PRIMARY KEY CLUSTERED ([Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId], [Nagradas_NagradaId] ASC);
GO

-- Creating primary key on [Knjizaras_KnjizaraId], [Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId] in table 'KnjizaraIzdaje'
ALTER TABLE [dbo].[KnjizaraIzdaje]
ADD CONSTRAINT [PK_KnjizaraIzdaje]
    PRIMARY KEY CLUSTERED ([Knjizaras_KnjizaraId], [Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId] ASC);
GO

-- Creating primary key on [Pisacs_Jmbg], [Knjigas_KnjigaId] in table 'PisacKnjiga'
ALTER TABLE [dbo].[PisacKnjiga]
ADD CONSTRAINT [PK_PisacKnjiga]
    PRIMARY KEY CLUSTERED ([Pisacs_Jmbg], [Knjigas_KnjigaId] ASC);
GO

-- Creating primary key on [Pisacs_Jmbg], [Dogadjajs_DogadjajId] in table 'PisacDogadjaj'
ALTER TABLE [dbo].[PisacDogadjaj]
ADD CONSTRAINT [PK_PisacDogadjaj]
    PRIMARY KEY CLUSTERED ([Pisacs_Jmbg], [Dogadjajs_DogadjajId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Knjigas_KnjigaId] in table 'KnjigaKategorija'
ALTER TABLE [dbo].[KnjigaKategorija]
ADD CONSTRAINT [FK_KnjigaKategorija_Knjiga]
    FOREIGN KEY ([Knjigas_KnjigaId])
    REFERENCES [dbo].[Knjigas]
        ([KnjigaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Kategorijas_KategorijaId] in table 'KnjigaKategorija'
ALTER TABLE [dbo].[KnjigaKategorija]
ADD CONSTRAINT [FK_KnjigaKategorija_Kategorija]
    FOREIGN KEY ([Kategorijas_KategorijaId])
    REFERENCES [dbo].[Kategorijas]
        ([KategorijaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnjigaKategorija_Kategorija'
CREATE INDEX [IX_FK_KnjigaKategorija_Kategorija]
ON [dbo].[KnjigaKategorija]
    ([Kategorijas_KategorijaId]);
GO

-- Creating foreign key on [OdeljenjeOdeljenjeId] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [FK_OdeljenjeRadnik]
    FOREIGN KEY ([OdeljenjeOdeljenjeId])
    REFERENCES [dbo].[Odeljenjes]
        ([OdeljenjeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OdeljenjeRadnik'
CREATE INDEX [IX_FK_OdeljenjeRadnik]
ON [dbo].[Radniks]
    ([OdeljenjeOdeljenjeId]);
GO

-- Creating foreign key on [KnjigaKnjigaId] in table 'Recenzijas'
ALTER TABLE [dbo].[Recenzijas]
ADD CONSTRAINT [FK_KnjigaRecenzija]
    FOREIGN KEY ([KnjigaKnjigaId])
    REFERENCES [dbo].[Knjigas]
        ([KnjigaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnjigaRecenzija'
CREATE INDEX [IX_FK_KnjigaRecenzija]
ON [dbo].[Recenzijas]
    ([KnjigaKnjigaId]);
GO

-- Creating foreign key on [OdeljenjeOdeljenjeId] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_OdeljenjeIzdaje]
    FOREIGN KEY ([OdeljenjeOdeljenjeId])
    REFERENCES [dbo].[Odeljenjes]
        ([OdeljenjeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OdeljenjeIzdaje'
CREATE INDEX [IX_FK_OdeljenjeIzdaje]
ON [dbo].[Izdajes]
    ([OdeljenjeOdeljenjeId]);
GO

-- Creating foreign key on [Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId] in table 'IzdajeNagrada'
ALTER TABLE [dbo].[IzdajeNagrada]
ADD CONSTRAINT [FK_IzdajeNagrada_Izdaje]
    FOREIGN KEY ([Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId])
    REFERENCES [dbo].[Izdajes]
        ([KnjigaKnjigaId], [OdeljenjeOdeljenjeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Nagradas_NagradaId] in table 'IzdajeNagrada'
ALTER TABLE [dbo].[IzdajeNagrada]
ADD CONSTRAINT [FK_IzdajeNagrada_Nagrada]
    FOREIGN KEY ([Nagradas_NagradaId])
    REFERENCES [dbo].[Nagradas]
        ([NagradaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IzdajeNagrada_Nagrada'
CREATE INDEX [IX_FK_IzdajeNagrada_Nagrada]
ON [dbo].[IzdajeNagrada]
    ([Nagradas_NagradaId]);
GO

-- Creating foreign key on [Knjizaras_KnjizaraId] in table 'KnjizaraIzdaje'
ALTER TABLE [dbo].[KnjizaraIzdaje]
ADD CONSTRAINT [FK_KnjizaraIzdaje_Knjizara]
    FOREIGN KEY ([Knjizaras_KnjizaraId])
    REFERENCES [dbo].[Knjizaras]
        ([KnjizaraId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId] in table 'KnjizaraIzdaje'
ALTER TABLE [dbo].[KnjizaraIzdaje]
ADD CONSTRAINT [FK_KnjizaraIzdaje_Izdaje]
    FOREIGN KEY ([Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId])
    REFERENCES [dbo].[Izdajes]
        ([KnjigaKnjigaId], [OdeljenjeOdeljenjeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnjizaraIzdaje_Izdaje'
CREATE INDEX [IX_FK_KnjizaraIzdaje_Izdaje]
ON [dbo].[KnjizaraIzdaje]
    ([Izdajes_KnjigaKnjigaId], [Izdajes_OdeljenjeOdeljenjeId]);
GO

-- Creating foreign key on [Jmbg] in table 'Pisacs'
ALTER TABLE [dbo].[Pisacs]
ADD CONSTRAINT [FK_PisacRadnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Radniks]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pisacs_Jmbg] in table 'PisacKnjiga'
ALTER TABLE [dbo].[PisacKnjiga]
ADD CONSTRAINT [FK_PisacKnjiga_Pisac]
    FOREIGN KEY ([Pisacs_Jmbg])
    REFERENCES [dbo].[Pisacs]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Knjigas_KnjigaId] in table 'PisacKnjiga'
ALTER TABLE [dbo].[PisacKnjiga]
ADD CONSTRAINT [FK_PisacKnjiga_Knjiga]
    FOREIGN KEY ([Knjigas_KnjigaId])
    REFERENCES [dbo].[Knjigas]
        ([KnjigaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PisacKnjiga_Knjiga'
CREATE INDEX [IX_FK_PisacKnjiga_Knjiga]
ON [dbo].[PisacKnjiga]
    ([Knjigas_KnjigaId]);
GO

-- Creating foreign key on [Knjiga_KnjigaId] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_KnjigaIzdaje]
    FOREIGN KEY ([Knjiga_KnjigaId])
    REFERENCES [dbo].[Knjigas]
        ([KnjigaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnjigaIzdaje'
CREATE INDEX [IX_FK_KnjigaIzdaje]
ON [dbo].[Izdajes]
    ([Knjiga_KnjigaId]);
GO

-- Creating foreign key on [Jmbg] in table 'Kriticars'
ALTER TABLE [dbo].[Kriticars]
ADD CONSTRAINT [FK_KriticarRadnik]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Radniks]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pisacs_Jmbg] in table 'PisacDogadjaj'
ALTER TABLE [dbo].[PisacDogadjaj]
ADD CONSTRAINT [FK_PisacDogadjaj_Pisac]
    FOREIGN KEY ([Pisacs_Jmbg])
    REFERENCES [dbo].[Pisacs]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dogadjajs_DogadjajId] in table 'PisacDogadjaj'
ALTER TABLE [dbo].[PisacDogadjaj]
ADD CONSTRAINT [FK_PisacDogadjaj_Dogadjaj]
    FOREIGN KEY ([Dogadjajs_DogadjajId])
    REFERENCES [dbo].[Dogadjajs]
        ([DogadjajId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PisacDogadjaj_Dogadjaj'
CREATE INDEX [IX_FK_PisacDogadjaj_Dogadjaj]
ON [dbo].[PisacDogadjaj]
    ([Dogadjajs_DogadjajId]);
GO

-- Creating foreign key on [Kriticar_Jmbg] in table 'Recenzijas'
ALTER TABLE [dbo].[Recenzijas]
ADD CONSTRAINT [FK_KriticarRecenzija]
    FOREIGN KEY ([Kriticar_Jmbg])
    REFERENCES [dbo].[Kriticars]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KriticarRecenzija'
CREATE INDEX [IX_FK_KriticarRecenzija]
ON [dbo].[Recenzijas]
    ([Kriticar_Jmbg]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------