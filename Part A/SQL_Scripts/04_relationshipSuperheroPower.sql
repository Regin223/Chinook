USE SuperherosDb

CREATE TABLE SuperheroPower (
	SuperheroId int NOT NULL FOREIGN KEY REFERENCES Superhero(id),
	PowerId int NOT NULL FOREIGN KEY REFERENCES Power(id),
	PRIMARY KEY (SuperheroId, PowerId)
);