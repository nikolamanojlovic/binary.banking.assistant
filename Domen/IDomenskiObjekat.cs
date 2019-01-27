using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        // Vraca naziv primarnog kljuca objekta
        String VratiNazivPK();
        // Vraca naziv tabele koja predstavlja objekat u bazi
        String VratiNazivTabele();
        // Vraca vrednosti za INSERT
        String VratiVrednostiZaUbacivanje();
        // Vraca vredost za WHERE
        String VratiUslovZaNadjiSlog();
        // Vraca vrednost za MAX
        String VratiAtributPretrazivanja();
        // Vraca vrednost za SET
        String PostaviVrednostAtributa();
        // Postavlja vrednost primarnog kljuca na 0
        void PostaviPocetniBroj(ref IDomenskiObjekat objekat);
        // Povecava vrednost primarnog kljuca za 1
        void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat);
        // Pretvara rezultat upita u odgovarajuci objekat
        bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat);
        // Proverava da li objekat sadrzi slabi objekat
        bool ImaVezaniObjekat();
    }
}
