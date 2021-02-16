CREATE DATABASE GuauHouse;

USE GuauHouse;

-- DROP TABLE IF EXISTS RESERVAS;
DROP TABLE IF EXISTS PERROS;
DROP TABLE IF EXISTS USUARIOS;
DROP TABLE IF EXISTS ROLES;

CREATE TABLE ROLES(
  ID INT PRIMARY KEY
  ,ROL NVARCHAR(10)
);

CREATE TABLE USUARIOS(
  ID INT PRIMARY KEY
  ,USUARIO NVARCHAR(18) UNIQUE
  ,PASS NVARCHAR(18)
  ,NOMBRE NVARCHAR(50)
  ,APELLIDOS NVARCHAR(50)
  ,DNI NVARCHAR(9)
  ,EMAIL NVARCHAR(50) UNIQUE
  ,TELEFONO NVARCHAR(9)
  ,IMAGEN NVARCHAR(50)
  ,ROL INT FOREIGN KEY REFERENCES ROLES(ID)
  ,FECHA_ALTA DATETIME
);

CREATE TABLE PERROS(
  ID INT PRIMARY KEY
  ,IDUSU INT FOREIGN KEY REFERENCES USUARIOS(ID)
  ,NOMBRE NVARCHAR(50)
  ,ESTATURA NVARCHAR(10)
  ,FOTO NVARCHAR(30)
  ,FECHA_ALTA DATETIME
);

--CREATE TABLE ESTATURAS(
--	ID INT PRIMARY KEY
--	,CLASIFICACION NVARCHAR(10)
--);

-- CREATE TABLE RESERVAS(
  -- ID INT PRIMARY KEY
  -- ,IDUSU INT FOREIGN KEY REFERENCES USUARIOS(ID)
  -- ,IDPER INT FOREIGN KEY REFERENCES PERROS(ID)
  -- ,FECHA DATETIME
  -- ,TURNO NVARCHAR(6)
  -- ,FECHA_ALTA DATETIME DEFAULT CURRENT_TIMESTAMP
-- );

INSERT INTO ROLES VALUES (1, 'admin');
INSERT INTO ROLES VALUES (2, 'usuario');
INSERT INTO ROLES VALUES (3, 'empleado');

INSERT INTO USUARIOS (ID, USUARIO, PASS, NOMBRE, APELLIDOS, DNI, EMAIL, TELEFONO, ROL, FECHA_ALTA)
	VALUES (1, 'naza', 'naza', 'Nazaret', 'de la Calle Mij�n', '50628847Z', 'naza@gmail.com', '627465604', 1, convert(datetime, '16/02/2021', 103));
INSERT INTO USUARIOS (ID, USUARIO, PASS, NOMBRE, APELLIDOS, DNI, EMAIL, TELEFONO, ROL, FECHA_ALTA)
	VALUES (2, 'vio', 'vio', 'Violeta', 'de la Calle Mij�n', '50675348S', 'vio@gmail.com', '611528490', 3, convert(datetime, '16/02/2021', 103));
INSERT INTO USUARIOS (ID, USUARIO, PASS, NOMBRE, APELLIDOS, DNI, EMAIL, TELEFONO, IMAGEN, ROL, FECHA_ALTA)
	VALUES (3, 'rober', 'rober', 'Roberto', 'G�mez Ortiz', '50254312Z', 'rober@gmail.com', '610842487', 'falsorober.jpg', 2, convert(datetime, '16/02/2021', 103));
INSERT INTO USUARIOS (ID, USUARIO, PASS, NOMBRE, APELLIDOS, DNI, EMAIL, TELEFONO, ROL, FECHA_ALTA)
	VALUES (4, 'sergio', 'sergio', 'Sergio', 'Cano', '54714859R', 'sergio@gmail.com', '685585141', 2, convert(datetime, '16/02/2021', 103));

INSERT INTO PERROS (ID, IDUSU, NOMBRE, ESTATURA, FECHA_ALTA)
	VALUES (1, 4, 'Sissel', 'Grande', convert(datetime, '16/02/2021', 103));
INSERT INTO PERROS (ID, IDUSU, NOMBRE, ESTATURA, FECHA_ALTA)
	VALUES (2, 3, 'Noa', 'Mediano', convert(datetime, '16/02/2021', 103));
INSERT INTO PERROS (ID, IDUSU, NOMBRE, ESTATURA, FECHA_ALTA)
	VALUES (4, 4, 'Gala', 'Peque�o', convert(datetime, '16/02/2021', 103));
INSERT INTO PERROS (ID, IDUSU, NOMBRE, ESTATURA, FECHA_ALTA)
	VALUES (3, 3, 'Zaz�', 'Mediano', convert(datetime, '16/02/2021', 103));
INSERT INTO PERROS (ID, IDUSU, NOMBRE, ESTATURA, FECHA_ALTA)
	VALUES (5, 3, 'Lul�', 'Grande', convert(datetime, '16/02/2021', 103));

select * from USUARIOS
select * from PERROS
update PERROS set FECHA_ALTA = '16/02/2021'