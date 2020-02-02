using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("tb_professor")]
    public class Professor: PessoaBase
    {
        [Key]
        [Column("oid_pessoa")]
        public long IdPessoa { get => Pessoa.IdPessoa; set => Pessoa.IdPessoa = value; }

        [NotMapped]
        public string NomePessoa { get => Pessoa.NomePessoa; set => Pessoa.NomePessoa = value; }

        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }

        public Professor() => Pessoa = new Pessoa();
    }
}