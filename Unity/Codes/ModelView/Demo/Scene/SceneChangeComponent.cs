using System;
using TMPro;
using UnityEngine;

namespace ET
{
    public class SceneChangeComponent: Entity, IAwake, IUpdate, IDestroy
    {
        public AsyncOperation loadMapOperation;
        public ETTask tcs;
        // public Action<int> Dlg_UpdateProcess;
        public TextMeshPro tmp;
    }
}