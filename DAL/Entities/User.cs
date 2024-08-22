using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.Entities;

[Serializable]
[DataContract]
[Table("users", Schema = "public")]
public class User : BaseEntity
{
    [DataMember]
    [Column("name")]
    [Required]
    public string? Name { get; set; }
}