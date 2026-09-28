using appSatTech.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace appSatTech.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbTecnicoContext _context;

        public AccountController(DbTecnicoContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Chamado");
            }
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Busca o cliente pelo CPF digitado
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(p => p.Cpf == model.Cpf);

            if (cliente == null)
            {
                ModelState.AddModelError("", "CPF não encontrado. Faça seu cadastro primeiro.");
                return View(model);
            }

            // Criando os dados da sessão (Claims)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, cliente.Codigo.ToString()),
                new Claim(ClaimTypes.Name, cliente.Nome),
                new Claim("CPF", cliente.Cpf)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // SALVANDO O ID NA SESSION ANTES DE REDIRECIONAR
            HttpContext.Session.SetInt32("ClienteId", cliente.Codigo);

            return RedirectToAction("Index", "Chamado");
        }

        // GET: /Account/Logout
        public async Task<IActionResult> Logout()
        {
            // LIMPA A SESSION NO LOGOUT
            HttpContext.Session.Clear();

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}