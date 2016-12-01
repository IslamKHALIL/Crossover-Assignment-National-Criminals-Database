using System;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using NationalCriminalsDB.Service.Models;
using NationalCriminalsDB.Service.Repositories;
using NationalCriminalsDB.Service.ViewModels;

namespace NationalCriminalsDB.Service.Helpers
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<ServiceDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<SearchService>();
            container.RegisterType<ICriminalRepository, CriminalRepository>();
            container.RegisterType<ICrime, Crime>();
            container.RegisterType<ICriminal, Criminal>();
            container.RegisterType<IPDFCreator, PDFCreator>();
            container.RegisterType<IResultsViewModel, ResultsViewModel>();
            container.RegisterType<ICrimeViewModel, CrimeViewModel>();
            container.RegisterType<IMail, Mail>();
            container.RegisterType<IConfiguration, ConfigManagerFacade>();
        }
    }

    public class PerRequestLifetimeManager : LifetimeManager
    {
        private readonly object key = new object();

        public override object GetValue()
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Items.Contains(key))
                return HttpContext.Current.Items[key];
            else
                return null;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(key);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[key] = newValue;
        }
    }
}
