using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.Shared.Dto
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است")]
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        [Range(1,int.MaxValue,ErrorMessage = "نقش مدیر را انتخاب کنید")]
        public int RoleId { get; set; }
        public int BlogCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public RoleDto? Role { get; set; }
        public FileDto? File { get; set; }
    }
}
