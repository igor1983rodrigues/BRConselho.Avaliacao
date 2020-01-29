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
                    model.Pessoa = null;
                    int id = conn.Insert(model) ?? 0;
                    if (id == 0) throw new Exception("Erro ao inserir os dados. Entre em contato com o administrador.");
                    return id;
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
	}
}