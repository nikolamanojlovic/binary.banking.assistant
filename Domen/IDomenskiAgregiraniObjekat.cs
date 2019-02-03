using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiAgregiraniObjekat : IDomenskiObjekat
    {
        // Vraca vrednosti za JOIN
        String VratiVrednostiZaJoin();
        // Vraca instancu agregiranog objekta
        IDomenskiObjekat VratiAgregiraniObjekat();
    }
}
