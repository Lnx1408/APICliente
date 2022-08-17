use ClienteDB;

CREATE TABLE Cliente
(
	Id int identity(1,1) not null primary key,
	Cedula varchar(50),
	Nombre varchar(50),
	Apellido varchar(50),
	Direccion varchar(100),
	Edad int
)

INSERT INTO Cliente(Cedula, Nombre, Apellido, Direccion, Edad) VALUES ('0987654321','James', 'Frost','Casa',21);
select * from Cliente;
