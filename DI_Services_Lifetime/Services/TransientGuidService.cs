
namespace DI_Services_Lifetime.Services
{
    public class TransientGuidService : ITransientGuidService 
    {
        //  lightweight,short-lived objects
        // example: generating a Guid each time it's requested
        private readonly Guid Id;
        public TransientGuidService()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
