using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        String VratiNazivPK();
        String VratiNazivTabele();
        String VratiNazivTabeleVezanogObjekta();
        String VratiVrednostiZaUbacivanje();
        String VratiUslovZaNadjiSlog();
        String VratiUslovZaNadjiSlogove();
        String VratiAtributPretrazivanja();
        String PostaviVrednostAtributa();
        void PostaviPocetniBroj(ref IDomenskiObjekat objekat);
        void PovecajBroj(SqlDataReader citac, ref IDomenskiObjekat objekat);
        bool Napuni(SqlDataReader citac, ref IDomenskiObjekat objekat);
        bool NapuniVezaneObjekte(SqlDataReader citac, ref IDomenskiObjekat objekat);
        bool ImaVezaniObjekat();
        List<IDomenskiObjekat> VratiVezaniObjekat();
    }
}
