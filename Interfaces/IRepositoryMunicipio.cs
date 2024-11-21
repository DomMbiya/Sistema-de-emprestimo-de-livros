using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IRepositoryMunicipio
    {
        IEnumerable<Tb_Mun> GetMunicipios();
        Tb_Mun GetMunicipioById(int id);
        Task<List<Tb_Mun>> GetMunicipiosAsync();


    }

}
