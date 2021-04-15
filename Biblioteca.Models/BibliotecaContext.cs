using Biblioteca.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Biblioteca;Integrated Security=True;")
        {
            //this.Configuration.LazyLoadingEnabled = false; 
            //Desativar carregamento lento para todas as entidades
            //{
            //    using (var context = new BibliotecaContext())
            //    {
            //        var alunos = context.Emprestimo.Include(b => b.Alunos).ToList();
            //        var livros = context.Emprestimo.Include(c => c.Livros).ToList();
            //    }
            //}
        }        

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Livro> Livro { get; set; }        
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Inadimplente> Inadimplente { get; set; }
        public DbSet<User> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprestimo>()//
                .HasRequired (e => e.Aluno)//Um empréstimo obrigatoriamente precisar ter um aluno
                .WithMany(a => a.Emprestimos);//O aluno esta em muitos empréstimos

            modelBuilder.Entity<Emprestimo>()
                .HasRequired(e => e.Livro)
                .WithMany(a => a.Emprestimos);

            base.OnModelCreating(modelBuilder);
        }


        //public static void Run()
        //{
        //    using (BibliotecaContext db = new BibliotecaContext())
        //    {
        //        var al = from a in db.Emprestimo.Include(a => a.Alunos)
        //                 select a;
        //        var li = from b in db.Emprestimo.Include(b => b.Livros)
        //                 select b;
        //    }
        //}
    }
}
