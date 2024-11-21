using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Interfaces
{
        public interface IRepositoryClienteContato
        {
            Task<List<ClienteContato>> GetClienteContatosAsync();
        }

    
}
