using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServVenda
    {
        void Inserir(InserirVendaDTO inserirVendaDto);

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
            venda.CodigoLivro = inserirVendaDto.CodigoLivro;

            _repoVenda.Inserir(venda);
        }

        
    }
}
