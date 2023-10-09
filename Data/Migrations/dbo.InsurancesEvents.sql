CREATE TABLE [dbo].[InsurancesEvents] (
    [Id]                INT  IDENTITY (1, 1) NOT NULL,
    [ContractNumber]    INT  NOT NULL,
    [EventNumber]       INT  NOT NULL,
    [DamageAmount]      INT  NOT NULL,
    [DamageDescription] TEXT NOT NULL,
    CONSTRAINT [PK_InsurancesEvents] PRIMARY KEY CLUSTERED ([Id] ASC)
);

