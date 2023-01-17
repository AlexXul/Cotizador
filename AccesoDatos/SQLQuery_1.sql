CREATE PROCEDURE ReestablecerIdProductos   
AS   
DECLARE @ID int
if exists (select top 1 1 from Productos)
BEGIN
    set @ID = (select top 1 Id from Productos order by Id desc)
END
ELSE
BEGIN
    set @ID = 0
END
DBCC CHECKIDENT (Productos, RESEED, @ID)

delete*from Descuentos

insert into IVAs(Valor)VALUES(16)
insert into Descuentos(Valor)VALUES(20)

select*from Facturas