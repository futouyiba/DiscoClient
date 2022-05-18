using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DistantLands.DataType;
using UnityEditor;

namespace DistantLands
{
    public class AddBodyMeshesToGender : EditorWindow
    {

        Gender gender;
        Vector2 scrollPosition = Vector2.zero;
        public bool replace = true;

        public List<BodyMesh> bodyMeshes;


        // Add menu named "My Window" to the Window menu
        [MenuItem("Distant Lands/Tailor/Add Meshes to Gender")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            AddBodyMeshesToGender window = (AddBodyMeshesToGender)GetWindow(typeof(AddBodyMeshesToGender), false, "Add Meshes to Gender");
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Space(20);

            gender = EditorGUILayout.ObjectField("Gender to Set", gender, typeof(Gender), true) as Gender;
            GUILayout.Space(5);
            replace = EditorGUILayout.Toggle("Replace Existing Meshes", replace);

            GUILayout.Space(20);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false);
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);


            SerializedProperty matProperty = so.FindProperty("bodyMeshes");
            EditorGUILayout.PropertyField(matProperty, true);
            so.ApplyModifiedProperties();
            EditorGUILayout.EndScrollView();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Add Meshes to Gender"))
            {

                ConvertCharacter();

            }

        }


        public void ConvertCharacter()
        {

            if (bodyMeshes.Count == 0) {
                Debug.Log("You forgot to assign the body meshes. Please do so before running the operation again!");
                return;
            }

            if (gender == null)
            {
                Debug.Log("You forgot to assign the gender. Please do so before running the operation again!");
                return;
            }
            List<BodyMesh> head = new List<BodyMesh>();
            List<BodyMesh> torso = new List<BodyMesh>();
            List<BodyMesh> legs = new List<BodyMesh>();
            List<BodyMesh> shoes = new List<BodyMesh>();


            foreach (BodyMesh i in bodyMeshes)
            {

                switch (i.bodyPart)
                {
                    case BodyMesh.BodyPart.head:
                        head.Add(i);
                        break;
                    case BodyMesh.BodyPart.torso:
                        torso.Add(i);
                        break;
                    case BodyMesh.BodyPart.legs:
                        legs.Add(i);
                        break;
                    case BodyMesh.BodyPart.shoes:
                        shoes.Add(i);
                        break;
                }


            }

            if (replace)
            {
                gender.headMeshes = head;
                gender.torsoMeshes = torso;
                gender.legsMeshes = legs;
                gender.shoesMeshes = shoes;

            } else
            {
                gender.headMeshes.AddRange(head);
                gender.torsoMeshes.AddRange(torso);
                gender.legsMeshes.AddRange(legs);
                gender.shoesMeshes.AddRange(shoes);

            }

            EditorUtility.SetDirty(gender);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("Successfully added meshes to gender!");
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }


    }
}