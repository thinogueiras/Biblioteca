using Biblioteca.Models.Tables;
using MahApps.Metro.Controls;
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

namespace Biblioteca.WPF
{
    /// <summary>
    /// Lógica interna para UsuarioWindow.xaml
    /// </summary>
    public partial class UsuarioWindow : MetroWindow
    {
        private readonly UserRepository viewModel;

        public UsuarioWindow()
        {
            InitializeComponent();
            viewModel = new UserRepository();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = viewModel.Login(new User() {UserName = txtLogin.Text, Password = txtPassword.Password});
            if (user != null)
            {
                this.Hide();
                MainWindow main = new MainWindow(this);
                main.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
