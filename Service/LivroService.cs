using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Models;
using SistemaAtualEmprestimo.Repository;
using System.Configuration;

namespace SistemaAtualEmprestimo.Service
{
    public class LivroService
    {

        public LivroRepository oRepositoryLivro { get; set; }

        // Construtor que recebe o LivroRepository através de injeção de dependência
        public LivroService(LivroRepository repositoryLivro)
        {
            oRepositoryLivro = repositoryLivro;
        }
    }

}
