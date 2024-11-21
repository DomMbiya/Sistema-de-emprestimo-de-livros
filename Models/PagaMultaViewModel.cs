namespace SistemaAtualEmprestimo.Models
{
    public class PagaMultaViewModel
    {
        public Tb_Devolucao oDevolucao { get; set; } = new Tb_Devolucao();
        public int Id_Pag_Multa { get; set; }
        public Tb_Multum oMultum{ get; set; } = new Tb_Multum();

        public Tb_Pag_Multum oPagMultum { get; set; } = new Tb_Pag_Multum();
        public List<Tb_Pag_Multum> oListPagMultum { get; set; } = new List<Tb_Pag_Multum>();
        public List<Tb_Devolucao> oListDevolucao { get; set; } = new List<Tb_Devolucao>();

        public List<Tb_Multum> oListMultum { get; set; } = new List<Tb_Multum>();

        public int qtd { get; set; }

        public string Retorno { get; set; }

        public Tb_Livro oLivro { get; set; } = new Tb_Livro();
        public Tb_Cliente oCliente { get; set; } = new Tb_Cliente();

        public string NomeCliente { get; set; }
        public string NumeroBI { get; set; }

        public int Valor { get; set; }

        public Tb_LivroCliente oLivroCliente { get; set; } = new Tb_LivroCliente();
        public List<Tb_LivroCliente> oListLivroCliente { get; set; } = new List<Tb_LivroCliente>();

    }
}
