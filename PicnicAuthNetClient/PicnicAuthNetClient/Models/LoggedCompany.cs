using System;

namespace PicnicAuthNetClient.Models
{
    public class LoggedCompany
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}