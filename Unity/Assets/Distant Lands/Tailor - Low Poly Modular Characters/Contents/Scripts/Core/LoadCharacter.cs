/** ---------------------------------------------------------------------------- **


    Manages loading of characters.

    - Distant Lands


*** ---------------------------------------------------------------------------- */


using UnityEngine;
using DistantLands.DataType;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/Character Loading")]
    public class LoadCharacter : MonoBehaviour
    {



        private CharacterColoring coloring;
        [HideInInspector]
        public CharacterCustomizer customizer;
        [Space(20)]
        public bool loadOnStart;
        public int slot;
        public TailorVariables variables;

        public enum LoadType
        {
            Random,
            Slot,
            Variables
        }

        public LoadType loadType;


        void Start()
        {

            if (!GetComponent<CharacterColoring>() || !GetComponent<CharacterCustomizer>())
                enabled = false;

           coloring = GetComponent<CharacterColoring>();
           customizer = GetComponent<CharacterCustomizer>();



            if (loadOnStart)
                Load();


        }

        public void Load()
        {
            switch (loadType)
            {
                case LoadType.Random: LoadRandom(); break;
                case LoadType.Slot: LoadSlot(); break;
                case LoadType.Variables: LoadVariables(); break;
            }

            if (customizer.accessories)
                customizer.accessories.UpdateProps();

        }

        public void LoadSlot()
        {


            if (PlayerPrefs.GetString("Tailor Slot " + slot) != "")
                customizer.LoadChar(slot);
            else
                LoadVariables();


        }

        public void LoadVariables()
        {

            if (!variables)
            {
                LoadRandom();
                return;
            }
            if (!variables.gender || !variables.head || !variables.torso || !variables.legs || !variables.shoes)
            {
                LoadRandom();
                return;
            }

            int i = customizer.GenderFromString(variables.gender.name);

            customizer.genderNum = i;

            customizer.skinColor = variables.skin;
            customizer.hairColor = variables.hair;
            customizer.primaryColor = variables.primary;
            customizer.secondaryColor = variables.secondary;
            customizer.tertiaryColor = variables.tertiary;
            customizer.additionalColor = variables.additional;

            customizer.selection[i].selectedHead = customizer.FindMeshInList(variables.head, customizer.genders[i].headMeshes);
            customizer.selection[i].selectedTorso = customizer.FindMeshInList(variables.torso, customizer.genders[i].torsoMeshes);
            customizer.selection[i].selectedLegs = customizer.FindMeshInList(variables.legs, customizer.genders[i].legsMeshes);
            customizer.selection[i].selectedShoes = customizer.FindMeshInList(variables.shoes, customizer.genders[i].shoesMeshes);

            customizer.accessories.SetAccessories(variables.accessories);



        }

        public void LoadRandom()
        {

            customizer.genderNum = Random.Range(0, customizer.genders.Count);

            CharacterCustomizer.Selection selection = customizer.selection[customizer.genderNum];
            Gender gender = customizer.genders[customizer.genderNum];

            selection.selectedHead = Random.Range(0, gender.headMeshes.Count);
            selection.selectedTorso = Random.Range(0, gender.torsoMeshes.Count);
            selection.selectedLegs = Random.Range(0, gender.legsMeshes.Count);
            selection.selectedShoes = Random.Range(0, gender.shoesMeshes.Count);

            customizer.skinColor = coloring.bodyColoring.skinColors[Random.Range(0, coloring.bodyColoring.skinColors.Count)];
            customizer.hairColor = coloring.bodyColoring.hairColors[Random.Range(0, coloring.bodyColoring.hairColors.Count)];

            Aesthetic i = coloring.aesthetics[Random.Range(0, coloring.aesthetics.Length)];

            customizer.primaryColor = i.primary;
            customizer.secondaryColor = i.secondary;
            customizer.tertiaryColor = i.tertiary;
            customizer.additionalColor = i.additional;

            customizer.accessories.RandomizeAccessories();

            customizer.ClampVariables();



        }
    }
}