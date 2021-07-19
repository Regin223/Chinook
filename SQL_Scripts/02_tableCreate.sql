USE SuperherosDb;

CREATE TABLE Superhero (
	id int not null IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255),
	Alias varchar(255),
	Origin varchar(255)
);

CREATE TABLE Assistant(
	id int not null IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255),
);

CREATE TABLE Power(
	id int not null IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255),
	Description varchar(8000)
);
