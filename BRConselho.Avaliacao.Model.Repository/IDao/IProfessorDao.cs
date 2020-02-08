using BRConselho.Avaliacao.Model.DAO.BaseInterface;
using BRConselho.Avaliacao.Model.Entity;
using System.Collections.Generic;

namespace BRConselho.Avaliacao.Model.Repository.IDao
{
    public interface IProfessorDao : IBaseDaoInterface<Professor>
    {
        IEnumerable<Professor> GetProfessorMediaIdadeAlunos(int from, int to);
    }
}