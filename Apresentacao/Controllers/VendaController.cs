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

        [Route("/api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, [FromBody]EditarVendaDTO editarDto)
        {
            try
            {
                _servVenda.Editar(id, editarDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var livros = _servVenda.BuscarTodos();

                var venda = livros.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Valor = p.Valor,
                        Funcionario = p.Funcionario
                    }).ToList();

                return Ok(venda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var venda = _servVenda.BuscarPorId(id);

                return Ok(venda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                _servVenda.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    

}
}
