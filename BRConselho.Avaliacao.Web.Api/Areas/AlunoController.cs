﻿using BRConselho.Avaliacao.Model.Entity;
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

        public AlunoController(IAlunoDao iAlunoDao) => this.iAlunoDao = iAlunoDao;

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ListAsync()
        {
            try
            {
                var res = await Task.Run(() => iAlunoDao.ObterTodos());

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

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteItemAsync(long id)
        {
            try
            {
                if (id <= 0) throw new Exception("Nenhum aluno foi informado");

                string message = null;

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