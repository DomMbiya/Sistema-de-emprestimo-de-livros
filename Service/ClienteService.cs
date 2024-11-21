using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Repository;

namespace SistemaAtualEmprestimo.Service
{
    public class ClienteService
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ClienteRepository oRepositoryCliente{ get; set; }

        // Construtor que recebe o LivroRepository através de injeção de dependência
        public ClienteService(ClienteRepository repositoryCliente)
        {
            oRepositoryCliente = repositoryCliente;
        }
        
    }
}
