using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Seriator.Model.Model.DAO
{
    class LoginDAO
    {
        MySqlConnection con = null;

        public bool Login(string user, string password)
        {
            bool result = false;
            try
            {
                string sql = "select user_name, user_password from tbl_user where user_name= '" + user + "'and  user_password = '" + password + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    result = true;
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante o login. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}
