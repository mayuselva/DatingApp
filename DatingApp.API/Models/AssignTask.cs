namespace DatingApp.API.Models
{
    public class AssignTask
    {
        public int ID{get;set;}
        public Employee Employee{get;set;}
        public Task Task{get;set;}
        public int EmployeeEmpNo{get;set;}
        public int TaskNo{get;set;}
    }
}