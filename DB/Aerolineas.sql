-- Creaci�n de la tabla de aerol�neas
CREATE TABLE Aerolineas (
    Codigo CHAR(3) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Inserci�n de 5 aerol�neas famosas
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('AA', 'American Airlines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('DL', 'Delta Air Lines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('UA', 'United Airlines');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('BA', 'British Airways');
INSERT INTO Aerolineas (Codigo, Nombre) VALUES ('LH', 'Lufthansa');
