using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServFuncionario
    {
        void Inserir(InserirFuncionarioDTO inserirFuncionarioDto);
        void Editar(int id, EditarFuncionarioDTO editarFuncionarioDto);
        List<Funcionario> BuscarTodos();
        Funcionario BuscarPorId(int id);
        void Remover(int id);
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

        public void Editar(int id, EditarFuncionarioDTO editarFuncionarioDto)
        {
            var funcionario = _repoFuncionario.BuscarPorId(id);

            funcionario.Email = editarFuncionarioDto.Email;

            _repoFuncionario.Editar(funcionario);
        }

        public List<Funcionario> BuscarTodos()
        {
            var funcionarios = _repoFuncionario.BuscarTodos();

            return funcionarios;
        }

        public Funcionario BuscarPorId(int id)
        {
            var funcionario = _repoFuncionario.BuscarPorId(id);

            return funcionario;
        }

        public void Remover(int id)
        {
            var funcionario = _repoFuncionario.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoFuncionario.Remover(funcionario);
        }


    }
}
