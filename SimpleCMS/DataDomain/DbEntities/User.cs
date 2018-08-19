using System.ComponentModel.DataAnnotations;

namespace DataDomain.DbEntities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public UserRole UserRole { get; set; }
        [Required]
        public int UserRoleId { get; set; }
    }
}
