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
        [MaxLength(30 , ErrorMessage = "عنوان فارسی باید کمتر از 30 حرف باشد")]
        public string FaName { get; set; }
        [Required(ErrorMessage = "وارد کردن نام انگلیسی الزامی است")]
        [MaxLength(30, ErrorMessage = "عنوان انگلیسی باید کمتر از 30 حرف باشد")]
        public string EnName { get; set; }
    }
}
