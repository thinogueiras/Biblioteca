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
    /// Lógica interna para LivrosWindow.xaml
    /// </summary>
    public partial class LivrosWindow : MetroWindow
    {
        private readonly LivroRepository viewModel;
        public Livro LivroSelecionado { get; private set; }
        public LivrosWindow()
        {
            InitializeComponent();
            viewModel = new LivroRepository();
            RefreshDataGrid();          
                 
        }

        private void BtnDeletar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Deseja excluir permanentemente o livro {LivroSelecionado.Nome}?", "Excluir livro", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                _ = viewModel.DeleteAsync(LivroSelecionado);
                RefreshDataGrid();
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            LivroEditarWindow editarWindow = new LivroEditarWindow(LivroSelecionado);
            editarWindow.ShowDialog();
            RefreshDataGrid();
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            LivroEditarWindow editarWindow = new LivroEditarWindow();
            editarWindow.ShowDialog();
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            DataGrid.ItemsSource = (System.Collections.IEnumerable)viewModel.GetAllRecordsAsync();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                LivroSelecionado = DataGrid.SelectedItem as Livro;
                if (LivroSelecionado == null)
                {
                    btnEditar.IsEnabled = false;
                    btnDeletar.IsEnabled = false;
                }
                else
                {
                    btnEditar.IsEnabled = true;
                    btnDeletar.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
