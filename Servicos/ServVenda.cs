using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServVenda
    {
        void Inserir(InserirVendaDTO inserirVendaDto);
        void Editar(int id, EditarVendaDTO editarVendaDto);
        List<Venda> BuscarTodos();
        Venda BuscarPorId(int id);
        void Remover(int id);

    }

    public class ServVenda : IServVenda
    {
        private IRepoVenda _repoVenda;

        public ServVenda(IRepoVenda repoVenda)
        {
            _repoVenda = repoVenda;
        }

        public void Inserir(InserirVendaDTO inserirVendaDto)
        {
            var venda = new Venda();

            venda.Id = inserirVendaDto.Id;
            venda.Valor = inserirVendaDto.Valor;
            venda.CodigoLivro = inserirVendaDto.CodigoLivro;
            venda.CodigoFuncionario = inserirVendaDto.CodigoFuncionario;

            _repoVenda.Inserir(venda);
        }

        public void Editar(int id, EditarVendaDTO editarVendaDto)
        {
            var venda = _repoVenda.BuscarPorId(id);

            venda.Valor = editarVendaDto.Valor;
            venda.CodigoFuncionario = editarVendaDto.CodigoFuncionario;

            _repoVenda.Editar(venda);
        }

        public List<Venda> BuscarTodos()
        {
            var venda = _repoVenda.BuscarTodos();

            return venda;
        }

        public Venda BuscarPorId(int id)
        {
            var venda = _repoVenda.BuscarPorId(id);

            return venda;
        }
        public void Remover(int id)
        {
            var venda = _repoVenda.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoVenda.Remover(venda);
        }

    }
}
