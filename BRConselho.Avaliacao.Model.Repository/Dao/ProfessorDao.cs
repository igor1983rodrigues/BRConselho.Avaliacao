using BRConselho.Avaliacao.Extension;
using BRConselho.Avaliacao.Model.Entity;
using BRConselho.Avaliacao.Model.Repository.BaseDao;
using BRConselho.Avaliacao.Model.Repository.IDao;
using BRConselho.Avaliacao.Model.Repository.ResourcesQueries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRConselho.Avaliacao.Model.Repository.Dao
{
	public class ProfessorDao : BaseAvaliacaoDaoRepository<Professor>, IProfessorDao
	{
        public override int Inserir(Professor model, out string mensagem, string strConnection = null)
        {
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                try
                {
                    conn.Open();
                    mensagem = null;
                    model.IdPessoa = conn.Insert(model.Pessoa) ?? 0;
                    if (model.IdPessoa == 0) throw new Exception("Erro ao inserir os dados. Entre em contato com o administrador.");
                    long? id = conn.InsertIgnoreKey<long?, Professor>(model) ?? 0;
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

        public override Professor ObterPorChave(object parametros, string strConnection = null)
        {
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                try
                {
                    conn.Open();
                    Professor professor = conn.Get<Professor>(parametros);

                    if (professor != null)
                    {
                        professor.Pessoa = conn.Get<Pessoa>(professor.IdPessoa);
                    }

                    return professor;
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

        public override void Alterar(Professor model, out string mensagem, string strConnection = null)
        {
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                try
                {
                    conn.Open();
                    int id = conn.Update(model.Pessoa);
                    if (id == 0) throw new Exception("Erro ao atualizar os dados. Entre em contato com o administrador.");
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

        public IEnumerable<Professor> GetProfessorMediaIdadeAlunos(int from, int to)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ProfessorQueries.GetProfessorMediaIdadeAlunos);
            sb.AppendLine("and\tProfessorTemp.MediaIdadeAlunos between @from and @to");

            string[] splitOn = new string[] { "IdPessoa" };
            Func<Professor, Pessoa, Professor> map = (professor, pessoa) => {
                professor.Pessoa = pessoa;
                return professor;
            };

            return ExecuteQuery(sb.ToString(), new
            {
                from,
                to
            }, map, splitOn);
        }
    }
}