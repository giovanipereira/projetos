﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProjetoControleEstoque.Model.utilitario
{
    public static class Conexao
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public static void Open()
        {
            if (connection.State.Equals(ConnectionState.Closed))
            {
                connection.Open();
            }
        }

        public static void Close()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
