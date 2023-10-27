using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Model;
using AdresbeheerDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDL.Repositories
{
    public class GemeenteRepositoryADO : IGemeenteRepository
    {
        private string connectionString;

        public GemeenteRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Gemeente GeefGemeente(int id)
        {
            try
            {
                string sql = "SELECT * FROM gemeente WHERE niscode=@id";
                using(SqlConnection conn = new SqlConnection(connectionString))
                using(SqlCommand cmd=conn.CreateCommand()) 
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    IDataReader reader=cmd.ExecuteReader();
                    reader.Read();
                    Gemeente g = new Gemeente(id, (string)reader["gemeentenaam"]);
                    reader.Close();
                    return g;
                }
            }
            catch(Exception ex) { throw new GemeenteRepositoryException("GeefGemeente",ex); }
        }

        public bool HeeftGemeente(int nIScode)
        {
            string sql = "SELECT count(*) FROM gemeente WHERE niscode=@niscode";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.CommandText= sql;
                    cmd.Parameters.AddWithValue("@niscode", nIScode);
                    return (int)cmd.ExecuteScalar() > 0;
                }
                catch (Exception ex) { throw new GemeenteRepositoryException("HeeftGemeente", ex); }
            }
        }

        public void VoegGemeenteToe(Gemeente gemeente)
        {
            string sql = "INSERT INTO gemeente(niscode,gemeentenaam) VALUES(@niscode,@gemeentenaam)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@niscode", gemeente.NIScode);
                    cmd.Parameters.AddWithValue("@gemeentenaam", gemeente.Gemeentenaam);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new GemeenteRepositoryException("voegGemeentetoe", ex); }
            }
        }
    }
}
