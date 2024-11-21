using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;


    namespace SistemaAtualEmprestimo.Repository
    {
        public class ClienteContatoRepository : IRepositoryClienteContato
        {
            private readonly EmprestimoAtualContext _context;

            public ClienteContatoRepository(EmprestimoAtualContext context)
            {
                _context = context;
            }

        public async Task<List<ClienteContato>> GetClienteContatosAsync()
        {
            var clientes = await _context.Tb_Clientes
                                       .Include(c => c.Tb_Contactos)
                                       .Include(c => c.Cod_MunNavigation) // Incluir a navegação para o município
                                       .ToListAsync();

            var clienteContatos = clientes.Select(cliente => new ClienteContato
            {
                Tb_Cliente = cliente,
                Tb_Contacto = cliente.Tb_Contactos.ToList(),
                Municipio = cliente.Cod_MunNavigation.Municipio, // Atribui o nome do município associado ao cliente
            }).ToList();

            return clienteContatos;
        }




    }
}

