using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class Task
    {
        [Key]
        public int No { get; set; }
        public string Name { get; set; }

        public ICollection<AssignTask> Employee{get;set;}
    }
}