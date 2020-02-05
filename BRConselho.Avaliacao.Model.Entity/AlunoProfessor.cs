using BRConselho.Avaliacao.Model.DAO.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("tb_aluno_professor")]
    public class AlunoProfessor: BaseEntity
    {
        [Key, Column("oid_aluno", Order = 1)]
        public long IdAluno { get; set; }

        [Key, Column("oid_professor", Order = 1)]
        public long IdProfessor { get; set; }

        [ForeignKey("IdAluno")]
        public Aluno Aluno { get; set; }

        [ForeignKey("IdProfessor")]
        public Professor Professor { get; set; }
    }
}
