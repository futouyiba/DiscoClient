﻿using UnityEngine;
using Random = System.Random;

namespace ET
{
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        private static GameObject ScatterGO = null;
        private static Transform ScatterTransform = null;
        private static Transform BigCornerTransform = null;
        private static Transform SmallCornerTransform = null;
        static Vector3 bigPos = Vector3.zero;
        static Vector3 smallPos = Vector3.zero;
        protected override async ETTask Run(EventType.AfterUnitCreate args)
        {
            if (ScatterGO == null)
            {
                ScatterGO = GameObject.Find("Scatter");
                if (ScatterGO == null)
                {
                    ScatterGO = GameObject.FindWithTag("Player");
                }
                Log.Info("scatter gameobject:" + ScatterGO.ToString());
                ScatterTransform = ScatterGO.transform;
                BigCornerTransform = ScatterTransform.Find("big");
                SmallCornerTransform = ScatterTransform.Find("small");
                bigPos = BigCornerTransform.position;
                smallPos = SmallCornerTransform.position;
            }
            CharComp charComp = args.Unit.GetComponent<CharComp>();

            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            var figureConfigId = RandomHelper.RandUInt32() % 6;
            var prefabName = "cSingle" +figureConfigId.ToString("00");
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(prefabName);
	        
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            go.transform.position = new Vector3(Mathf.Lerp(smallPos.x, bigPos.x, charComp.playerData.x),
                Mathf.Lerp(smallPos.y, bigPos.y, 0.5f), Mathf.Lerp(smallPos.z, bigPos.z, charComp.playerData.y));
            
            // todo random direction
            // go.transform.
            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            if (charComp.CharType == CharType.Npc)
            {
                go.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
            }
            else
            {
                go.transform.GetChild(1).GetComponent<TextMesh>().color = Color.yellow;
            }
            // args.Unit.AddComponent<AnimatorComponent>(); todo
            await ETTask.CompletedTask;
        }
    }
}