using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetCoreWebApi.Models1
{
    public class Product
    {
      
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public bool IsOnSale { get; internal set; }
    }
}
