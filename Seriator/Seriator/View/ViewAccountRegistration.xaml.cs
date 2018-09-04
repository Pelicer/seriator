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
    public partial class ViewAccountRegistration : Window
    {
        AccountDAO account = new AccountDAO();

        public ViewAccountRegistration()
        {
            InitializeComponent();
        }

        //Registration methods.

        public void Save()
        { 
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Por favor, digite seu nome de usuário desejado.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            else if (pswPassword.Password == "")
            {
                MessageBox.Show("Por favor, digite sua senha desejada.", "Aviso!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
            }
            else
            {
                account.AccountRegistration(txtUserName.Text, pswPassword.Password);
                MessageBox.Show("Sua conta foi registrada com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                this.Close();
            }
        }

        //Buttons behavior.

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pswPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { Save(); }
        }
    }
}
