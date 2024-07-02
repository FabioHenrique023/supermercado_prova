using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using supermercado_prova.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using System.Linq;

namespace supermercado_prova.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario model)
        {
            Repositorio<Usuario> repo = new Repositorio<Usuario>();
            List<Usuario> usuarios = repo.Listar();
            
            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Senha))
            {
                ViewBag.Errors = "Campo login e senha é obrigatório";
                return View("Index", model);
            } 

            var usuario = usuarios.FirstOrDefault(p => p.Login.Contains(model.Login));
            Hash hash = new Hash(SHA256.Create());
            
            if(usuario != null && hash.validarSenha(model.Senha, usuario.Senha))
            {
                HttpContext.Session.SetString("UsuarioLogado", model.Login);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.Login));
                identity.AddClaim(new Claim(ClaimTypes.Name, model.Login));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                var autPrincipal = new ClaimsPrincipal(identity);

                var principal = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(autPrincipal),
                    principal
                ).Wait();

                return RedirectToAction("Editar", new { id = usuario.Id });
            } else if(usuario != null && !hash.validarSenha(model.Senha, usuario.Senha)){
                ViewBag.Errors = "Senha inválida";
                return View("Index", model);
            }
            else
            {
                ViewBag.Errors = "Usuário não encontrado";
                return View("Index", model);
            }
        }

        public IActionResult Sair() {
            HttpContext.SignOutAsync().GetAwaiter();
            return View("Index");
        }

        [Authorize]
        public IActionResult Editar(int id)
        {
            Repositorio<Usuario> repo = new Repositorio<Usuario>();
            Usuario usuario = repo.Buscar(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Editar(Usuario model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Repositorio<Usuario> repo = new Repositorio<Usuario>();
            Hash hash = new Hash(SHA256.Create());
            Usuario usuario = repo.Buscar(model.Id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Login = model.Login;
            usuario.Senha = hash.CriptografarSenha(model.Senha);

            repo.Atualizar(usuario);

            TempData["Message"] = "Usuário atualizado com sucesso.";

            return RedirectToAction("Index", "Home");
        }
    }
}