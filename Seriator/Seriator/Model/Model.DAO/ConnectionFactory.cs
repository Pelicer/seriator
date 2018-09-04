﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Seriator.Model.Model.DAO
{
    class ConnectionFactory
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection connection = null;

            try
            {
                string serverName = "localhost"; // path to sever database.
                string mydatabase = "db_seriator"; // database name.
                string username = "root"; // database username.
                string password = "1123581321"; // database password.


                connection = new MySqlConnection("server=" + serverName + ";database=" + mydatabase + ";uid=" + username + ";pwd=" + password + "");

                return connection;

            }
            catch (MySqlException)
            {
                MessageBox.Show("Falha ao obter conexão com o banco de dados. Por favor, verifique sua conexão.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);              
            }
            return connection;
        }


    }
}
