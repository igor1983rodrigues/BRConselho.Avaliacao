using BRConselho.Avaliacao.Model.Repository.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BRConselho.Avaliacao.Web.Api.Areas
{
    [RoutePrefix("/api/aluno")]
    public class AlunoController : ApiController
    {
        private IAlunoDao iAlunoDao;

        public AlunoController(IAlunoDao iAlunoDao) => this.iAlunoDao = iAlunoDao;
    
        [HttpGet]
        public async Task<IHttpActionResult> ListAsync()
        {
            try
            {
                var res = await Task.Run(() => iAlunoDao.ObterTodos());

                return Ok(new { resultado = "funcionou"});
//                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
