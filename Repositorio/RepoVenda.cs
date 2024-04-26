using Entidades;

namespace Repositorio
{
    public interface IRepoVenda
    {
        void Inserir(Venda venda);
    }

    public class RepoVenda : IRepoVenda
    {
        private DataContext _dataContext;

        public RepoVenda(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Venda venda)
        {
            _dataContext.Add(venda);

            _dataContext.SaveChanges();
        }

    }
}
