using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServFuncionario
    {
        void Inserir(InserirFuncionarioDTO inserirFuncionarioDto);

    }

    public class ServFuncionario : IServFuncionario
    {
        private IRepoFuncionario _repoFuncionario;

        public ServFuncionario(IRepoFuncionario repoFuncionario)
        {
            _repoFuncionario = repoFuncionario;
        }

        public void Inserir(InserirFuncionarioDTO inserirFuncionarioDto)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = inserirFuncionarioDto.Nome;
            funcionario.CPF = inserirFuncionarioDto.CPF;
            funcionario.Nascimento = inserirFuncionarioDto.Nascimento;
            funcionario.Email = inserirFuncionarioDto.Email;

            _repoFuncionario.Inserir(funcionario);
        }

        
    }
}
