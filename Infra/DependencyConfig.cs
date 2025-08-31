using AuthorsBooksApp.Controllers;
using AuthorsBooksApp.Services;
using AuthorsBooksApp.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Web.Mvc;

namespace AuthorsBooksApp.Infra
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            container.Register<IBookService, BookService>(Lifestyle.Transient);
            container.Register<IAuthorService, AuthorService>(Lifestyle.Transient);
            container.Register<IApiClientService, ApiClientService>(Lifestyle.Transient);
            container.Register<IAuthService, AuthService>(Lifestyle.Transient);



            container.RegisterMvcControllers();
            container.RegisterMvcIntegratedFilterProvider();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}