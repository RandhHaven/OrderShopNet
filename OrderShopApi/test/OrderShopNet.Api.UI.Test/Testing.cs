namespace OrderShopNet.Api.UI.Test
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using OrderShopNet.Api.Infrastructure.Persistence;
    using Respawn;
    using System.Threading.Tasks;

    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration = null!;
        private static Checkpoint _checkpoint = null!;
        private static string? _currentUserId;
        private static IServiceScopeFactory _scopeFactory = null!;


        public static async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(keyValues);
        }

        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("AppConnection"));
            _currentUserId = null;
        }

    }
}