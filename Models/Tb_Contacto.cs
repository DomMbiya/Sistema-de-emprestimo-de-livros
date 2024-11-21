using System;
using System.Collections.Generic;

namespace SistemaAtualEmprestimo.Models;

public partial class Tb_Contacto
{
    public int Id_Cliente { get; set; }

    public string Contacto { get; set; }

    public virtual Tb_Cliente Id_ClienteNavigation { get; set; }
}
