using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Business.Helpers.Response
{
    public class CategoryResponse
    {
        public int NumberTask { get; set; }
        public string DescriptionTask { get; set; }
        public string Message { get; set; }
    }
}
