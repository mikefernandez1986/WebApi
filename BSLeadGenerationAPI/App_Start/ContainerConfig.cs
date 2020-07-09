using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using LeadGenerationAdminBO;
using LeadGenerationAdminBO.Interfaces;
using LeadGenerationAdminDAO;
using LeadGenerationAdminDAO.ILeadGen;

namespace BSLeadGenerationAdminAPI.App_Start
{
    /// <summary>
    /// This is used for dependency injection.
    /// This is the prefered way when we have a test driven environnement.
    /// used in this project with a future perspective to provide automated test cases on a CI/CD pipeline if decided for a container based deployment
    /// </summary>
    public static class ContainerConfig
    {
        public static IContainer RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LeadGenBO>().As<ILeadGenBO>();
            builder.RegisterType<LeadGenDAO>().As<ILeadGenDAO>();
            var container = builder.Build();

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
            return container;
        }
    }
}