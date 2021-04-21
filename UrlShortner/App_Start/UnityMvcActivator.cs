using System.Linq;
using System.Web.Mvc;
using Unity.Mvc5;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UrlShortner.UnityMvcActivator), nameof(UrlShortner.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UrlShortner.UnityMvcActivator), nameof(UrlShortner.UnityMvcActivator.Shutdown))]

namespace UrlShortner
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.GetConfiguredContainer()));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.GetConfiguredContainer().Dispose();
        }
    }
}