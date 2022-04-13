using System.Collections.Generic;
using System.Threading.Tasks;

namespace ET
{
	public class UnitComponent: Entity, IAwake, IDestroy, IUpdate
	{
		public Dictionary<int, Unit> NpcUnits = new Dictionary<int, Unit>();
		public Dictionary<int, Unit> PlayerUnits = new Dictionary<int, Unit>();
		public int npcPopulateIndex = 0;
		public int npcInstantiateViewIndex = 0;
		public bool bStartInstantiateNpc = false;
	}
}