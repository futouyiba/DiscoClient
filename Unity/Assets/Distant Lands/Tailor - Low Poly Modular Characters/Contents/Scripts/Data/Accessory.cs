using UnityEngine;

namespace DistantLands.DataType
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Accessory", order = 361)]
    public class Accessory : ScriptableObject
    {

        public GameObject prefab;
        public BodyArea area;

        [Space(30)]


        public BodyMesh.EditableMaterial[] materials;



        [Space(30)]
        public Vector3 positionOffset;
        public Vector3 rotationOffset;

        [Space(30)]
        public Stats.Stat[] stats;

    }
}
