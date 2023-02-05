using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplearnBlogProject.Shared.Dto
{
    public class TagDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        public string Name { get; set; }
    }
}
