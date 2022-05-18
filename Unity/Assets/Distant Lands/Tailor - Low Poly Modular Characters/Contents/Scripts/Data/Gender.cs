
using System.Collections.Generic;
using UnityEngine;


namespace DistantLands.DataType
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Gender", order = 361)]
    public class Gender : ScriptableObject
    {

        public Avatar animationAvatar;


        [Tooltip("The name to switch the root bone to in order to use the proper avatar for this gender")]
        public string rootBoneName;



        [Space(20)]
        public List<BodyMesh> headMeshes;
        public List<BodyMesh> torsoMeshes;
        public List<BodyMesh> legsMeshes;
        public List<BodyMesh> shoesMeshes;


    }
}