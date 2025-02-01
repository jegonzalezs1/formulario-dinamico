-- Crear la base de datos
CREATE DATABASE navegacion_dinamica
ON 
(
    NAME = navegacion_dinamica_dat,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\navegacion_dinamica.mdf',
    SIZE = 500MB,
    FILEGROWTH = 30%
)
LOG ON 
(
    NAME = navegacion_dinamica_log,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\navegacion_dinamica.ldf',
    SIZE = 250MB,
    FILEGROWTH = 15%
);
GO

-- Usar la base de datos creada
USE navegacion_dinamica;
GO

-- Crear la tabla Formulario
CREATE TABLE Formulario (
    IdFormulario INT NOT NULL IDENTITY(1,1),
    NombreFormulario VARCHAR(100) NOT NULL
	PRIMARY KEY(IdFormulario)
);
GO

-- Crear la tabla Campo
CREATE TABLE Campo (
    IdCampo INT NOT NULL IDENTITY(1,1),
    NombreCampo VARCHAR(100) NOT NULL,
    TipoCampo VARCHAR(100) NOT NULL,
	IdFormulario INT NOT NULL
	PRIMARY KEY(IdCampo)
	CONSTRAINT FK_Campo_Formulario FOREIGN KEY (IdFormulario) REFERENCES Formulario(IdFormulario) ON DELETE CASCADE
);
GO

CREATE PROC sp_crud_formulario
    @accion CHAR(1),
    @id_form INT = NULL,
    @nomb_form VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF @accion = 'I' -- Insertar
        BEGIN
            INSERT INTO Formulario (NombreFormulario) VALUES (@nomb_form);
        END
        ELSE IF @accion = 'U' -- Actualizar
        BEGIN
            UPDATE Formulario SET NombreFormulario = @nomb_form WHERE IdFormulario = @id_form;
        END
        ELSE IF @accion = 'D' -- Eliminar
        BEGIN
            DELETE FROM Formulario WHERE IdFormulario = @id_form;
        END
        ELSE IF @accion = 'C' -- Consultar por ID
        BEGIN
            SELECT * FROM Formulario WHERE IdFormulario = @id_form;
        END
        ELSE IF @accion = 'G' -- Obtener Todos
        BEGIN
            SELECT * FROM Formulario;
        END
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO

CREATE PROC sp_crud_campo
    @accion CHAR(1),
    @id_campo INT = NULL,
    @nomb_campo VARCHAR(100) = NULL,
	@tipo_campo VARCHAR(100) = NULL,
    @id_form INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        IF @accion = 'I' -- Insertar
        BEGIN
            INSERT INTO Campo (NombreCampo, TipoCampo, IdFormulario) VALUES (@nomb_campo, @tipo_campo, @id_form);
        END
        ELSE IF @accion = 'U' -- Actualizar
        BEGIN
            UPDATE Campo SET NombreCampo = @nomb_campo, TipoCampo = @tipo_campo, IdFormulario = @id_form WHERE IdCampo = @id_campo;
        END
        ELSE IF @accion = 'D' -- Eliminar
        BEGIN
            DELETE FROM Campo WHERE IdCampo = @id_campo
        END
        ELSE IF @accion = 'C' -- Consultar por ID
        BEGIN
            SELECT f.IdFormulario, f.NombreFormulario, c.IdCampo, c.NombreCampo, c.TipoCampo FROM Formulario f
            INNER JOIN Campo c ON f.IdFormulario = c.IdFormulario 
			WHERE c.IdCampo = @id_campo
        END
        ELSE IF @accion = 'G' -- Obtener Todos
        BEGIN
            SELECT f.IdFormulario, f.NombreFormulario, c.IdCampo, c.NombreCampo, c.TipoCampo FROM Formulario f
            INNER JOIN Campo c ON f.IdFormulario = c.IdFormulario;
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO