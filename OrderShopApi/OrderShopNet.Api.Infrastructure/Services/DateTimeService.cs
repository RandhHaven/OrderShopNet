using OrderShopNet.Api.Application.Common.Interfaces;

namespace OrderShopNet.Api.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
