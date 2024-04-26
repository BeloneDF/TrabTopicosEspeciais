using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private IServVenda _servVenda;

        public VendaController(IServVenda servVenda)
        {
            _servVenda = servVenda;
        }

        [HttpPost]
        public ActionResult Inserir(InserirVendaDTO inserirDto)
        {
            try
            {
                _servVenda.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
