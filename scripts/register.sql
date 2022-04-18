delimiter  //
create procedure sp_registrar(vcuenta varchar(8),vcontraseña varchar(10), vnombre varchar(12), vsexo boolean, vnacimiento date, vmail1 varchar(40), vmail2 varchar(40))

begin

declare id INt; 
declare mailaux int;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
   rollback;
    END;
   start transaction; 
insert into Usuarios (cuenta, nombre, sexo, contraseña, fechaNacimiento)values(vCuenta,vnombre, vsexo, vcontraseña, vnacimiento
);

select IdUsuario into id from Usuarios where nombre = vNombre and Cuenta = vCuenta and contraseña = vcontraseña;
insert into Mails (Mail) values(vmail1);
select Idmail into mailaux from Mails where Mail = vmail1;
insert into relusuariomail (idUsuario, Idmail) values (Id, mailaux);
if vmail2 <> " " then
insert into Mails (Mail) values(vmail2);
select Idmail into mailaux from Mails where Mail = vmail2;
insert into relusuariomail (idUsuario, Idmail) values (Id, mailaux);
end if;
commit; 

end//

delimiter ;
call sp_registrar('IvanIvan', 'andrea01', 'Ivan', '1', '1970/04/11', 'fgqgqwgqgw', ' ');

select * from Som.Usuarios;
select*from som.mails;
select * from som.relusuariomail;
