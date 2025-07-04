﻿using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace tMS.Models
{
    [Table("UserConfig")]
    public class DbUserConfig : BaseModel
    {
        [PrimaryKey("user_id")] public string UserId { get; set; }
        [Column("color_primary")] public string ColorPrimary { get; set; }
        [Column("color_secondary")] public string ColorSecondary { get; set; }
    }
}
