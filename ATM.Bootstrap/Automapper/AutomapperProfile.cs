using ATM.Business.DTO;
using ATM.Data.Models;
using AutoMapper;

namespace ATM.Bootstrap.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Operation, OperationDTO>().ReverseMap();
        }
    }
}
