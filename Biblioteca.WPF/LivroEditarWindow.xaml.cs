using Biblioteca.Models.Tables;
using Biblioteca.Repository;
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
    /// Lógica interna para LivroEditarWindow.xaml
    /// </summary>
    public partial class LivroEditarWindow : MetroWindow
    {
        private readonly LivroRepository viewModel;
        private Livro livroSelecionado;

        public LivroEditarWindow()
        {
            InitializeComponent();
            viewModel = new LivroRepository();
            livroSelecionado = new Livro();
            Refresh();
        }

        public LivroEditarWindow(Livro livroSelecionado) : this()
        {
            this.livroSelecionado = livroSelecionado;
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Livro livro = new Livro
            {
                Nome = txtNome.Text,
                Autor = txtAutor.Text,
                Editora = txtEditora.Text,
                AnoPublicacao = Convert.ToDateTime(txtAnoPublicacao.Text),
                QtdExemplares = Convert.ToInt32(txtQtdExemplares.Text)
            };

            if (string.IsNullOrEmpty(livro.Nome))
            {
                MessageBox.Show("O nome do livro é obrigatório", "Erro ao salvar livro", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (string.IsNullOrEmpty(livro.Autor))
            {
                MessageBox.Show("O autor é obrigatório", "Erro ao salvar livro", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (livroSelecionado.Id != 0)
                {
                    livro.Id = livroSelecionado.Id;
                    viewModel.UpdateAsync(livro);
                }
                else
                {
                    viewModel.AddAsync(livro);
                }
                this.Close();
            }

        }
        private void Refresh()
        {
            txtNome.Text = livroSelecionado.Nome;
            txtAutor.Text = livroSelecionado.Autor;
            txtEditora.Text = livroSelecionado.Editora;
            txtAnoPublicacao.Text = livroSelecionado.AnoPublicacao.ToShortDateString();
            txtQtdExemplares.Text = livroSelecionado.QtdExemplares.ToString();
        }
    }
}

