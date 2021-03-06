﻿using Seriator.Model;
using Seriator.Model.Model.DAO;
using System;
using System.Collections.Generic;
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
    public partial class ViewCurrentSeries : Window
    {
        int id;
        int i = 0;
        SeriesDAO SeriesDAO = new SeriesDAO();

        public ViewCurrentSeries(int user_id)
        {
            InitializeComponent();
            id = user_id;
            Random r = new Random();
            int i = r.Next(11, 19);
            string stg = i.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            CurrentAnimeWindow.Background = ib;
        }

        public void LoadScreen()
        {
            tblCurrentSeries.ItemsSource = SeriesDAO.CurrentSeriesLoad(id);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CurrenAnime_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Do nothing.
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ViewSeriesRegistration registration = new ViewSeriesRegistration(id, 2);
            registration.ShowDialog();
            LoadScreen();
        }

        private void CurrentAnime_Loaded(object sender, RoutedEventArgs e)
        {
            tblCurrentSeries.ItemsSource = SeriesDAO.CurrentSeriesLoad(id);
        }

        public string TableValues(int i)
        {
            try
            {
                DataGridCellInfo cellInfo = tblCurrentSeries.SelectedCells[i];
                DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
                FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
                BindingOperations.SetBinding(element, TagProperty, column.Binding);

                return (element.Tag.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, selecione a série que você gostaria de editar.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }

            return null;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(1) != null)
            {
                MessageBoxResult result = MessageBox.Show("Você tem certeza de que gostaria de excluir a série selecionada?",
               "Aviso!", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {

                    ModelSeries anime = new ModelSeries();
                    anime = SeriesDAO.Selection(TableValues(1));
                    double t = anime.SeriesCurrentEpisode * anime.SeriesDuration;
                    SeriesDAO.DeleteSeries(anime.SeriesTitle);
                    //Removes the time watched from user equals to total of time watched of the deleted anime.
                    AccountDAO accountDAO = new AccountDAO();
                    anime = SeriesDAO.Selection(TableValues(1));

                    if (accountDAO.DeleteTimeWatched(id, t))
                    {
                        MessageBox.Show("Série deletada com sucesso da sua conta.", "Successo!");
                    }
                }
                else
                {
                    //Do nothing.
                }
            }
            else
            {

            }

            LoadScreen();
        }


        private void tblCurrentSeries_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TableValues(1) != null)
            {
                SeriesDAO SeriesDAO = new SeriesDAO();
                ModelSeries anime = new ModelSeries();
                anime = SeriesDAO.Selection(TableValues(1));
                ViewSeriesRegistration registration = new ViewSeriesRegistration(anime, 2);
                registration.ShowDialog();
                LoadScreen();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(1) != null)
            {
                SeriesDAO SeriesDAO = new SeriesDAO();
                ModelSeries anime = new ModelSeries();
                anime = SeriesDAO.Selection(TableValues(1));
                ViewSeriesRegistration registration = new ViewSeriesRegistration(anime, 2);
                registration.ShowDialog();
                LoadScreen();
            }

        }

        private void txtSearchTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchTitle.Text == "")
            {
                LoadScreen();
            }
            else
            {
                tblCurrentSeries.ItemsSource = SeriesDAO.SearchTitle(txtSearchTitle.Text, 2);
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                txtSearchTitle.Visibility = Visibility.Visible;
                i = 1;
            }
            else if (i == 1)
            {
                txtSearchTitle.Visibility = Visibility.Hidden;
                txtSearchTitle.Text = "";
                LoadScreen();
                i = 0;

            }
        }

        private void tblCurrentSeries_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TableValues(1) != null)
                {
                    SeriesDAO SeriesDAO = new SeriesDAO();
                    ModelSeries anime = new ModelSeries();
                    anime = SeriesDAO.Selection(TableValues(1));
                    ViewSeriesRegistration registration = new ViewSeriesRegistration(anime, 2);
                    registration.ShowDialog();
                }
            }
        }

        private void CurrenSeries_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void CurrenSeries_Loaded(object sender, RoutedEventArgs e)
        {
            tblCurrentSeries.ItemsSource = SeriesDAO.CurrentSeriesLoad(id);
        }
    }




}
