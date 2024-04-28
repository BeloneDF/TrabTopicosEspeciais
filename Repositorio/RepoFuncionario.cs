using Entidades;

namespace Repositorio
{
    public interface IRepoFuncionario
    {
        void Inserir(Funcionario funcionario);
        void Editar(Funcionario funcionario);
        List<Funcionario> BuscarTodos();
        void Remover(Funcionario funcionario);
        Funcionario BuscarPorId(int id);
    }

    public class RepoFuncionario : IRepoFuncionario
    {
        private DataContext _dataContext;

        public RepoFuncionario(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Funcionario funcionario)
        {
            _dataContext.Add(funcionario);

            _dataContext.SaveChanges();
        }
        public Funcionario BuscarPorId(int id)
        {
            var funcionario = _dataContext.Funcionario.Where(p => p.Id == id).FirstOrDefault();

            return funcionario;
        }

        public void Editar(Funcionario funcionario)
        {
            _dataContext.SaveChanges();
        }

        public List<Funcionario> BuscarTodos()
        {
            var funcionarios = _dataContext.Funcionario.ToList();

            return funcionarios;
        }

        public void Remover(Funcionario funcionario)
        {
            _dataContext.Remove(funcionario);

            _dataContext.SaveChanges();
        }
    }
}
