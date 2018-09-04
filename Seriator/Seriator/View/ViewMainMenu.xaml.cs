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
    public partial class View : Window
    {
        AccountDAO account = new Model.Model.DAO.AccountDAO();
        ModelAccount a = new Model.ModelAccount();
        int user_id;

        public View(int userId)
        {
            InitializeComponent();
            Model.Model.DAO.AccountDAO account = new Model.Model.DAO.AccountDAO();
            txtUserName.Text = account.AccountSelectionUserName(userId);
            user_id = userId;
            Random r = new Random();
            int i = r.Next(1, 10);
            string stg = i.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            MainMenuWindow.Background = ib;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            ViewSeriesRegistration registration = new ViewSeriesRegistration(user_id, 0);
            registration.ShowDialog();
        }

        private void imgExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            ViewAccountStatus status = new ViewAccountStatus(user_id);
            status.ShowDialog();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ViewAccountConfiguration view = new ViewAccountConfiguration(user_id);
            view.ShowDialog();
            txtUserName.Text = account.AccountSelectionUserName(user_id);
        }

        private void btnPending_Click(object sender, RoutedEventArgs e)
        {
            ViewPendingSeries pending = new ViewPendingSeries(user_id);
            pending.ShowDialog();
        }

        private void btnCurrent_Click(object sender, RoutedEventArgs e)
        {
            ViewCurrentSeries current = new ViewCurrentSeries(user_id);
            current.ShowDialog();
        }

        private void btnFinished_Click(object sender, RoutedEventArgs e)
        {
            ViewFinishedSeries finished = new ViewFinishedSeries(user_id);
            finished.ShowDialog();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainMenu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Você tem certeza de que deseja sair do sistema?.", "Aviso!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void txtUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (account.ChangeAccountName(user_id, a.UserName, txtUserName.Text))
            {
                MessageBox.Show("Seu nome de usuário foi alterado com sucesso.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            else
            {
                MessageBox.Show("Algo errado aconteceu durante a alteração. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
        }

        private void txtUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            a.UserName = txtUserName.Text;
        }
    }
}
