using System;
using System.Collections.Generic;
using ET.Stage;
using UnityEngine;


namespace ET.Demo.Stage
{
    public class ParticleComponentUpdateSystem: UpdateSystem<ParticleComponent>
    {
        public override void Update(ParticleComponent self)
        {
            if (Input.GetKey(KeyCode.P))
            {
                if (self._testIsPlaying)
                {
                    self.OnOff("ParticleGroup1", false);
                    self._testIsPlaying = false;
                }
                else
                {
                    self.OnOff("ParticleGroup1", true);
                    self._testIsPlaying = true;
                }
            }
        }
    }
    
    
    
    public static class ParticleComponentSystem
    {
        public static void Init(this ParticleComponent self)
        {
            self.AddParticleGroup("ParticleGroup1");
        }
        
        public static bool AddParticleGroup(this ParticleComponent self, string tagName)
        {
            var Gos = GameObject.FindGameObjectsWithTag(tagName);
            if (!(Gos?.Length > 0))
            {
                Log.Error($"no gos found for tag {tagName}");
                return false;
            }

            // ParticleComponent.ParticleGroupInfo giCreated = new ParticleComponent.ParticleGroupInfo();
            var giCreated = CreateParticleGroupInfo();
            giCreated.Gos.AddRange(Gos);
            foreach (var go in Gos)
            {
                var particleSystems = go.GetComponentsInChildren<ParticleSystem>();
                if (!(particleSystems?.Length > 0))
                {
                    Log.Warning($"no particle system found for item {go.name}");
                    continue;
                }
                giCreated.particleSystems.AddRange(particleSystems);
            }

            if (!(giCreated.particleSystems?.Count > 0))
            {//没有particle system，有问题
                Log.Error($"no particle system found for Tag: {tagName}");
                return false;
            }

            self.dict.Add(tagName, giCreated);
            return true;
        }

        public static bool OnOff(this ParticleComponent self, string tagName, bool isOn)
        {
            ParticleComponent.ParticleGroupInfo gi;
            var ret = self.dict.TryGetValue(tagName, out gi);
            if (!ret)
            {
                Log.Error($"no gi for {tagName} found");
                return false;
            }
            
            foreach (ParticleSystem giParticleSystem in gi.particleSystems)
            {
                if (isOn) giParticleSystem.Play(true);
                else giParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
            return true;
        }

        public static ParticleComponent.ParticleGroupInfo CreateParticleGroupInfo()
        {
            ParticleComponent.ParticleGroupInfo infoCreated = new ParticleComponent.ParticleGroupInfo();
            infoCreated.Gos = new List<GameObject>();
            infoCreated.particleSystems = new List<ParticleSystem>();
            return infoCreated;
        }
        
    }
}