using BRConselho.Avaliacao.Model.DAO.Entity;
using System.Collections.Generic;

namespace BRConselho.Avaliacao.Model.DAO.BaseInterface
{
    public interface IBaseDaoInterface<T> where T: BaseEntity
    {
        int Inserir(T model, out string mensagem, string strConnection = null);
        void Alterar(T model, out string mensagem, string strConnection = null);
        void Excluir(object obj, out string mensagem, string strConnection = null);
        void ExcluirLista(object obj, out string mensagem, string strConnection = null);
        T ObterPorChave(object parametros, string strConnection = null);
        IEnumerable<T> Obter(object parametros, string strConnection = null);
        IEnumerable<T> ObterTodos(string strConnection = null);
    }
}
