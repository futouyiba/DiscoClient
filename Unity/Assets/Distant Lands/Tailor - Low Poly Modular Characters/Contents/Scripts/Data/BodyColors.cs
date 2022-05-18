using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.DataType
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Body Colors", order = 361)]
    public class BodyColors : ScriptableObject
    {

        public List<Color> skinColors;
        public List<Color> hairColors;


    }
}