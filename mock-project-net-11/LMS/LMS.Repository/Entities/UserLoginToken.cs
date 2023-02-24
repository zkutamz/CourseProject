using System;

namespace LMS.Repository.Entities
{
    public class UserLoginToken
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
#nullable enable
        public string? Token { get; set; }
#nullable disable
        public DateTime Expires { get; set; } = DateTime.UtcNow.AddDays(7);
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;

    }
}
