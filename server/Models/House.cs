using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class House
    {
        public int Id { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }
    }
}