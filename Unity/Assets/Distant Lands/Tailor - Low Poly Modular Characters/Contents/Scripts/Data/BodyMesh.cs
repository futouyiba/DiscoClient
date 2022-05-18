/** ---------------------------------------------------------------------------- **


    The basic extension used by Tailor for meshes and materials.

    - Distant Lands


*** ---------------------------------------------------------------------------- */



using UnityEngine;


namespace DistantLands.DataType
{

    [System.Serializable]
    [CreateAssetMenu(menuName = "Distant Lands/Tailor Body Mesh", order = 361)]
    public class BodyMesh : ScriptableObject
    {

        [Tooltip("The mesh this will use.")]
        public Mesh mesh;
        [Tooltip("The section of the body that this mesh corresponds to.")]
        public BodyPart bodyPart;


        [System.Serializable]
        public class EditableMaterial
        {

            public enum ColorType
            {
                skin, hair, primary, secondary, tertiary, additional, custom

            };


            [Tooltip("Which color from the customizer does this submesh use? Set custom to use the color of the material.")]
            public ColorType colorType;
            [Tooltip("The material that this submesh will base its new material off of.")]
            public Material material;
            [Space(20)]
            [Range(-1, 1)]
            [Tooltip("Tweak the value of the original color.")]
            public float valueChange;
            [Range(-1, 1)]
            [Tooltip("Tweak the saturation of the original color.")]
            public float saturationChange;

            



        }

        public EditableMaterial[] materials;

        [Space(20)]
        public Stats.Stat[] stats;


        public enum BodyPart
        {
            head, torso, legs, shoes

        };



        public float GetStat(Statistic stat)
        {

            float j = 0;

            //foreach (Statistic i in stats)
            //    if (i == stat)
            //        j = i.amount;

            return j;

        }

    }
}