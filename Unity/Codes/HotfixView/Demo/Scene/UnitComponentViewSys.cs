using TMPro;
using UnityEngine;

namespace ET
{
    public class UnitComponentUpdateSystem : UpdateSystem<UnitComponent>
    {
        private static GameObject ScatterGO = null;
        private static Transform ScatterTransform = null;
        private static Transform BigCornerTransform = null;
        private static Transform SmallCornerTransform = null;
        static Vector3 bigPos = Vector3.zero;
        static Vector3 smallPos = Vector3.zero;
        static Vector3 bigPosOuter = Vector3.zero;
        static Vector3 smallPosOuter = Vector3.zero;
        public override void Update(UnitComponent self)
        {
            if (!self.bStartInstantiateNpc)
                return;

            if (self.npcInstantiateViewIndex >= self.npcPopulateIndex)
            {
                self.bStartInstantiateNpc = false;
                self.npcPopulateIndex = 0;
                return;
            }
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
            
            var npcUnit = self.NpcUnits[self.npcInstantiateViewIndex];
            CharComp charComp = npcUnit.GetComponent<CharComp>();
            uint figureConfigId = (uint)charComp.playerData.figure_id;
            var prefabName = "cSingle" +figureConfigId.ToString("00");
            //GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            var bundleGameObject = AddressableComponent.Instance.LoadAssetByPath<GameObject>("Unit.unity3d");
            GameObject prefab = bundleGameObject.Get<GameObject>(prefabName);
	        
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            // go.transform.position = new Vector3(Mathf.Lerp(smallPos.x, bigPos.x, charComp.playerData.x),
                // Mathf.Lerp(smallPos.y, bigPos.y, 0.5f), Mathf.Lerp(smallPos.z, bigPos.z, charComp.playerData.y));
            go.transform.position = AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(charComp.playerData.x, charComp.playerData.y);
            // todo random direction
            // go.transform.
            GameObjectComponent gameObjectComp = npcUnit.AddComponent<GameObjectComponent>();
            gameObjectComp.GameObject = go;
            gameObjectComp.FowardDirection = RandomHelper.RandFloat01() < 0.5f? 1f : -1f;
            gameObjectComp.SpriteGO = go.transform.GetChild(0).gameObject;
            gameObjectComp.SpriteRenderer = gameObjectComp.SpriteGO.GetComponent<SpriteRenderer>();
            gameObjectComp.OriScale = gameObjectComp.SpriteGO.transform.localScale;
            gameObjectComp.NameTMP = go.transform.GetChild(1).GetComponent<TextMeshPro>();
            if (charComp.CharType == CharType.Npc)
            {
                // go.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);//todo refactor to XiuGouComponent
                go.transform.GetChild(1).GetComponent<TextMeshPro>().text = charComp.playerData.player_name;
                gameObjectComp.StartRandomMovePeriodical().Coroutine();
            }
            
            self.npcInstantiateViewIndex++;
        }
    }
}