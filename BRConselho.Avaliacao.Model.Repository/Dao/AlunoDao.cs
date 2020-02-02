using BRConselho.Avaliacao.Extension;
using BRConselho.Avaliacao.Model.Entity;
using BRConselho.Avaliacao.Model.Repository.BaseDao;
using BRConselho.Avaliacao.Model.Repository.IDao;
using Dapper;
using System;

namespace BRConselho.Avaliacao.Model.Repository.Dao
{
	public class AlunoDao : BaseAvaliacaoDaoRepository<Aluno>, IAlunoDao
	{
		public override int Inserir(Aluno model, out string mensagem, string strConnection = null)
		{
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                try
                {
                    conn.Open();
                    mensagem = null;
                    model.IdPessoa = conn.Insert(model.Pessoa) ?? 0;
                    if (model.IdPessoa == 0) throw new Exception("Erro ao inserir os dados. Entre em contato com o administrador.");
                    long? id = conn.InsertIgnoreKey<long?, Aluno>(model) ?? 0;
                    return (int)model.IdPessoa;
                }
                catch (Exception ex)
                {
                    mensagem = ex.Message;
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override Aluno ObterPorChave(object parametros, string strConnection = null)
        {
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                try
                {
                    conn.Open();
                    Aluno aluno = conn.Get<Aluno>(parametros);

                    if (aluno != null)
                    {
                        aluno.Pessoa = conn.Get<Pessoa>(aluno.IdPessoa);
                    }

                    return aluno;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}