using System;
using System.ComponentModel.DataAnnotations;

namespace C_Sharp_CRUD.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
    }
}
