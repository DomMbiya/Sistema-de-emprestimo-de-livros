using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Models;
using SistemaAtualEmprestimo.Repository;
using SistemaAtualEmprestimo.Service;

namespace SistemaAtualEmprestimo.Controllers
{
    public class LivroController : Controller
    {

        private readonly LivroService _livroService;
        private readonly LivroRepository _livroRepository;
        private readonly EmprestimoAtualContext _context;

        public LivroController(LivroService livroService, LivroRepository livroRepository, EmprestimoAtualContext context)
        {
            _livroService = livroService;
            _livroRepository = livroRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _context.Tb_Livros.ToListAsync();
            return View(livros);
        }
        [HttpPost]


        public async Task<IActionResult> Create(Tb_Livro livro)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _livroRepository.InserirLivroAsync(livro);
                ViewBag.Mensagem = resultado;
                return View(livro);
            }
            return View(livro);
        }

        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Tb_Livros
                .FirstOrDefaultAsync(m => m.Id_Livro == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        //public IActionResult Edit(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    var livro = _context.Tb_Livros.Find(id);
        //    //if (livro == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    return View(livro);
        //}

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Autor,Editora,Edicao,Qtd,DataLancamento")] Tb_Livro livro)
        //{
        //    if (id != livro.Id_Livro)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(livro);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LivroExists(livro.Id_Livro))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(livro);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var livro = await _context.Tb_Livros
        //        .FirstOrDefaultAsync(m => m.Id_Livro == id);
        //    if (livro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(livro);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var livro = await _context.Tb_Livros.FindAsync(id);
        //    _context.Tb_Livros.Remove(livro);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Edit(int id)
        {
            Tb_Livro oLivro = _livroService.oRepositoryLivro.SelecionarPk(id);
            return View(oLivro);
        }
        [HttpPost]
        public IActionResult Edit(Tb_Livro model)
        {
            Tb_Livro oLivro = _livroService.oRepositoryLivro.Alterar(model);
            int id = oLivro.Id_Livro;
            return RedirectToAction("Details", new { id });
        }
        public IActionResult Delete(int id)
        {
            _livroService.oRepositoryLivro.Excluir(id);
            return RedirectToAction("index");
        }

        private bool LivroExists(int id)
        {
            return _context.Tb_Livros.Any(e => e.Id_Livro == id);
        }
    }
}




