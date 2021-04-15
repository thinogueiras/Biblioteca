using Biblioteca.Models.Tables;
using Biblioteca.Repository;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Configuration;

namespace Biblioteca.WPF
{
    /// <summary>
    /// Lógica interna para AlunosWindow.xaml
    /// </summary>
    public partial class AlunosWindow : MetroWindow
    {        
        private readonly AlunoRepository viewModel;        

        public Aluno AlunoSelecionado { get;  private set; }

        public AlunosWindow()
        {                      
            InitializeComponent();
            viewModel = new AlunoRepository();
            _ = RefreshDataGrid();            
        }       

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            AlunoEditarWindow editarWindow = new AlunoEditarWindow();
            editarWindow.AlunoWindow = this;
            editarWindow.ShowDialog();
            _ = RefreshDataGrid();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            AlunoEditarWindow editarWindow = new AlunoEditarWindow(AlunoSelecionado);
            editarWindow.AlunoWindow = this;
            editarWindow.ShowDialog();            
            _ = RefreshDataGrid();            
        }

        private void BtnDeletar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Deseja excluir permanentemente o aluno {AlunoSelecionado.Nome}?","Excluir Aluno", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                _ = viewModel.DeleteAsync(AlunoSelecionado);
                _ = RefreshDataGrid();
            }
        }

        public async Task RefreshDataGrid()
        {
            myDataGrid.ItemsSource = null;
            var list = await viewModel.GetAllRecordsAsync();
            myDataGrid.ItemsSource = (System.Collections.IEnumerable)list;            
        }
        
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AlunoSelecionado = myDataGrid.SelectedItem as Aluno;
                if (AlunoSelecionado == null)
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
