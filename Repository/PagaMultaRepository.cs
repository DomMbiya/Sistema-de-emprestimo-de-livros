using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Repository
{
    public class PagaMultaRepository: IPagaMultaRepository
    {
        private readonly EmprestimoAtualContext _context;

        public PagaMultaRepository(EmprestimoAtualContext context)
        {
            _context = context;
        }

        public async Task<bool> PagarMultaAsync(int idPagMulta)
        {
            var multa = await _context.Tb_Pag_Multa.FindAsync(idPagMulta);
            if (multa == null) return false;

            multa.Estado = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PagaMultaViewModel>> ObterMultasPendentesAsync()
        {
            return await _context.Tb_Pag_Multa
                .Where(d => d.Estado == false)
                .Include(d => d.Id_MultaNavigation) // Inclui a relação com Tb_Multum
                .Include(d => d.Id_DevolucaoNavigation.Id_LivroClienteNavigation.Id_ClienteNavigation) // Inclui a relação até Tb_Cliente
                .Select(d => new PagaMultaViewModel
                {
                    NomeCliente = d.Id_DevolucaoNavigation.Id_LivroClienteNavigation.Id_ClienteNavigation.Nome,
                    NumeroBI = d.Id_DevolucaoNavigation.Id_LivroClienteNavigation.Id_ClienteNavigation.Bi,
                    oMultum = new Tb_Multum { Valor = d.Id_MultaNavigation.Valor }
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PagaMultaViewModel>> ObterMultasPagasAsync()
        {
            return await _context.Tb_Pag_Multa
                .Where(d => d.Estado == true)
                .Include(d => d.Id_MultaNavigation) // Inclui a relação com Tb_Multum
                .Include(d => d.Id_DevolucaoNavigation.Id_LivroClienteNavigation.Id_ClienteNavigation) // Inclui a relação até Tb_Cliente
                .Select(d => new PagaMultaViewModel
                {
                    NomeCliente = d.Id_DevolucaoNavigation.Id_LivroClienteNavigation.Id_ClienteNavigation.Nome,
                    NumeroBI = d.Id_DevolucaoNavigation.Id_LivroClienteNavigation.Id_ClienteNavigation.Bi,
                    oMultum = new Tb_Multum { Valor = d.Id_MultaNavigation.Valor }
                })
                .ToListAsync();
        }


    }
}
