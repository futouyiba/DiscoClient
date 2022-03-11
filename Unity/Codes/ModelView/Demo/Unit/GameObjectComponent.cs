using UnityEngine;
using TMPro;

namespace ET
{
    public class GameObjectComponent: Entity, IAwake, IDestroy
    {
        public GameObject GameObject;
        public TextMeshPro NameTMP;
        public Vector3 OriScale;
        public GameObject SpriteGO;
        public SpriteRenderer SpriteRenderer;
        /// <summary>
        /// 1f = face right(basically what we originally design); -1f = face left(opposite to the prefab);
        /// </summary>
        public float FowardDirection;
    }
}