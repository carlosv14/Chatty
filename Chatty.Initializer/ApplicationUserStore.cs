using Chatty.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Chatty.Initializer
{
    public class ApplicationUserStore : UserStore<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUserStore<ApplicationUser>, IUserStore<ApplicationUser, string>, IDisposable
    {
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }
}
