using System.Collections.Generic;

namespace TestTask.Users.BLL.DTOs
{
    public class PaginationResultDto<TEntity> where TEntity : class
    {
        public int TotalCount { get; set; }

        public IEnumerable<TEntity> Results { get; set; }
    }
}