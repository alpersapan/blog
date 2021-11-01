using System;

#nullable disable

namespace blog.Models
{
    public partial class BlogCategoryUser
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public string BlogContent { get; set; }
        public DateTime? BlogDate { get; set; }
        public string UserMail { get; set; }
        public string UserPw { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
