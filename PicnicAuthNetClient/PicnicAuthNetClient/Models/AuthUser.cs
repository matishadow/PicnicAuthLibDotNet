using System;

namespace PicnicAuthNetClient.Models
{
    public class AuthUser
    {
        public string ExternalId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}