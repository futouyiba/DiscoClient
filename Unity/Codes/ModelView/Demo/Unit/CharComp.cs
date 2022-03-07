using UnityEngine;

namespace ET
{
    public enum CharType
    {
        Player,
        Npc,
    }
    
    public class CharComp:Entity, IAwake, IDestroy
    {
        public CharType CharType;
        public int PlayerId;

        protected CharComp(CharType charType, int playerId)
        {
            this.CharType = charType;
            this.PlayerId = playerId;
        }

    }
}