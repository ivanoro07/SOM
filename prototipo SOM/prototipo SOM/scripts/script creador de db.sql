create schema if not exists SOM ;

use SOM; 
delimiter $$
create procedure sp_creacion()
begin
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
idUsuario int,
idMail int,
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
resultado int,

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
create table SOM.relIndicadoresCategorias( /*faltan fk*/
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
create table SOM.relUsuarioAnalisis( /*faltan fk*/
idUsuarioAnalisis int not null auto_increment,
idUsuarios int,
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
create table SOM.relIndicadoresAnalisis( /*faltan fk*/
idrelIndicadoresAnalisis int not null auto_increment,
idIndicadores int,
idAnalisis int, 
primary key(idrelIndicadoresAnalisis),
foreign key(idAnalisis)
references SOM.Analisis(idAnalisis)
on delete no action
on update no action,
foreign key(idIndicadores)
references SOM.Indicadores(idIndicadores)
on delete no action
on update no action
);
end$$
delimiter ;






