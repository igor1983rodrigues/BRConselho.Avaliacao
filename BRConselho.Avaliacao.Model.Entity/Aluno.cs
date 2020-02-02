using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("tb_aluno")]
    public class Aluno: PessoaBase
    {
        [Key]
        [Column("oid_pessoa")]
        public long IdPessoa { get => Pessoa.IdPessoa; set => Pessoa.IdPessoa = value; }

        [NotMapped]
        public string NomePessoa { get => Pessoa.NomePessoa; set => Pessoa.NomePessoa = value; }

        [Column("dt_nasc_aluno")]
        public DateTime DataNascimentoAluno { get; set; }

        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }

        public Aluno() => Pessoa = new Pessoa();
    }
}
