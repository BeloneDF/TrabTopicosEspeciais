namespace Entidades
{
    public class Funcionario
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Nascimento { get; set; }

        public int CodigoVenda { get; set; }

        public Venda Venda { get; set; }

    }
}
