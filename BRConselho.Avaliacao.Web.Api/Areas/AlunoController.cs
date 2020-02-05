using BRConselho.Avaliacao.Model.Entity;
using BRConselho.Avaliacao.Model.Repository.IDao;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BRConselho.Avaliacao.Web.Api.Areas
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {
        private IAlunoDao iAlunoDao;
        private IPessoaDao iPessoaDao;
        private IAlunoProfessorDao iAlunoProfessorDao;

        public AlunoController(
            IAlunoDao iAlunoDao,
            IPessoaDao iPessoaDao,
            IAlunoProfessorDao iAlunoProfessorDao
        )
        {
            this.iAlunoDao = iAlunoDao;
            this.iPessoaDao = iPessoaDao;
            this.iAlunoProfessorDao = iAlunoProfessorDao;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ListAsync()
        {
            try
            {
                var res = await Task.Run(() => iAlunoDao.ObterTodos());
                foreach (var item in res)
                {
                    item.Pessoa = await Task.Run(() => iPessoaDao.ObterPorChave(item.IdPessoa));
                    item.Professor = await Task.Run(() => iAlunoDao.ObterProfessor(item.IdPessoa));
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("menores")]
        public async Task<IHttpActionResult> ListMenoresAsync()
        {
            try
            {
                var res = await Task.Run(() => iAlunoDao.ObterMenores());
                foreach (var item in res)
                {
                    item.Pessoa = await Task.Run(() => iPessoaDao.ObterPorChave(item.IdPessoa));
                    item.Professor = await Task.Run(() => iAlunoDao.ObterProfessor(item.IdPessoa));
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> GetItemById(long id)
        {
            try
            {
                var res = await Task.Run(() => iAlunoDao.ObterPorChave(id));
                if (res != null)
                    res.Professor = await Task.Run(() => iAlunoDao.ObterProfessor(res.IdPessoa));

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateItemAsync([FromBody]JObject posted)
        {
            try
            {
                string message = null;
                Aluno aluno = posted.ToObject<Aluno>();
                var res = await Task.Run(() => this.iAlunoDao.Inserir(aluno, out message));
                if (!string.IsNullOrEmpty(message))
                {
                    throw new Exception(message);
                }

                return Ok(new
                {
                    Id = res,
                    Message = "Registro salvo com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> UpdateItemAsync(long id, [FromBody]JObject posted)
        {
            try
            {
                if (id <= 0 || posted == null) throw new Exception("Nenhum aluno foi informado");

                string message = null;
                Aluno alunoNew = posted.ToObject<Aluno>();

                Aluno alunoOld = await Task.Run(() => iAlunoDao.ObterPorChave(id));

                if (alunoOld == null) throw new Exception("O aluno informado não está cadastrado.");

                await Task.Run(() => this.iAlunoDao.Alterar(alunoNew, out message));
                if (!string.IsNullOrEmpty(message))
                {
                    throw new Exception(message);
                }

                await Task.Run(() => this.iPessoaDao.Alterar(alunoNew.Pessoa, out message));
                if (!string.IsNullOrEmpty(message))
                {
                    throw new Exception(message);
                }

                await Task.Run(() => this.iAlunoProfessorDao.ExcluirLista(new
                {
                    IdAluno = alunoNew.IdPessoa
                }, out message));
                if (!string.IsNullOrEmpty(message))
                {
                    throw new Exception(message);
                }

                await Task.Run(() => this.iAlunoProfessorDao.InserirAlunoProfessor(new AlunoProfessor
                {
                    IdAluno = alunoNew.IdPessoa,
                    IdProfessor = alunoNew.Professor.IdPessoa
                }, out message));
                if (!string.IsNullOrEmpty(message))
                {
                    throw new Exception(message);
                }

                return Ok(new
                {
                    Id = id,
                    Message = "Registro atualizado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteItemAsync(long id)
        {
            try
            {
                if (id <= 0) throw new Exception("Nenhum aluno foi informado");

                string message = null;

                await Task.Run(() => this.iAlunoProfessorDao.ExcluirLista(new
                {
                    IdAluno = id
                }, out message));

                await Task.Run(() => this.iAlunoDao.Excluir(id, out message));

                if (!string.IsNullOrEmpty(message))
                {
                    throw new Exception(message);
                }

                return Ok(new
                {
                    Id = id,
                    Message = "Registro excluído com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
