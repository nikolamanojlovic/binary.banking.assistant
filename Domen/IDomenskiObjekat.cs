using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        // Vraca vrednost primarnog kljuca objekta
        String VratiPK();
        // Vraca vrednost za MAX
        String VratiNazivPK();
        String VratiPKIUslov(String sifraJakog = "");
        // Vraca naziv tabele koja predstavlja objekat u bazi
        String VratiNazivTabele();
        // Vraca vrednosti za INSERT
        String VratiVrednostiZaUbacivanje(String sifraJakog = "");
        // Vraca vredost za WHERE
        String VratiUslovZaNadjiSlog();
        // Vraca vrednost za SET
        String PostaviVrednostAtributa(String sifraJakog = "");
        // Vraca vredost za WHERE za slabog objekta
        String VratiKriterijumJakog(String sifraJakog = "");
        // Vraca vrednost za JOIN 
        String VratiVrednostiZaJoin(String sifraJakog = "");
        // Vraca popunjen slab objekat
        List<IDomenskiObjekat> VratiListu(ref MySqlDataReader citac);
    }


         //   string VratiImeTabele();
        //string VratiKljucIUslov();
        //string VratiVrednostiZaInsert(int sifraJakog = 0);
        //string VratiKoloneZaInsert();
        //string VratiKljuc();
       // int VratiVrednostKljuca();
      //  string KriterujumPretrage();
      //  string KriterijumJakog(int sifraJakog = 0);
      //  string VratiVrednostiZaUpdate(int sifraJakog = 0);
      //  string VratiKljucZaJoin(IOpstiDomenskiObjekat odo);
      //  List<IOpstiDomenskiObjekat> VratiListu(OleDbDataReader citac);
}
