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

    public class LightGroupInfo
    {
        public LightBehaviourType behType;
        public bool isOn;
    }

    public class LightComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public LightBehaviourType type;
        public Dictionary<int, GameObject> GoDict = new Dictionary<int, GameObject>();
        public Dictionary<int, LightGroupInfo> GroupInfoDict = new Dictionary<int, LightGroupInfo>();

    }
}