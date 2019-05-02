CREATE DATABASE bba_bp CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci;
USE bba_bp;

CREATE TABLE admin (
	admin_id INTEGER,
    jmbg VARCHAR(255),
    ime VARCHAR(255),
    prezime VARCHAR(255),
    mejl VARCHAR(255),
    telefon VARCHAR(255),
    sifra  VARCHAR(255),
    pozicija VARCHAR(255),
    PRIMARY KEY(admin_id)
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
    broj_kuce INTEGER,
    grad VARCHAR(255),
    PRIMARY KEY(klijent_id)
);

CREATE TABLE racun (
	klijent_id INTEGER REFERENCES klijent(klijent_id) ON DELETE CASCADE,
	racun_id INTEGER,
    broj_racuna VARCHAR(255),
    tip_racuna VARCHAR(255),
    datum_kreiranja DATE,
    PRIMARY KEY(klijent_id, racun_id)
);

CREATE TABLE tip_kredita (
	tip_kredita_id INTEGER,
	naziv VARCHAR(255),
    min_dug DOUBLE,
    max_dug DOUBLE,
    vremenski_okvir VARCHAR(255),
    PRIMARY KEY(tip_kredita_id)
);

CREATE TABLE transakcija (
	vremenska_oznaka DATETIME,
    posiljalac_klijent_id INTEGER,
	posiljalac_racun_id INTEGER,
    primalac_klijent_id INTEGER,
	primalac_racun_id INTEGER,
    iznos DOUBLE,
    PRIMARY KEY(vremenska_oznaka, posiljalac_klijent_id, posiljalac_racun_id, primalac_klijent_id, primalac_racun_id)
);

CREATE TABLE aktivni_kredit (
	klijent_id INTEGER,
    tip_kredita_id INTEGER,
    broj_kredita INTEGER,
    datum_uzimanja DATE,
	rok_dospeca DATE,
    datum_isplate DATE,
    kamata DOUBLE,
    broj_rata INTEGER,
    iznos DOUBLE,
    PRIMARY KEY(klijent_id, tip_kredita_id, broj_kredita)
);

CREATE TABLE rata (
	klijent_id INTEGER,
    tip_kredita_id INTEGER,
    broj_kredita INTEGER,
	redni_broj INTEGER,
    rok_dospeca DATE,
	transakcija_vremenska_oznaka DATETIME,
    transakcija_posiljalac_klijent_id INTEGER,
	transakcija_posiljalac_racun_id INTEGER,
    transakcija_primalac_klijent_id INTEGER,
	transakcija_primalac_racun_id INTEGER,
    FOREIGN KEY(transakcija_vremenska_oznaka, transakcija_posiljalac_klijent_id, transakcija_posiljalac_racun_id, transakcija_primalac_klijent_id, transakcija_primalac_racun_id) REFERENCES transakcija(vremenska_oznaka, posiljalac_klijent_id, posiljalac_racun_id, primalac_klijent_id, primalac_racun_id),
	PRIMARY KEY(klijent_id, tip_kredita_id, broj_kredita, redni_broj)
);
        
INSERT INTO admin VALUES(0, "030303", "Nikola", "Manojlović", "nikola@gmail.com", "065555555", "nikola", "Administrator");

INSERT INTO klijent VALUES(-1, "", "BBA Bank", "", "bba@gmail.com", "060000000", "", "Bulevar Oslobođenja", 25, "Beograd");
INSERT INTO klijent VALUES(0, "040404", "Jovan", "Jović", "jovan@gmail.com", "064444444", "jovan", "Bulevar Oslobođenja", 5, "Beograd");