using BRConselho.Avaliacao.Extension;
using BRConselho.Avaliacao.Model.Entity;
using BRConselho.Avaliacao.Model.Repository.BaseDao;
using BRConselho.Avaliacao.Model.Repository.IDao;
using BRConselho.Avaliacao.Model.Repository.ResourcesQueries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRConselho.Avaliacao.Model.Repository.Dao
{
    public class AlunoDao : BaseAvaliacaoDaoRepository<Aluno>, IAlunoDao
    {
        public override int Inserir(Aluno model, out string mensagem, string strConnection = null)
        {
            using (var conn = ObterConexao(strConnection ?? StrConnection))
            {
                System.Data.Common.DbTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    mensagem = null;
                    model.IdPessoa = conn.Insert(model.Pessoa, transaction) ?? 0;
                    if (model.IdPessoa == 0) throw new Exception("Erro ao inserir os dados. Entre em contato com o administrador.");
                    long? id = conn.InsertIgnoreKey<long?, Aluno>(model, transaction) ?? 0;

                    if (model.Professor != null)
                    {
                        conn.Insert(new AlunoProfessor
                        {
                            IdAluno = model.IdPessoa,
                            IdProfessor = model.Professor.IdPessoa
                        }, transaction);
                    }

                    transaction.Commit();
                    return (int)model.IdPessoa;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    mensagem = ex.Message;
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public IEnumerable<Aluno> ObterAlunos(object param = null)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine(AlunoQueries.GetAlunos);
            if (param != null)
                param.GetType().GetProperties().AsList().ForEach(prop =>
                {
                    sbQuery.AppendLine($"and Aluno.{prop.Name} = @{prop.Name}");
                });

            Func<Aluno, Pessoa, AlunoProfessor, Professor, Pessoa, Aluno> map =
            (
                aluno,
                pessoaAluno,
                alunoProfessor,
                professor,
                pessoaProfessor
            ) =>
            {
                aluno.Pessoa = pessoaAluno;
                aluno.Professor = professor;
                aluno.Professor.Pessoa = pessoaProfessor;
                return aluno;
            };

            string[] splitOn = new string[] {
                "IdPessoa",
                "IdAluno",
                "IdProfessor",
                "IdPessoa"
            };

            IEnumerable<Aluno> res = ExecuteQuery(sbQuery.ToString(), param, map, splitOn);

            return res;
        }

        public IEnumerable<Aluno> ObterMenores()
        {
            var param = new
            {
                DateTime = DateTime.Today.AddYears(-16)
            }
            ;
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine(AlunoQueries.GetAlunos);
            sbQuery.AppendLine($"and Aluno.dt_nasc_aluno <= @DateTime");

            Func<Aluno, Pessoa, AlunoProfessor, Professor, Pessoa, Aluno> map =
            (
                aluno,
                pessoaAluno,
                alunoProfessor,
                professor,
                pessoaProfessor
            ) =>
            {
                aluno.Pessoa = pessoaAluno;
                aluno.Professor = professor;
                aluno.Professor.Pessoa = pessoaProfessor;
                return aluno;
            };

            string[] splitOn = new string[] {
                "IdPessoa",
                "IdAluno",
                "IdProfessor",
                "IdPessoa"
            };

            IEnumerable<Aluno> res = ExecuteQuery(sbQuery.ToString(), param, map, splitOn);

            return res;
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

        public Professor ObterProfessor(long idAluno)
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine(AlunoQueries.GetProfessor);
            Func<AlunoProfessor, Professor, Pessoa, Professor> map =
            (
                alunoProfessor,
                professor,
                pessoaProfessor
            ) =>
            {
                professor.Pessoa = pessoaProfessor;
                return professor;
            };

            string[] splitOn = new string[] {
                "IdAluno",
                "IdProfessor",
                "IdPessoa"
            };

            IEnumerable<Professor> res = ExecuteQuery(sbQuery.ToString(), new {
                IdAluno = idAluno
            }, map, splitOn);

            return res.FirstOrDefault();
        }
    }
}