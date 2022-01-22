using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShopNet.Api.Domain.EntitiesDTO
{
    internal class OrderShopDTO
    { 
        public Guid? OrderShopId { get; set; }

        public String? Title { get; set; }

        public String? NumberOrder { get; set; }

        public String? ProductOrderGuid { get; set; }
    }
}
