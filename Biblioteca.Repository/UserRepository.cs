using Biblioteca.Models.Tables;
using Biblioteca.Repository;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

public class UserRepository : BaseRepositorio<User>
{
    public UserRepository()
    {
        _ = SeedAsync();
    }
    public async Task<User> Login (User user)
    {
        return await _context.Usuario
            .Where(w => w.UserName == user.UserName &&
                        w.Password == user.Password)
            .FirstOrDefaultAsync();
    }

    public async Task SeedAsync()
    {
        if (!_context.Usuario.Any())
        {
            _context.Usuario.Add(new User { UserName = "admin", Password = "admin" });
            await _context.SaveChangesAsync();
        }
    }
}