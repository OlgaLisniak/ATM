namespace ATM.Business.Interfaces
{
    public interface IATMMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
