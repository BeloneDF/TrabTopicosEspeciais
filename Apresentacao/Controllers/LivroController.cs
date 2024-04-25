using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private IServLivro _servLivro;

        public LivroController(IServLivro servLivro)
        {
            _servLivro = servLivro;
        }

        [HttpPost]
        public ActionResult Inserir(InserirLivroDTO inserirDto)
        {
            try
            {
                _servLivro.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, [FromBody]EditarLivroDTO editarDto)
        {
            try
            {
                _servLivro.Editar(id, editarDto);

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
                var livros = _servLivro.BuscarTodos();

                var pizzariaEnxuta = livros.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Titulo = p.Titulo
                    }).ToList();

                return Ok(pizzariaEnxuta);
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
                var pizzaria = _servLivro.BuscarPorId(id);

                return Ok(pizzaria);
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
                _servLivro.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
