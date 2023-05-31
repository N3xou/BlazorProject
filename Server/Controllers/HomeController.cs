using BlazorProject.Shared;
using Microsoft.AspNetCore.Mvc;

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
				// Generate a unique ID
				int uniqueId = GenerateUniqueId();
				int queueNumber = GetQueueNumber();

				// Create a new cookie with the unique ID
				Response.Cookies.Append("ID", uniqueId.ToString(), new CookieOptions
				{
					Expires = DateTime.Now.AddHours(5),
				});

				// Add the unique ID to the dictionary
				queueService.AddToQueue(uniqueId, queueNumber);
			}

			return View();
		}

		private int GenerateUniqueId()
		{
			// Generate a unique ID using a suitable logic, such as using a GUID or a random number generator
			// For simplicity, let's generate a random number between 1 and 1000
			Random random = new Random();
			int uniqueId = random.Next(1, 1001);
			return uniqueId;
		}
		private int GetQueueNumber()
		{
			// Calculate the next queue number based on the dictionary's count
			int queueNumber = queueService.queueDict.Count + 1;
			return queueNumber;
		}



	}
}
// test, not working yet