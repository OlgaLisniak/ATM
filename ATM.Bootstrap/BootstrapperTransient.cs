using ATM.Bootstrap.Automapper;
using ATM.Business.Interfaces;
using ATM.Business.Services;
using ATM.Data;
using ATM.Data.Interfaces;
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
                 .As<ICreditCardService>().InstancePerRequest();
            builder.RegisterType<CreditCardRepository>()
                 .As<ICreditCardRepository>().InstancePerRequest();
            builder.RegisterType<OperationService>()
                .As<IOperationService>().InstancePerRequest();
            builder.RegisterType<OperationRepository>()
                 .As<IOperationRepository>().InstancePerRequest();
            builder.RegisterType<ATMAutoMapper>()
                 .As<IATMMapper>().InstancePerRequest();
        }
    }
}
