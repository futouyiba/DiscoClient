using UnityEngine;

namespace ET
{
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(EventType.AfterUnitCreate args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            var figureConfigId = args.Unit.ConfigId;
            var prefabName = "cSingle" +figureConfigId.ToString("00");
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>(prefabName);
	        
            GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            go.transform.position = new Vector3(args.Unit.Position.x * 12f, args.Unit.Position.y, args.Unit.Position.z * 8f);
            // todo random direction
            // go.transform.
            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            if (args.Unit.Config.Type == (int)UnitType.Player)
            {
                go.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            // args.Unit.AddComponent<AnimatorComponent>(); todo
            await ETTask.CompletedTask;
        }
    }
}