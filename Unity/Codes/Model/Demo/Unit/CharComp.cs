using UnityEngine;

namespace ET
{
    public enum CharType
    {
        Player,
        Npc,
    }
    
    public class CharComp:Entity, IAwake
    {
        public CharType CharType;
        // use the id within Unit instead...
        // public int PlayerId; 


    }
}