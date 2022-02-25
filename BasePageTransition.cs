using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer.Unity;

namespace UniPage
{
    public class BasePageTransition<TPage> : IPageTransition where TPage : BasePage
    {
        public virtual async UniTask<BasePage> LoadPage()
        {
            var pageInstance = await DoPrefabLoad();
            var pageLifetimeScope = pageInstance.GetComponent<LifetimeScope>();
            InitializePageParameter(pageLifetimeScope);
            pageLifetimeScope.Build();
            var page = (TPage) pageLifetimeScope.Container.Resolve(typeof(TPage));
            return page;
        }

        private async UniTask<GameObject> DoPrefabLoad()
        {
            var pageNameAttr = Attribute.GetCustomAttribute(typeof(TPage), typeof(PageAssetAttribute)) as PageAssetAttribute;
            if (String.IsNullOrEmpty(pageNameAttr?.AssetLocation))
            {
                Debug.LogError("Declare scene name attribute in page class: " + typeof(TPage));
                return null;
            }
            
            var prefab = await Addressables.LoadAssetAsync<GameObject>(pageNameAttr.AssetLocation);
            return GameObject.Instantiate(prefab);
        }
        
        protected virtual void InitializePageParameter(LifetimeScope scope) {}
    }

    public class BasePageTransition<TPage, TParam> : BasePageTransition<TPage> where TPage : BasePage<TParam>
    {
        public TParam Parameter { get; set; }

        protected override void InitializePageParameter(LifetimeScope scope)
        {
            if (scope is LifetimeScopeWithParam<TParam> s)
            {
                s.Param = Parameter;
            }
        }
    }
}