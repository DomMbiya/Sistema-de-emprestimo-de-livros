namespace SistemaAtualEmprestimo.Models
{
    
        public class EmprestimoViewModel
        {
            public int IdLivro { get; set; }
            public int IdCliente { get; set; }
            public int qtd { get; set; }
            public string Retorno { get; set; } 

        public Tb_Livro oLivro { get; set; } = new Tb_Livro();
        public Tb_Cliente oCliente { get; set; } = new Tb_Cliente();

        public Tb_Contacto oContato { get; set; } = new Tb_Contacto();
        public ClienteContato oClienteContato { get; set; } = new ClienteContato();

        public List<Tb_Cliente> oListCliente { get; set; } = new List<Tb_Cliente>();

        public List<Tb_Livro> oListLivro { get; set; } = new List<Tb_Livro>();

        public List<Tb_Contacto> oListContacto { get; set; } = new List<Tb_Contacto>();
        public List<ClienteContato> oListClienteContato { get; set; }= new List<ClienteContato>();


    }

    
}
