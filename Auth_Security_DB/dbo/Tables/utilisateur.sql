CREATE TABLE [dbo].[utilisateur] (
    [id]     INT            IDENTITY (1, 1) NOT NULL,
    [mail]   NVARCHAR (250) NOT NULL,
    [nom]    NVARCHAR (250) NOT NULL,
    [prenom] NVARCHAR (250) NOT NULL,
    [passwd] VARBINARY (64) NOT NULL,
    [salt]   NVARCHAR (8)   NOT NULL,
    UNIQUE NONCLUSTERED ([mail] ASC)
);

