using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UniPage
{
    public class PageManager : MonoBehaviour
    {
        private Stack<BasePage> pages = new Stack<BasePage>();
        
        public async UniTask PushAsync(IPageTransition transition)
        {
            var page = await transition.LoadPage();
            if (pages.Count > 0)
            {
                var currentPage = pages.Peek();
                await currentPage.Pause();
            }
            await page.Initialize();
            pages.Push(page);
        }

        public async void Pop()
        {
            if (pages.Count > 0)
            {
                var current = pages.Pop();
                await current.Pause();
                await current.Discard();
            }

            pages.Peek()?.Resume();
        }

        public async UniTask ReplaceAllAsync(IPageTransition transition)
        {
            while (pages.Count > 0)
            {
                var screen = pages.Pop();
                await screen.Discard();
            }

            PushAsync(transition);
        }
    }
}