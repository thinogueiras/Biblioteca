using Biblioteca.Models.Tables;
using Biblioteca.Repository;
using MahApps.Metro.Controls;
using System;
using System.Collections;
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
    /// Lógica interna para EmprestimoWindow.xaml
    /// </summary>
    public partial class EmprestimosWindow : MetroWindow
    {
        public readonly EmprestimoRepository viewModel;

        public Emprestimo EmprestimoSelecionado { get; private set; }

        public EmprestimosWindow()
        {
            InitializeComponent();

            viewModel = new EmprestimoRepository();
            RefreshDataGrid();
        }        

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDevolver.IsEnabled = false;
            btnCancelar.IsEnabled = false;

            try
            {
                EmprestimoSelecionado = DataGrid.SelectedItem as Emprestimo;

                if (EmprestimoSelecionado != null && EmprestimoSelecionado.Status == StatusEnum.Aberto)
                {
                    btnDevolver.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private void RefreshDataGrid()
        {            
            DataGrid.ItemsSource = (System.Collections.IEnumerable)viewModel.GetAllAsync();
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            EmprestimoEditar editarWindow = new EmprestimoEditar();
            editarWindow.ShowDialog();
        }

        private void BtnDevolver_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desejaa devolver o livro?",
                                "Devolução de Livro",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question,
                                MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                EmprestimoSelecionado.DataDevolucao = DateTime.Now.ToLocalTime();
                EmprestimoSelecionado.Status = StatusEnum.Devolvido;
                _ = viewModel.UpdateAsync(EmprestimoSelecionado);
            }

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desejaa cancelar o empréstimo?",
                                "Cancelamento do Livro",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question,
                                MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                EmprestimoSelecionado.DataDevolucao = DateTime.Now.ToLocalTime();
                EmprestimoSelecionado.Status = StatusEnum.Cancelado;
                Task task = viewModel.UpdateAsync(EmprestimoSelecionado);
            }
        }
    }
}
