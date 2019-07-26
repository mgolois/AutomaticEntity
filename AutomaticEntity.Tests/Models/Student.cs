using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutomaticEntity.Tests.Models
{
    [Table("Students")]
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
