using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Stage
{
    public class ParticleComponent:Entity,IAwake,IUpdate
    {
        public Dictionary<string, ParticleGroupInfo> dict= new Dictionary<string, ParticleGroupInfo>();
        public bool _testIsPlaying;
        public struct ParticleGroupInfo
        {
            //所有这个组里有标签的go
            public List<GameObject> Gos;
            //所有这个组里的particlesystem
            public List<ParticleSystem> particleSystems;

        } 
    }
}