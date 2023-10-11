using Configuration_Asp_Dot_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Configuration_Asp_Dot_.Controllers
{
    public class HomeController : Controller
    {   private readonly ParentOptions options;

        public HomeController(IOptions<ParentOptions> configuration)
        {
              options = configuration.Value;
            //Dependecncy Injection using Default Container
        }
        public IActionResult Index()
        {
          string child1= _configuration.child1;//can access directly
                return View();
        }
    }
}
/*Simple One*/
/*string testvalue = _configuration.GetValue<string>("test");*/


/*Hierarical Configuration*/
// Method 1 - GetValue with Assignment
/*string valueFromMethod1 = _configuration.GetValue<string>("parent:child1"); // Retrieve and assign the value

// Method 2 - GetSection
string valueFromMethod2 = _configuration.GetSection("parent")["child1"]; // Retrieve and assign the value

//Options
ParentOptions options = _configuration.GetSection("parent").Get<ParentOptions>();
string optionExample = options.child1;//use new object

//using bind method
ParentOptions options2 = new ParentOptions();
_configuration.GetSection("parent").Bind(options2);

string optionExample2 = options2.child1;//use existing objecti.e(constructor)
*/                                        //However above methods is prefered most i.e parent 

/*Optionally it can be passed to ViewBag*/