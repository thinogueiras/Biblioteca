using Biblioteca.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public class AlunoRepository : BaseRepositorio<Aluno>
    {
        public async Task<List<Aluno>> GetAllAsync()
        {
            return await _context.Aluno.OrderBy(x => x.Nome).ToListAsync();
        }

        public void Delete(Aluno alunoSelecionado)
        {
            throw new NotImplementedException();
        }
    }
}
