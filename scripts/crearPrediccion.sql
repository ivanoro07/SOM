use som; 
delimiter //
create procedure sp_GuardarAnalisis (vresultado double, vcuenta varchar(8), indi1 boolean, indi2 boolean, indi3 boolean, indi4 boolean, indi5 boolean, indi6 boolean, indi7 boolean, indi8 boolean, indi9 boolean, indi10 boolean, indi11 boolean, indi12 boolean)

begin
declare fechaHoy date; 
declare vidanalisis int; 
declare vidUsuario int; 
declare vidindicador int; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
   rollback;
    END;
 start transaction;   
select now() into fechahoy;
insert into Analisis (fecha, resultado) values(fechahoy,vresultado);

select idusuario into vidUsuario from Usuarios where cuenta = vcuenta ;
select idanalisis into vidanalisis from Analisis where fecha = fechahoy and resultado = vresultado order by idanalisis desc limit 1; 
insert into relusuarioanalisis(idusuario, idanalisis) values (vidusuario, vidanalisis);


insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (1, vidanalisis, indi1); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (2, vidanalisis, indi2); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (3, vidanalisis, indi3); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (4, vidanalisis, indi4); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (5, vidanalisis, indi5); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (6, vidanalisis, indi6); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (7, vidanalisis, indi7); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (8, vidanalisis, indi8); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (9, vidanalisis, indi9); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (10, vidanalisis, indi10); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (11, vidanalisis, indi11); 
insert into relIndicadoresAnalisis(idindicadores,idanalisis,valor) values (12, vidanalisis, indi12); 

commit; 

end //
delimiter ;
