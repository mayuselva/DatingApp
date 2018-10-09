using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base (options) {  }

        public DbSet<Value> Values { get; set; } //vallues- table name
        public DbSet<User> Users {get;set;} //Users table name 
        public DbSet<Photo> Photos {get;set;}
        public DbSet<Employee> Employees{get;set;}
        public DbSet<Task> Tasks{get;set;}
        public DbSet<AssignTask> AssignTasks{get;set;}
    }
}