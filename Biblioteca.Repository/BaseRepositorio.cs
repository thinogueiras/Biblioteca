using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public class BaseRepositorio<T> where T : class
    {
        public readonly BibliotecaContext _context;
        public BaseRepositorio()
        {
            _context = new BibliotecaContext();
        }

        public async Task<List<T>> GetAllRecordsAsync()
        {
            return await _context.Set<T>().ToListAsync();            
        }

        public async Task<T> GetDetailAsync(int Id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync();//where(w=>w.Id = Id).FirtOrDefault();
        }

        public async Task AddAsync(T record)
        {
            _context.Set<T>().Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T record)
        {
            _context.Entry<T>(record).State = EntityState.Modified;
            await _context.SaveChangesAsync();            
        }

        public async Task DeleteAsync(T record)
        {
            _context.Set<T>().Remove(record);
            await _context.SaveChangesAsync();
        }
    }
}
