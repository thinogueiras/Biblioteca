using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models.Tables
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Nome { get; set; }
        [Required, MaxLength(15)]
        public string CPF { get; set; }
        public DateTime DataMatricula { get; set; }

        public ICollection<Emprestimo> Emprestimos { get; set; }

        public ICollection<Inadimplente> Inadimplentes { get; set; }
        
    }
}
