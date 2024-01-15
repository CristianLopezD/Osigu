-- Creación de la tabla de aerolíneas
CREATE TABLE Aerolineas (
    ID CHAR(3) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Creación de la tabla de estados
CREATE TABLE Estados (
    ID CHAR(1) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Creación de la tabla de ciudades
CREATE TABLE Ciudades (
    ID VARCHAR(2) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Creación de la tabla de usuarios
CREATE TABLE [User] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL
);

-- Creación de la tabla de vuelos
CREATE TABLE Vuelos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CiudadOrigen VARCHAR(2) REFERENCES Ciudades(ID),
    CiudadDestino VARCHAR(2) REFERENCES Ciudades(ID),
    Fecha DATE,
    HoraSalida TIME,
    HoraLlegada TIME,
    NumeroVuelo NVARCHAR(4) UNIQUE,
    Aerolinea CHAR(3) REFERENCES Aerolineas(ID),
    EstadoVuelo CHAR(1) REFERENCES Estados(ID)
);

-- Creating a view
CREATE or ALTER VIEW v_Vuelos 
AS
	SELECT	CiuOrg.Nombre		AS CiudadOrigen,
			CiuDest.Nombre		AS CiudadDestino,
			Vuelos.Fecha,
			Vuelos.HoraSalida,
			Vuelos.HoraLlegada,
			Vuelos.NumeroVuelo,
			Aerolineas.Nombre	AS Aerolinea,
			Estados.Nombre		AS EstadoVuelo
	FROM	Vuelos 
	JOIN	Ciudades CiuOrg  ON Vuelos.CiudadOrigen  = CiuOrg.ID
	JOIN	Ciudades CiuDest ON Vuelos.CiudadDestino = CiuDest.ID
	JOIN	Aerolineas		 ON Vuelos.Aerolinea	 = Aerolineas.ID
	JOIN	Estados			 ON Vuelos.EstadoVuelo	 = Estados.ID;




