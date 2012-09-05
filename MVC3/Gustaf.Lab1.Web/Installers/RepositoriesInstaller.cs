using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Gustaf.Lab1.Web.Repositories;

namespace ToBeSeen.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .Where(Component.IsInSameNamespaceAs<Repository>())
                                .WithService.DefaultInterfaces()
                                .LifestyleTransient());
        }
    }
}