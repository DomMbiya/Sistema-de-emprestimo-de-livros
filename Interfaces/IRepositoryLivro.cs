using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IRepositoryLivro : IRepositoryModel<Tb_Livro>
    {
        Task<List<Tb_Livro>> GetLivrosAsync();
        Task<string> InserirLivroAsync(Tb_Livro livro);

    }
}
