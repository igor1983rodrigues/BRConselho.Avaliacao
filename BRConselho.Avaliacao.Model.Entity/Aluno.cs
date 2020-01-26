using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRConselho.Avaliacao.Model.Entity
{
    [Table("tb_aluno")]
    public class Aluno: PessoaBase
    {
        [Column("dt_nasc_aluno")]
        public DateTime DataNascimentoAluno { get; set; }

        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }
    }
}
