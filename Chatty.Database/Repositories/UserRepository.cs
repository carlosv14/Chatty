using System.Linq;
using Chatty.Database.Models;

namespace Chatty.Database.Repositories
{
    public class UserRepository : ChattyBaseRepository<ApplicationUser>
    {
        public UserRepository(ChattyContext context) 
            : base(context)
        {
            this.Context = context;
        }

        public override IQueryable<ApplicationUser> All()
        {
            return this.Context.Users;
        }
    }
}
