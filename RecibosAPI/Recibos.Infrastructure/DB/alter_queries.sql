--Scaffold-DbContext "Server=(localdb)\ProjectsV13;Database=RecibosDB;Integrated Security = true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DB

SELECT *
FROM Usuarios

SELECT *
FROM Recibos


--ALTER TABLE Usuarios
--ALTER COLUMN CONSTRAINT Id PRIMARY KEY NOT NULL (Id);


--ALTER TABLE Recibos
--ADD UsuarioId_FK int
--FOREIGN KEY (UsuarioId_FK) REFERENCES Usuarios(Id);

--ALTER TABLE Recibos 
--ALTER COLUMN UsuarioId_FK INT NOT NULL 

--UPDATE Recibos
--SET UsuarioId_FK = 1