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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca.WPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public UsuarioWindow UsuarioWindow { get; set; }

        public MainWindow(UsuarioWindow usuarioWindow)
        {
            InitializeComponent();
            UsuarioWindow = usuarioWindow;
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }

        protected override void OnClosed(EventArgs e)
        {
            UsuarioWindow.Show();
            base.OnClosed(e);
        }

        private void BtnAluno_Click(object sender, RoutedEventArgs e)
        {
            AlunosWindow alunos = new AlunosWindow();
            alunos.Show();
        }

        private void BtnLivro_Click(object sender, RoutedEventArgs e)
        {
            LivrosWindow livros = new LivrosWindow();
            livros.Show();
        }

        private void BtnEmprestimo_Click(object sender, RoutedEventArgs e)
        {
            EmprestimosWindow emprestimos = new EmprestimosWindow();
            emprestimos.Show();
        }

        private void BtnInadimplente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
