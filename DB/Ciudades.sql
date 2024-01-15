-- Creación de la tabla de ciudades con ID de tipo VARCHAR(2)
CREATE TABLE Ciudades (
    ID VARCHAR(2) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

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



select *  from Ciudades
