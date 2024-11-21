namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<string> EmprestimoAsync(int idLivro, int idCliente, int qtd);
    }

}
