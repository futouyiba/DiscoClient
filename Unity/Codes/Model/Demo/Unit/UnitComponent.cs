using System.Collections.Generic;

namespace ET
{
	public class UnitComponent: Entity, IAwake, IDestroy
	{
		public Dictionary<long, Unit> NpcUnits;
		public Dictionary<int, Unit> PlayerUnits;
	}
}