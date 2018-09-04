using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Seriator.Model.Model.DAO
{
    class AccountDAO
    {

        MySqlConnection con = null;
        ModelAccount userAccount = new ModelAccount();

        public void AccountRegistration(string username, string password)
        {
            try
            {
                string sql = "insert into tbl_user(user_name, user_password, user_timeWatched) values('" + username + "', '" + password + "', 0);";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante o cadastro. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public int AccountSelectionId(string user_name)
        {
            try
            {
                string sql = "select user_id from tbl_user where user_name = '" + user_name + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    userAccount.UserId = dtreader.GetInt16("user_id");
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a seleção. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return userAccount.UserId;
        }

        public string AccountSelectionUserName(int user_id)
        {
            try
            {
                string sql = "select user_name from tbl_user where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    userAccount.UserName = dtreader.GetString("user_name");
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a seleção. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return userAccount.UserName;
        }

        public string AccountSelectionUserPassword(int user_id)
        {
            try
            {
                string sql = "select user_password from tbl_user where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    userAccount.UserPassword = dtreader.GetString("user_password");
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a seleção. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return userAccount.UserPassword;
        }

        public bool UpdateAccount(int user_id, string oldUser_Name, string oldUser_Password, string newUser_Name, string newUserPassword)
        {
            bool i = false;

            ModelAccount x = new ModelAccount();
            ModelAccount y = new ModelAccount();

            x.UserName = oldUser_Name;
            x.UserPassword = oldUser_Password;

            try
            {
                string sql = "update tbl_user set user_name = '" + newUser_Name + "', user_password = '" + newUserPassword + "' where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                con.Close();

                sql = "select user_password from tbl_user where user_id =  " + user_id + ";";

                cmd = new MySqlCommand(sql, con);

                con.Open();

                dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    y.UserPassword = dtreader.GetString("user_password");

                    if (x.UserPassword == y.UserPassword)
                    {
                        i = false;
                    }
                    else
                    {
                        i = true;
                    }

                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a edição. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return i;

        }

        public double SelectTimeWatched(int user_id)
        {
            double i = 0;

            try
            {
                string sql = "select user_timeWatched from tbl_user where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    i = dtreader.GetDouble("user_timeWatched");

                }
                else
                {
                    //no error margin.
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a seleção. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return i;

        }

        public bool DeleteAccount(int user_id)
        {
            bool i = false;
            try
            {
                string sql = "delete from tbl_series where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                con.Close();

                sql = "delete from tbl_user where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                cmd = new MySqlCommand(sql, con);

                con.Open();

                dtreader = cmd.ExecuteReader();

                con.Close();

                sql = "select * from tbl_user where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                cmd = new MySqlCommand(sql, con);

                con.Open();

                dtreader = cmd.ExecuteReader();

                if (dtreader.Read())
                {
                    i = false;
                }
                else
                {
                    i = true;
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a exclusão. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;

        }

        public bool ChangeAccountName(int user_id, string oldUser_Name, string newUser_Name)
        {
            bool i = false;

            ModelAccount x = new ModelAccount();
            ModelAccount y = new ModelAccount();

            x.UserName = oldUser_Name;


            try
            {
                string sql = "update tbl_user set user_name = '" + newUser_Name + "' where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                con.Close();

                sql = "select user_name from tbl_user where user_name =  '" + newUser_Name + "';";

                cmd = new MySqlCommand(sql, con);

                con.Open();

                dtreader = cmd.ExecuteReader();

                if (dtreader.Read())//If there's any data.
                {
                    i = true;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a edição. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return i;

        }

        public bool TimeWatched(int user_id, double time)
        {
            bool i = false;
            try
            {

                string sql = "update tbl_user set user_timeWatched = (user_timeWatched + " + time + ") where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                sql = "select user_timeWatched from tbl_user where user_id = " + user_id + ";";

                cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())
                {
                    i = true;
                }
                else
                {
                    i = false;
                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu ao cadastrar seu tempo assistido. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public bool DeleteTimeWatched(int user_id, double time)
        {
            bool i = false;
            try
            {

                string sql = "update tbl_user set user_timeWatched = (user_timeWatched - " + time + ") where user_id = " + user_id + ";";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                sql = "select user_timeWatched from tbl_user where user_id = " + user_id + ";";

                cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                if (dtreader.Read())
                {
                    i = true;
                }
                else
                {
                    i = false;
                }


            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante o processo de exclusão. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return i;
        }

    }

}
