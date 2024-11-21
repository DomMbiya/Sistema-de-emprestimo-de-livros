using Microsoft.AspNetCore.Mvc;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Controllers
{
    public class PagaMultaController : Controller
    {
        private readonly IPagaMultaRepository _pagamultaRepository;
        private readonly EmprestimoAtualContext _context;
 

        public PagaMultaController(IPagaMultaRepository pagamultaRepository, EmprestimoAtualContext context)
        {
            _pagamultaRepository = pagamultaRepository;
            _context = context;

        }
        public async Task<IActionResult>Index()
        {
            var multasPagas = await _pagamultaRepository.ObterMultasPagasAsync();
            return View(multasPagas);
        }

        public async Task<IActionResult> PagarMulta()
        {
            var multas = await _pagamultaRepository.ObterMultasPendentesAsync();
            if (multas == null || !multas.Any())
            {
                return View("Error", new ErrorViewModel { RequestId = "Nenhuma multa pendente encontrada" });
            }
            return View(multas);
        }

       

        [HttpPost]
        public async Task<IActionResult> PagarMulta(PagaMultaViewModel viewmodel)
        {
            var result = await _pagamultaRepository.PagarMultaAsync(viewmodel.Id_Pag_Multa);

            if (result)
            {
                TempData["MensagemSucesso"] = "Multa paga com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu um erro ao tentar pagar a multa.";
            return RedirectToAction("Index");
        }


    }
}
