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
        public float FowardDirection;
    }
}