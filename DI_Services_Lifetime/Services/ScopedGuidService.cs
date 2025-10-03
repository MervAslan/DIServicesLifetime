namespace DI_Services_Lifetime.Services
{
    public class ScopedGuidService : IScopedGuidService
    {
        //Objects that should stay the same during a request
        // example: user session,DbContext
        private readonly Guid Id;
        public ScopedGuidService()
        {
            Id = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
    
    
}
