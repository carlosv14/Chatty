[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Chatty.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Chatty.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Chatty.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using Chatty.Core.Authentication;
    using Chatty.Core.ChatRoom;
    using Chatty.Core.Message;
    using Chatty.Core.User;
    using Chatty.Database;
    using Chatty.Database.Models;
    using Chatty.Database.Repositories;
    using Chatty.Web.Hubs.Clients;
    using Chatty.Web.Hubs.Servers;
    using Chatty.Web.Hubs.Tickers;
    using Chatty.Web.Utils.Security;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.DataProtection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ChattyContext>().ToSelf().InRequestScope();
            kernel.Bind<DbContext>().ToMethod(c => c.Kernel.Get<ChattyContext>());

            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InRequestScope();
            kernel.Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole>>().InRequestScope();
            kernel.Bind<IDataProtectionProvider>().To<MachineKeyDataProtectionProvider>().InRequestScope();
            kernel.Bind<IDataProtector>().ToMethod((k) => k.Kernel.Get<IDataProtectionProvider>().Create("ASP.NET Identity")).InRequestScope();
            kernel.Bind<DataProtectorTokenProvider<ApplicationUser>>().ToSelf().InRequestScope();
            kernel.Bind<UserManager<ApplicationUser>>().To<ApplicationUserManager>().InRequestScope();
            kernel.Bind<RoleManager<IdentityRole>>().ToSelf().InRequestScope();
            kernel.Bind<IAuthenticationManager>().ToMethod((k) => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            kernel.Bind<ApplicationSignInManager>().ToSelf().InRequestScope();

            kernel.Bind<IRepository<ChatRoom>>().To<ChatRoomRepository>();
            kernel.Bind<IRepository<ApplicationUser>>().To<UserRepository>();
            kernel.Bind<IRepository<Message>>().To<MessageRepository>();

            kernel.Bind<IChatRoomManager>().To<ChatRoomManager>();
            kernel.Bind<IUserManager>().To<UserManager>();
            kernel.Bind<IMessageManager>().To<MessageManager>();

            GlobalHost.DependencyResolver = new SignalRStartupResolver(kernel);
            kernel.Bind<ChatHub>().ToSelf().InRequestScope();
            kernel.Bind<IChatTicker>().To<ChatTicker>().InRequestScope();
            kernel.Bind<IHubContext<IChatClient>>().ToMethod(c => GlobalHost.ConnectionManager.GetHubContext<ChatHub, IChatClient>());
        }     
        
        private class SignalRStartupResolver : DefaultDependencyResolver
        {
            private readonly IKernel kernel;
            public SignalRStartupResolver(IKernel kernel)
            {
                this.kernel = kernel;
            }
            public override object GetService(Type serviceType)
            {
                return this.kernel.TryGet(serviceType) ?? base.GetService(serviceType);
            }

            public override IEnumerable<object> GetServices(Type serviceType)
            {
                return this.kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
            }
        }
    }
}
