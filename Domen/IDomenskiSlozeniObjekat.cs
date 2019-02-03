using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiSlozeniObjekat : IDomenskiObjekat
    {
        // Vraca instancu slabog objekta
        IDomenskiObjekat VratiVezaniObjekat();
        // Vraca slab objekta
        List<IDomenskiObjekat> VratiVezaneObjekte();
        // Pretvara rezultat upita u odgovarajuci slab objekat
        bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat);
    }
}
