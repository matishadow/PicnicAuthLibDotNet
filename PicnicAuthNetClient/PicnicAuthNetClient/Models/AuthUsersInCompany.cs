using System.Collections.Generic;

namespace PicnicAuthNetClient.Models
{
    public class AuthUsersInCompany
    {
        public IEnumerable<AuthUser> AuthUsers { get; set; }
    }
}