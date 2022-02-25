using Cysharp.Threading.Tasks;

namespace UniPage
{
    public interface IPageTransition
    {
        public UniTask<BasePage> LoadPage();
    }
}