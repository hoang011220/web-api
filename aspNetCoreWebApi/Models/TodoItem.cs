using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetCoreWebApi.Models
{
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public bool IsComplete { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Secret { get; set; }
    }
}
