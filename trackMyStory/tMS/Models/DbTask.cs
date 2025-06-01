using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace tMS.Models
{
    [Table("Tasks")]
    public class DbTask : BaseModel
    {
        [PrimaryKey("id")] public string Id { get; set; }
        [Column("user_id")] public string UserId { get; set; }
        [Column("category_id")] public string CategoryId { get; set; }
        [Column("name")] public string Name { get; set; }

        public DbCategory? Category { get; set; }
    }
}
