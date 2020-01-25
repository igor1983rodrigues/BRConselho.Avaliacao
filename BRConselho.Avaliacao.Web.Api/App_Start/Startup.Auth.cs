using Microsoft.Owin.Cors;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using BRConselho.Avaliacao.Model.Repository.Dao;
using BRConselho.Avaliacao.Model.Repository.IDao;

namespace BRConselho.Avaliacao.Web.Api
{
    internal static class StartupExtensao
    {
        public static void Configurar(this Container container)
        {
            container.Register<IAlunoDao, AlunoDao>();
            container.Register<IPessoaDao, PessoaDao>();
            container.Register<IProfessorDao, ProfessorDao>();
        }
    }

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var container = new Container();

            container.Configurar();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            var httpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(container)
            };

            //-- Habilita Cores
            app.UseCors(CorsOptions.AllowAll);

            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}