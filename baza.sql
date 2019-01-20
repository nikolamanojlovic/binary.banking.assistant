CREATE DATABASE bba_bp CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci;

CREATE TABLE admin (
	admin_id INTEGER,
    jmbg VARCHAR(255),
    ime VARCHAR(255),
    prezime VARCHAR(255),
    mejl VARCHAR(255),
    telefon VARCHAR(255),
    sifra  VARCHAR(255),
    pozicija VARCHAR(255)
);

CREATE TABLE klijent (
	klijent_id INTEGER,
    jmbg VARCHAR(255),
    ime VARCHAR(255),
    prezime VARCHAR(255),
    mejl VARCHAR(255),
    telefon VARCHAR(255),
    sifra  VARCHAR(255),
    ulica VARCHAR(255),
    brojKuce INTEGER,
    grad VARCHAR(255)
);

INSERT INTO admin VALUES(0, "030303", "Nikola", "Manojlović", "nikola@gmail.com", "065555555", "nikola", "Administrator");
INSERT INTO klijent VALUES(0, "040404", "Jovan", "Jović", "jovan@gmail.com", "064444444", "jovan", "Bulevar Oslobođenja", 5, "Beograd");