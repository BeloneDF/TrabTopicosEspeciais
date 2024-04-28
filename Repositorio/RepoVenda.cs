using Entidades;

namespace Repositorio
{
    public interface IRepoVenda
    {
        void Inserir(Venda venda);
        void Editar(Venda venda);
        List<Venda> BuscarTodos();
        Venda BuscarPorId(int id);
        void Remover(Venda venda);
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
        public void Editar(Venda venda)
        {
            _dataContext.SaveChanges();
        }
        public List<Venda> BuscarTodos()
        {
            var vendas = _dataContext.Venda.ToList();

            return vendas;
        }

        public Venda BuscarPorId(int id)
        {
            var venda = _dataContext.Venda.Where(p => p.Id == id).FirstOrDefault();

            return venda;
        }

        public void Remover(Venda venda)
        {
            _dataContext.Remove(venda);

            _dataContext.SaveChanges();
        }

    }
}
