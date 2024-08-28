CREATE DATABASE [TestAlicundeDB]
GO

USE [TestAlicundeDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BalanceResponsibleParties](
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Country] [varchar](2) NOT NULL,
	[BusinessId] [varchar](20) NOT NULL,
	[CodingScheme] [varchar](3) NOT NULL,
	[ValidityStart] [datetime] NOT NULL,
	[ValidityEnd] [datetime] NOT NULL,
 CONSTRAINT [PK_BalanceResponsibleParties] PRIMARY KEY CLUSTERED 
(
	[Code] ASC,
	[Country] ASC
))
GO