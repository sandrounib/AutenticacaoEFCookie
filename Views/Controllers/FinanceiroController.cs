using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace autenticacaoefcookie.Controllers
{
    [Authorize(Roles="Financeiro")]
    
    public class FinanceiroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}