using Microsoft.AspNetCore.Antiforgery;
using Pizza.Controllers;

namespace Pizza.Web.Host.Controllers
{
    public class AntiForgeryController : PizzaControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
