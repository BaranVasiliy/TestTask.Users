using System.Collections.Generic;

namespace TestTask.Users.Initialize.Models
{
    public class Topic
    {
        public string Name { get; set; }

        public IEnumerable<Subscriber> Subscribers { get; set; }
    }
}