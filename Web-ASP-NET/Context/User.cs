using System;
using System.ComponentModel.DataAnnotations;

namespace Web_ASP_NET.Context
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public string Provider { get; set; }
        public string FirebaseUid { get; set; }
    }
}