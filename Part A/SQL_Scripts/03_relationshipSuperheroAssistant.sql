USE SuperherosDb;
ALTER TABLE Assistant
ADD SuperheroId int FOREIGN KEY REFERENCES Superhero(id); 