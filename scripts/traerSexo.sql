use SOM; 
delimiter  //
create procedure sp_traerSexo(vcuenta varchar(8))

begin
declare resultado boolean ;
  DECLARE exit HANDLER FOR SQLEXCEPTION
    BEGIN
   rollbacK;
    END;


start transaction;
select Sexo into resultado from Usuarios where vcuenta = Usuarios.Cuenta ;
select resultado; 
commit; 
  
end//
delimiter ;