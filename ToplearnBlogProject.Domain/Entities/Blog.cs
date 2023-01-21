using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplearnBlogProject.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public string Description { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
        public string? ReadTime { get; set; }
        public int CategoryId { get; set; }
        public int AdminId { get; set; }
        public int Likes { get; set; }
        public int Visits { get; set; }
        public bool IsActive { get; set; }
        public bool Offer { get; set; }
        public bool Selected { get; set; }
        public bool Popular { get; set; }
        public bool Emergency { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Category Category { get; set; }
        public Admin Admin { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BlogTag> BlogTags { get; set; }
        public List<BlogFile> Files { get; set; }
    }
}
