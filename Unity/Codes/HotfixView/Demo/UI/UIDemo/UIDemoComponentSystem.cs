using System;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
namespace ET{
    [ObjectSystem]
    public class UIDemoComponentAwakeSystem:AwakeSystem<UIDemoComponent>{
        public override void Awake(UIDemoComponent self){
            var rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.loginBtn = rc.Get<GameObject>("LoginBtn");
            self.loginBtn.GetComponent<Button>().onClick.AddListener(()=>{
                self.OnLogin();
            });
            self.account = rc.Get<GameObject>("Account");
            self.password = rc.Get<GameObject>("Password");
        }
    }
    public static class UIDemoComponentSystem{
        public static void OnLogin(this UIDemoComponent self){
            Debug.LogWarning("login");
        }
    }
}