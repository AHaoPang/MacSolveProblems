using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ForSolveProblem
{
    public class CastleAbout : IProblem
    {
        public CastleAbout()
        {
        }

        public void RunProblem()
        {
            Test1();
        }

        private void Test1()
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.InThisApplication(GetType().Assembly));

            var king = container.Resolve<ILearn>();
            var temp = king.SaySomeStr();

            container.Dispose();
        }


        public interface ILearn
        {
            string SaySomeStr();
        }

        public class LearnSome : ILearn
        {
            public string SaySomeStr() => "Hello~";
        }
    }

    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(GetType().Assembly)
                .Where(Component.IsInSameNamespaceAs<CastleAbout>())
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }
}
