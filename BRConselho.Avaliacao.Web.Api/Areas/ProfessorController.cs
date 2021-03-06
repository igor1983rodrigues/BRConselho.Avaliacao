﻿using BRConselho.Avaliacao.Model.Entity;
using BRConselho.Avaliacao.Model.Repository.IDao;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BRConselho.Avaliacao.Web.Api.Areas
{
    [RoutePrefix("api/professor")]
    public class ProfessorController : ApiController
    {
        private IProfessorDao iProfessorDao;
        private IPessoaDao iPessoaDao;

        public ProfessorController(
            IProfessorDao iProfessorDao,
            IPessoaDao iPessoaDao)
        {
            this.iProfessorDao = iProfessorDao;
            this.iPessoaDao = iPessoaDao;
        }

        [HttpGet]
        [Route("idadealuno/{from:int}/{to:int}")]
        public IHttpActionResult GetProfessorMediaIdadeAlunos(int from, int to)
        {
            try
            {
                var res = iProfessorDao.GetProfessorMediaIdadeAlunos(from, to);

                return Ok(res);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ListAsync()
        {
            try
            {
                var res = await Task.Run(() => iProfessorDao.ObterTodos());
                foreach (var item in res)
                {
                    item.Pessoa = await Task.Run(() => iPessoaDao.ObterPorChave(item.IdPessoa));
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
                var res = await Task.Run(() => iProfessorDao.ObterPorChave(id));

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
                Professor professor = posted.ToObject<Professor>();
                var res = await Task.Run(() => this.iProfessorDao.Inserir(professor, out message));
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
                if (id <= 0 || posted == null) throw new Exception("Nenhum professor foi informado");

                string message = null;
                Professor professorNew = posted.ToObject<Professor>();

                Professor professorOld = await Task.Run(() => iProfessorDao.ObterPorChave(id));

                if (professorOld == null) throw new Exception("O professor informado não está cadastrado.");

                await Task.Run(() => this.iProfessorDao.Alterar(professorNew, out message));

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
                if (id <= 0) throw new Exception("Nenhum professor foi informado");

                string message = null;

                await Task.Run(() => this.iProfessorDao.Excluir(id, out message));

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