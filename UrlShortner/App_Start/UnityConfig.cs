using System;

using Unity;
using UrlShortner.Web.Business;
using UrlShortner.Web.Business.Impl;

namespace UrlShortner
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUrlManager, UrlManager>();
        }
    }
}