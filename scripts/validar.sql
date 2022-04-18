use som; 
delimiter  //
create procedure sp_Validar(vcontra varchar(10), vnombre varchar(12), vsexo boolean, vcuenta varchar(8), vfecha date)
begin
declare devolucion int; 

DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
   rollback;
    END;
   start transaction; 
   select count(1) into devolucion from Usuarios U
  
   where u.contraseña = vcontra and u.nombre = vnombre and U.sexo = vsexo and  U.fechaNacimiento = vfecha and U.cuenta = vcuenta; 
select devolucion ; 
end//


delimiter ;
select * from usuarios ; 

