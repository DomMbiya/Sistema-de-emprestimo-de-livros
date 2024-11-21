using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Pag_Multum
{
    public int Id_Pag_Multa { get; set; }

    public int? Id_Multa { get; set; }

    public DateTime? data_pag_multa { get; set; }

    public int? Id_Devolucao { get; set; }

    public bool Estado { get; set; }

    public virtual Tb_Devolucao Id_DevolucaoNavigation { get; set; }

    public virtual Tb_Multum Id_MultaNavigation { get; set; }
}
