using System;
using UnityEngine;
namespace ET{
    [UIEvent(UIType.UIDemo)]
    public class UIDemoEvent:AUIEvent{
        public override async ETTask<UI> OnCreate(UIComponent uiComponent,UILayer uiLayer){
            await uiComponent.Domain.GetComponent<ResourcesLoaderComponent>().LoadAsync(UIType.UIDemo.StringToAB());
            var bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset(UIType.UIDemo.StringToAB(),UIType.UIDemo);
            var gameObject = UnityEngine.Object.Instantiate(bundleGameObject,UIEventComponent.Instance.UILayers[(int)uiLayer]);
            var ui = uiComponent.AddChild<UI,string,GameObject>(UIType.UIDemo,gameObject);
            ui.AddComponent<UIDemoComponent>();
            return ui;
        }
        public override void OnRemove(UIComponent uIComponent){
            ResourcesComponent.Instance.UnloadBundle(UIType.UIDemo.StringToAB());
        }
    }
}