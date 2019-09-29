using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToDoList.Models
{
    public enum Attributes
    {
        Personal, Business
    }
    public class ToDoLists
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(255)]
        public string Definition { get; set; }
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.DD HH:mm")]       
        public DateTime? DueDate { get; set; }
        public bool Priority { get; set; }
        public Attributes? Attribute { get; set; }
    }
}