using System.Collections.Generic;

namespace DesignPatterns.AdapterPattern.Models
{
    public class ApiResult<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
