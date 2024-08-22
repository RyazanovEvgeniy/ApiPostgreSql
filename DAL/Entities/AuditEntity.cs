using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

[Serializable]
public abstract class AuditEntity : BaseEntity
{
    [Column("created_user_id")]
    public long CreatedUserId { get; set; }

    [Column("created_datetime")]
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

    [Column("updated_user_id")]
    public long? UpdatedUserId { get; set; }

    [Column("updated_datetime")]
    public DateTime? UpdatedDateTime { get; set; }
}