using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Repository
{
    public class RepositoryMunicipio : IRepositoryMunicipio
    {
        private readonly EmprestimoAtualContext _context;

        public RepositoryMunicipio(EmprestimoAtualContext context)
        {
            _context = context;
        }

        public IEnumerable<Tb_Mun> GetMunicipios()
        {
            return _context.Tb_Muns.ToList();
        }

        public Tb_Mun GetMunicipioById(int id)
        {
            return _context.Tb_Muns.Find(id);
        }

        public async Task<List<Tb_Mun>> GetMunicipiosAsync()
        {
            return await _context.Tb_Muns.ToListAsync();
        }
    }

}
