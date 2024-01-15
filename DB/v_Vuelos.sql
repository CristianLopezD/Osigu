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

