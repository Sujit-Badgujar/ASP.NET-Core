CREATE PROCEDURE ManageUsers
    @Flag CHAR(1),
    @UserId INT = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @Email NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Flag = 'i'
    BEGIN
        INSERT INTO Users (FirstName, LastName, Email)
        VALUES (@FirstName, @LastName, @Email);
    END
    ELSE IF @Flag = 'u'
    BEGIN
        UPDATE Users
        SET FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email
        WHERE UserId = @UserId;
    END
    ELSE IF @Flag = 'd'
    BEGIN
        DELETE FROM Users
        WHERE UserId = @UserId;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Flag!', 16, 1);
    END
END;
