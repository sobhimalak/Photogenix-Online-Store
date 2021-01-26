using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.DataAccess.SQL;
using PhotographyOnlineStore.Services;
using PhotoographyOnlineStore.Core.Contracts;
using PhotoographyOnlineStore.Core.Models;
using System;

using Unity;

namespace PhotographyOnlineStore.WebUI
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
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepository<Product>, SqlRepository<Product>>();
            container.RegisterType<IRepository<ProductCategory>, SqlRepository<ProductCategory>>();
            container.RegisterType<IRepository<ShoppingCart>, SqlRepository<ShoppingCart>>();
            container.RegisterType<IRepository<ShoppingCartItem>, SqlRepository<ShoppingCartItem>>();
            container.RegisterType<IShoppingCartService, ShoppingCartService>();
            container.RegisterType<IRepository<Customer>, SqlRepository<Customer>>();
            container.RegisterType<IRepository<Order>, SqlRepository<Order>>();
            container.RegisterType<IOrderService, OrderService>();

        }
    }
}