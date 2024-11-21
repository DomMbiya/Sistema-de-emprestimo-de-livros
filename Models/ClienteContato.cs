
namespace SistemaAtualEmprestimo.Models
{
    public class ClienteContato
    {
        //public List<Tb_Mun> Municipios { get; set; }= new List<Tb_Mun> { };
        public Tb_Cliente Tb_Cliente { get; set; } = new Tb_Cliente();

        public List<Tb_Contacto> Tb_Contacto { get; set; } = new List<Tb_Contacto>();

        public Tb_Mun Tb_Mun { get; set; } = new Tb_Mun();
        public List <Tb_Mun> Municipios { get; set; }= new List<Tb_Mun>();

        public string Nome { get; set; }
        public string Municipio{ get; set; }
        public int Contacto { get; set; }
        public string Bi { get; set; }
    }
}
