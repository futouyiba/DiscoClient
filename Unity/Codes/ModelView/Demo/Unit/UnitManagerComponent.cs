using UnityEngine;

namespace ET
{
    /// <summary>
    /// still thinking about the relation between this and UnitComponent...
    /// </summary>
    public class UnitManagerComponent: Entity, IAwake, IDestroy
    {
        private static GameObject ScatterGO;
        private static Transform ScatterTransform;
        private static Transform BigCornerTransform;
        private static Transform SmallCornerTransform;
    }
}