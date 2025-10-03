namespace DI_Services_Lifetime.Services
{
    public class SingletonGuidService : ISingletonGuidService
    {
        //Shared objects for the entire app
        // example: logging, caching, configuration
        private readonly Guid Id;
        public SingletonGuidService()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
