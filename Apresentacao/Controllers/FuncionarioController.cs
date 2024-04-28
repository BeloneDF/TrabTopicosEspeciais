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

        [Route("/api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, [FromBody]EditarFuncionarioDTO editarFuncionarioDto)
        {
            try
            {
                _servFuncionario.Editar(id, editarFuncionarioDto);

                return Ok();
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
                var funcionario = _servFuncionario.BuscarPorId(id);

                return Ok(funcionario);
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
                var funcionarios = _servFuncionario.BuscarTodos();

                var funcionarioEnxuto = funcionarios.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Nome = p.Nome
                    }).ToList();

                return Ok(funcionarioEnxuto);
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
                _servFuncionario.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
