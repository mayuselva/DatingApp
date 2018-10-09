using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
    public class Employee
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpNo{get;set;}
        public string Name{get;set;}
        public ICollection<AssignTask> Tasks{get;set;}
    }
}