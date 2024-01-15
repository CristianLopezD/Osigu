-- Creación de la tabla de estados
CREATE TABLE Estados (
    Codigo CHAR(1) PRIMARY KEY,
    Nombre NVARCHAR(50)
);

-- Inserción de los cuatro estados
INSERT INTO Estados (Codigo, Nombre) VALUES ('P', 'Programado');
INSERT INTO Estados (Codigo, Nombre) VALUES ('V', 'En Vuelo');
INSERT INTO Estados (Codigo, Nombre) VALUES ('F', 'Finalizado');
INSERT INTO Estados (Codigo, Nombre) VALUES ('C', 'Cancelado');
