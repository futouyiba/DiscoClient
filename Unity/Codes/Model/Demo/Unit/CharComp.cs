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
        public int PlayerId; 

        /// <summary>
        /// every once and a while, the char will move or stay still, or do something else.
        /// the interval would be random, the action will be random.
        /// Doesn't need state machine, for moving don't intertwine with other actions.
        ///
        /// For a player, this wandering will be terminated by player actions.
        /// </summary>
        public void Wander()
        {
            
        }
        
        /// <summary>
        /// 搭讪的应对上 玩家和npc完全不同
        /// </summary>
        public virtual void ReactToDashan()
        {
            
        }
        
        
    }
    
    
}