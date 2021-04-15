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
    /// Lógica interna para EmprestimoEditar.xaml
    /// </summary>
    public partial class EmprestimoEditar : MetroWindow
    {
        private readonly EmprestimoRepository viewModel; //= new EmprestimoRepository();
        private readonly AlunoRepository alunoviewModel;
        private readonly LivroRepository livroviewModel;

        public Aluno Aluno { get; set; }
        public Livro Livro { get; set; }

        public Emprestimo EmprestimoSelecionado { get; set; } //= new Emprestimo();

        public EmprestimoEditar()
        {
            InitializeComponent();

            viewModel = new EmprestimoRepository();
            alunoviewModel = new AlunoRepository();
            livroviewModel = new LivroRepository();

            EmprestimoSelecionado = new Emprestimo()
            {
                DataEmprestimo = DateTime.Now.ToLocalTime(),
                DataDevolucao = DateTime.Now.AddDays(10),
                Status = StatusEnum.Aberto
            };
            Refresh();
        }

        public EmprestimoEditar(Emprestimo emprestimoSelecionado) : this()
        {
            EmprestimoSelecionado = emprestimoSelecionado;
            EmprestimoSelecionado.DataDevolucao = DateTime.Now.ToLocalTime();
            EmprestimoSelecionado.DataLimiteDevolucao = DateTime.Now.ToLocalTime();
            EmprestimoSelecionado.Status = StatusEnum.Devolvido;
            Refresh();
        }

        private void Refresh()
        {
            cbAluno.ItemsSource = (System.Collections.IEnumerable)alunoviewModel.GetAllRecordsAsync();
            cbLivro.ItemsSource = (System.Collections.IEnumerable)livroviewModel.GetAllRecordsAsync();

            txtDataEmprestimo.Text = EmprestimoSelecionado.DataEmprestimo.ToString();
            txtDataDevolucao.Text = EmprestimoSelecionado.DataDevolucao.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Aluno = (Aluno)cbAluno.SelectedItem;
            var Livro = (Livro)cbLivro.SelectedItem;

            Emprestimo emprestimo = new Emprestimo
            {
                DataEmprestimo = Convert.ToDateTime(txtDataEmprestimo.Text),
                DataDevolucao = Convert.ToDateTime(txtDataDevolucao.Text),
                DataLimiteDevolucao = Convert.ToDateTime(txtDataDevolucao.Text),
                IdAluno = Aluno.Id,
                IdLivro = Livro.Id                
            };            

            if (emprestimo.IdAluno == 0)
            {
                MessageBox.Show("O aluno é obrigatório", "Erro ao salvar empréstimo", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (emprestimo.IdLivro == 0)
            {
                MessageBox.Show("O livro é obrigatório", "Erro ao salvar empréstimo", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (EmprestimoSelecionado.Id != 0)
                {
                    emprestimo.Id = EmprestimoSelecionado.Id;
                    viewModel.UpdateAsync(emprestimo);
                }
                else
                {
                    viewModel.AddAsync(emprestimo);
                }
                this.Close();
            }
        }

        private void BtnMenosDias_Click(object sender, RoutedEventArgs e)
        {
            txtDataDevolucao.Text = Convert.ToDateTime(txtDataDevolucao.Text).AddDays(-1).ToString();
        }

        private void BtnMaisDias_Click(object sender, RoutedEventArgs e)
        {
            txtDataDevolucao.Text = Convert.ToDateTime(txtDataDevolucao.Text).AddDays(1).ToString();
        }
    }
}
