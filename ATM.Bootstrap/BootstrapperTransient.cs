using ATM.Bootstrap.Automapper;
using ATM.Business.Services;
using ATM.Data;
using ATM.Data.Repositories;
using Autofac;
using System.Data.Entity;

namespace ATM.Bootstrap
{
    public class BootstrapperTransient
    {
        public void SetInitializer()
        {
            Database.SetInitializer(new ATMDbInitializer());
        }

        public void RegisterDomainModels(ContainerBuilder builder)
        {
            builder.RegisterType<ATMDbContext>().InstancePerRequest();

            builder.RegisterType<CreditCardService>()
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<CreditCardRepository>()
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<OperationService>()
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<OperationRepository>()
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<ATMAutoMapper>()
                .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
