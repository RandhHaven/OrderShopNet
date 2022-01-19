using OrderShopNet.Api.Domain.Common;

namespace OrderShopNet.Api.Domain.Entities
{
    public sealed class OrderShop : AuditableEntity
    {
        public int OrderShopId { get; set; }

        public String? Title { get; set; }

        public String? NumberOrder { get; set; }

        public IList<ProductDetail> Items { get; private set; } = new List<ProductDetail>();
    }
}
