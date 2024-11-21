using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using SistemaAtualEmprestimo.Repository;
using System.Diagnostics;

namespace SistemaAtualEmprestimo.Controllers
{
 

        public class EmprestimoController : Controller
        {
            private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly EmprestimoAtualContext _context;
        private readonly IRepositoryCliente _clienteRepository;
        private readonly IRepositoryLivro _livroRepository;

        public EmprestimoController(IEmprestimoRepository emprestimoRepository, EmprestimoAtualContext context, IRepositoryLivro repositoryLivro, IRepositoryCliente repositoryCliente)
        {
            _emprestimoRepository = emprestimoRepository;
            _context = context;
            _clienteRepository = repositoryCliente;
            _livroRepository = repositoryLivro;
        }
        public async Task<IActionResult> Index()
        {
            var livrosClientes = await _context.Tb_LivroClientes
                .Include(l => l.Id_ClienteNavigation)
                .Include(l => l.Id_LivroNavigation)
                .ToListAsync();
            return View(livrosClientes);
        }

        [HttpGet]
        public async Task <IActionResult> RealizarEmprestimo()
        {
            var clientes = await _clienteRepository.GetClientesAsync() ?? new List<Tb_Cliente>();
            var livros = await _livroRepository.GetLivrosAsync() ?? new List<Tb_Livro>();

            var viewModel = new EmprestimoViewModel
            {
                oListCliente = clientes,
                oListLivro = livros
            };

            return View(viewModel);
        }

        [HttpPost]
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> RealizarEmprestimo(EmprestimoViewModel viewModel)
        {
            // Verifique se os valores foram corretamente recebidos
            var retorno = await _emprestimoRepository.EmprestimoAsync(viewModel.IdLivro, viewModel.IdCliente, viewModel.qtd);

            ViewBag.Retorno = retorno; // Exemplo de como passar o retorno para a view

            var clientes = await _clienteRepository.GetClientesAsync() ?? new List<Tb_Cliente>();
            var livros = await _livroRepository.GetLivrosAsync() ?? new List<Tb_Livro>();

            viewModel.oListCliente = clientes;
            viewModel.oListLivro = livros;

            return View(viewModel);
        }


    }

}

