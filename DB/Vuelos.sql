-- Creación de la tabla
CREATE TABLE Vuelos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CiudadOrigen	INT,
    CiudadDestino	NVARCHAR(50),
    Fecha			DATE,
    HoraSalida		TIME,
    HoraLlegada		TIME,
    NumeroVuelo		NVARCHAR(4) UNIQUE,
    Aerolinea		NVARCHAR(2),
    EstadoVuelo		NVARCHAR(1)
);

-- Inserción de 10 registros de ejemplo
INSERT INTO Vuelos (CiudadOrigen, CiudadDestino, Fecha, HoraSalida, HoraLlegada, NumeroVuelo, Aerolinea, EstadoVuelo)
VALUES
(1,  2,  '2024-01-01', '08:00', '12:00', 'V123', 'AA', 'P'),
(2,  3,  '2024-01-02', '10:30', '14:30', 'V456', 'DL', 'V'),
(3,  4,  '2024-01-03', '12:45', '16:45', 'V789', 'UA', 'F'),
(4,  5,  '2024-01-04', '15:15', '19:15', 'V101', 'BA', 'P'),
(5,  6,  '2024-01-05', '18:00', '22:00', 'V202', 'LH', 'C'),
(6,  7,  '2024-01-06', '20:30', '00:30', 'V303', 'AA', 'V'),
(7,  8,  '2024-01-07', '22:45', '02:45', 'V404', 'DL', 'F'),
(8,  9,  '2024-01-08', '01:10', '05:10', 'V505', 'UA', 'P'),
(9,  10, '2024-01-09', '03:30', '07:30', 'V606', 'BA', 'V'),
(10, 1,  '2024-01-10', '06:15', '10:15', 'V707', 'LH', 'F');
