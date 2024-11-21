using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Mun
{
    public int Cod_Mun { get; set; }

    public string Municipio { get; set; }

    public int? Cod_Prov { get; set; }

    public virtual Tb_Prov Cod_ProvNavigation { get; set; }

    public virtual ICollection<Tb_Cliente> Tb_Clientes { get; set; } = new List<Tb_Cliente>();

  
}
