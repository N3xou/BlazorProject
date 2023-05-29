using Microsoft.AspNetCore.Mvc;

namespace BlazorProject.Server.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			Response.Cookies.Append("ID", "1", new CookieOptions
			{
				Expires = DateTime.Now.AddHours(5),
			});
			return View();
		}
		private Dictionary<string, string> _cookies;
		
	}
}
// test, not working yet