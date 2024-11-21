using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IPagaMultaRepository
    {
        Task<IEnumerable<PagaMultaViewModel>> ObterMultasPendentesAsync();
        Task<IEnumerable<PagaMultaViewModel>> ObterMultasPagasAsync();
        Task<bool> PagarMultaAsync(int idPagMulta);
    }
}
