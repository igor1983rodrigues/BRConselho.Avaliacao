using BRConselho.Avaliacao.Model.DAO.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    public abstract class PessoaBase: BaseEntity
    {
        [Key]
        [Column("oid_pessoa")]
        public long IdPessoa { get; set; }

    }
}
