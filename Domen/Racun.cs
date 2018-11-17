using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Konstante;

namespace Domen
{
    public class Racun
    {
        private long id;
        private String brojRacuna;
        private TipRacuna tip;
        private DateTime datumKreiranja;

        public DateTime DatumKreiranja
        {
            get { return datumKreiranja; }
            set { datumKreiranja = value; }
        }

        public TipRacuna Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public String BrojRacuna
        {
            get { return brojRacuna; }
            set { brojRacuna = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public string RetrivePKFieldName()
        {
            return Konstante.Konstante.
            //return String.Concat(Konstante.T.PK_CLIENT_ID_FIELD, Konstante., Konstante.AccountTable.PK_ACCOUNT_ID_FIELD);
        }

        public string RetriveTableName()
        {
          //  return Constants.AccountTable.TABLE_NAME;
        }

        public string RetriveValuesForInsertation()
        {
          //  return String.Format(Constants.AccountTable.ACCOUNT_TABLE_INSERT, this.id, this.brojRacuna, this.tip, this.datumKreiranja.ToString(Constants.SQL.DATE_FORMAT));
        }
    }

    public enum TipRacuna
    {
        RSD,
        EUR,
        USD
    }
}
}
