using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using System.Data;

namespace SistemaAtualEmprestimo.Repository
{
    public class LivroRepository : RepositoryBase<Tb_Livro>, IRepositoryLivro
    {
        private readonly EmprestimoAtualContext _context;

        public LivroRepository(EmprestimoAtualContext context, bool SaveChanges=true): base(SaveChanges)
        {
            _context = context;
        }
        public async Task<List<Tb_Livro>> GetLivrosAsync()
        {
            return await _context.Tb_Livros.ToListAsync();
        }

        public async Task<string> InserirLivroAsync(Tb_Livro livro)
        {
            var retorno = new SqlParameter
            {
                ParameterName = "@retorno",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Direction = ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Inserir_Livros @nome, @autor, @editora, @edicao, @qtd, @data_lancamento, @retorno OUTPUT",
                new SqlParameter("@nome", livro.Nome),
                new SqlParameter("@autor", livro.Autor),
                new SqlParameter("@editora", livro.Editora),
                new SqlParameter("@edicao", livro.Edicao),
                new SqlParameter("@qtd", livro.Qtd),
                new SqlParameter("@data_lancamento", livro.data_lancamento),
                retorno
            );

            return (string)retorno.Value;
        }

    
    }

}

