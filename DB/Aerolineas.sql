-- Creación de la tabla de aerolíneas
CREATE TABLE Aerolineas (
    Codigo CHAR(3) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Inserción de 5 aerolíneas famosas
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('AA', 'American Airlines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('DL', 'Delta Air Lines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('UA', 'United Airlines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('BA', 'British Airways');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('LH', 'Lufthansa');
