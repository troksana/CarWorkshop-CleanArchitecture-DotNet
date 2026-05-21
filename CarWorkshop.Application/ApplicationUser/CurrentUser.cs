using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.ApplicationUser
{
    //reprezentacja aktualnie zalogowanego uzytkowanika
    public class CurrentUser
    {
        public CurrentUser(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
            Roles = roles;
        }
        public string Id { get; set; }
        public string Email {  get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
