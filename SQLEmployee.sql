create database DataEmployee
go
create table tblEmployee(
employeeId int primary key identity,
Documento int not null,
Nombre varchar(75) not null,
Apellido varchar(75) not null,
Correo varchar(80) not null,
Telefono varchar(13) not null,
Direccion varchar(90) not null,
Genero varchar(1) not null
)
go
create proc sp_busqueda(
@value varchar(255)
)
as
begin
	if @value = ''
		select *from tblEmployee
	else
	select * from tblEmployee where Nombre like CONCAT('%',@value,'%') or Apellido like CONCAT('%',@value,'%')
end

go 
create proc sp_crear(
@Documento int,
@Nombre varchar(75),
@Apellido varchar(75),
@Correo varchar(80),
@Telefono varchar(13),
@Direccion varchar(90),
@Genero varchar(1)
)
as
begin
	insert into tblEmployee(Documento,Nombre,Apellido,Correo,Telefono,Direccion,Genero ) values (@Documento,@Nombre,@Apellido,@Correo,@Telefono,@Direccion,@Genero)
end
go
