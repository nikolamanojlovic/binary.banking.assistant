using Domen;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sesija
{
    public class Broker
    {
        public static Broker Instanca;
        public static String Poruka;

        public SqlConnection Konekcija;
        public SqlCommand Komanda;
        public SqlDataReader Citac;
        public SqlTransaction Transakcija;

        public Broker()
        {
            Konekcija = new SqlConnection(@"server=localhost;user id=root;database=bba_bp");
            Komanda = new SqlCommand
            {
                Connection = Konekcija
            };
        }

        public static Broker DajInstancu()
        {
            if (Instanca == null)
            {
                return new Broker();
            }
            return Instanca;
        }

        #region Konekcija i Transakcija
        public void OtvoriKonekciju()
        {
            Konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            if (Konekcija != null && Konekcija.State == ConnectionState.Open)
            {
                Konekcija.Close();
            }
        }

        public void ZapocniTransakciju()
        {
            Transakcija = Konekcija.BeginTransaction();
            Komanda.Transaction = Transakcija;
        }

        public void PotvrdiTransakciju()
        {
            Transakcija.Commit();
        }

        public void PonistiTransakciju()
        {
            Transakcija.Rollback();
        }
        #endregion

        #region Operacije nad bazom
        public bool PamtiSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = Konstante.SQL.INSERT_INTO + odo.VratiNazivTabele() + 
                                      String.Format(Konstante.SQL.VALUES, odo.VratiVrednostiZaUbacivanje());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool BrisiSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.DELETE_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlog());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool PromeniSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = Konstante.SQL.UPDATE + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.SET, odo.PostaviVrednostAtributa());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DaLiPostojiSlog(IDomenskiObjekat odo)
        {
            bool signal = true;
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlog());
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                signal = Citac.HasRows;
                Poruka = signal ? Konstante.DB.SLOG_POSTOJI : Konstante.DB.SLOG_NE_POSTOJI;
            }
            catch (Exception)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return false;
            }
            return signal;
        }

        public bool KreirajSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, String.Format(Konstante.SQL.MAX, odo.VratiAtributPretrazivanja())) +
                                      odo.VratiNazivTabele();
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();

                if (Citac.HasRows)
                {
                    odo.PostaviPocetniBroj(ref odo);
                }
                else
                {
                    odo.PovecajBroj(Citac, ref odo);
                }

                Komanda.CommandText = Konstante.SQL.INSERT_INTO + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.VALUES, odo.VratiVrednostiZaUbacivanje());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool NadjiSlogIVratiGa(IDomenskiObjekat odo)
        {
            bool signal = true;
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlog());
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();

                if (!signal)
                {
                    Poruka = Konstante.DB.SLOG_NE_POSTOJI;
                    return false;
                }
                Poruka = Konstante.DB.SLOG_POSTOJI;

                if (odo.ImaVezaniObjekat() && odo.Napuni(Citac, ref odo))
                {
                    Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabeleVezanogObjekta() +
                                          String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlogove());
                    Komanda.CommandType = CommandType.Text;
                    Citac = Komanda.ExecuteReader();
                    Poruka = odo.NapuniVezaneObjekte(Citac, ref odo) ? Konstante.DB.VEZANI_SLOG_USPESNO_PROCITAN : Konstante.DB.VEZANI_SLOG_NEUSPESNO_PROCITAN;
                }
            }
            catch (Exception)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return false;
            }
            return true;
        }

        public bool NadjiSlogSaSlozenimUslovomIVratiGa(IDomenskiObjekat odo)
        {
            bool signal = true;
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiAtributPretrazivanja());
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();

                if (!signal)
                {
                    Poruka = Konstante.DB.SLOG_NE_POSTOJI;
                    return false;
                }
                Poruka = Konstante.DB.SLOG_POSTOJI;

                if (odo.ImaVezaniObjekat() && odo.Napuni(Citac, ref odo))
                {
                    Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabeleVezanogObjekta() +
                                          String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlogove());
                    Komanda.CommandType = CommandType.Text;
                    Citac = Komanda.ExecuteReader();
                    Poruka = odo.NapuniVezaneObjekte(Citac, ref odo) ? Konstante.DB.VEZANI_SLOG_USPESNO_PROCITAN : Konstante.DB.VEZANI_SLOG_NEUSPESNO_PROCITAN;
                }
            }
            catch (Exception)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return false;
            }
            return true;
        }

        public bool PamtiSlozeniSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = Konstante.SQL.INSERT_INTO + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.VALUES, odo.VratiVrednostiZaUbacivanje());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();

                foreach(IDomenskiObjekat vezani in odo.VratiVezaniObjekat())
                {
                    Komanda.CommandText = Konstante.SQL.INSERT_INTO + vezani.VratiNazivTabele() +
                                          String.Format(Konstante.SQL.VALUES, vezani.VratiVrednostiZaUbacivanje());
                    Komanda.CommandType = CommandType.Text;
                    Komanda.ExecuteNonQuery();
                }

                Poruka = Konstante.DB.SLOZENI_SLOG_USPENO_ZAPAMCEN;
            }
            catch (Exception)
            {
                Poruka = Konstante.DB.SLOZENI_SLOG_NEUSPENO_ZAPAMCEN;
                PonistiTransakciju();
                return false;
            }
            return true;
        }
        #endregion
    }
}
