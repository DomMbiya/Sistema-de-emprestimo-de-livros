using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using System.Data;

namespace SistemaAtualEmprestimo.Repository
{
    public class ClienteRepository : RepositoryBase<Tb_Cliente>, IRepositoryCliente
    {
       
            private readonly EmprestimoAtualContext _context;

        public ClienteRepository(EmprestimoAtualContext context, bool SaveChanges = true) : base(SaveChanges)
        {
            _context = context;
        }

        public async Task<List<Tb_Cliente>> GetClientesAsync()
        {
            return await _context.Tb_Clientes.ToListAsync();
        }

        //public ClienteRepository(EmprestimoAtualContext context)
        //    {
        //        _context = context;
        //    }

        // Seus métodos existentes...
        //public async Task<string> InserirClienteAsync(string bi, string nome, string mun, int contacto)
        //{
        //    using (var connection = _context.Database.GetDbConnection())
        //    {
        //        using (var command = connection.CreateCommand())
        //        {
        //            command.CommandText = "InserirCliente";
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.Add(new SqlParameter("@BI", bi));
        //            command.Parameters.Add(new SqlParameter("@Nome", nome));
        //            command.Parameters.Add(new SqlParameter("@Mun", mun));
        //            command.Parameters.Add(new SqlParameter("@Contacto", contacto));

        //            var retornoParameter = new SqlParameter("@Retorno", SqlDbType.NVarChar, 50)
        //            {
        //                Direction = ParameterDirection.Output
        //            };
        //            command.Parameters.Add(retornoParameter);

        //            await connection.OpenAsync();
        //            await command.ExecuteNonQueryAsync();

        //            return (string)retornoParameter.Value;
        //        }
        //    }
        //}



        public async Task<string> InserirClienteAsync(string bi, string nome, string mun, int contacto)
            {
                try
                {
                    // Parâmetros de saída
                    var retornoParam = new SqlParameter("@Retorno", SqlDbType.NVarChar, 50);
                    retornoParam.Direction = ParameterDirection.Output;

                    // Executar o procedimento armazenado
                    await _context.Database.ExecuteSqlRawAsync(
                        "EXEC [dbo].[InserirCliente] @BI, @Nome, @Mun, @Contacto, @Retorno OUTPUT",
                        new SqlParameter("@BI", bi),
                        new SqlParameter("@Nome", nome),
                        new SqlParameter("@Mun", mun),
                        new SqlParameter("@Contacto", contacto),
                        retornoParam
                    );

                    // Obter o resultado do parâmetro de saída
                    var retorno = retornoParam.Value.ToString();
                    return retorno;
                }
                catch (Exception ex)
                {
                    // Lidar com exceções aqui, se necessário
                    return $"Erro ao inserir cliente: {ex.Message}";
                }
            }
        

        public async Task<List<Tb_Cliente>> GetClienteContatosAsync()
            {
                var clientes = new List<Tb_Cliente>();

                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();

                    string query = @"
            SELECT 
                c.Id_Cliente, 
                c.Bi, 
                c.Nome, 
                COALESCE(contacto.Contacto, '') AS Contacto,
                mun.Municipio AS Municipio
            FROM 
                Tb_Cliente c
            LEFT JOIN 
                Tb_Contacto contacto ON c.Id_Cliente = contacto.Id_Cliente
            LEFT JOIN 
                Tb_Mun mun ON c.Cod_Mun = mun.Cod_Mun";

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = query;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var cliente = new Tb_Cliente
                                {
                                    Id_Cliente = reader.GetInt32(0),
                                    Bi = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Tb_Contactos = new List<Tb_Contacto> { new Tb_Contacto { Contacto = reader.GetString(3) } },
                                    Cod_MunNavigation = new Tb_Mun { Municipio = reader.GetString(10) }
                                };
                                clientes.Add(cliente);
                            }
                        }
                    }
                }

                return clientes;
            }

       
    }
}


