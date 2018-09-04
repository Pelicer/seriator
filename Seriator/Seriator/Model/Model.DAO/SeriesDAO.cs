using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Seriator.Model.Model.DAO
{
    class SeriesDAO
    {
        MySqlConnection con = null;


        //Comands for general menagement.
        public int SeriesRegistration(ModelSeries series)
        {
            try
            {

                string sql = @"insert into 
                    tbl_series(series_status, series_title, series_seasons, series_episodes, series_synopsys, series_episodePerSeason, series_currentSeason, series_currentEpisode, 
                    series_progressSeason, series_progressEpisodes, series_duration, series_dayFinished, user_id, category_id) values("
                     + series.SeriesStatus + ", '"
                     + series.SeriesTitle + "', "
                     + series.SeriesSeason + ", "
                     + series.SeriesEpisodes + ", '"
                     + series.SeriesSynopsys + "',"
                     + series.SeriesEpisodePerSeason + ","
                     + series.SeriesCurrentSeason + ", "
                     + series.SeriesCurrentEpisode + ", '"
                     + series.SeriesCurrentSeason + " of "
                     + series.SeriesSeason + "', '"
                     + series.SeriesCurrentEpisode + " of "
                     + series.SeriesEpisodes.ToString() + "', "
                     + series.SeriesDuration + ", '"
                     + series.SeriesFinishDate.ToString("yyyy/MM/dd") + "', "
                     + series.SeriesUser + ", "
                     + series.SeriesCategory + ");";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                con.Close();

                sql = "select series_id, series_title from tbl_series where series_title = '" + series.SeriesTitle + "';";

                con.Open();

                cmd = new MySqlCommand(sql, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    series.SeriesId = reader.GetInt16("series_id");
                }
                else {
                    //something went wrong.
                }

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

            return series.SeriesId;

        }

        public bool UpdateSeries(ModelSeries series)
        {
            bool i;
            try
            {
                string sql = @"update tbl_series set series_status ="
                + series.SeriesStatus + ", series_title = '"
                + series.SeriesTitle + "', series_seasons = "
                + series.SeriesSeason + ", series_episodes = "
                + series.SeriesEpisodes + ", series_synopsys = '"
                + series.SeriesSynopsys + "', series_duration =" +
                + series.SeriesDuration + ", series_synopsys = '"
                + series.SeriesSynopsys + "', series_dayFinished = '"
                + series.SeriesFinishDate.ToString("yyyy/MM/dd") + "',category_id = "
                + series.SeriesCategory + ", series_episodePerSeason = "
                + series.SeriesEpisodePerSeason + ", series_currentSeason = "
                + series.SeriesCurrentSeason + ", series_currentEpisode = "
                + series.SeriesCurrentEpisode + ", series_progressSeason = '"
                + series.SeriesCurrentSeason + " of "
                + series.SeriesSeason + "', series_progressEpisodes = '"
                + series.SeriesCurrentEpisode + " of " + series.SeriesEpisodes + "' where series_id = "
                + series.SeriesId + ";";

                con = ConnectionFactory.Connection();

                con.Open();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.ExecuteNonQuery();

                con.Close();

                sql = "select series_title from tbl_series where series_title = '" + series.SeriesTitle + "';";

                con.Open();
                cmd = new MySqlCommand(sql, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = true;
                }
                else {
                    i = false;
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

        public bool DeleteSeries(string series_title)
        {
            bool i = false;
            try
            {
                string sql = "delete from tbl_series where series_title = '" + series_title + "';";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

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

        //Comands for checking and selection.
        public ModelSeries Selection(string title)
        {
            ModelSeries series = new ModelSeries();

            string sql = @"select series_id, series_title, series_status, series_seasons, series_episodes, series_synopsys, series_episodePerSeason, series_currentSeason, series_currentEpisode, series_progressSeason, 
            series_progressEpisodes, series_duration, series_dayFinished, user_id, category_id  from tbl_series where series_title = '" + title + "';";
            con = ConnectionFactory.Connection();

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataReader dt = cmd.ExecuteReader();

                if (dt.Read())
                {
                    series.SeriesId = dt.GetInt16("series_id");
                    series.SeriesTitle = dt.GetString("series_title");
                    series.SeriesStatus = dt.GetInt16("series_status");
                    series.SeriesId = dt.GetInt32("series_id");
                    series.SeriesSeason = dt.GetInt32("series_seasons");
                    series.SeriesEpisodes = dt.GetDouble("series_episodes");
                    series.SeriesSynopsys = dt.GetString("series_synopsys");
                    series.SeriesDuration = dt.GetDouble("series_duration");
                    series.SeriesFinishDate = dt.GetDateTime("series_dayFinished");
                    series.SeriesUser = dt.GetInt32("user_id");
                    series.SeriesCategory = dt.GetInt32("category_id");
                    series.SeriesEpisodePerSeason = dt.GetDouble("series_episodePerSeason");
                    series.SeriesProgressSeason = dt.GetString("series_progressSeason");
                    series.SeriesProgressEpisodes = dt.GetString("series_progressEpisodes");
                    series.SeriesCurrentSeason = dt.GetDouble("series_currentSeason");
                    series.SeriesCurrentEpisode = dt.GetDouble("series_currentEpisode");
                }
                con.Close();

                sql = "select category_title from tbl_category where category_id = " + series.SeriesCategory + ";";

                con.Open();
                cmd = new MySqlCommand(sql, con);
                dt = cmd.ExecuteReader();

                if (dt.Read())
                {
                    series.SeriesCategoryTitle = dt.GetString("category_title");
                }
                con.Close();

            }

            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a seleção. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }

            return series;

        }

        public bool UniqueCheck(string title)
        {
            bool i = true;

            string sql = "select series_title from tbl_series where series_title = '" + title + "';";
            con = ConnectionFactory.Connection();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataReader dt = cmd.ExecuteReader();

                if (dt.Read())
                {
                    i = false;
                }
                else
                {
                    i = true;
                }
                con.Close();

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante uma verificação. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }

            return i;
        }

        //Comands for loading.
        public List<ModelSeries> PendingSeriesLoad(int user_id)
        {
           

            List<ModelSeries> x = new List<ModelSeries>();
            try
            {
                string sql = "select series_id, series_title, series_seasons, series_episodes, series_duration, category_id from tbl_series where user_id = " + user_id + " and series_status = 1;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    ModelSeries series = new ModelSeries();

                    series.SeriesId = dtreader.GetInt16("series_id");
                    series.SeriesTitle = dtreader.GetString("series_title");
                    series.SeriesCategory = dtreader.GetInt16("category_id");
                    series.SeriesSeason = dtreader.GetInt16("series_seasons");
                    series.SeriesEpisodes = dtreader.GetDouble("series_episodes");
                    series.SeriesDuration = dtreader.GetDouble("series_duration");

                    x.Add(series);
                }

                con.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu ao carregar as séries pendentes. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }

            return x;


        }

        public List<ModelSeries> CurrentSeriesLoad(int user_id)
        {

            List<ModelSeries> x = new List<ModelSeries>();
            try
            {
                string sql = "select series_id, series_title, series_currentSeason, series_currentEpisode, series_progressEpisodes, category_id from tbl_series where user_id = " + user_id + " and series_status = 2;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    ModelSeries series = new ModelSeries();
                    series.SeriesId = dtreader.GetInt16("series_id");
                    series.SeriesTitle = dtreader.GetString("series_title");
                    series.SeriesCategory = dtreader.GetInt16("category_id");
                    series.SeriesCurrentSeason = dtreader.GetDouble("series_currentSeason");
                    series.SeriesCurrentEpisode = dtreader.GetDouble("series_currentEpisode");
                    series.SeriesProgressEpisodes = dtreader.GetString("series_progressEpisodes");

                    x.Add(series);
                }

                con.Close();

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu ao carregar as séries atuais. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }

            return x;


        }

        public List<ModelSeries> FinishedSeriesLoad(int user_id)
        {
            List<ModelSeries> x = new List<ModelSeries>();
            try
            {
                string sql = "select series_id, series_title, series_seasons, series_episodes, series_duration, series_dayFinished, category_id from tbl_series where user_id = " + user_id + " and series_status = 3;";

                con = ConnectionFactory.Connection();

                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();

                MySqlDataReader dtreader = cmd.ExecuteReader();

                while (dtreader.Read())//If there's any data.
                {
                    ModelSeries series = new ModelSeries();

                    series.SeriesId = dtreader.GetInt16("series_id");
                    series.SeriesTitle = dtreader.GetString("series_title");
                    series.SeriesCategory = dtreader.GetInt16("category_id");
                    series.SeriesSeason = dtreader.GetInt16("series_seasons");
                    series.SeriesEpisodes = dtreader.GetDouble("series_episodes");
                    series.SeriesDuration = dtreader.GetDouble("series_duration");
                    series.SeriesFinishDate = dtreader.GetDateTime("series_dayFinished");

                    x.Add(series);

                }

                con.Close();

            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu ao carregar as séries finalizadas. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }

            return x;


        }

        public List<ModelSeries> SearchTitle(string title, int status)
        {
            List<ModelSeries> x = new List<ModelSeries>();

            string sql = @"select series_id, series_status, series_title, series_seasons, series_episodes, series_duration, series_dayFinished, category_id from tbl_series where series_title like '" + title + "' and series_status = + " + status + ";";
            con = ConnectionFactory.Connection();

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                MySqlDataReader dt = cmd.ExecuteReader();

                while (dt.Read())
                {
                    ModelSeries a = new ModelSeries();

                    a.SeriesId = dt.GetInt16("series_id");
                    a.SeriesStatus = dt.GetInt16("series_status");
                    a.SeriesTitle = dt.GetString("series_title");
                    a.SeriesSeason = dt.GetInt16("series_seasons");
                    a.SeriesEpisodes = dt.GetDouble("series_episodes");
                    a.SeriesDuration = dt.GetDouble("series_duration");
                    a.SeriesFinishDate = dt.GetDateTime("series_dayFinished");
                    a.SeriesCategory = dt.GetInt16("category_id");

                    x.Add(a);

                }
                con.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Algo errado aconteceu durante a filtragem. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                throw new Exception(e.Message);
            }
            return x;

        }


    }
}
