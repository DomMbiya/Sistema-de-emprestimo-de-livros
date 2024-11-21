using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_LivroCliente
{
    public int Id_LivroCliente { get; set; }

    public int? Id_Livro { get; set; }

    public int? Id_Cliente { get; set; }

    public DateTime data_emprestimo { get; set; }

    public DateTime data_devolucao { get; set; }

    public bool entregue { get; set; }

    public int? Qtd { get; set; }

    public virtual Tb_Cliente Id_ClienteNavigation { get; set; }

    public virtual Tb_Livro Id_LivroNavigation { get; set; }

    public virtual ICollection<Tb_Devolucao> Tb_Devolucaos { get; set; } = new List<Tb_Devolucao>();
}
