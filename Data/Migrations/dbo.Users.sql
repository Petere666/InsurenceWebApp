CREATE TABLE [dbo].[Users] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR(50)  NOT NULL,
    [SurName]         NVARCHAR(50)  NOT NULL,
    [BirthDate]       DATE          NOT NULL,
    [Age]             TINYINT       NOT NULL,
    [City]            NVARCHAR(50)  NOT NULL,
    [Street]          NVARCHAR(50)  NOT NULL,
    [ReferenceNumber] NVARCHAR (50) NOT NULL,
    [TelephoneNumber] NVARCHAR (15) NOT NULL,
    [Email]           NVARCHAR(50)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

