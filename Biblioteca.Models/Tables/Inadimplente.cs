using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models.Tables
{
    [Table("Inadimplente")]
    public class Inadimplente
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEmprestimo { get; set; }
        public int IdAluno { get; set; }
        public DateTime DataInadimplencia { get; set; }
        [MaxLength(2000)]
        public string Observacao { get; set; }

        [ForeignKey("IdEmprestimo")]
        public Emprestimo Emprestimos { get; set; }        
    }
}
