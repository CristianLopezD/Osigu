-- Creaci�n de la tabla de ciudades con ID de tipo VARCHAR(2)
CREATE TABLE Ciudades (
    ID VARCHAR(2) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Inserci�n de 10 registros de ciudades reales
INSERT INTO Ciudades (ID, Nombre) VALUES ('NY', 'Nueva York');
INSERT INTO Ciudades (ID, Nombre) VALUES ('LN', 'Londres');
INSERT INTO Ciudades (ID, Nombre) VALUES ('TK', 'Tokio');
INSERT INTO Ciudades (ID, Nombre) VALUES ('PR', 'Par�s');
INSERT INTO Ciudades (ID, Nombre) VALUES ('SD', 'S�dney');
INSERT INTO Ciudades (ID, Nombre) VALUES ('RM', 'Roma');
INSERT INTO Ciudades (ID, Nombre) VALUES ('MC', 'Mosc�');
INSERT INTO Ciudades (ID, Nombre) VALUES ('PK', 'Pek�n');
INSERT INTO Ciudades (ID, Nombre) VALUES ('RJ', 'R�o de Janeiro');
INSERT INTO Ciudades (ID, Nombre) VALUES ('BO', 'Bogot�');



select *  from Ciudades
