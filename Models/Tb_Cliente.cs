using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Cliente
{
    public int Id_Cliente { get; set; }

    public string Bi { get; set; }

    public string Nome { get; set; }

    public int? Cod_Mun { get; set; }

    public virtual Tb_Mun Cod_MunNavigation { get; set; }

    public virtual ICollection<Tb_Contacto> Tb_Contactos { get; set; } = new List<Tb_Contacto>();

    public virtual ICollection<Tb_LivroCliente> Tb_LivroClientes { get; set; } = new List<Tb_LivroCliente>();

    
}
