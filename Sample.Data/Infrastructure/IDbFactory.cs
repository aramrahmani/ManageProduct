using System;

namespace Sample.Data
{
    public interface IDbFactory : IDisposable
    {
        SampleEntities Init();
    }
}
