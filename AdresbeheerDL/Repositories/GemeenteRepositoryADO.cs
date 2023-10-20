﻿using AdresbeheerBL.Interfaces;
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
    }
}
