BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "BoekVorm" (
	"Id"	INTEGER NOT NULL,
	"Omschrijving"	TEXT,
	"Digitaal"	INTEGER NOT NULL,
	CONSTRAINT "PK_BoekVorm" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Genres" (
	"Id"	INTEGER NOT NULL,
	"Omschrijving"	TEXT,
	"Doelgroep"	INTEGER NOT NULL,
	CONSTRAINT "PK_Genres" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Talen" (
	"Key"	TEXT NOT NULL,
	"Naam"	TEXT NOT NULL,
	CONSTRAINT "PK_Talen" PRIMARY KEY("Key")
);
CREATE TABLE IF NOT EXISTS "Uitgeverijen" (
	"Id"	INTEGER NOT NULL,
	"Naam"	TEXT NOT NULL,
	"Hoofdkwartier"	TEXT,
	"Oprichter"	TEXT,
	CONSTRAINT "PK_Uitgeverijen" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "SubGenres" (
	"Id"	INTEGER NOT NULL,
	"GenreId"	INTEGER NOT NULL,
	"Omschrijving"	TEXT,
	"Doelgroep"	INTEGER,
	"MinLeeftijd"	INTEGER,
	CONSTRAINT "FK_SubGenres_Genres_GenreId" FOREIGN KEY("GenreId") REFERENCES "Genres"("Id") ON DELETE CASCADE,
	CONSTRAINT "PK_SubGenres" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "DbImages" (
	"Id"	INTEGER NOT NULL,
	"Naam"	TEXT,
	"Content"	BLOB NOT NULL,
	"ImageType"	INTEGER NOT NULL,
	"Description"	TEXT,
	CONSTRAINT "PK_DbImages" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Auteurs" (
	"Id"	INTEGER NOT NULL,
	"Achtergrond"	TEXT,
	"Achternaam"	TEXT,
	"Afbeelding"	TEXT,
	"ArtiestenNaam"	TEXT NOT NULL,
	"FotoId"	INTEGER,
	"Voornaam"	TEXT,
	"Woonplaats"	TEXT,
	CONSTRAINT "FK_Auteurs_DbImages_FotoId" FOREIGN KEY("FotoId") REFERENCES "DbImages"("Id") ON DELETE RESTRICT,
	CONSTRAINT "PK_Auteurs" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Boeken" (
	"Id"	INTEGER NOT NULL,
	"Afbeelding"	TEXT,
	"AuteurId"	INTEGER,
	"EAN"	TEXT,
	"FotoId"	INTEGER,
	"GenreId"	INTEGER,
	"ISBN10"	TEXT,
	"ISBN13"	TEXT,
	"KorteInhoud"	TEXT,
	"Naam"	TEXT NOT NULL,
	"TaalKey"	TEXT,
	"UitgeverijId"	INTEGER,
	"VormId"	INTEGER,
	CONSTRAINT "FK_Boeken_SubGenres_GenreId" FOREIGN KEY("GenreId") REFERENCES "SubGenres"("Id") ON DELETE RESTRICT,
	CONSTRAINT "FK_Boeken_DbImages_FotoId" FOREIGN KEY("FotoId") REFERENCES "DbImages"("Id") ON DELETE RESTRICT,
	CONSTRAINT "FK_Boeken_BoekVorm_VormId" FOREIGN KEY("VormId") REFERENCES "BoekVorm"("Id") ON DELETE RESTRICT,
	CONSTRAINT "FK_Boeken_Talen_TaalKey" FOREIGN KEY("TaalKey") REFERENCES "Talen"("Key") ON DELETE RESTRICT,
	CONSTRAINT "FK_Boeken_Auteurs_AuteurId" FOREIGN KEY("AuteurId") REFERENCES "Auteurs"("Id") ON DELETE RESTRICT,
	CONSTRAINT "FK_Boeken_Uitgeverijen_UitgeverijId" FOREIGN KEY("UitgeverijId") REFERENCES "Uitgeverijen"("Id") ON DELETE RESTRICT,
	CONSTRAINT "PK_Boeken" PRIMARY KEY("Id" AUTOINCREMENT)
);
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (0,NULL,0);
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (1,'Gebonden','false');
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (2,'Paperback','false');
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (3,'Audio boek','true');
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (5,'Ongebonden','false');
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (6,'E-boek','true');
INSERT INTO "BoekVorm" ("Id","Omschrijving","Digitaal") VALUES (7,'Ongebonden','false');
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (1,'Strips',2);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (2,'Romans',16);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (3,'Educatief',12);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (4,'Religie & spiritualiteit',12);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (5,'Kinderboeken',1);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (6,'Lifestyle',12);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (7,'Romantiek & Erotiek',16);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (8,'Jongvolwassenen',14);
INSERT INTO "Genres" ("Id","Omschrijving","Doelgroep") VALUES (9,'Sciencefiction & fantasy',12);
INSERT INTO "Talen" ("Key","Naam") VALUES ('EN-US','Engels');
INSERT INTO "Talen" ("Key","Naam") VALUES ('NL-NL','Nederlands');
INSERT INTO "Talen" ("Key","Naam") VALUES ('EN-UK','Engels (UK)');
INSERT INTO "Talen" ("Key","Naam") VALUES ('NL-BE','Nederlands (België)');
INSERT INTO "Talen" ("Key","Naam") VALUES ('FR-FR','Frans');
INSERT INTO "Talen" ("Key","Naam") VALUES ('DE-DE','Duits');
INSERT INTO "Talen" ("Key","Naam") VALUES ('SP-SP','Spaans');
INSERT INTO "Uitgeverijen" ("Id","Naam","Hoofdkwartier","Oprichter") VALUES (1,'Standaard Uitgeverij','Franklin Rooseveltplaats 12, 2060 Antwerpen',NULL);
INSERT INTO "Uitgeverijen" ("Id","Naam","Hoofdkwartier","Oprichter") VALUES (2,'J.M. Meulenhoff','Amsterdam','Johannes Marius Meulenhoff');
INSERT INTO "Uitgeverijen" ("Id","Naam","Hoofdkwartier","Oprichter") VALUES (3,'Overamstel Uitgevers','Amsterdam',NULL);
INSERT INTO "Uitgeverijen" ("Id","Naam","Hoofdkwartier","Oprichter") VALUES (4,'Penguin UK','Londen',NULL);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (1,1,'Stripverhaal',8,2);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (2,1,'Manga',12,10);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (3,1,'Graphic novels',14,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (4,2,'Trillers',16,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (5,2,'Drama',16,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (6,2,'Mysterie',16,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (7,2,'Literaire romans',16,14);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (8,3,'Geschiedenis',12,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (9,3,'ICT',12,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (10,3,'Wetenschappen',14,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (11,3,'Recht',18,16);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (12,4,'Religie',16,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (13,4,'spiritualiteit',16,14);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (14,5,'Prentenboeken',1,1);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (15,5,'Verhalen',6,4);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (16,6,'Sport',10,8);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (17,6,'Gezin',16,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (18,6,'Koken',16,8);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (19,7,'Romantiek',16,14);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (20,7,'Erotiek',18,16);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (21,8,'Misdaad',14,10);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (22,8,'Mysterie',14,10);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (23,8,'Romantiek',14,10);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (24,9,'Fantasy',14,12);
INSERT INTO "SubGenres" ("Id","GenreId","Omschrijving","Doelgroep","MinLeeftijd") VALUES (25,9,'SF',14,12);
INSERT INTO "Auteurs" ("Id","Achtergrond","Achternaam","Afbeelding","ArtiestenNaam","FotoId","Voornaam","Woonplaats") VALUES (1,'Willy Vandersteen was een Belgische maker van stripboeken. In een carrière van 50 jaar creëerde hij een grote studio en publiceerde hij meer dan 1.000 stripalbums in meer dan 25 series, waarvan hij wereldwijd meer dan 200 miljoen exemplaren verkocht.','Vandersteen','E:\Data\Syntra\Images\jefnys.jpg','Willy Vandersteen',NULL,'Willebrord Jan Frans Maria','Antwerpen');
INSERT INTO "Auteurs" ("Id","Achtergrond","Achternaam","Afbeelding","ArtiestenNaam","FotoId","Voornaam","Woonplaats") VALUES (2,'Jozef "Jef" Nys was een Belgische stripboekmaker. Hij werd vooral bekend door zijn stripverhaal Jommeke.','Nys','E:\Data\Syntra\Images\jefnys.jpg','Jef Nys',NULL,'Jozef','Wilrijk');
INSERT INTO "Auteurs" ("Id","Achtergrond","Achternaam","Afbeelding","ArtiestenNaam","FotoId","Voornaam","Woonplaats") VALUES (3,'Alberto Aleandro Uderzo was een Franse striptekenaar en scenarioschrijver. Hij is vooral bekend als de co-creator en illustrator van de Astérix-serie in samenwerking met René Goscinny. Hij tekende ook andere strips zoals Oumpah-pah, opnieuw met Goscinny.','Uderzo','E:\Data\Syntra\Images\uderzo.jpg','Uderzo',NULL,'Alberto Aleandro','Neuilly-sur-Seine');
INSERT INTO "Auteurs" ("Id","Achtergrond","Achternaam","Afbeelding","ArtiestenNaam","FotoId","Voornaam","Woonplaats") VALUES (4,'Gabriel García Márquez was een Colombiaanse romanschrijver, schrijver van korte verhalen, scenarioschrijver en journalist, in heel Latijns-Amerika liefkozend Gabo of Gabito genoemd.','Márquez','E:\Data\Syntra\Images\GGMarquez.jpg','Gabriel García Márquez',NULL,'Gabriel José García','Mexico City');
INSERT INTO "Auteurs" ("Id","Achtergrond","Achternaam","Afbeelding","ArtiestenNaam","FotoId","Voornaam","Woonplaats") VALUES (5,'Mev. Agatha Mary Clarissa Christie was een Engelse schrijver die bekend stond om haar zesenzestig detectiveverhalen en veertien korte verhalencollecties, met name die rond fictieve detectives Hercule Poirot en Miss Marple','Miller','E:\Data\Syntra\Images\AgathaChristie.jpg','Agatha Christie',NULL,'Agatha Mary Clarissa','Cholsey');
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (1,'E:\Data\Syntra\Images\Books\moord-op-de-nijl.jpg',5,'9789048822577',NULL,4,NULL,NULL,'Poirot hoort toevallig hoe twee mensen plannen maken voor een huwelijksreis naar Egypte. Als hij'' een paar maanden later een bootreis maakt over de Nijl, ontmoet hij ze daar. De man is inderdaad op huwelijksreis, maar met een andere vrouw. En het meisje is er ook... Alleen!. De situatie bevalt Poirot helemaal niet. Maar wat kan hij anders doen dan afwachten wat er gebeuren zal?','Moord op de Nijl','NL-BE',3,2);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (2,'E:\Data\Syntra\Images\Books\100JaarEenzaamheid.jpg',4,'9789029091848',NULL,7,NULL,NULL,'Honderd jaar eenzaamheid verhaalt van het exotische en tragische geslacht Buendía, dat de stad Macondo op het moeras veroverde, ruim een eeuw voordat de stad haar apocalyptische einde vindt. Natuurrampen, exploitatie en meedogenloze oorlogen bepalen de geschiedenis van de Buendía''s, waarvan de stichter José Arcadio, een alles beproevende amateur-alchemist, onder meer bewijst dat de wereld rond is: een zinvolle, zij het late ontdekking.','Honderd jaar eenzaamheid','NL-NL',2,1);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (3,'E:\Data\Syntra\Images\Books\LoveITC.jpg',4,'9780141189208',NULL,7,NULL,NULL,'Florentino Ariza is a hopeless romantic who falls passionately for the beautiful Fermina Daza, but finds his love tragically rejected. Instead Fermina marriesdistinguished doctor Juvenal Urbino, while Florentino can only wait silently for her. He can never forget his first and only true love. Then, fifty-one years, nine months and four days later, Fermina''s husband dies unexpectedly. At last Florentino has another chance to declare his feelings and discover if a passion that has endured for half a century will remain unrequited, in a rich, fantastical and humane celebration of love in all its many forms. ','Love in the Time of Cholera','EN-UK',4,7);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (4,'E:\Data\Syntra\Images\Books\SchatVanBeersel.jpg',1,'9789002263347',NULL,1,NULL,NULL,'en groene vleermuis zaait paniek tijdens een toneelvoorstelling in het kasteel van Beersel. Isidoor, de gids van Beersel, beweert dat de vleermuis een spook is en verliest na zijn verhaal een perkament.','De schat van Beersel','NL-BE',1,2);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (5,'E:\Data\Syntra\Images\Books\GewisteWiske.jpg',1,'9789002268755',NULL,1,NULL,NULL,'De Zwarte Madam is springlevend en zint naar goede gewoonte op wraak. Samen met haar kornuiten Lange Wapper en Kludde smeedt ze plannen om de mensheid een flinke loer te draaien. Wanneer Wiske die snode plannen toevallig te zien krijgt, neemt de zwarte toverkol haar geheugen af. Kunnen Suske en zijn vrienden de betovering verbreken?','Het gewiste Wiske','NL-BE',1,2);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (6,'E:\Data\Syntra\Images\Books\kaas-met-gaatjes.jpg',2,'9789462101203',NULL,1,NULL,NULL,'Jommeke is een elfjarige jongen die met zijn vriendjes Filiberke, Annemieke en Rozemieke de wereld afreist. Met zijn pientere ideeën kan hij zich uit elke benarde situatie redden.','Kaas met gaatjes','NL-BE',1,2);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (7,'E:\Data\Syntra\Images\Books\JanHaring.jpg',2,'9789462101036',NULL,1,NULL,NULL,'Als Jommeke op een dag een geheimzinnige brief krijgt van een mysterieuze zeebonk, is zijn nieuwsgierigheid geprikkeld. Hij gaat op zoek naar de zogenoemde Jan Haring, die Jommeke en zijn vrienden de woelige baren opstuurt met een bijzondere opdracht… al wil de oude kapitein niet veel kwijt over het doel van die zeereis.','De plank van Jan haring','NL-BE',1,2);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (8,'E:\Data\Syntra\Images\Books\Amoras.jpg',1,'9789002257605',NULL,1,NULL,NULL,'Ontdek nu de donkere en duistere spin-off van Suske en Wiske, geschreven (Marc Legendre) en getekend (Charel Cambré) door twee winnaars van de Bronzen Adhemar, de belangrijkste prijs voor een stripauteur in Vlaanderen.','Amoras bundel','NL-BE',1,1);
INSERT INTO "Boeken" ("Id","Afbeelding","AuteurId","EAN","FotoId","GenreId","ISBN10","ISBN13","KorteInhoud","Naam","TaalKey","UitgeverijId","VormId") VALUES (9,NULL,1,NULL,NULL,NULL,NULL,NULL,NULL,'De rechte rechter','NL-NL',NULL,1);
CREATE INDEX IF NOT EXISTS "IX_SubGenres_GenreId" ON "SubGenres" (
	"GenreId"
);
CREATE INDEX IF NOT EXISTS "IX_Auteurs_FotoId" ON "Auteurs" (
	"FotoId"
);
CREATE INDEX IF NOT EXISTS "IX_Boeken_AuteurId" ON "Boeken" (
	"AuteurId"
);
CREATE INDEX IF NOT EXISTS "IX_Boeken_FotoId" ON "Boeken" (
	"FotoId"
);
CREATE INDEX IF NOT EXISTS "IX_Boeken_GenreId" ON "Boeken" (
	"GenreId"
);
CREATE INDEX IF NOT EXISTS "IX_Boeken_TaalKey" ON "Boeken" (
	"TaalKey"
);
CREATE INDEX IF NOT EXISTS "IX_Boeken_UitgeverijId" ON "Boeken" (
	"UitgeverijId"
);
CREATE INDEX IF NOT EXISTS "IX_Boeken_VormId" ON "Boeken" (
	"VormId"
);
COMMIT;
