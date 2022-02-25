using Cysharp.Threading.Tasks;

namespace UniPage
{
    public abstract class BasePage
    {
        public virtual UniTask Initialize()
        {
            return new UniTask();
        }
        
        public virtual UniTask Pause()
        {
            return new UniTask();
        }
        
        public virtual UniTask Resume()
        {
            return new UniTask();
        }
        
        public virtual UniTask Discard()
        {
            return new UniTask();
        }
    }

    public abstract class BasePage<TParam> : BasePage
    {
        protected TParam Parameter { get; }
        // private ReactiveProperty<TParam> parameter = new ReactiveProperty<TParam>();
        // public IReadOnlyReactiveProperty<TParam> Parameter => parameter;
        //
        // public void SetParameter(TParam param)
        // {
        //     parameter.Value = param;
        // }
    }
}