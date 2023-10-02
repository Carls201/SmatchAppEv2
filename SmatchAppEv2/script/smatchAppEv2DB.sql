
CREATE DATABASE smatchAppEv2DB
use smatchAppEv2DB

CREATE TABLE Usuario(
	id_usuario int primary key identity,
	nombre varchar(25) not null,
	fecha_nac date not null,
	altura int not null,
	peso int not null,
	sexo varchar(10) not null,
	correo varchar(50) not null,
	pass varchar(25) not null
)

CREATE TABLE Lugar(
	id_lugar int primary key identity,
	nombre_lugar varchar(25) not null,
	direccion varchar(25) not null,
	descripcion varchar(100) 
)

CREATE TABLE Deporte(
	id_deporte int primary key identity,
	nombre_deporte varchar(25) not null
)

CREATE TABLE CrearSesion(
	id_sesion int primary key identity,
	nombre_sesion varchar(25) not null,
	descripcion varchar(100) not null,
	fecha_encuentro date not null,
	id_usuario int not null,
	id_deporte int not null,
	id_lugar int not null,
	FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
	FOREIGN KEY (id_deporte) REFERENCES Deporte(id_deporte),
	FOREIGN KEY (id_lugar) REFERENCES Lugar(id_lugar)
)

CREATE TABLE Notificacion(
	id_notificacion int primary key identity,
	id_usuarioEmisor int not null,
	id_usuarioReceptor int not null,
	mensaje varchar(30) not null,
	confirmacion bit not null
	FOREIGN KEY (id_usuarioEmisor) REFERENCES Usuario(id_usuario),
	FOREIGN KEY (id_usuarioReceptor) REFERENCES Usuario(id_usuario)
)

CREATE TABLE Sala(
	id_sala int primary key identity,
	cantidad_usuarios int not null,
	estado bit not null,
	id_sesion int not null,
	id_usuario int not null,
	FOREIGN KEY (id_sesion) REFERENCES CrearSesion(id_sesion),
	FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
)

CREATE TABLE ConfirmarUsuario(
	id_confirmar int primary key identity,
	id_usuario int not null,
	id_sala int not null,
	estado varchar(20) not null,
	FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
	FOREIGN KEY (id_sala) REFERENCES Sala(id_sala)
)

CREATE TABLE Chat(
	id_chat int primary key identity,
	mensaje varchar(100),
	id_sala int not null,
	FOREIGN KEY (id_sala) REFERENCES Sala(id_sala)
)

