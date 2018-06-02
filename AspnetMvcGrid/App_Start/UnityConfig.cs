using System;

using Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using AspnetMvcGrid.Interfaces;



namespace AspnetMvcGrid
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              container.LoadConfiguration();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            //container.RegisterType<IAppDbContext, ApplicationDbContext>();
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
         //container.RegisterType<UserManager<ApplicationUserIdentity>>();
            //container.RegisterType<DbContext, ApplicationDbContext>();
         //container.RegisterType<ApplicationUserManager>();
            //container.RegisterType<AccountController>(new InjectionConstructor());
        }

        public static IAppDbContext CreateDbContext()
        {
            return Container.Resolve< IAppDbContext>();
        }

        public static IAppDbContext CreateDbContext(string dataProviderName)
        {
            return Container.Resolve<IAppDbContext>(dataProviderName);
        }
    }
}