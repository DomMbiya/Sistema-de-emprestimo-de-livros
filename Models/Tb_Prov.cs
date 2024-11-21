using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Prov
{
    public int Cod_Prov { get; set; }

    public string Provincia { get; set; }

    public virtual ICollection<Tb_Mun> Tb_Muns { get; set; } = new List<Tb_Mun>();
}
