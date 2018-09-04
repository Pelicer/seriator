using Seriator.Model;
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
    public partial class ViewPendingSeries : Window
    {
        int id;
        int i = 0;
        SeriesDAO seriesDAO = new SeriesDAO();
        ModelSeries series = new ModelSeries();

        public ViewPendingSeries(int user_id)
        {
            InitializeComponent();
            Model.Model.DAO.SeriesDAO series = new Model.Model.DAO.SeriesDAO();
            id = user_id;
            Random r = new Random();
            int i = r.Next(11, 19);
            string stg = i.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            PendingAnimeWindow.Background = ib;
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PendingSeries_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Do nothing.
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ViewSeriesRegistration registration = new ViewSeriesRegistration(id, 1);
            registration.ShowDialog();
            LoadScreen();
        }
        
        public void LoadScreen()
        {
            tblPendingSeries.ItemsSource = seriesDAO.PendingSeriesLoad(id);
        }

        private void tblPendingSeries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing.
        }

        private void tblPendingSeries_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TableValues(1) != null)
            {
                SeriesDAO seriesDAO = new SeriesDAO();
                ModelSeries series = new ModelSeries();
                series = seriesDAO.Selection(TableValues(1));
                ViewSeriesRegistration registration = new ViewSeriesRegistration(series, 1);
                registration.ShowDialog();
                LoadScreen();

            }

        }

        public string TableValues(int i)
        {
            try
            {
                DataGridCellInfo cellInfo = tblPendingSeries.SelectedCells[i];
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

        private void txtSearchTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchTitle.Text == "")
            {
                LoadScreen();
            }
            else
            {
                tblPendingSeries.ItemsSource = seriesDAO.SearchTitle(txtSearchTitle.Text, 1);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(1) != null)
            {
                MessageBoxResult result = MessageBox.Show("Você tem certeza de que gostaria de excluir a série selecionada?",
               "Aviso!", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {

                    ModelSeries series = new ModelSeries();
                    series = seriesDAO.Selection(TableValues(1));

                    seriesDAO.DeleteSeries(series.SeriesTitle);

                    MessageBox.Show("A série foi deletada da sua conta com sucesso.", "Successo!");

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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TableValues(1) != null)
            {
                SeriesDAO seriesDAO = new SeriesDAO();
                ModelSeries series = new ModelSeries();

                series = seriesDAO.Selection(TableValues(1));
                ViewSeriesRegistration registration = new ViewSeriesRegistration(series, 1);
                registration.ShowDialog();
                LoadScreen();

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

        private void tblPendingAnimes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (TableValues(1) != null)
                {
                    SeriesDAO seriesDAO = new SeriesDAO();
                    ModelSeries series = new ModelSeries();
                    series = seriesDAO.Selection(TableValues(1));
                    ViewSeriesRegistration registration = new ViewSeriesRegistration(series, 1);
                    registration.ShowDialog();

                }
            }
        }

        private void tblPendingSeries_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PendingSeries_Loaded(object sender, RoutedEventArgs e)
        {
            tblPendingSeries.ItemsSource = seriesDAO.PendingSeriesLoad(id);
        }

        private void tblPendingSeries_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

