using BRConselho.Avaliacao.Model.DAO.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("tb_pessoa")]
    public class Pessoa: PessoaBase
    {
        [Required]
        [Column("nome_pessoa")]
        [StringLength(96, ErrorMessage = "O nome da pessoa deve ser menor que 96 caracteres.")]
        public string NomePessoa { get; set; }
    }
}
