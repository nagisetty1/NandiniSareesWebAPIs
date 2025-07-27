CREATE TABLE [dbo].[Sarees] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NULL,
    [Description] NVARCHAR (MAX)  NULL,
    [ImageUrl]    NVARCHAR (MAX)  NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Category]    NVARCHAR (MAX)  NULL,
    [CreatedAt]   DATETIME2 (7)   NOT NULL,
    [UpdatedAt]   DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_Sarees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

