using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using supermercado_prova.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace supermercado_prova.Controllers;

    [Authorize]
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IWebHostEnvironment _appEnvironment;
        private List<Estado> _estados;

        public ClienteController(ILogger<ClienteController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;

            // Carregar estados do arquivo JSON
            var json = System.IO.File.ReadAllText(Path.Combine(_appEnvironment.ContentRootPath, "estados-cidades.json"));
            var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
            _estados = rootObject.Estados;
        }

        public class Estado
        {
            public string Nome { get; set; }
            public List<string> Cidades { get; set; }
        }

        public class RootObject
        {
            public List<Estado> Estados { get; set; }
        }

        [HttpGet]
        public IActionResult Cliente(int id = 0)
        {
            Repositorio<Cliente> repoCliente = new Repositorio<Cliente>();
            Cliente cliente = repoCliente.Buscar(id) ?? new Cliente();

            CarregarEstadosParaViewBag();

            return View(cliente);
        }

        private void CarregarEstadosParaViewBag()
        {
            ViewBag.Estados = new SelectList(_estados, nameof(Estado.Nome), nameof(Estado.Nome));
        }

        public IActionResult Listar()
        {
            Repositorio<Cliente> repo = new Repositorio<Cliente>();
            List<Cliente> lista = repo.Listar();

            return View(lista);
        }

        [HttpGet]
        public JsonResult GetCidades(string nome)
        {
            var estadoSelecionado = _estados.FirstOrDefault(e => e.Nome == nome);
            if (estadoSelecionado != null)
            {
                var cidades = estadoSelecionado.Cidades;
                return Json(cidades);
            }
            else
            {
                return Json(new List<string>());
            }
        }

        [HttpPost]
        public IActionResult Cliente(Cliente model, IFormFile anexo)
        {
            Repositorio<Cliente> repo = new Repositorio<Cliente>();

            if (!ModelState.IsValid)
            {
                CarregarEstadosParaViewBag();
                return View(model);
            }

            model.Imagens = string.Empty;
            if (anexo != null)
            {
                string caminho = Path.Combine(_appEnvironment.WebRootPath, "imagens", anexo.FileName);
                using (FileStream stream = new FileStream(caminho, FileMode.Create))
                {
                    anexo.CopyTo(stream);
                }

                model.Imagens = "/imagens/" + anexo.FileName;
            }

            List<Cliente> clientes = repo.Listar();
            var CodigoFiscalExistente = clientes.FirstOrDefault(p => p.CodigoFiscal == model.CodigoFiscal && p.Id != model.Id);
            var InscricaoEstadualExistente = clientes.FirstOrDefault(p => p.InscricaoEstadual == model.InscricaoEstadual && p.Id != model.Id);

            if (CodigoFiscalExistente != null)
            {
                ViewBag.Errors = "Código Fiscal já existe";
                CarregarEstadosParaViewBag();
                return View(model);
            }

            if (InscricaoEstadualExistente != null)
            {
                ViewBag.Errors = "Inscrição Estadual já existe";
                CarregarEstadosParaViewBag();
                return View(model);
            }

            if (model.Id != 0)
            {
                repo.Atualizar(model);
            }
            else
            {
                repo.Adicionar(model);
            }

            return RedirectToAction("Listar");
        }

        public FileContentResult Exportar(int id)
        {
            Repositorio<Cliente> repo = new Repositorio<Cliente>();
            Cliente model = repo.Buscar(id);
            string json = JsonConvert.SerializeObject(model);
            byte[] arquivoBytes = new System.Text.UTF8Encoding().GetBytes(json);
            return File(arquivoBytes, "text/json", "Dados_cliente.json");
        }

        public IActionResult Remove(int id)
        {
            Repositorio<Cliente> repo = new Repositorio<Cliente>();
            repo.Remover(id);

            return RedirectToAction("Listar");
        }
    }