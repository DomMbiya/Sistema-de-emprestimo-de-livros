using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Controllers
{
    public class DevolucaoController : Controller
    {
       
            private readonly IDevolucaoRepository _devolucaoRepository;
        private readonly EmprestimoAtualContext _context;
        public DevolucaoController(IDevolucaoRepository devolucaoRepository, EmprestimoAtualContext context)
        {
            _devolucaoRepository = devolucaoRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var devolucoes = await _context.Tb_Devolucaos
                .Include(d => d.Id_LivroClienteNavigation)
                    .ThenInclude(lc => lc.Id_LivroNavigation)
                .Include(d => d.Id_LivroClienteNavigation)
                    .ThenInclude(lc => lc.Id_ClienteNavigation)
                .Select(d => new DevolucaoViewModel
                {
                    IdLivroCliente = d.Id_LivroCliente,
                    qtd = d.Qtd,
                    oDevolucao = d,
                    NomeCliente = d.Id_LivroClienteNavigation.Id_ClienteNavigation.Nome,
                    TituloLivro = d.Id_LivroClienteNavigation.Id_LivroNavigation.Nome,
                    oLivroCliente = d.Id_LivroClienteNavigation,
                    oLivro = d.Id_LivroClienteNavigation.Id_LivroNavigation,
                    oCliente = d.Id_LivroClienteNavigation.Id_ClienteNavigation
                })
                .ToListAsync();

            return View(devolucoes);
        }


        [HttpGet]
        public IActionResult Devolucao()
        {
            var emprestimosPendentes = _devolucaoRepository.GetEmprestimosPendentes(); // Método fictício, ajuste conforme seu repository

            var viewModel = new DevolucaoViewModel
            {
                oListLivroCliente = (List<Tb_LivroCliente>)emprestimosPendentes
            };

            return View(viewModel);
        }
        [HttpPost]
            public async Task<IActionResult> Devolucao(DevolucaoViewModel viewModel)
            {
                var retorno = await _devolucaoRepository.Devolucao(viewModel.IdLivroCliente, viewModel.qtd);
                ViewBag.Retorno = retorno; // Ou use um modelo para retornar a resposta para a view
            var emprestimosPendentes = _devolucaoRepository.GetEmprestimosPendentes(); // Método fictício, ajuste conforme seu repository

            viewModel.oListLivroCliente = (List<Tb_LivroCliente>)emprestimosPendentes;
            

            return View(viewModel);
        }
        

    }
}
