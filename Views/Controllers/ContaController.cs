using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using autenticacaoefcookie.Dados;
using autenticacaoefcookie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace autenticacaoefcookie.Controllers
{
    public class ContaController : Controller
    {
        readonly AutenticacaoContext _contexto;

        public ContaController(AutenticacaoContext context)
        {
            _contexto = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            try
            {
                Usuario user = _contexto.Usuarios.Include("UsuariosPermissoes")
                                        .Include("UsuariosPermissoes.Permissao")
                                        .FirstOrDefault(c => c.Email == usuario.Email && c.Senha == usuario.Senha);
                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim(ClaimTypes.Name, user.Nome));
                    claims.Add(new Claim(ClaimTypes.Sid, user.IdUsuario.ToString()));


                    foreach(var item in user.UsuariosPermissoes){
                        claims.Add(new Claim(ClaimTypes.Role, item.Permissao.Nome));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Financeiro");
                }

                return View(usuario);
            }
            catch(System.Exception)
            {
                return View(usuario);
            }
        }

        [HttpGet]

        public IActionResult Sair(){
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
