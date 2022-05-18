using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DistantLands.DataType
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Variables", order = 361)]
    public class TailorVariables : ScriptableObject
    {

        public Gender gender;

        [Space(20)]
        public BodyMesh head;
        public BodyMesh torso;
        public BodyMesh legs;
        public BodyMesh shoes;

        [Space(20)]
        public Color skin = Color.white;
        public Color hair = Color.white;

        [Space(20)]
        public Color primary = Color.white;
        public Color secondary = Color.white;
        public Color tertiary = Color.white;
        public Color additional = Color.white;

        [Space(20)]
        public Accessory[] accessories;


    }
}