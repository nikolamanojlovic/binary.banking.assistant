using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        String VratiNazivTabele();
        String VratiNazivPK();
        String VratiVrednostiZaUbacivanje();
    }
}
