using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using System.Data;

namespace SistemaAtualEmprestimo.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly EmprestimoAtualContext _context;

        public EmprestimoRepository(EmprestimoAtualContext context)
        {
            _context = context;
        }

        public async Task<string> EmprestimoAsync(int idLivro, int idCliente, int qtd)
        {
            var retornoParam = new SqlParameter("@Retorno", SqlDbType.NVarChar, 50);
            retornoParam.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Emprestimo] @id_livro, @id_cliente, @qtd, @Retorno OUTPUT",
                new SqlParameter("@id_livro", idLivro),
                new SqlParameter("@id_cliente", idCliente),
                new SqlParameter("@qtd", qtd),
                retornoParam);

            return retornoParam.Value.ToString();
        }
    }

}
