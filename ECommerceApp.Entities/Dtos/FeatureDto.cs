using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Entities.Dtos
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
    }
}
