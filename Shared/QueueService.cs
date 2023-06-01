using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared
{
	public class QueueService
	{
		public Queue<int> queue;

		public QueueService()
		{
			queue = new Queue<int>();
		}

		public void AddToQueue(int value)
		{

			queue.Enqueue(value);
		}
		public void RemoveFromQueue()
		{
			queue.Dequeue();
		}
		public void RemoveFromQueue(int value)
		{
			int index = this.GetPosition(value);
			List<int> listFormat = new List<int>(this.queue);
			listFormat.RemoveAt(index);
			this.queue = new Queue<int>(listFormat);
		}
		public int GetPosition(int value)
		{
			int position = 0;
			foreach(int item in queue)
			{
				if (item == value)
				{
					return position += 1;
				}
				else
				{
					position++;
				}
			}
			return 0;
		}

		// Other methods to interact with the queueDict as needed
	}

}
