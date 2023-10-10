using Microsoft.AspNetCore.Mvc;

namespace Configuration_Asp_Dot_.Controllers
{
    public class HomeController : Controller
    {   private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
              _configuration = configuration;
            //Dependecncy Injection using Default Container
        }
        public IActionResult Index()
        {
            string testvalue=_configuration.GetValue<string>("test");
           /* Externally we can pass those value to ViewBag for rendering.*/
            return View();
        }
    }
}
