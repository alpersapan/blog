using System;

#nullable disable

namespace blog.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public DateTime? BlogDate { get; set; }
    }
}
