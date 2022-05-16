CREATE DATABASE Ticketing;

USE Ticketing;

CREATE TABLE Tickets(
ID int constraint PK_ID primary key identity(1,1),
Descrizione varchar(500),
Data datetime,
Utente varchar(100),
Stato varchar(10),
CONSTRAINT CHK_STATO CHECK (Stato = 'New' OR Stato = 'OnGoing' OR Stato = 'Resolved'),
)

INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-11 12:30', 'Marco', 'New');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-12 12:30', 'Matteo', 'Resolved');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-27 10:30', 'Luca', 'OnGoing');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-14 09:30', 'Anna', 'New');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-19 09:30', 'Marta', 'OnGoing');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-16 12:30', 'Antonio', 'OnGoing');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-17 12:30', 'Michele', 'OnGoing');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-18 12:30', 'Giulia', 'Resolved');
INSERT INTO Tickets VALUES('questa è una descrizione', '2022-05-25 12:30', 'Aurora', 'New');
