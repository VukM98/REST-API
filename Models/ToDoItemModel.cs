using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDoItemModel
    {
        [Key]
        public int ItemId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime? Date { get; set; }

        public bool Completed { get; set; }

        public bool Deleted { get; set; }
    }
}