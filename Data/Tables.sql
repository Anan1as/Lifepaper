<<<<<<< HEAD
-- Active: 1720743402803@@bxrvrak0bv02ibdgxkki-mysql.services.clever-cloud.com@3306@bxrvrak0bv02ibdgxkki
=======
<<<<<<< HEAD
-- Active: 1720743402803@@bxrvrak0bv02ibdgxkki-mysql.services.clever-cloud.com@3306@bxrvrak0bv02ibdgxkki
=======
-- Active: 1720740987905@@bxrvrak0bv02ibdgxkki-mysql.services.clever-cloud.com@3306@bxrvrak0bv02ibdgxkki
>>>>>>> 7dcdd617ab1a6807130e7ecaf8dd89cb2a22c2c5
>>>>>>> 139770b9df4fc21712bc8134c2084cdc23dc0faf
CREATE TABLE Usuarios (
    UserId INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Correo VARCHAR(100) UNIQUE,
    Contraseña VARCHAR(255),
    FechaRegistro DATETIME,
    GoogleId VARCHAR(50) NULL,
    Nacionalidad VARCHAR(50)
);

INSERT INTO `Usuarios`(`Nombre`, `Apellido`, `Correo`, `Contraseña`, `Nacionalidad`) VALUES
("Daniel", "Gómez", "test@test.com", "1234", "Colombiano");

CREATE TABLE HojasDeVida (
    HojaDeVidaId INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Direccion VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    EnlacePublico VARCHAR(255),
    FOREIGN KEY (UserId) REFERENCES Usuarios(UserId)
);

CREATE TABLE ExperienciasLaborales (
    ExperienciaId INT PRIMARY KEY AUTO_INCREMENT,
    HojaDeVidaId INT,
    Empresa VARCHAR(100),
    Puesto VARCHAR(100),
    FechaInicio DATE,
    FechaFin DATE,
    Descripcion TEXT,
    FOREIGN KEY (HojaDeVidaId) REFERENCES HojasDeVida(HojaDeVidaId)
);

CREATE TABLE FormacionesAcademicas (
    FormacionId INT PRIMARY KEY AUTO_INCREMENT,
    HojaDeVidaId INT,
    Institucion VARCHAR(100),
    Titulo VARCHAR(100),
    FechaInicio DATE,
    FechaFin DATE,
    Descripcion TEXT,
    FOREIGN KEY (HojaDeVidaId) REFERENCES HojasDeVida(HojaDeVidaId)
);

CREATE TABLE HabilidadesCompetencias (
    HabilidadId INT PRIMARY KEY AUTO_INCREMENT,
    HojaDeVidaId INT,
    Habilidad VARCHAR(100),
    Nivel ENUM('Básico', 'Intermedio', 'Avanzado'),
    FOREIGN KEY (HojaDeVidaId) REFERENCES HojasDeVida(HojaDeVidaId)
);


INSERT INTO Usuarios (Nombre, Apellido, Correo, Contraseña, FechaRegistro)
VALUES ('Yeifry Leandro', 'Vargas Rivera', 'yeifry.121@gmail.com', '12345', NOW());

SELECT * FROM `Usuarios`;