using BRConselho.Avaliacao.Model.DAO.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("TB_PESSOA")]
    public class Pessoa: BaseEntity
    {
        [Key]
        [Column("OID_PESSOA")]
        public long IdPessoa { get; set; }

        [Required]
        [Column("NOME_PESSOA")]
        [StringLength(96, ErrorMessage = "O nome da pessoa deve ser menor que 96 caracteres.")]
        public string NomePessoa { get; set; }
    }
}
