using System.Collections.Generic;

namespace TestTask.Users.BLL.DTOs.Pagination
{
    public class PagedResultDto<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResultDto()
        {
            Results = new List<T>();
        }
    }
}