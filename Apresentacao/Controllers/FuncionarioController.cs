using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IServFuncionario _servFuncionario;

        public FuncionarioController(IServFuncionario servFuncionario)
        {
            _servFuncionario = servFuncionario;
        }

        [HttpPost]
        public ActionResult Inserir(InserirFuncionarioDTO inserirFuncionarioDto)
        {
            try
            {
                _servFuncionario.Inserir(inserirFuncionarioDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
