using Biblioteca.Models;
using Biblioteca.Models.Tables;
using Biblioteca.Repository;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Lógica interna para AlunoEditarWindow.xaml
    /// </summary>
    public partial class AlunoEditarWindow : MetroWindow
    {
        private readonly AlunoRepository viewModel;

        private Aluno alunoSelecionado;

        public AlunosWindow AlunoWindow { get; set; }

        public AlunoEditarWindow()
        {
            InitializeComponent();
            viewModel = new AlunoRepository();
            alunoSelecionado = new Aluno();
            Refresh();
        }

        public AlunoEditarWindow(Aluno alunoSelecionado) : this()
        {
            this.alunoSelecionado = alunoSelecionado;
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aluno aluno = new Aluno
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                DataMatricula = Convert.ToDateTime(txtDataMatricula.Text)
        };

            if (string.IsNullOrEmpty(aluno.Nome))
            {
                MessageBox.Show("O nome do aluno é obrigatório", "Erro ao salvar aluno", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (string.IsNullOrEmpty(aluno.CPF))
            {
                MessageBox.Show("O CPF é obrigatório", "Erro ao salvar aluno", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (alunoSelecionado.Id != 0)
                {
                    aluno.Id = alunoSelecionado.Id;
                    _ = viewModel.UpdateAsync(aluno);                                     
                }
                else
                {
                    _ = viewModel.AddAsync(aluno);
                }

                _ = AlunoWindow.RefreshDataGrid();
                this.Close();                
            }
        }
        public void Refresh()
        {
            txtNome.Text = alunoSelecionado.Nome;
            txtCPF.Text = alunoSelecionado.CPF;
            txtDataMatricula.Text = alunoSelecionado.DataMatricula.ToShortDateString();            
        }       
    }
}
