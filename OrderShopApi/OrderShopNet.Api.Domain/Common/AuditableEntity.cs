namespace OrderShopNet.Api.Domain.Common;

public abstract class AuditableEntity
{
    public DateTime Created { get; set; }

    public String? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public String? LastModifiedBy { get; set; }
}