using BlazorProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace BlazorProject.Server.Controllers
{
		public class HomeController : Controller
		{
			private readonly QueueService queueService;
			public HomeController(QueueService queueService) 
			{
				this.queueService = queueService;
			}
			public IActionResult Index()
			{
				// Read the ID cookie
				string cookieValue = Request.Cookies["ID"];

				// Check if the cookie value is null or empty
				if (string.IsNullOrEmpty(cookieValue))
				{

					int uniqueId = GenerateUniqueId();
					// Create a new cookie with the unique ID
					Response.Cookies.Append("ID", uniqueId.ToString(), new CookieOptions
					{
						Expires = DateTime.Now.AddHours(5),
					});	
				}

				return View();
			}
		public void AddToQueue()
		{
			int id;
			if (int.TryParse(Request.Cookies["ID"], out id))	
			queueService.AddToQueue(id);
			
		}
		public int QueueNumber()
		{
			int id;
			if (int.TryParse(Request.Cookies["ID"], out id));
			return queueService.GetPosition(id);
		}
		private int GenerateUniqueId()
		{
			// Generate a unique ID using a suitable logic, such as using a GUID or a random number generator
			// For simplicity, let's generate a random number between 1 and 1000
			Random random = new Random();
			int uniqueId = random.Next(1, 1001);
			return uniqueId;
		}
		



	}
}
// test, not working yet