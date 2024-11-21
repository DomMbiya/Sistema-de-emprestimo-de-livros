using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using System.Data;

namespace SistemaAtualEmprestimo.Repository
{
    public class DevolucaoRepository : IDevolucaoRepository
    {
        private readonly EmprestimoAtualContext _context;

        public DevolucaoRepository(EmprestimoAtualContext context)
        {
            _context = context;
        }
        public IEnumerable<Tb_LivroCliente> GetEmprestimosPendentes()
        {
            return _context.Tb_LivroClientes
                .Where(e => !e.entregue) // Filtra onde entregue é false
                .Include(e => e.Id_ClienteNavigation) // Inclui a navegação para o cliente, se necessário
                .Include(e => e.Id_LivroNavigation)   // Inclui a navegação para o livro, se necessário
                .ToList();
        }

        public async Task<string> Devolucao(int idLivroCliente, int qtd)
        {
            var retornoParam = new SqlParameter("@Retorno", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Output
            };

            var idLivroClienteParam = new SqlParameter("@Id_LivroCliente", idLivroCliente);
            var qtdParam = new SqlParameter("@qtd", qtd);

            await _context.Database.ExecuteSqlRawAsync(
                "exec Devolucao @Id_LivroCliente, @qtd, @Retorno OUTPUT",
                idLivroClienteParam, qtdParam, retornoParam);

            return (string)retornoParam.Value;
        }
    }

}
