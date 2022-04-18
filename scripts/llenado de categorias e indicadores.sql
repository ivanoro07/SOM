/*llenar categorias e indicadores*/
use SOM ; 
insert into categorias (descripcion) values("Covid");
insert into categorias (descripcion)values("Alergia");
insert into categorias (descripcion)values("Resfriado");
insert into categorias (descripcion)values("Gripe");
insert into categorias (descripcion)values("Migrañas");



insert into indicadores (descripcion, mapeo) values ("sexo", "1");
insert into indicadores (descripcion, mapeo) values ("Dolor de cabeza", "2");
insert into indicadores (descripcion, mapeo) values ("Tos", "3");
insert into indicadores (descripcion, mapeo) values ("Estornudos", "4");
insert into indicadores (descripcion, mapeo) values ("Dolor muscular", "5");
insert into indicadores (descripcion, mapeo) values ("Cansancio", "6");
insert into indicadores (descripcion, mapeo) values ("Dolor de Garganta", "7");
insert into indicadores (descripcion, mapeo) values ("Congestion Nasal", "8");
insert into indicadores (descripcion, mapeo) values ("Fiebre", "9");
insert into indicadores (descripcion, mapeo) values ("Nauseas", "10");
insert into indicadores (descripcion, mapeo) values ("Diarrea", "11");
insert into indicadores (descripcion, mapeo) values ("Perdida del gusto y olfato", "12");
insert into indicadores (descripcion, mapeo) values ("Barrio", "13");
insert into indicadores (descripcion, mapeo) values ("Tamaño del hogar", "14");

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(1,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(1,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(1,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(1,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(1,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(2,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(2,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(2,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(2,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(2,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(3,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(3,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(3,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(3,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(3,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(4,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(4,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(4,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(4,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(4,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(5,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(5,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(5,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(5,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(5,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(6,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(6,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(6,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(6,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(6,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(7,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(7,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(7,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(7,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(7,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(8,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(8,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(8,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(8,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(8,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(9,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(9,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(9,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(9,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(9,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(10,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(10,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(10,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(10,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(10,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(11,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(11,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(11,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(11,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(11,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(12,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(12,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(12,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(12,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(12,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(13,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(13,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(13,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(13,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(13,5);

insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(14,1);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(14,2);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(14,3);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(14,4);
insert into relIndicadoresCategorias (idIndicadores, idCategoria) values(14,5);














