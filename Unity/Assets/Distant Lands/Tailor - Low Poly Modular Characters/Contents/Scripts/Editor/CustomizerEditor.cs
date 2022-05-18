using UnityEngine;
using UnityEditor;


namespace DistantLands
{
    [CustomEditor(typeof(CharacterCustomizer))]
    [CanEditMultipleObjects]
    public class CustomizerEditor : Editor
    {


        private CharacterCustomizer customizer;
        private string newName = "Loadable Character";

        void OnEnable()
        {



        }

        public override void OnInspectorGUI()
        {


            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (GUILayout.Button("Generate Loadable Character"))
            {

                CreateDynamic();
                Debug.Log("SUCCESFULLY CREATED NEW TAILOR CHARACTER");

            }




        }



        // Create is called by the inspector script to build the new character.
        public void CreateDynamic()
        {

            customizer = FindObjectOfType<CharacterCustomizer>();

            GameObject i = Instantiate(customizer.gameObject);

            if (i.GetComponent<Turntable>())
                DestroyImmediate(i.GetComponent<Turntable>());



            if (!i.GetComponent<LoadCharacter>())
            {
                i.AddComponent<LoadCharacter>();
            }



            i.name = newName;

        }



    }
}