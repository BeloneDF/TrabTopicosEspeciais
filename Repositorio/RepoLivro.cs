using Entidades;

namespace Repositorio
{
    public interface IRepoLivro
    {
        void Inserir(Livro livro);
        void Editar(Livro livro);
        List<Livro> BuscarTodos();
        Livro BuscarPorId(int id);

        void Remover(Livro livro);
    }

    public class RepoLivro : IRepoLivro
    {
        private DataContext _dataContext;

        public RepoLivro(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Livro livro)
        {
            _dataContext.Add(livro);

            _dataContext.SaveChanges();
        }

        public void Editar(Livro livro)
        {
            _dataContext.SaveChanges();
        }

        public List<Livro> BuscarTodos()
        {
            var livros = _dataContext.Livro.ToList();

            return livros;
        }

        public Livro BuscarPorId(int id)
        {
            var livro = _dataContext.Livro.Where(p => p.Id == id).FirstOrDefault();

            return livro;
        }

        public void Remover(Livro livro)
        {
            _dataContext.Remove(livro);

            _dataContext.SaveChanges();
        }
    }
}
