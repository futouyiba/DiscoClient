using UnityEngine;
using UnityEditor;

namespace DistantLands
{
    public class CreateStaticCharacterEditor : EditorWindow
    {

        Vector2 scrollPosition = Vector2.zero;


        bool generateMats;

        public Material Skin;
        public Material Hair;
        public int suffix;
        public string newName = "New Character";
        public bool saveAccessories = true;

        public Material Primary;
        public Material Secondary;
        public Material Tertiary;
        public Material Additional;


        // Add menu named "My Window" to the Window menu
        [MenuItem("Distant Lands/Tailor/Create Static Character From Active Tailor Customizer", false, 10)]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            CreateStaticCharacterEditor window = (CreateStaticCharacterEditor)GetWindow(typeof(CreateStaticCharacterEditor), false, "Create Static Character");
            window.Show();
        }

        void OnGUI()
        {




            GUILayout.Space(20);

            generateMats = EditorGUILayout.Toggle("Save Custom Materials", generateMats);
            saveAccessories = EditorGUILayout.Toggle("Save Accesories", saveAccessories);


            GUILayout.Space(20);

            GUILayout.Label("Body Materials", EditorStyles.boldLabel);


            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false);
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);



            SerializedProperty matProperty = so.FindProperty("Skin");
            EditorGUILayout.PropertyField(matProperty, true);

            matProperty = so.FindProperty("Hair");
            EditorGUILayout.PropertyField(matProperty, true);



            GUILayout.Label("Clothing Materials", EditorStyles.boldLabel);

            matProperty = so.FindProperty("Primary");
            EditorGUILayout.PropertyField(matProperty, true);

            matProperty = so.FindProperty("Secondary");
            EditorGUILayout.PropertyField(matProperty, true);

            matProperty = so.FindProperty("Tertiary");
            EditorGUILayout.PropertyField(matProperty, true);

            matProperty = so.FindProperty("Additional");
            EditorGUILayout.PropertyField(matProperty, true);


            so.ApplyModifiedProperties();

            GUILayout.Space(20);

            newName = EditorGUILayout.TextField("Character Name", newName);

            EditorGUILayout.EndScrollView();




            GUILayout.FlexibleSpace();



            if (Application.isPlaying)
            {
                if (GUILayout.Button("Create"))
                {

                    ConvertCharacter();


                }
            }
            else
                EditorGUILayout.HelpBox("Psst! The saving action only works while the application is running...", MessageType.Info);

        }


        public void ConvertCharacter()
        {

            string path = EditorUtility.OpenFolderPanel("Save Location", "Asset/", "");


            if (path.Length == 0)
                return;

            path = "Assets" + path.Substring(Application.dataPath.Length) + "/";


            CharacterCustomizer customizer = FindObjectOfType<CharacterCustomizer>();



            GameObject i = Instantiate(customizer.gameObject);
            customizer = i.GetComponent<CharacterCustomizer>();
            string genderName = customizer.genders[customizer.genderNum].name;

            CreateStaticCharacter.Materials combo = new CreateStaticCharacter.Materials();
            int iteration = suffix;



            if (generateMats)
            {

                Material mat = new Material(Skin);
                mat.color = customizer.skinColor;
                AssetDatabase.CreateAsset(mat, path + newName + " Skin.mat");
                combo.skin = mat;

                mat = new Material(Hair);
                mat.color = customizer.hairColor;
                AssetDatabase.CreateAsset(mat, path + newName + " Hair.mat");
                combo.hair = mat;

                mat = new Material(Primary);
                mat.color = customizer.primaryColor;
                AssetDatabase.CreateAsset(mat, path + newName + " Primary.mat");
                combo.primary = mat;

                mat = new Material(Secondary);
                mat.color = customizer.secondaryColor;
                AssetDatabase.CreateAsset(mat, path + newName + " Secondary.mat");
                combo.secondary = mat;

                mat = new Material(Tertiary);
                mat.color = customizer.tertiaryColor;
                AssetDatabase.CreateAsset(mat, path + newName + " Tertiary.mat");
                combo.tertiary = mat;

                mat = new Material(Additional);
                mat.color = customizer.additionalColor;
                AssetDatabase.CreateAsset(mat, path + newName + " Additional.mat"); 
                combo.additional = mat;
            }



            CreateStaticCharacter j = customizer.gameObject.AddComponent<CreateStaticCharacter>();

            j.newName = newName;
            j.path = path;
            j.suffix = suffix;
            j.saveAccessories = saveAccessories;

            if (generateMats)
                j.Load(combo);
            else
                j.Load();

        }



        [System.Serializable]
        public class StaticMaterial
        {

            public Material baseMat;

        }



    }
}