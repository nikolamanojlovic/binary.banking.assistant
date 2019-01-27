using Domen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sesija
{
    public class Broker
    {
        public static Broker Instanca;
        public static String Poruka;

        public MySqlConnection Konekcija;
        public MySqlCommand Komanda;
        public MySqlDataReader Citac;
        public MySqlTransaction Transakcija;

        public Broker()
        {
            Konekcija = new MySqlConnection(@"server=localhost;user id=root;database=bba_bp");
            Komanda = Konekcija.CreateCommand();
        }

        public static Broker DajInstancu()
        {
            if (Instanca == null)
            {
                Instanca = new Broker();
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

        public void ZatvoriCitac()
        {
            if (!Citac.IsClosed)
            {
                Citac.Close();
            }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                Console.WriteLine(ex.StackTrace);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public IDomenskiObjekat NadjiSlogIVratiGa(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlog());
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();

                if (!Citac.HasRows)
                {
                    Poruka = Konstante.DB.SLOG_NE_POSTOJI;
                    return null;
                }
                odo.Napuni(Citac, ref odo);
                Poruka = Konstante.DB.SLOG_POSTOJI;
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
            return odo;
        }

        public List<IDomenskiObjekat> NadjiVezaneSlogoveIVratiIh(IDomenskiObjekat odo)
        {
            if (odo.ImaVezaniObjekat())
            {
                IDomenskiObjekat slab = (odo as IDomenskiSlozeniObjekat).VratiVezaniObjekat();

                if (!String.IsNullOrEmpty(slab.VratiUslovZaNadjiSlog()))
                {
                    Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + slab.VratiNazivTabele() +
                    String.Format(Konstante.SQL.WHERE, new String[]
                                            {
                                                (odo as IDomenskiSlozeniObjekat).VratiUslovZaNadjiSlogove(),
                                                Konstante.SQL.AND,
                                                slab.VratiUslovZaNadjiSlog()
                                            });
                }
                else
                {
                    Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + slab.VratiNazivTabele() +
                    String.Format(Konstante.SQL.WHERE, (odo as IDomenskiSlozeniObjekat).VratiUslovZaNadjiSlogove());
                }

                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                Poruka = (odo as IDomenskiSlozeniObjekat).NapuniVezaneObjekte(Citac, ref odo)
                         ? Konstante.DB.VEZANI_SLOG_USPESNO_PROCITAN : Konstante.DB.VEZANI_SLOG_NEUSPESNO_PROCITAN;
            }
            return (odo as IDomenskiSlozeniObjekat).VratiVezaneObjekte();
        }

        public bool PamtiSlozeniSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = Konstante.SQL.INSERT_INTO + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.VALUES, odo.VratiVrednostiZaUbacivanje());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();

                foreach(IDomenskiObjekat vezani in (odo as IDomenskiSlozeniObjekat).VratiVezaneObjekte())
                {
                    Komanda.CommandText = Konstante.SQL.INSERT_INTO + vezani.VratiNazivTabele() +
                                          String.Format(Konstante.SQL.VALUES, vezani.VratiVrednostiZaUbacivanje());
                    Komanda.CommandType = CommandType.Text;
                    Komanda.ExecuteNonQuery();
                }

                Poruka = Konstante.DB.SLOZENI_SLOG_USPENO_ZAPAMCEN;
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.SLOZENI_SLOG_NEUSPENO_ZAPAMCEN;
                PonistiTransakciju();
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion
    }
}
