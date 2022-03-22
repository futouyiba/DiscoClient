using System.Collections.Generic;
using UnityEngine;

namespace ET.Light
{
    public enum LightBehaviourType
    {
        DiscoBall,
        Quad,
        Laser,
        SpotBall,
        Cookie,
        
    }

    public class LightComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public LightBehaviourType type;
        public Dictionary<int,GameObject> GoDict;
        
    }
}