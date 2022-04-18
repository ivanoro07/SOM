use SOM; 
delimiter  //
create procedure sp_loguear(vcuenta varchar(8),vcontraseña varchar(10))

begin
declare resultado int ;
  DECLARE exit HANDLER FOR SQLEXCEPTION
    BEGIN
   rollbacK;
    END;


start transaction;
select count(1) into resultado from Usuarios where vcuenta = Usuarios.Cuenta and vcontraseña = Usuarios.Contraseña;
select resultado; 
commit; 
  
end//
delimiter ;



call sp_loguear("jorge", "54");