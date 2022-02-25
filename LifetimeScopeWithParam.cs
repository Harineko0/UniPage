using VContainer;
using VContainer.Unity;

namespace UniPage
{
    public class LifetimeScopeWithParam<TParam> : LifetimeScope
    {
        public TParam Param;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(Param);
        }
    }
}