using System.Collections.Generic;
using System.Threading.Tasks;

namespace ET
{
	public class UnitComponent: Entity, IAwake, IDestroy
	{
		public Dictionary<long, Unit> NpcUnits = new Dictionary<long, Unit>();
		public Dictionary<int, Unit> PlayerUnits = new Dictionary<int, Unit>();
	}
}