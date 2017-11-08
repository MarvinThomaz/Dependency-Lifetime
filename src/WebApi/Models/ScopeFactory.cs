namespace WebApi.Models
{
    public class ScopeFactory
    {
        private readonly TransientScope _firstTransientScope;
        private readonly TransientScope _secondTransientScope;
        private readonly ScopedScope _scopedScope;
        private readonly SingletonScope _singletonScope;

        public ScopeFactory(ScopedScope scopedScope, SingletonScope singletonScope, TransientScope firstTransientScope, TransientScope secondTransientScope)
        {
            _scopedScope = scopedScope;
            _singletonScope = singletonScope;
            _firstTransientScope = firstTransientScope;
            _secondTransientScope = secondTransientScope;
        }

        public Scope Singleton => _singletonScope;
        public Scope Scoped => _scopedScope;
        public Scope FirstTransient => _firstTransientScope;
        public Scope SecondTransient => _secondTransientScope;
    }
}