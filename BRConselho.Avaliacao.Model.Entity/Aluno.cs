using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("TB_ALUNO")]
    public class Aluno: Pessoa
    {
        [Column("DT_NASC_ALUNO")]
        public DateTime DataNascimentoAluno { get; set; }
    }
}
