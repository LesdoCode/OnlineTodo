using System.Web.Mvc;

namespace OnlineTodo.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}