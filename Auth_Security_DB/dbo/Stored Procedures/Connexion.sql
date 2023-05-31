CREATE PROCEDURE Connexion
    @mail NVARCHAR(250), 
    @passwd NVARCHAR(20)
AS
BEGIN
    DECLARE @Pepper NVARCHAR(128) = '%0Pepper0%'

    SELECT Id, Nom, Prenom, @mail AS mail FROM Utilisateur
    WHERE mail = @mail AND Passwd = HASHBYTES('SHA2_512', salt + @passwd + @Pepper);
END
