namespace Entidades
{
    public class Venda
    {
        public int Id { get; set; }

        public int Valor { get; set; }

        public int CodigoLivro { get; set; }

        public Livro Livro { get; set; }


    }
}
