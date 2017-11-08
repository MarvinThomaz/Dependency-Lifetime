namespace WebApi.Models
{
    public class SingletonScope : Scope
    {
        public SingletonScope() : base(nameof(SingletonScope))
        {
            
        }
    }
}