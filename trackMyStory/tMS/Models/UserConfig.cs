using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tMS.Models
{
    [Table("UserConfig")]
    public class UserConfig : BaseModel
    {
        [PrimaryKey("user_id")] public string UserId { get; set; }
        [Column("color_primary")] public string ColorPrimary { get; set; }
        [Column("color_secondary")] public string ColorSecondary { get; set; }
    }
}
