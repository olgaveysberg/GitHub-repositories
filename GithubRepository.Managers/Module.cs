using Autofac;

namespace GithubRepository.Managers
{
    public class Module : Autofac.Module // Autofac is an addictive Inversion of Control container for .NET Core, ASP.NET Core, .NET 4.5.1+
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            //registers repository manager
            builder.RegisterType<RepositoryManager>().As<IRepositoryManager>();
            //registers accessor module to register repository accessor
            builder.RegisterModule<Accessors.Module>();
        }
    }
}
