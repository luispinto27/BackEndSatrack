using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Models;

namespace TaskManager.Business.Helpers.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLimited { get; set; }
        public bool isCompleted { get; set; }
        public int CategoryId { get; set; }
    }
}
