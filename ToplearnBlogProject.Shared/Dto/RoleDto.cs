using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToplearnBlogProject.Shared.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام فارسی الزامی است")]
        public string FaName { get; set; }
        [Required(ErrorMessage = "وارد کردن نام انگلیسی الزامی است")]
        public string EnName { get; set; }
    }
}
