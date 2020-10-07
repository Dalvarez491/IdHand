/* Crear la Base de Datos IdHand*/
CREATE DATABASE IdHand;

/* Poner en uso la Base de Datos */
USE IdHand;

/* Crear la tabla Tbl_Administrador */
CREATE TABLE Tbl_Administrador(
Id_A  INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
Nombre_A VARCHAR(30),
Correo_A VARCHAR(30),
Contraseña_A VARCHAR(30)
);

/* Crear la tabla Tbl_Usuario */
CREATE TABLE Tbl_Usuario(
Documento_U  VARCHAR(12) NOT NULL PRIMARY KEY,
Correo_U VARCHAR(30),
Nombre_U VARCHAR(30),
Contraseña_U VARCHAR(30),
TipoSangre_U VARCHAR(3),
NombreEps_U VARCHAR(30),
NombreARL_U VARCHAR(30),
Audio_U BLOB,
CodigoQR_U VARCHAR(100),
Id_CentroR INT REFERENCES Tbl_CentroRemision(Id_CentroR)
);

/* Crear la tabla Tbl_CentroRemision */
CREATE TABLE Tbl_CentroRemision(
Id_CentroR INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
Dirrecion_CentroR VARCHAR(30),
Telefono_CentroR VARCHAR(12)
);

/* Crear la tabla Tbl_Administrador_Usuario */
CREATE TABLE Tbl_Administrador_Usuario(
Id_A INT REFERENCES Tbl_Administrador(Id_A),
Documento_U VARCHAR(12) REFERENCES Tbl_Administrador(Documento_U),
Nombre_A VARCHAR(30),
Fecha_Admi DATE
);

/* Crear table Tbl_Contacto_E */
CREATE TABLE Tbl_Contacto_E(
Id_Contacto_E INT Not Null AUTO_INCREMENT Primary Key,
Celular_Contacto_E Varchar(10),
Parentesco_Contacto_E Varchar(10)
);

/*CREACIÓN DE LA TABLA INTERMEDIA ENTRE TBL_USUSARIO Y TBL_CONTACTO_E */
CREATE TABLE Tbl_Usuario_Contacto_E(
Documento_U Varchar(12) REFERENCES Tbl_Usuario(Documento_U),
Id_Contacto_E INT REFERENCES Tbl_Contacto_E(Id_Contacto_E),
Fecha_Contacto date
);

/* Crear table Tbl_padecimiento */
CREATE TABLE Tbl_Padecimiento(
Id_padecimiento INT Not Null AUTO_INCREMENT Primary Key,
Tipo_padecimiento Varchar(10)
);

/* CREACIÓN DE LA TABLA INTERMEDIA ENTRE TBL_USUARIO Y TBL_PADECIMIENTO */
CREATE TABLE Tbl_Usuario_Padecimiento(
Documento_U Varchar(12) REFERENCES Tbl_Usuario(Documento_U),
Id_Padecimiento INT REFERENCES Tbl_padecimiento(Id_padecimiento),
Fecha_Padecimiento date
);

/* CREACIÓN DE LA TABLA TBL_ENFERMEDAD */
CREATE TABLE Tbl_Enfermedad(
Id_Enfermedad INT  NOT NULL AUTO_INCREMENT PRIMARY KEY,
Nombre_Enfermedad VARCHAR(30),
Id_Padecimiento INT REFERENCES Tbl_Padecimiento(Id_Padecimiento));

/* Crear table Tbl_Alergia */
CREATE TABLE Tbl_Alergia(
Id_Alergia INT Not Null AUTO_INCREMENT Primary Key,
Nombre_Alergia Varchar(30),
Id_Padecimiento INT REFERENCES Tbl_Padecimiento(Id_Padecimiento)
);