--begin tran 
--EXEC sp_InsertVuelo 'NY', 'LN', '2024-01-11', '08:00', '12:00', 'V999', 'AA', 'P';
--rollback

CREATE OR ALTER PROCEDURE sp_InsertVuelo
    @CiudadOrigen VARCHAR(2),
    @CiudadDestino VARCHAR(2),
    @Fecha DATE,
    @HoraSalida TIME,
    @HoraLlegada TIME,
    @NumeroVuelo NVARCHAR(4),
    @Aerolinea CHAR(3),
    @EstadoVuelo CHAR(1)
AS
BEGIN
    BEGIN TRY
        -- Check if CiudadOrigen and CiudadDestino exist in Ciudades table
        IF NOT EXISTS (SELECT 1 FROM Ciudades WHERE ID IN (@CiudadOrigen, @CiudadDestino))
        BEGIN
            THROW 50000, 'CiudadOrigen o CiudadDestino Incorrectas.', 1;
        END

        -- Check if Aerolinea exists in Aerolineas table
        IF NOT EXISTS (SELECT 1 FROM Aerolineas WHERE ID = @Aerolinea)
        BEGIN
            THROW 50000, 'Aerolinea Incorrecta.', 1;
        END

        -- Check if EstadoVuelo exists in Estados table
        IF NOT EXISTS (SELECT 1 FROM Estados WHERE ID = @EstadoVuelo)
        BEGIN
            THROW 50000, 'EstadoVuelo Incorrectas.', 1;
        END

        -- Check if the NumeroVuelo is unique
        IF EXISTS (SELECT 1 FROM Vuelos WHERE NumeroVuelo = @NumeroVuelo)
        BEGIN
            THROW 50000, 'NumeroVuelo Debe ser Unico.', 1;
        END

        -- Insert the new record into Vuelos table
        INSERT INTO Vuelos (CiudadOrigen, CiudadDestino, Fecha, HoraSalida, HoraLlegada, NumeroVuelo, Aerolinea, EstadoVuelo)
        VALUES (@CiudadOrigen, @CiudadDestino, @Fecha, @HoraSalida, @HoraLlegada, @NumeroVuelo, @Aerolinea, @EstadoVuelo);

        PRINT '';
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		DECLARE @DetailedErrorMessage NVARCHAR(4000);

		SET @DetailedErrorMessage = 'ERROR Creando registro. Validar la información e intentar de nuevo.' +
			CHAR(13) + CHAR(10) + 'Mensaje de error original: ' + @ErrorMessage;

		THROW 50000, @DetailedErrorMessage, 1;
    END CATCH
END;
