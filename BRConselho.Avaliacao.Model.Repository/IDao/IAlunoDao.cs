using BRConselho.Avaliacao.Model.DAO.BaseInterface;
using BRConselho.Avaliacao.Model.Entity;
using System.Collections.Generic;

namespace BRConselho.Avaliacao.Model.Repository.IDao
{
    public interface IAlunoDao : IBaseDaoInterface<Aluno>
    {
        IEnumerable<Aluno> ObterAlunos(object param = null);
        Professor ObterProfessor(long idAluno);
        IEnumerable<Aluno> ObterMaiores();
    }
}