using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.DataType
{
    [HideInInspector]
    [System.Serializable]
    public class SaveProperties
    {
        public string gender;

        [Space(20)]
        public string head;
        public string torso;
        public string legs;
        public string shoes;

        [Space(20)]
        public Color skin = Color.white;
        public Color hair = Color.white;

        [Space(20)]
        public Color primary = Color.white;
        public Color secondary = Color.white;
        public Color tertiary = Color.white;
        public Color additional = Color.white;


        public string[] accessories;

    }
}