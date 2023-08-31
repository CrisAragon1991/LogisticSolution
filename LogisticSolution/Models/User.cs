using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogisticSolution.Models
{
    public enum RoleType
    {
        Admin,
        Client
    }
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] Password { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public RoleType Role { get; set;}

        public virtual ICollection<DeliverySchedule>? DeliverySchedules { get; set; }
    }
}
