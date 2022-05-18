using UnityEngine;

namespace DistantLands.DataType
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Aesthetic", order = 361)]
    public class Aesthetic : ScriptableObject
    {



        [Tooltip("The main color. Mostly used by the torso")]
        public Color primary = Color.white;
        [Tooltip("The secondary color. Mostly used by the legs.")]
        public Color secondary = Color.white;
        [Tooltip("The tertiary color. Mostly used by the shoes.")]
        public Color tertiary = Color.white;
        [Tooltip("The accent color. Used sparingly.")]
        public Color additional = Color.white;

    }
}