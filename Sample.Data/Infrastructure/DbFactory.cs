
namespace Sample.Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        SampleEntities dbContext;

        public SampleEntities Init()
        {
            return dbContext ?? (dbContext = new SampleEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
