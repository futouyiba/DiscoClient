using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo, CharType charType)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
	        Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        // unitComponent.Add(unit);
	        
	        unit.AddComponent<MoveComponent>();
	        if (unitInfo.MoveInfo != null)
	        {
		        if (unitInfo.MoveInfo.X.Count > 0)
		        {
			        using (ListComponent<Vector3> list = ListComponent<Vector3>.Create())
			        {
				        list.Add(unit.Position);
				        for (int i = 0; i < unitInfo.MoveInfo.X.Count; ++i)
				        {
					        list.Add(new Vector3(unitInfo.MoveInfo.X[i], unitInfo.MoveInfo.Y[i], unitInfo.MoveInfo.Z[i]));
				        }

				        unit.MoveToAsync(list).Coroutine();
			        }
		        }
	        }

	        unit.AddComponent<ObjectWait>();
	        var charComp = unit.AddComponent<CharComp>();
	        charComp.CharType = charType;

	        // unit.AddComponent<XunLuoPathComponent>();
	        
	        Game.EventSystem.Publish(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }
        
        // todo a new factory method for player, and another for npc.
        // public static Unit CreatePlayer(Scene currentScene,currentScene float posX, float posY, int playerId, int figureId,)
    }
}
