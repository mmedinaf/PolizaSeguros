create database PruebaSeguros;
go

use PruebaSeguros;
go

/*
use master;
go
drop database PruebaSeguros;
*/

create table Seguro
(
	IdSeguro int primary key identity(1,1),
	DescripcionSeguro varchar(100) not null unique,
	CostoSeguro decimal(7, 2) not null
);
go

create table Poliza
(
	IdPoliza int primary key identity(1,1),
	Cliente varchar(200) not null,
	FechaAdquisicion datetime not null,
	FechaVencimiento datetime,
	IdSeguro int foreign key references Seguro(IdSeguro)
);
go

insert into Seguro values ('Obligatorio Vehiculo Sedan', 50);
insert into Seguro values ('Obligatorio Motocicleta', 40);
insert into Seguro values ('Obligatorio Transporte', 100);

insert into Poliza values ('Maria Lopez', getdate(), DATEADD(YEAR, 1, GETDATE()),  1);
insert into Poliza values ('Juan Perez', '2019-12-23', '2019-12-22', 2);
insert into Poliza values ('Javier Gomez', getdate(), DATEADD(MONTH, 6, GETDATE()), 3);


select P.Cliente, P.FechaAdquisicion, P.FechaVencimiento, S.DescripcionSeguro
from Poliza P INNER JOIN Seguro S ON P.IdSeguro = S.IdSeguro