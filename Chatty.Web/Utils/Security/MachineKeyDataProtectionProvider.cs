using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatty.Web.Utils.Security
{
    public class MachineKeyDataProtectionProvider : IDataProtectionProvider
    {
        public MachineKeyDataProtectionProvider()
        {
        }

        public IDataProtector Create(params string[] purposes)
        {
            return new MachineKeyDataProtector(purposes);
        }
    }
}