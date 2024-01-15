
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username	nvarchar (50)	unique	not null,
	[Password]	nvarchar (100)			not null,
	[Name]		nvarchar (50)			not null,
	Email		nvarchar (100)	unique  not null
)
go
	insert into [User] values (NEWID(), 'admin',	'admin123',	'adminUser',      'admin@admin.com')
	insert into [User] values (NEWID(), 'Cristian',	'123123',	'Cristian Lopez', 'Cristian.l@gmail.com')
	insert into [User] values (NEWID(), 'Camilo',	'asdfg',	'Camilo Diaz',	  'Camilo.d@gmail.com')
go

select * from [User]

