using Seriator.Model;
using Seriator.Model.Model.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Seriator.View
{

    public partial class ViewSeriesRegistration : Window
    {
        //Global variables.
        int i = 1;
        int x = 0;

        //Getters and setters for image counting.
        int y = 1;

        int id;
        int status;
        string title;
        string fileName;
        string fileNameExt;
        bool imageChanged = false;

        //Global objects.
        ModelSeries series = new ModelSeries();
        ModelAccount account = new ModelAccount();
        SeriesDAO SeriesDAO = new SeriesDAO();
        AccountDAO accountDAO = new AccountDAO();



        public ViewSeriesRegistration(int user_id, int previousWindow)
        {
            InitializeComponent();
            series.SeriesUser = user_id;

            x = user_id;

            Random r = new Random();
            int w = r.Next(11, 19);
            string stg = w.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            RegistrationWindow.Background = ib;

            imgPendentChecked.IsEnabled = true; imgPendentChecked.Visibility = Visibility.Visible;
            imgPendentUnchecked.IsEnabled = true; imgPendentUnchecked.Visibility = Visibility.Visible;
            imgCurrentChecked.IsEnabled = true; imgCurrentChecked.Visibility = Visibility.Visible;
            imgCurrentUnchecked.IsEnabled = true; imgCurrentUnchecked.Visibility = Visibility.Visible;
            imgFinishedChecked.IsEnabled = true; imgFinishedChecked.Visibility = Visibility.Visible;
            imgFinishedUnchecked.IsEnabled = true; imgFinishedUnchecked.Visibility = Visibility.Visible;
            series.SeriesStatus = 0;
            btnEdit.Visibility = Visibility.Hidden;
        }

        internal ViewSeriesRegistration(ModelSeries series, int previous_window)
        {
            InitializeComponent();
            id = series.SeriesId;
            title = series.SeriesTitle;
            status = series.SeriesStatus;

            Random r = new Random();
            int w = r.Next(11, 19);
            string stg = w.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            RegistrationWindow.Background = ib;

            if (previous_window == 1)
            {
                //Loading the image.
                if (!System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + ".png"))
                {
                    //The image does not exists.
                }
                else
                {
                    if (System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + "Temp.png"))
                    {
                        File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png", true);
                        if (System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png"))
                        {
                            y = Directory.GetFiles(@"C:\Seriator\", "*", SearchOption.TopDirectoryOnly).Length;
                            y++;
                            File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png", true);
                            imgSeries.Source = new BitmapImage(new Uri(@"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png"));
                        }
                    }
                    else
                    {
                        File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp.png", true);
                        imgSeries.Source = new BitmapImage(new Uri(@"C:\Seriator\" + series.SeriesId + "Temp.png"));
                    }
                }


                //Variables for comboBox.
                string duration = series.SeriesDuration.ToString() + " minutos";
                string seasons = series.SeriesSeason.ToString() + " Temporadas";

                //Comboboxes
                cbxCategory.SelectedValue = series.SeriesCategoryTitle;
                cbxSeasons.Items.Add(seasons);
                cbxSeasons.SelectedValue = seasons;
                cbxDuration.SelectedValue = duration;

                //Loading slider and progress bar.
                slider.Value = series.SeriesCurrentEpisode;

                txtTitle.Text = series.SeriesTitle;
                txtSynopsys.Text = series.SeriesSynopsys;
                fileNameExt = txtTitle.Text + ".png";
                txtEpisodes.Text = series.SeriesEpisodes.ToString();
                txtCurrentEpisode.Visibility = Visibility.Hidden;
                txtEpisodeSeason.Text = series.SeriesEpisodePerSeason.ToString();
                txtCurrentSeason.Visibility = Visibility.Hidden;
                lblCurrentEpisode.Visibility = Visibility.Hidden;
                lblCurrentSeason.Visibility = Visibility.Hidden;
                imgPendentChecked.Visibility = Visibility.Visible;
                imgPendentUnchecked.Visibility = Visibility.Hidden;
                slider.IsEnabled = false;
                txtSynopsys.IsEnabled = false;
                txtEpisodeSeason.IsEnabled = false;
                txtCurrentSeason.IsEnabled = false;
                txtCurrentEpisode.IsEnabled = false;
                txtEpisodes.IsEnabled = false;
                txtTitle.IsEnabled = false;
                cbxCategory.IsEnabled = false;
                cbxDuration.IsEnabled = false;
                cbxSeasons.IsEnabled = false;
                btnSave.IsEnabled = false;
                series.SeriesStatus = 1;
            }
            else if (previous_window == 2)
            {
                //Loading the image.
                if (!System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + ".png"))
                {
                    //The image does not exists.
                }
                else
                {
                    if (System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + "Temp.png"))
                    {
                        File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png", true);
                        if (System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png"))
                        {
                            y = Directory.GetFiles(@"C:\Seriator\", "*", SearchOption.TopDirectoryOnly).Length;
                            y++;
                            File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png", true);
                            imgSeries.Source = new BitmapImage(new Uri(@"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png"));
                        }
                    }
                    else
                    {
                        File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp.png", true);
                        imgSeries.Source = new BitmapImage(new Uri(@"C:\Seriator\" + series.SeriesId + "Temp.png"));
                    }
                }


                //Variables for comboBox.
                string duration = series.SeriesDuration.ToString() + " minutos";
                string seasons = series.SeriesSeason.ToString() + " Temporadas";

                //Comboboxes
                cbxCategory.SelectedValue = series.SeriesCategoryTitle;
                cbxSeasons.Items.Add(seasons);
                cbxSeasons.SelectedValue = seasons;
                cbxDuration.SelectedValue = duration;

                //Loading slider and progress bar.
                slider.Value = series.SeriesCurrentEpisode;

                txtTitle.Text = series.SeriesTitle;
                txtSynopsys.Text = series.SeriesSynopsys;
                fileNameExt = txtTitle.Text + ".png";
                txtEpisodes.Text = series.SeriesEpisodes.ToString();
                txtCurrentEpisode.Text = series.SeriesCurrentEpisode.ToString();
                txtCurrentSeason.Text = series.SeriesCurrentSeason.ToString();
                txtEpisodeSeason.Text = series.SeriesEpisodePerSeason.ToString();
                imgCurrentChecked.Visibility = Visibility.Visible;
                imgCurrentUnchecked.Visibility = Visibility.Hidden;
                imgFinishedChecked.Visibility = Visibility.Hidden;
                txtCurrentEpisode.Visibility = Visibility.Visible;
                txtCurrentSeason.Visibility = Visibility.Visible;
                txtEpisodeSeason.Visibility = Visibility.Visible;
                datePicker.Visibility = Visibility.Hidden;
                slider.IsEnabled = false;
                txtSynopsys.IsEnabled = false;
                txtEpisodeSeason.IsEnabled = false;
                txtCurrentSeason.IsEnabled = false;
                txtCurrentEpisode.IsEnabled = false;
                txtEpisodes.IsEnabled = false;
                txtTitle.IsEnabled = false;
                cbxCategory.IsEnabled = false;
                cbxDuration.IsEnabled = false;
                cbxSeasons.IsEnabled = false;
                btnSave.IsEnabled = false;
                series.SeriesStatus = 2;
            }
            else if (previous_window == 3)
            {
                //Loading the image.
                if (!System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + ".png"))
                {
                    //The image does not exists.
                }
                else
                {
                    if (System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + "Temp.png"))
                    {
                        File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png", true);
                        if (System.IO.File.Exists(@"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png"))
                        {
                            y = Directory.GetFiles(@"C:\Seriator\", "*", SearchOption.TopDirectoryOnly).Length;
                            y++;
                            File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png", true);
                            imgSeries.Source = new BitmapImage(new Uri(@"C:\Seriator\" + series.SeriesId + "Temp" + y + ".png"));
                        }
                    }
                    else
                    {
                        File.Copy(@"C:\Seriator\" + series.SeriesId + ".png", @"C:\Seriator\" + series.SeriesId + "Temp.png", true);
                        imgSeries.Source = new BitmapImage(new Uri(@"C:\Seriator\" + series.SeriesId + "Temp.png"));
                    }
                }

                //Variables for comboBox.
                string duration = series.SeriesDuration.ToString() + " minutos";
                string seasons = series.SeriesSeason.ToString() + " Temporadas";

                //Comboboxes
                cbxCategory.SelectedValue = series.SeriesCategoryTitle;
                cbxSeasons.Items.Add(seasons);
                cbxSeasons.SelectedValue = seasons;
                cbxDuration.SelectedValue = duration;

                //Loading slider and progress bar.
                slider.Value = series.SeriesCurrentEpisode;

                txtTitle.Text = series.SeriesTitle;
                txtSynopsys.Text = series.SeriesSynopsys;
                fileNameExt = txtTitle.Text + ".png";
                txtEpisodes.Text = series.SeriesEpisodes.ToString();
                txtCurrentEpisode.Text = series.SeriesCurrentEpisode.ToString();
                txtCurrentSeason.Text = series.SeriesCurrentSeason.ToString();
                txtEpisodeSeason.Text = series.SeriesEpisodePerSeason.ToString();
                txtCurrentEpisode.Visibility = Visibility.Visible;
                txtCurrentSeason.Visibility = Visibility.Visible;
                txtEpisodeSeason.Visibility = Visibility.Visible;
                imgFinishedChecked.Visibility = Visibility.Visible;
                imgFinishedUnchecked.Visibility = Visibility.Hidden;
                datePicker.Visibility = Visibility.Visible;
                datePicker.Text = series.SeriesFinishDate.ToString();
                slider.IsEnabled = false;
                txtSynopsys.IsEnabled = false;
                txtEpisodeSeason.IsEnabled = false;
                txtCurrentSeason.IsEnabled = false;
                txtCurrentEpisode.IsEnabled = false;
                txtEpisodes.IsEnabled = false;
                txtTitle.IsEnabled = false;
                cbxCategory.IsEnabled = false;
                cbxDuration.IsEnabled = false;
                cbxSeasons.IsEnabled = false;
                datePicker.IsEnabled = false;
                btnSave.IsEnabled = false;
                series.SeriesStatus = 3;

            }
            else if (previous_window == 0)
            {
                btnEdit.Visibility = Visibility.Hidden;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Register_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Fechar a janela vai cancelar seu cadastro", "Aviso!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(lblCount.Content.ToString()) < 0)
            {
                txtSynopsys.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                try
                {
                    series.SeriesCurrentEpisode = double.Parse(txtCurrentEpisode.Text);

                    if (datePicker.IsVisible == true)
                    {

                        series.SeriesFinishDate = DateTime.Parse(datePicker.Text);

                    }

                    if (i == 1)
                    {
                        if (SeriesDAO.UniqueCheck(txtTitle.Text))
                        {
                            if (txtCurrentEpisode.Visibility == Visibility.Hidden)
                            {
                                series.SeriesCurrentEpisode = 0;
                            }
                            else
                            {
                                series.SeriesCurrentEpisode = Double.Parse(txtCurrentEpisode.Text);
                            }

                            if (txtEpisodeSeason.Visibility == Visibility.Hidden)
                            {
                                series.SeriesEpisodePerSeason = 0;
                            }
                            else
                            {
                                series.SeriesEpisodePerSeason = Double.Parse(txtEpisodeSeason.Text);
                            }
                            if (txtCurrentSeason.Visibility == Visibility.Hidden)
                            {
                                series.SeriesCurrentSeason = 0;
                            }
                            else
                            {
                                series.SeriesCurrentSeason = Double.Parse(txtCurrentSeason.Text);
                            }

                            //Wathed series registration.
                            if (series.SeriesCurrentEpisode == series.SeriesEpisodes)
                            {
                                if (datePicker.Visibility == Visibility.Hidden)
                                {
                                    System.Windows.MessageBox.Show("Parece que você assistiu todos os episódios. Essa série será classificada como finalizada.", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                                    status = 3;
                                    account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);
                                    datePicker.Visibility = Visibility.Visible;
                                    imgCurrentChecked.Visibility = Visibility.Hidden;
                                    imgPendentChecked.Visibility = Visibility.Hidden;
                                    imgFinishedChecked.Visibility = Visibility.Visible;
                                }
                                else if (datePicker.Visibility == Visibility.Visible)
                                {
                                    series.SeriesStatus = status;
                                    account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);

                                    if (SeriesDAO.SeriesRegistration(series) > 0)
                                    {
                                        System.Windows.MessageBox.Show("Série cadastrada com sucesso.", "Registrada com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Hide();

                                        accountDAO.TimeWatched(x, account.UserTimeWatched);

                                        //Check if there's an image.
                                        if (imageChanged == true)
                                        {
                                            //copy image to D:\test as a png image with the series's title name.
                                            File.Copy(fileName, @"C:\Seriator\" + series.SeriesId + ".png", true);
                                        }
                                        else
                                        {
                                        }
                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show("Algo errado aconteceu durante o cadastro. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                        this.Hide();
                                    }
                                }
                            }
                            else
                            {
                                //Pending and current series registration.
                                series.SeriesStatus = status;

                                if (SeriesDAO.SeriesRegistration(series) > 0)
                                {
                                    account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);

                                    System.Windows.MessageBox.Show("Série cadastrada com sucesso.", "Registrada com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                    this.Hide();

                                    accountDAO.TimeWatched(x, account.UserTimeWatched);

                                    //Check if there's an image.
                                    if (imageChanged == true)
                                    {
                                        //copy image to D:\test as a png image with the series's title name.
                                        File.Copy(fileName, @"C:\Seriator\" + series.SeriesId.ToString() + ".png", true);
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("Algo errado aconteceu durante o cadastro. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Já existe uma série com esse título.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                            txtTitle.BorderBrush = System.Windows.Media.Brushes.Red;
                        }
                    }

                    if (i == 2)
                    {
                        if (title == txtTitle.Text)
                        {
                            series.SeriesEpisodes = Double.Parse(txtEpisodes.Text);
                            series.SeriesTitle = title;
                            series.SeriesId = id;

                            if (txtCurrentEpisode.Visibility == Visibility.Hidden)
                            {
                                series.SeriesCurrentEpisode = 0;
                            }
                            else
                            {
                                series.SeriesCurrentEpisode = Double.Parse(txtCurrentEpisode.Text);
                            }
                            if (txtCurrentSeason.Visibility == Visibility.Hidden)
                            {
                                series.SeriesCurrentSeason = 0;
                            }
                            else
                            {
                                series.SeriesCurrentSeason = Double.Parse(txtCurrentSeason.Text);
                            }

                            if (txtEpisodeSeason.Visibility == Visibility.Hidden)
                            {
                                series.SeriesEpisodePerSeason = 0;
                            }
                            else
                            {
                                series.SeriesEpisodePerSeason = Double.Parse(txtEpisodeSeason.Text);
                            }

                            if (series.SeriesCurrentEpisode == series.SeriesEpisodes)
                            {
                                if (datePicker.Visibility == Visibility.Hidden)
                                {
                                    System.Windows.MessageBox.Show("Parece que você assistiu todos os episódios. Essa série será classificada como finalizada.", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                                    status = 3;
                                    account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);
                                    datePicker.Visibility = Visibility.Visible;
                                    imgCurrentChecked.Visibility = Visibility.Hidden;
                                    imgPendentChecked.Visibility = Visibility.Hidden;
                                    imgFinishedChecked.Visibility = Visibility.Visible;
                                }
                                else if (datePicker.Visibility == Visibility.Visible)
                                {

                                    series.SeriesStatus = status;
                                    account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);

                                    if (imageChanged == true)
                                    {
                                        //copy image to D:\test as a png image with the series's title name.
                                        File.Delete(@"C:\Seriator\" + series.SeriesId);
                                        File.Copy(fileName, @"C:\Seriator\" + series.SeriesId + ".png", true);
                                    }
                                    else
                                    {
                                    }

                                    if (SeriesDAO.UpdateSeries(series))
                                    {
                                        System.Windows.MessageBox.Show("Série editava com sucesso.", "Editada com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Hide();

                                        accountDAO.TimeWatched(id, account.UserTimeWatched);

                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show("Algo errado aconteceu durante a edição. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                        this.Hide();
                                    }
                                }
                            }
                            else
                            {
                                series.SeriesStatus = status;

                                if (SeriesDAO.UpdateSeries(series))
                                {
                                    account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);

                                    System.Windows.MessageBox.Show("Série editada com sucesso.", "Editada com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                    this.Hide();

                                    accountDAO.TimeWatched(id, account.UserTimeWatched);

                                    if (imageChanged == true)
                                    {
                                        File.Delete(@"C:\Seriator\" + series.SeriesId);
                                        File.Copy(fileName, @"C:\Seriator\" + series.SeriesId + ".png", true);
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("Algo errado aconteceu durante a edição. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                    this.Hide();
                                }

                            }
                        }
                        else
                        {
                            if (SeriesDAO.UniqueCheck(txtTitle.Text))
                            {
                                series.SeriesEpisodes = Double.Parse(txtEpisodes.Text);
                                series.SeriesTitle = title;
                                series.SeriesId = id;

                                if (txtCurrentEpisode.Visibility == Visibility.Hidden)
                                {
                                    series.SeriesCurrentEpisode = 0;
                                }
                                else
                                {
                                    series.SeriesCurrentEpisode = Double.Parse(txtCurrentEpisode.Text);
                                }
                                if (txtCurrentSeason.Visibility == Visibility.Hidden)
                                {
                                    series.SeriesCurrentSeason = 0;
                                }
                                else
                                {
                                    series.SeriesCurrentSeason = Double.Parse(txtCurrentSeason.Text);
                                }

                                if (txtEpisodeSeason.Visibility == Visibility.Hidden)
                                {
                                    series.SeriesEpisodePerSeason = 0;
                                }
                                else
                                {
                                    series.SeriesEpisodePerSeason = Double.Parse(txtEpisodeSeason.Text);
                                }

                                if (series.SeriesCurrentEpisode == series.SeriesEpisodes)
                                {
                                    if (datePicker.Visibility == Visibility.Hidden)
                                    {
                                        System.Windows.MessageBox.Show("Parece que você assistiu todos os episódios. Essa série será classificada como finalizada.", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                                        status = 3;
                                        account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);
                                        datePicker.Visibility = Visibility.Visible;
                                        imgCurrentChecked.Visibility = Visibility.Hidden;
                                        imgPendentChecked.Visibility = Visibility.Hidden;
                                        imgFinishedChecked.Visibility = Visibility.Visible;
                                    }
                                    else if (datePicker.Visibility == Visibility.Visible)
                                    {

                                        series.SeriesStatus = status;
                                        account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);

                                        if (imageChanged == true)
                                        {
                                            //copy image to D:\test as a png image with the series's title name.
                                            File.Delete(@"C:\Seriator\" + series.SeriesId);
                                            File.Copy(fileName, @"C:\Seriator\" + series.SeriesId + ".png", true);
                                        }
                                        else
                                        {
                                        }

                                        if (SeriesDAO.UpdateSeries(series))
                                        {
                                            System.Windows.MessageBox.Show("Série editada com sucesso.", "Editada com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                            this.Hide();

                                            accountDAO.TimeWatched(id, account.UserTimeWatched);

                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("Algo errado aconteceu durante a edição. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                            this.Hide();
                                        }
                                    }
                                }
                                else
                                {
                                    series.SeriesStatus = status;

                                    if (SeriesDAO.UpdateSeries(series))
                                    {
                                        account.UserTimeWatched = (series.SeriesCurrentEpisode * series.SeriesDuration);

                                        System.Windows.MessageBox.Show("Série editada com sucesso.", "Editada com sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                                        this.Hide();

                                        accountDAO.TimeWatched(id, account.UserTimeWatched);

                                        if (imageChanged == true)
                                        {
                                            File.Delete(@"C:\Seriator\" + series.SeriesId);
                                            File.Copy(fileName, @"C:\Seriator\" + series.SeriesId + ".png", true);
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {
                                        System.Windows.MessageBox.Show("Algo errado aconteceu durante a edição. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                        this.Hide();
                                    }
                                }
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Já existe uma série com esse título.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                                txtTitle.BorderBrush = System.Windows.Media.Brushes.Red;
                            }
                        }

                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Algo errado aconteceu durante o cadastro. Por favor, tente novamente mais tarde.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                }
            }

        }

        private void imgPendentChecked_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (imgCurrentChecked.IsVisible == true)
            {
                status = 2;

                slider.IsEnabled = true;
                slider.Value = 0;

                if (series.SeriesSeason == 1)
                {
                    txtEpisodeSeason.Text = txtEpisodes.Text;
                }
                txtCurrentEpisode.Visibility = Visibility.Visible;
                lblCurrentEpisode.Visibility = Visibility.Visible;
                txtCurrentSeason.Visibility = Visibility.Visible;
                lblCurrentSeason.Visibility = Visibility.Visible;
                if (series.SeriesSeason == 1)
                {
                    txtCurrentSeason.Text = series.SeriesSeason.ToString();
                }
                else
                {
                    txtCurrentSeason.Text = "";
                }
            }
            else if (imgFinishedChecked.IsVisible == true)
            {
                status = 3;

                slider.IsEnabled = false;
                slider.Value = double.Parse(txtEpisodes.Text.ToString());

                if (series.SeriesSeason == 1)
                {
                    txtEpisodeSeason.Text = txtEpisodes.Text;
                }
                txtCurrentEpisode.Visibility = Visibility.Visible;
                lblCurrentEpisode.Visibility = Visibility.Visible;
                txtCurrentSeason.Visibility = Visibility.Visible;
                lblCurrentSeason.Visibility = Visibility.Visible;
                txtCurrentSeason.Text = series.SeriesSeason.ToString();
                txtCurrentEpisode.Text = series.SeriesEpisodes.ToString();


            }
            imgPendentChecked.Visibility = Visibility.Hidden;
            imgPendentUnchecked.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Hidden;
        }

        private void imgCurrentChecked_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (imgPendentChecked.IsVisible == true)
            {
                slider.IsEnabled = false;
                slider.Value = 0;

                status = 1;
                if (series.SeriesSeason == 1)
                {
                    txtEpisodeSeason.Text = txtEpisodes.Text;
                }
                txtCurrentEpisode.Visibility = Visibility.Hidden;
                lblCurrentEpisode.Visibility = Visibility.Hidden;
                txtCurrentSeason.Visibility = Visibility.Hidden;
                lblCurrentSeason.Visibility = Visibility.Hidden;
            }
            else if (imgFinishedChecked.IsVisible == true)
            {
                slider.IsEnabled = false;
                slider.Value = double.Parse(txtEpisodes.Text.ToString());

                status = 3;

                if (series.SeriesSeason == 1)
                {
                    txtEpisodeSeason.Text = txtEpisodes.Text;
                }
                series.SeriesStatus = 3;
                txtCurrentEpisode.Visibility = Visibility.Visible;
                lblCurrentEpisode.Visibility = Visibility.Visible;
                txtCurrentSeason.Visibility = Visibility.Visible;
                lblCurrentSeason.Visibility = Visibility.Visible;
                txtCurrentSeason.Text = series.SeriesSeason.ToString();
                txtCurrentEpisode.Text = series.SeriesEpisodes.ToString();
            }
            imgCurrentChecked.Visibility = Visibility.Hidden;
            imgCurrentUnchecked.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Hidden;
        }

        private void imgFinishedChecked_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (imgPendentChecked.IsVisible == true)
            {
                status = 1;
                slider.IsEnabled = false;
                slider.Value = 0;

                if (series.SeriesSeason == 1)
                {
                    txtEpisodeSeason.Text = txtEpisodes.Text;
                }
                txtCurrentEpisode.Visibility = Visibility.Hidden;
                lblCurrentEpisode.Visibility = Visibility.Hidden;
                txtCurrentSeason.Visibility = Visibility.Hidden;
                lblCurrentSeason.Visibility = Visibility.Hidden;
            }
            else if (imgCurrentChecked.IsVisible == true)
            {
                status = 2;

                slider.IsEnabled = true;

                if (series.SeriesSeason == 1)
                {
                    txtEpisodeSeason.Text = txtEpisodes.Text;
                }
                txtCurrentEpisode.Visibility = Visibility.Visible;
                lblCurrentEpisode.Visibility = Visibility.Visible;
                txtCurrentSeason.Visibility = Visibility.Visible;
                lblCurrentSeason.Visibility = Visibility.Visible;
                if (series.SeriesSeason == 1)
                {
                    txtCurrentSeason.Text = series.SeriesSeason.ToString();
                }
                else
                {
                    txtCurrentSeason.Text = "";
                }
            }
            imgFinishedChecked.Visibility = Visibility.Hidden;
            imgFinishedUnchecked.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Hidden;
        }

        private void imgPendentUnchecked_MouseDown(object sender, MouseButtonEventArgs e)
        {
            status = 1;

            slider.IsEnabled = false;

            imgCurrentUnchecked.Visibility = Visibility.Visible;
            imgFinishedUnchecked.Visibility = Visibility.Visible;

            if (series.SeriesSeason == 1)
            {
                txtEpisodeSeason.Text = txtEpisodes.Text;
            }
            imgPendentUnchecked.Visibility = Visibility.Hidden;
            imgPendentChecked.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Hidden;
            txtCurrentEpisode.Visibility = Visibility.Hidden;
            lblCurrentEpisode.Visibility = Visibility.Hidden;
            txtCurrentSeason.Visibility = Visibility.Hidden;
            lblCurrentSeason.Visibility = Visibility.Hidden;

        }

        private void imgCurrentUnchecked_MouseDown(object sender, MouseButtonEventArgs e)
        {
            status = 2;

            slider.IsEnabled = true;
            slider.Value = 0;

            imgFinishedUnchecked.Visibility = Visibility.Visible;
            imgPendentUnchecked.Visibility = Visibility.Visible;

            if (series.SeriesSeason == 1)
            {
                txtEpisodeSeason.Text = txtEpisodes.Text;
            }
            imgCurrentUnchecked.Visibility = Visibility.Hidden;
            imgCurrentChecked.Visibility = Visibility.Visible;
            datePicker.Visibility = Visibility.Hidden;
            txtCurrentEpisode.Visibility = Visibility.Visible;
            lblCurrentEpisode.Visibility = Visibility.Visible;
            txtCurrentSeason.Visibility = Visibility.Visible;
            lblCurrentSeason.Visibility = Visibility.Visible;
            if (series.SeriesSeason == 1)
            {
                txtCurrentSeason.Text = series.SeriesSeason.ToString();
            }
            else
            {
                txtCurrentSeason.Text = "";
            }
        }

        private void imgFinishedUnchecked_MouseDown(object sender, MouseButtonEventArgs e)
        {
            status = 3;
            slider.Value = double.Parse(txtEpisodes.Text.ToString());

            imgCurrentUnchecked.Visibility = Visibility.Visible;
            imgPendentUnchecked.Visibility = Visibility.Visible;

            if (series.SeriesSeason == 1)
            {
                txtEpisodeSeason.Text = txtEpisodes.Text;
            }
            imgFinishedUnchecked.Visibility = Visibility.Hidden;
            imgFinishedChecked.Visibility = Visibility.Visible;
            System.Windows.MessageBox.Show("Por favor, insira a data em que terminou a série.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            datePicker.Visibility = Visibility.Visible;
            txtCurrentEpisode.Visibility = Visibility.Visible;
            lblCurrentEpisode.Visibility = Visibility.Visible;
            txtCurrentSeason.Visibility = Visibility.Visible;
            lblCurrentSeason.Visibility = Visibility.Visible;
            txtCurrentSeason.Text = series.SeriesSeason.ToString();
            txtCurrentEpisode.Text = series.SeriesEpisodes.ToString();
        }

        private void txtTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text == "")
            {
                System.Windows.MessageBox.Show("Por favor, insira o título da série.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            series.SeriesTitle = txtTitle.Text;
            title = series.SeriesTitle;
        }

        private void txtEpisodes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEpisodes.Text == "")
            {
                System.Windows.MessageBox.Show("Por favor, insira a quantidade de episódios", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            else
            {
                series.SeriesEpisodes = double.Parse(txtEpisodes.Text);
                slider.Maximum = double.Parse(txtEpisodes.Text);
            }
        }

        private void Drama_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 1;
        }

        private void Acao_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 2;
        }

        private void Horror_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 3;
        }

        private void Comedia_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 4;
        }

        private void Terror_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 5;
        }

        private void Heroi_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 6;
        }

        private void Fantasia_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 7;
        }

        private void Desenho_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 8;
        }

        private void Suspense_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 9;
        }

        private void SitCom_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesCategory = 10;
        }

        private void Season1_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 1;
        }

        private void Season2_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 2;
        }

        private void Season3_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 3;
        }

        private void Season4_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 4;
        }

        private void Season5_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 5;
        }

        private void Season6_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 6;
        }

        private void Season7_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 7;
        }

        private void Season8_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 8;
        }

        private void Season9_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 9;
        }

        private void Season10_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesSeason = 10;
        }

        private void Duration1_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesDuration = 20;
        }

        private void Duration2_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesDuration = 40;
        }

        private void Duration3_Selected(object sender, RoutedEventArgs e)
        {
            series.SeriesDuration = 60;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            i = 2;
            txtEpisodes.IsEnabled = true;
            txtSynopsys.IsEnabled = true;
            txtTitle.IsEnabled = true;
            cbxCategory.IsEnabled = true;
            cbxDuration.IsEnabled = true;
            cbxSeasons.IsEnabled = true;
            txtEpisodeSeason.IsEnabled = true;
            txtCurrentSeason.IsEnabled = true;
            txtCurrentEpisode.IsEnabled = true;
            datePicker.IsEnabled = true;
            btnSave.IsEnabled = true;
        }

        private void txtEpisodeSeason_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEpisodeSeason.Text == "")
            {
                System.Windows.MessageBox.Show("Por favor, insira o número de episódios por temporada.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            else
            {
            }
        }

        private void txtCurrentSeason_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCurrentSeason.Text == "")
            {
                System.Windows.MessageBox.Show("Por favor, insira a temporada em que você está.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            else
            {
            }
        }

        private void txtCurrentEpisode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCurrentEpisode.Text == "")
            {
                System.Windows.MessageBox.Show("Por favor, insira o episódio em que você está.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            else
            {
            }
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            imageChanged = true;

            System.Windows.MessageBox.Show("A imagem precisa ser do tipo .PNG", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);

            //creates the dialog for selection 
            Microsoft.Win32.OpenFileDialog selection = new Microsoft.Win32.OpenFileDialog();

            //default file extasion configurated for images. 
            selection.DefaultExt = ".*";
            selection.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            //boolean for check selection further in the code.
            Nullable<bool> result = selection.ShowDialog();

            //get the selected file.
            if (result == true)
            {
                //loads the image into the imgseries component.
                imgSeries.Source = new BitmapImage(new Uri(selection.FileName));
            }

            //creates the target path to copy image if it doens't exists.
            if (!System.IO.Directory.Exists(@"C:\Seriator"))
            {
                System.IO.Directory.CreateDirectory(@"C:\Seriator");
            }

            //set the global variable fileName with the filename
            fileName = selection.FileName;
        }

        private void txtEpisodes_TextChanged(object sender, TextChangedEventArgs e)
        {
            //only allows the user to enter numbers.
            Random r = new Random();
            int i = r.Next(0, 999999);
            if (!int.TryParse(txtEpisodes.Text, out i))
            {
                txtEpisodes.Text = "";
                txtEpisodes.Focus();
                return;
            }
            else
            {
                slider.Maximum = double.Parse(txtEpisodes.Text);
                progressBar.Maximum = double.Parse(txtEpisodes.Text);
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtCurrentEpisode.Text = (Math.Round((slider.Value), 0)).ToString();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lenght;
            lenght = txtSynopsys.Text;

            //setting the label of remaining characters.
            lblCount.Content = (1000 - txtSynopsys.Text.Length).ToString();

            //changing the label color for yellow if remaining characters are bellow 100.
            if (int.Parse(lblCount.Content.ToString()) < 10)
            {
                //changing the label color for red if remaining characters are bellow 10.
                lblCount.Foreground = System.Windows.Media.Brushes.Red;
            }
            else if (int.Parse(lblCount.Content.ToString()) < 100)
            {
                lblCount.Foreground = System.Windows.Media.Brushes.Yellow;
            }
            else
            {
                lblCount.Foreground = System.Windows.Media.Brushes.White;
            }

            if (int.Parse(lblCount.Content.ToString()) >= 0)
            {
                //if it is higher or equals 1, at least, set the synopsys.
                series.SeriesSynopsys = txtSynopsys.Text;
            }
            else
            {
                //if it drops to zero, doesn't store the value in series.seriesSynopsys anymore.
            }
        }

        private void txtSynopsys_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSynopsys.BorderBrush = System.Windows.Media.Brushes.LightGray;
        }

        private void txtTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTitle.BorderBrush = System.Windows.Media.Brushes.LightGray;
        }
    }

}
