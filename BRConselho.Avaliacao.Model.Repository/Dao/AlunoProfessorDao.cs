using BRConselho.Avaliacao.Extension;
using BRConselho.Avaliacao.Model.Entity;
using BRConselho.Avaliacao.Model.Repository.IDao;
using System;
using BRConselho.Avaliacao.Model.Repository.BaseDao;

namespace BRConselho.Avaliacao.Model.Repository.Dao
{
	public class AlunoProfessorDao : BaseAvaliacaoDaoRepository<AlunoProfessor>, IAlunoProfessorDao
	{
        public void InserirAlunoProfessor(AlunoProfessor model, out string mensagem, string strConnection = null)
        {
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                System.Data.Common.DbTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    mensagem = null;
                    conn.InsertIgnoreKey<long?, AlunoProfessor>(model, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    mensagem = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override void ExcluirLista(object obj, out string mensagem, string strConnection = null)
		{
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                try
                {
                    conn.Open();
                    conn.DeleteListIgnoreKey<AlunoProfessor>(obj);
                    mensagem = null;
                }
                catch (Exception ex)
                {
                    mensagem = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}