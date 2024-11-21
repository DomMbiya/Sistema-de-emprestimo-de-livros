using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IDevolucaoRepository
    {
        Task<string> Devolucao(int idLivroCliente, int qtd);
        IEnumerable<Tb_LivroCliente> GetEmprestimosPendentes();
    }
}
