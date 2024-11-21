using SistemaAtualEmprestimo.Models;
using SistemaAtualEmprestimo.Repository;

namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IRepositoryCliente : IRepositoryModel<Tb_Cliente>
    {
        Task<List<Tb_Cliente>> GetClientesAsync();
        Task<string> InserirClienteAsync(string bi, string nome, string mun, int contacto);
    }
}
