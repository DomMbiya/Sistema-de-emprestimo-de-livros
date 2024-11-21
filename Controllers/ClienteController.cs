using Microsoft.AspNetCore.Mvc;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using SistemaAtualEmprestimo.Repository;
using SistemaAtualEmprestimo.Service;

namespace SistemaAtualEmprestimo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IRepositoryClienteContato _clienteContatoRepository;
        private readonly ClienteService _clienteService;
        private readonly IRepositoryMunicipio _repositorymunicipio;
        //private readonly IRepositoryMunicipio _repositorymunicipio;
        public ClienteController(IRepositoryCliente repositoryCliente,IRepositoryMunicipio repositoryMunicipio, IRepositoryClienteContato clienteContatoRepository,ClienteService clienteService)
        {
            _repositoryCliente = repositoryCliente;
            _clienteContatoRepository = clienteContatoRepository;
            _clienteService = clienteService;
            _repositorymunicipio = repositoryMunicipio;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clienteContatos = await _clienteContatoRepository.GetClienteContatosAsync();
            return View(clienteContatos);
        }
        [HttpGet]
        public async Task<IActionResult> InserirCliente()
        {
            var model = new ClienteContato(); // Certifique-se de criar um ViewModel adequado se necessário
            model.Municipios = await _repositorymunicipio.GetMunicipiosAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> InserirCliente(string bi, string nome, string mun, int contacto)
        {
            if (ModelState.IsValid)
            {
                string resultado = await _repositoryCliente.InserirClienteAsync(bi, nome, mun, contacto);

                ViewBag.Message = resultado;

                // Redirecionar para a action Index após o sucesso da inserção
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retornar a view com o modelo preenchido
            var model = new ClienteContato();
            model.Municipios = await _repositorymunicipio.GetMunicipiosAsync();
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            _clienteService.oRepositoryCliente.Excluir(id);
            return RedirectToAction("index");
        }
    }
}
