using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Multum
{
    public int Id_Multa { get; set; }

    public string Valor { get; set; }

    public virtual ICollection<Tb_Pag_Multum> Tb_Pag_Multa { get; set; } = new List<Tb_Pag_Multum>();
}
