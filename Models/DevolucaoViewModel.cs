namespace SistemaAtualEmprestimo.Models
{
    public class DevolucaoViewModel
    {
        public int IdLivroCliente { get; set; }
        public int qtd { get; set; }

        public string Retorno { get; set; }

        public Tb_LivroCliente oLivroCliente { get; set; } = new Tb_LivroCliente();
        public List<Tb_LivroCliente> oListLivroCliente { get; set; } = new List<Tb_LivroCliente>();

        public Tb_Devolucao oDevolucao { get; set; } = new Tb_Devolucao();

        public List<Tb_Devolucao> oListDevolucao { get; set; } = new List<Tb_Devolucao>();

        public Tb_Livro oLivro { get; set; } = new Tb_Livro();
        public Tb_Cliente oCliente { get; set; } = new Tb_Cliente();

        public List<Tb_Cliente> oListCliente { get; set; } = new List<Tb_Cliente>();

        public List<Tb_Livro> oListLivro { get; set; } = new List<Tb_Livro>();

        public string NomeCliente { get; set; }
        public string TituloLivro { get; set; }

    }
}
