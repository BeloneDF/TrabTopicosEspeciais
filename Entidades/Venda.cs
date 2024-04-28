namespace Entidades
{
    public class Venda
    {
        public int Id { get; set; }

        public string Valor { get; set; }

        public int CodigoLivro { get; set; }

        public int CodigoFuncionario { get; set; }

        public Funcionario Funcionario { get; set; }

        public Livro Livro { get; set; }


    }
}
