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
    public partial class ViewAccountStatus : Window
    {

        ModelAccount account = new ModelAccount();
        AccountDAO accountDAO = new AccountDAO();

        public ViewAccountStatus(int user_id)
        {
            InitializeComponent();
            Random r = new Random();
            int i = r.Next(11, 19);
            string stg = i.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            AccountStatusWindow.Background = ib;

            account.UserTimeWatched = accountDAO.SelectTimeWatched(user_id);

            lblHours.Content = Math.Round((account.UserTimeWatched / 60), 1);
            lblDays.Content = Math.Round(((account.UserTimeWatched / 60) / 24), 1);
            lblMonths.Content = Math.Round((((account.UserTimeWatched / 60) / 24) / 30), 1);

        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AccountStatus_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Do nothing.
        }
    }
}
