using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityMVC.Models
{
    public class ToDoList
    {

        public ToDoList()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}