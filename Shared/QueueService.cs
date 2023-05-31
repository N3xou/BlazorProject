using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
	public class QueueService
	{
		public Dictionary<int, int> queueDict;

		public QueueService()
		{
			queueDict = new Dictionary<int, int>();
		}

		public void AddToQueue(int key, int value)
		{
			queueDict.Add(key, value);
		}

		// Other methods to interact with the queueDict as needed
	}

}
