using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriber
{
    public class Publisher
    {
        public Action OnChange { get; set; }

        public void Publish()
        {
            OnChange?.Invoke();
        }

        public void ConfigureMessage(int subscriberId, string message)
        {
            Console.WriteLine(string.Format("Hey subscriber {0}, this is your message: {1}", subscriberId.ToString(), message));
        }
    }
}
