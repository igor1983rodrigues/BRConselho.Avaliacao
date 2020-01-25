//namespace BRConselho.Avaliacao.Web.Api
//{
//	internal static class StartupExtensao
//	{
//		public static void Configurar(this Container container)
//		{
//			container.Register<ITelefoneDao, TelefoneDao>();
//			container.Register<IEmpresaDao, EmpresaDao>();
//			container.Register<IFornecedorDao, FornecedorDao>();
//			container.Register<IFornecedorPessoaFisicaDao, FornecedorPessoaFisicaDao>();
//			container.Register<IFornecedorPessoaJuridicaDao, FornecedorPessoaJuridicaDao>();
//		}
//	}

//	public partial class Startup
//	{
//		public void ConfigureAuth(IAppBuilder app)
//		{
//			var container = new Container();

//			container.Configurar();
//			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
//			container.RegisterMvcIntegratedFilterProvider();

//			container.Verify();

//			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

//			var httpConfiguration = new HttpConfiguration
//			{
//				DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(container)
//			};

//			//-- Habilita Cores
//			app.UseCors(CorsOptions.AllowAll);

//			WebApiConfig.Register(httpConfiguration);
//			app.UseWebApi(httpConfiguration);
//		}
//	}
//}