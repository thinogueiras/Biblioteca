using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models.Tables
{
    [Table("Emprestimo")]
    public class Emprestimo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public int IdLivro { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimiteDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        [MaxLength(2000)]
        public string Observacao { get; set; }

        [ForeignKey("IdAluno")]
        public Aluno Aluno { get; set; }

        [ForeignKey("IdLivro")]
        public Livro Livro { get; set; }
    }
    public enum StatusEnum
    {
        Aberto,
        Devolvido,
        Cancelado
    }
}
