using ATM.Business.Interfaces;
using AutoMapper;

namespace ATM.Bootstrap.Automapper
{
    public class ATMAutoMapper : IATMMapper
    {
        private readonly IMapper mapper;

        public ATMAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            });

            mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }
    }
}
