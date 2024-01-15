INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('AA', 'American Airlines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('DL', 'Delta Air Lines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('UA', 'United Airlines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('BA', 'British Airways');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('LH', 'Lufthansa');

-- Inserción de los cuatro estados
INSERT INTO Estados (Codigo, Nombre) VALUES ('P', 'Programado');
INSERT INTO Estados (Codigo, Nombre) VALUES ('V', 'En Vuelo');
INSERT INTO Estados (Codigo, Nombre) VALUES ('F', 'Finalizado');
INSERT INTO Estados (Codigo, Nombre) VALUES ('C', 'Cancelado');


-- Inserción de 10 registros de ciudades reales
INSERT INTO Ciudades (ID, Nombre) VALUES ('NY', 'Nueva York');
INSERT INTO Ciudades (ID, Nombre) VALUES ('LN', 'Londres');
INSERT INTO Ciudades (ID, Nombre) VALUES ('TK', 'Tokio');
INSERT INTO Ciudades (ID, Nombre) VALUES ('PR', 'París');
INSERT INTO Ciudades (ID, Nombre) VALUES ('SD', 'Sídney');
INSERT INTO Ciudades (ID, Nombre) VALUES ('RM', 'Roma');
INSERT INTO Ciudades (ID, Nombre) VALUES ('MC', 'Moscú');
INSERT INTO Ciudades (ID, Nombre) VALUES ('PK', 'Pekín');
INSERT INTO Ciudades (ID, Nombre) VALUES ('RJ', 'Río de Janeiro');
INSERT INTO Ciudades (ID, Nombre) VALUES ('BO', 'Bogotá');


INSERT INTO Vuelos (CiudadOrigen, CiudadDestino, Fecha, HoraSalida, HoraLlegada, NumeroVuelo, Aerolinea, EstadoVuelo)
VALUES
('NY', 'LN', '2024-01-01', '08:00', '12:00', 'V123', 'AA', 'P'),
('LN', 'TK', '2024-01-02', '10:30', '14:30', 'V456', 'DL', 'V'),
('TK', 'PR', '2024-01-03', '12:45', '16:45', 'V789', 'UA', 'F'),
('PR', 'SD', '2024-01-04', '15:15', '19:15', 'V101', 'BA', 'P'),
('SD', 'RM', '2024-01-05', '18:00', '22:00', 'V202', 'LH', 'C'),
('RM', 'MC', '2024-01-06', '20:30', '00:30', 'V303', 'AA', 'V'),
('MC', 'PK', '2024-01-07', '22:45', '02:45', 'V404', 'DL', 'F'),
('PK', 'RJ', '2024-01-08', '01:10', '05:10', 'V505', 'UA', 'P'),
('RJ', 'BO', '2024-01-09', '03:30', '07:30', 'V606', 'BA', 'V'),
('BO', 'NY', '2024-01-10', '06:15', '10:15', 'V707', 'LH', 'F');



insert into [User] values (NEWID(), 'admin',	'admin123',	'adminUser',      'admin@admin.com')
insert into [User] values (NEWID(), 'Cristian',	'123123',	'Cristian Lopez', 'Cristian.l@gmail.com')
insert into [User] values (NEWID(), 'Camilo',	'asdfg',	'Camilo Diaz',	  'Camilo.d@gmail.com')


