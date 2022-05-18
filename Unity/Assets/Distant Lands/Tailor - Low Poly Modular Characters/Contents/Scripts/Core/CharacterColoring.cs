/** ---------------------------------------------------------------------------- **


    Used by the UI to set colors in the customizer from presets.

    - Distant Lands


*** ---------------------------------------------------------------------------- */


using UnityEngine;
using DistantLands.DataType;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/Character Coloring")]
    public class CharacterColoring : MonoBehaviour
    {


        [Space(20)]
        public Aesthetic[] aesthetics;

        [Space(20)]
        public BodyColors bodyColoring;

        private CharacterCustomizer characterCustomizer;


        private void Start()
        {

            characterCustomizer = FindObjectOfType<CharacterCustomizer>();



        }

        public void SetPalette(Aesthetic aesthetic)
        {


            characterCustomizer.primaryColor = aesthetic.primary;
            characterCustomizer.secondaryColor = aesthetic.secondary;
            characterCustomizer.tertiaryColor = aesthetic.tertiary;
            characterCustomizer.additionalColor = aesthetic.additional;


        }




    }
}