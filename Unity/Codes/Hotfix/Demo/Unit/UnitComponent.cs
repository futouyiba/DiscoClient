namespace ET
{
	[ObjectSystem]
	public class UnitComponentAwakeSystem : AwakeSystem<UnitComponent>
	{
		public override void Awake(UnitComponent self)
		{
		}
	}
	
	[ObjectSystem]
	public class UnitComponentDestroySystem : DestroySystem<UnitComponent>
	{
		public override void Destroy(UnitComponent self)
		{
		}
	}
	
	public static class UnitComponentSystem
	{
		public static void Add(this UnitComponent self, Unit unit)
		{
		}

		public static Unit Get(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			return unit;
		}

		public static void Remove(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			unit?.Dispose();
		}

		public static bool AddNpc(this UnitComponent self, Unit unit)
		{
			if (!self.NpcUnits.ContainsKey(unit.Id))
			{
				self.NpcUnits.Add(unit.Id, unit);
				return true;
			}

			return false;
		}

		public static bool RemoveNpc(this UnitComponent self, Unit unit)
		{
			if (self.NpcUnits.ContainsKey(unit.Id))
			{
				self.NpcUnits.Remove(unit.Id);
				return true;
			}

			return false;
		}

		public static bool AddPlayer(this UnitComponent self, Unit unit)
		{
			if (!self.PlayerUnits.ContainsKey(unit.Config.Id))
			{
				self.PlayerUnits.Add(unit.Config.Id, unit);
				return true;
			}

			return false;
		}

		public static bool RemovePlayer(this UnitComponent self, Unit unit)
		{
			if (self.PlayerUnits.ContainsKey(unit.Config.Id))
			{
				self.PlayerUnits.Remove(unit.Config.Id);
				return true;
			}

			return false;
		}
	}
}