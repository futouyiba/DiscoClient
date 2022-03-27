using UnityEngine;
using TMPro;

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
        static Vector3 bigPosOuter = Vector3.zero;
        static Vector3 smallPosOuter = Vector3.zero;

        public static (float, float) UnityPosToServerXY(Vector3 unityPos)
        {
            if (ScatterGO == null)
            {
                return (0f, 0f);
            }

            var x = Mathf.Clamp01((unityPos.x - smallPos.x) / (bigPos.x - smallPos.x));
            var y = Mathf.Clamp01((unityPos.z - smallPos.z) / (bigPos.z - smallPos.z));
            return (x, y);
        }

        public static Vector3 ServerXYToUnityPos(float x, float y)
        {
            if (ScatterGO == null)
            {
                return Vector3.zero;
            }

            return new Vector3(Mathf.Lerp(smallPos.x, bigPos.x, x),
                Mathf.Lerp(smallPos.y, bigPos.y, 0.5f), Mathf.Lerp(smallPos.z, bigPos.z, y));
        }
        
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
            uint figureConfigId;
            if (charComp.CharType == CharType.Npc)
            {
                figureConfigId = RandomHelper.RandUInt32() % 6;
            }
            else
            {
                figureConfigId = (uint)charComp.playerData.figure_id;
            }
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
            GameObjectComponent gameObjectComp = args.Unit.AddComponent<GameObjectComponent>();
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
            else
            {
                go.transform.GetChild(1).GetComponent<TextMeshPro>().color = Color.yellow;
            }
            // args.Unit.AddComponent<AnimatorComponent>(); todo
            if (charComp.playerData.is_dj != 0)
            {
                await Game.EventSystem.PublishAsync(new EventType.BecomeDJ() { Unit = args.Unit , SeatId = charComp.playerData.is_dj});
            }

            await ETTask.CompletedTask;
        }
    }
}