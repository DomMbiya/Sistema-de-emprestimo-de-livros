using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Devolucao
{
    public int Id_Devolucao { get; set; }

    public int Id_LivroCliente { get; set; }

    public DateTime? data_entregue { get; set; }

    public int Qtd { get; set; }

    public virtual Tb_LivroCliente Id_LivroClienteNavigation { get; set; }

    public virtual ICollection<Tb_Pag_Multum> Tb_Pag_Multa { get; set; } = new List<Tb_Pag_Multum>();
}
