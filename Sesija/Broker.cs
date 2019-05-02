using Domen;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
            Konekcija.Close();
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
            if (Citac != null && !Citac.IsClosed)
            {
                Citac.Close();
            }
        }
        #endregion

        #region Operacije nad bazom
        public bool PamtiSlog(IDomenskiObjekat odo, String sifraJakog = "")
        {
            try
            {
                Komanda.CommandText = Konstante.SQL.INSERT_INTO + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.VALUES, odo.VratiVrednostiZaUbacivanje(sifraJakog));
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool BrisiSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.DELETE_FROM, odo.VratiNazivTabele()) +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiPKIUslov());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool BrisiSlabeSlogove(IDomenskiObjekat odo, String sifraJakog)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.DELETE_FROM, odo.VratiNazivTabele()) +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiPKIUslov(sifraJakog));
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
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
                                      String.Format(Konstante.SQL.SET, odo.PostaviVrednostAtributa()) +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiPKIUslov());
                Komanda.CommandType = CommandType.Text;
                Komanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IDomenskiObjekat VratiSlog(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiUslovZaNadjiSlog());
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele();
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac);
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiSveSlabeObjekte(IDomenskiObjekat odo, string sifraJakog)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiKriterijumJakog(sifraJakog));
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac);
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiSveSlabeObjekteSaKriterijumom(IDomenskiObjekat odo, string kriterijum, string sifraJakog)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, String.Join(Konstante.SQL.AND, new String[] 
                                      {
                                            odo.VratiKriterijumJakog(sifraJakog),
                                            kriterijum
                                      }));
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac);
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiSveAgregiranebjekte(IDomenskiObjekat odo, string sifraJakog)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() + odo.VratiVrednostiZaJoin(sifraJakog) +
                                      String.Format(Konstante.SQL.WHERE, odo.VratiKriterijumJakog(sifraJakog));
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac);
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiSveAgregiranebjekteSaKriterijumom(IDomenskiObjekat odo, string kriterijum, string sifraJakog)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() + odo.VratiVrednostiZaJoin(sifraJakog) +
                                      String.Format(Konstante.SQL.WHERE, kriterijum);
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac);
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public List<IDomenskiObjekat> VratiPoKriterijumu(IDomenskiObjekat odo, string kriterijum)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, Konstante.SQL.ALL) + odo.VratiNazivTabele() +
                                      String.Format(Konstante.SQL.WHERE, kriterijum);
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                return odo.VratiListu(ref Citac);
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return null;
            }
        }

        public String VratiID(IDomenskiObjekat odo)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, String.Format(Konstante.SQL.MAX, odo.VratiNazivPK())) +
                                                    odo.VratiNazivTabele();
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                if (Citac.Read())
                {
                    return Convert.ToString(Citac.GetInt64(0) + 1);
                }
                return Konstante.Opste.NULA;
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return Konstante.Opste.NULA;
            }
        }

        public String VratiIDSlabog(IDomenskiObjekat odo, String kriterijum)
        {
            try
            {
                Komanda.CommandText = String.Format(Konstante.SQL.SELECT_FROM, String.Format(Konstante.SQL.MAX, odo.VratiNazivPK())) +
                                                    odo.VratiNazivTabele() + String.Format(Konstante.SQL.WHERE, kriterijum);
                Komanda.CommandType = CommandType.Text;
                Citac = Komanda.ExecuteReader();
                if (Citac.Read())
                {
                    return Convert.ToString(Citac.GetInt64(0) + 1);
                }
                return Konstante.Opste.NULA;
            }
            catch (Exception ex)
            {
                Poruka = Konstante.DB.NAUSPESNO_PRETRAZIVANJE;
                return Konstante.Opste.NULA;
            }
        }
        #endregion
    }
}
