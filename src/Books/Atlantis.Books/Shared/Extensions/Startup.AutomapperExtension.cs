namespace Atlantis.Books.Shared.Extensions
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Startup
    {
        #region Configure Services
        public static IServiceCollection AddAtlantisAutomapper(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("Atlantis Automapper: Configuring services...");

            var atlantisAssemblies = GetAtlantisAssemblies();
            var mapper = GetMapper(atlantisAssemblies);
            services.AddSingleton(mapper);

            logger.LogInformation("Atlantis Automapper: Successfully configured services.");

            return services;
        }
        #endregion Configure Services

        #region Private Methods
        private static IMapper GetMapper(IEnumerable<Assembly> atlantisAssemblies) =>
            new MapperConfiguration(configExp => configExp.AddMaps(atlantisAssemblies.ToArray()))
                .CreateMapper();

        private static IEnumerable<Assembly> GetAtlantisAssemblies() =>
            AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.GetName().FullName.StartsWith("Atlantis."));
        #endregion Private Methods
    }
}
