using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models.Tables
{
    [Table("Livro")]
    public class Livro
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Nome { get; set; }
        [Required, MaxLength(200)]
        public string Autor { get; set; }
        [Required, MaxLength(200)]        
        public string Editora { get; set; }
        public DateTime AnoPublicacao { get; set; }
        public int QtdExemplares { get; set; }

        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
