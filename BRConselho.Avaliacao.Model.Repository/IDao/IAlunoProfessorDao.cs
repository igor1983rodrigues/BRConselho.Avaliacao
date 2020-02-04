using BRConselho.Avaliacao.Model.DAO.BaseInterface;
using BRConselho.Avaliacao.Model.Entity;

namespace BRConselho.Avaliacao.Model.Repository.IDao
{
    public interface IAlunoProfessorDao : IBaseDaoInterface<AlunoProfessor>
    {
        void InserirAlunoProfessor(AlunoProfessor model, out string mensagem, string strConnection = null);
    }
}