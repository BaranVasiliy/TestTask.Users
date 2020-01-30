using System.Collections.Generic;

namespace TestTask.Users.Initialize.Models
{
    public class Subscriber
    {
        public string Name { get; set; }

        public IEnumerable<string> Labels { get; set; }
    }
}