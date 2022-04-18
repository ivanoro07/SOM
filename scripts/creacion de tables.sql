CREATE SCHEMA `som` ;
use SOM; 
create table SOM.usuarios(
idUsuario int not null auto_increment,
cuenta varchar(8) not null,
nombre varchar(12) not null,
sexo boolean not null, 
contraseña varchar(10) not null,
fechaNacimiento date not null,
primary key(idUsuario)
);
create table SOM.mails(
idMail int not null auto_increment,
Mail varchar(40) not null,
primary key(idMail)
);
create table SOM.relUsuarioMail( /*faltan las FK*/
idUsuariomail int not null auto_increment,
idUsuario int not null,
idMail int not null,
primary key(idUsuariomail),
foreign key(idUsuario)
references SOM.Usuarios(idUsuario)
on delete no action
on update no action, 
foreign key(idMail)
references SOM.Mails(idMail)
on delete no action
on update no action
);
create table SOM.Analisis(
idAnalisis int not null auto_increment,
fecha date,
resultado double,

primary key(idAnalisis)
);
create table SOM.Indicadores(
idIndicadores int not null auto_increment,
descripcion varchar(100),
mapeo varchar(2),

primary key(idIndicadores)
);
create table SOM.Categorias(
idCategoria int not null auto_increment,
descripcion varchar(100),
primary key(idCAtegoria)
);
create table SOM.relIndicadoresCategorias( 
idrelIndiCat int not null auto_increment,
idIndicadores int,
idCategoria int, 
primary key(idrelIndiCat),
foreign key(idIndicadores)
references SOM.Indicadores(idIndicadores)
on delete no action
on update no action,
foreign key(idCategoria)
references SOM.categorias(idCategoria)
on delete no action
on update no action
);
create table SOM.relUsuarioAnalisis( 
idUsuarioAnalisis int not null auto_increment,
idUsuario int,
idAnalisis int, 

primary key(idUsuarioAnalisis),
foreign key(idUsuario)
references SOM.Usuarios(idUsuario)
on delete no action
on update no action,
foreign key(idAnalisis)
references SOM.Analisis(idAnalisis)
on delete no action
on update no action
);
create table SOM.relindicadoresAnalisis( 
idrelindicadoresAnalisis int not null auto_increment,
idindicadores int,
idAnalisis int, 
valor boolean,
primary key(idrelindicadoresAnalisis),
foreign key(idAnalisis)
references SOM.Analisis(idAnalisis)
on delete no action
on update no action,
foreign key(idindicadores)
references SOM.indicadores(idindicadores)
on delete no action
on update no action


);





