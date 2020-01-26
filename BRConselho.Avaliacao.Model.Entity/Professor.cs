using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("tb_professor")]
    public class Professor: PessoaBase
    {
        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }
    }
}