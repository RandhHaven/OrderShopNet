namespace OrderShopNet.Api.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;
using OrderShopNet.Api.Core.Common.Models;
using System.Linq;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
