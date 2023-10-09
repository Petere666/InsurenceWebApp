CREATE TABLE [dbo].[Insurances] (
    [Id]             INT   IDENTITY (1, 1) NOT NULL,
    [ContractNumber] INT   NOT NULL,
    [MonthPayment]   MONEY NOT NULL,
    [Principal]      MONEY NOT NULL,
    [Validity]       DATE  NOT NULL,
    CONSTRAINT [PK_Insurances] PRIMARY KEY CLUSTERED ([Id] ASC)
);

