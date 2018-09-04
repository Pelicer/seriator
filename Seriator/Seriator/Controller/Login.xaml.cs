using Seriator.Model;
using Seriator.Model.Model.DAO;
using Seriator.View;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Seriator.Controller
{
    public partial class Login : Window
    {

        int user_id;

        LoginDAO login = new LoginDAO();
        AccountDAO account = new AccountDAO();


        public Login()
        {
            InitializeComponent();


            if (Directory.Exists(@"C:\Seriator"))
            {
                //Delete on tempporary files in cache.
                string path = @"C:\Seriator";
                string filesToDelete = @"*Temp*.png";
                string[] fileList = Directory.GetFiles(path, filesToDelete);

                foreach (string file in fileList)
                {
                    File.Delete(file);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(@"D:\CookYourself");
            }
           
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            

            user_id = account.AccountSelectionId(txtUserName.Text);

            if (login.Login(txtUserName.Text, pswBox.Password))
            {
                View.View view = new View.View(user_id);
                view.Show();
                this.Visibility = Visibility.Collapsed;
                System.Windows.MessageBox.Show("Bem vindo ao seu programa pessoal de gerenciamento de séries", "Bem vindo!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            }
            else
            {
                System.Windows.MessageBox.Show("Algo deu errado. Você tem certeza que digitou suas credenciais corretamente?", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                txtUserName.Text = "";
                pswBox.Password = "";
                txtUserName.Focus();
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void lblRegisterNewAccount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewAccountRegistration account = new ViewAccountRegistration();
            account.ShowDialog();
        }

        private void pswBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                user_id = account.AccountSelectionId(txtUserName.Text);

                if (login.Login(txtUserName.Text, pswBox.Password))
                {
                    View.View view = new View.View(user_id);
                    view.Show();
                    this.Visibility = Visibility.Collapsed;
                    System.Windows.MessageBox.Show("Bem vindo ao seu programa pessoal de gerenciamento de séries", "Bem vindo!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                }
                else
                {
                    System.Windows.MessageBox.Show("Algo deu errado. Você tem certeza que digitou suas credenciais corretamente?", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    txtUserName.Text = "";
                    pswBox.Password = "";
                    txtUserName.Focus();
                }
            }
        }
    }
}
