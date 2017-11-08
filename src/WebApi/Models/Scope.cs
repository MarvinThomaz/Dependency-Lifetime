using System;

namespace WebApi.Models
{
    public abstract class Scope : IDisposable
    {
        protected Scope(string name)
        {
            Key = $"{name} - {Guid.NewGuid().ToString()}";
        }

        public string Key { get; internal set; }

        public void Dispose()
        {
            Key = null;
        }

        ~Scope()
        {
            if (Key != null)
                Key = null;
        }
    }
}