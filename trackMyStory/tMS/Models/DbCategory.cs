using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace tMS.Models
{
    [Table("Categories")]
    public class DbCategory : BaseModel
    {
        [PrimaryKey("id")] public string Id { get; set; }
        [Column("user_id")] public string UserId { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("color")] public string Color { get; set; }
    }
}
