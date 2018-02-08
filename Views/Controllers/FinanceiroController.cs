using Microsoft.AspNetCore.Mvc;

namespace autenticacaoefcookie.Controllers
{
    public class FinanceiroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}