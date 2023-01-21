using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplearnBlogProject.Domain.Entities
{
    public class BlogFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Extension { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
