
CREATE PROCEDURE NewUser
    @mail NVARCHAR(250),
    @nom NVARCHAR(250),
    @prenom NVARCHAR(250),
    @passwd NVARCHAR(250)
AS
BEGIN
    DECLARE @salt NVARCHAR(8)
	DECLARE @Pepper NVARCHAR(128)='%0Pepper0%'


    SET @salt = CHAR(65 + FLOOR(RAND() * 26))
    SET @salt = @salt + CHAR(65 + FLOOR(RAND() * 26))
    SET @salt = @salt + CHAR(65 + FLOOR(RAND() * 26))
    SET @salt = @salt + CHAR(65 + FLOOR(RAND() * 26))
    SET @salt = @salt + CHAR(65 + FLOOR(RAND() * 26))

    SET @salt = @salt + CAST(FLOOR(RAND() * 10) AS VARCHAR(1))
    SET @salt = @salt + CAST(FLOOR(RAND() * 10) AS VARCHAR(1))
    SET @salt = @salt + CAST(FLOOR(RAND() * 10) AS VARCHAR(1))

    DECLARE @hashedPasswd BINARY(64)
    SET @hashedPasswd = HASHBYTES('SHA2_512', @salt+@passwd+@Pepper)

    INSERT INTO utilisateur (mail, nom, prenom, passwd, salt)
    VALUES (@mail, @nom, @prenom, @hashedPasswd, @salt)
END
