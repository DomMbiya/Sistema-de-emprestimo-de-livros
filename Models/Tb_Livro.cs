using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Livro
{
    public int Id_Livro { get; set; }

    public string Nome { get; set; }

    public string Autor { get; set; }

    public string Editora { get; set; }

    public int Edicao { get; set; }

    public int Qtd { get; set; }

    public DateTime data_lancamento { get; set; }

    public DateTime data_criacao { get; set; }

    public bool? estado { get; set; }

    public virtual ICollection<Tb_LivroCliente> Tb_LivroClientes { get; set; } = new List<Tb_LivroCliente>();
}
