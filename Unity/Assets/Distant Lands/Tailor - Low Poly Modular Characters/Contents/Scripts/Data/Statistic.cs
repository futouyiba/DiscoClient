using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.DataType
{
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Statistic", order = 361)]
    public class Statistic : ScriptableObject
    {
        public string displayName = "New Stat";
        [Tooltip("Use for descriptions.")]
        [Multiline]
        public string extendedText = "Use this for description";

        [Space(20)]
        public float maxAmount = 10;

        [Space(20)]
        public Sprite icon;

    }
}