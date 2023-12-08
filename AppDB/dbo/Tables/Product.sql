CREATE TABLE [dbo].[Product] (
    [Id]          BIGINT         NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Description] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);

