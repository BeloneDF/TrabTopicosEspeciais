using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServLivro
    {
        void Inserir(InserirLivroDTO inserirLivroDto);
        void Editar(int id, EditarLivroDTO editarLivroDto);
        List<Livro> BuscarTodos();
        Livro BuscarPorId(int id);
        void Remover(int id);

    }

    public class ServLivro : IServLivro
    {
        private IRepoLivro _repoLivro;

        public ServLivro(IRepoLivro repoLivro)
        {
            _repoLivro = repoLivro;
        }

        public void Inserir(InserirLivroDTO inserirLivroDto)
        {
            var livro = new Livro();

            livro.Titulo = inserirLivroDto.Titulo;
            livro.Autor = inserirLivroDto.Autor;
            livro.Genero = inserirLivroDto.Genero;
            livro.Editora= inserirLivroDto.Editora;
            livro.Publicacao = inserirLivroDto.Publicacao;
            livro.Preco = inserirLivroDto.Preco;

            ValidacoesAntesDeInserir(livro);

            _repoLivro.Inserir(livro);
        }

        public void ValidacoesAntesDeInserir(Livro livro)
        {
            if (livro.Titulo.Length < 4)
            {
                throw new Exception("Nome inválido. Deve possuir no mínimo 4 caracteres.");
            }
        }

        public void Editar(int id, EditarLivroDTO editarLivroDto)
        {
            var livro = _repoLivro.BuscarPorId(id);

            livro.Preco = editarLivroDto.Preco;

            _repoLivro.Editar(livro);
        }

        public List<Livro> BuscarTodos()
        {
            var livros = _repoLivro.BuscarTodos();

            return livros;
        }

        public Livro BuscarPorId(int id)
        {
            var livro = _repoLivro.BuscarPorId(id);

            return livro;
        }


        public void Remover(int id)
        {
            var livro = _repoLivro.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoLivro.Remover(livro);
        }

        
    }
}
