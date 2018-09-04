using Seriator.Model;
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
    public partial class ViewAccountConfiguration : Window
    {
        Model.Model.DAO.AccountDAO account = new Model.Model.DAO.AccountDAO();
        int id;

        public ViewAccountConfiguration(int user_id)
        {
            InitializeComponent();
            id = user_id;

            Random r = new Random();
            int i = r.Next(11, 19);
            string stg = i.ToString() + ".jpg";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("Images/Background/" + stg, UriKind.Relative));
            AccountConfigurationWindow.Background = ib;
            txtCurrentAccount.Text = account.AccountSelectionUserName(id);
            txtCurrentPassword.Text = account.AccountSelectionUserPassword(id);

        }

        //Configurations methods.

        public void Save()
        {
            if (txtNewAccountName.Text == "" && pswNewPassword.Password == "")
            {
                MessageBox.Show("Por favor, insira seu novo nome de usuário e senha.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            else if (txtNewAccountName.Text == "")
            {
                MessageBox.Show("Por favor, insira seu novo nome de usuário.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            else if (pswNewPassword.Password == "")
            {
                MessageBox.Show("Por favor, insira sua nova senha.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            else
            {
                if (account.UpdateAccount(id, txtCurrentAccount.Text, txtCurrentPassword.Text, txtNewAccountName.Text, pswNewPassword.Password))
                {
                    MessageBox.Show("Sua senha e nome de usuário foram alterados com sucesso.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Algo deu errado durante o processo de alteração. Por favor, tente novamente mais tarde.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    this.Close();
                }
            }
        }

        public void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Você tem certeza que deseja excluir sua conta?", "Aviso!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                if (account.DeleteAccount(id))
                {
                    MessageBox.Show("Quase lá! O programa fechará agora para que as alterações sejam terminadas.", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                    System.Environment.Exit(0);
                }
            }
        }
        //Button's behavior.

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void pswNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { Save(); }
        }
    }
}
