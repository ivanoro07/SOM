use som; 
delimiter  //
create procedure sp_traerIndicadores()

begin
declare indicador varchar(100);
select descripcion  from Indicadores; 
end//


delimiter ;

call sp_traerIndicadores();