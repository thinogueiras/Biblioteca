using Biblioteca.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Biblioteca.Repository
{
    public class EmprestimoRepository : BaseRepositorio<Emprestimo>
    {
        public async Task<List<Emprestimo>> GetAllAsync()
        {
            return await _context.Set<Emprestimo>().Include("Aluno").Include("Livro").ToListAsync();                
        }
    }
}
