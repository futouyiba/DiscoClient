using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DistantLands.DataType;
using UnityEditor;

namespace DistantLands
{
    public class CreateBodyMeshes : EditorWindow
    {

        Transform rootObject;
        Vector2 scrollPosition = Vector2.zero;

        public int totalNum = 0;
        public int currentTask = 0;

        public BodyMesh.EditableMaterial[] MaterialReassignments;


        // Add menu named "My Window" to the Window menu
        [MenuItem("Distant Lands/Tailor/Convert Character to Tailor Meshes")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            CreateBodyMeshes window = (CreateBodyMeshes)GetWindow(typeof(CreateBodyMeshes), false, "Convert Character to Tailor Meshes");
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Space(20);

            rootObject = EditorGUILayout.ObjectField("Character Root", rootObject, typeof(Transform), true) as Transform;

            GUILayout.Space(20);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false);
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);



            SerializedProperty matProperty = so.FindProperty("MaterialReassignments");
            EditorGUILayout.PropertyField(matProperty, true);
            so.ApplyModifiedProperties();


            EditorGUILayout.EndScrollView();
            GUILayout.FlexibleSpace();


            if (GUILayout.Button("Convert"))
            {

                ConvertCharacter();

            }

        }


        public void ConvertCharacter()
        {



            string path = EditorUtility.OpenFolderPanel("Save Location", "Asset/", "");


            if (path.Length == 0)
                return;

            path = "Assets" + path.Substring(Application.dataPath.Length);


            List<Material> CustomMats = new List<Material>();
            foreach (BodyMesh.EditableMaterial k in MaterialReassignments) { CustomMats.Add(k.material); }

            totalNum = rootObject.GetComponentsInChildren<SkinnedMeshRenderer>().Length + 1;
            currentTask = 0;

            foreach (SkinnedMeshRenderer i in rootObject.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                if (EditorUtility.DisplayCancelableProgressBar("Saving Meshes", "Please Wait!", currentTask / totalNum))
                {
                    Debug.Log("Successfully Cancelled Operation");
                    EditorUtility.ClearProgressBar();
                    return;
                }
                else
                {
                    BodyMesh j = CreateInstance<BodyMesh>();
                    List<BodyMesh.EditableMaterial> editableMats = new List<BodyMesh.EditableMaterial>();

                    j.mesh = i.sharedMesh;
                    j.name = j.mesh.name;

                    if (i.sharedMesh.name.Contains("Head"))
                        j.bodyPart = BodyMesh.BodyPart.head;
                    else
                    if (i.sharedMesh.name.Contains("Torso"))
                        j.bodyPart = BodyMesh.BodyPart.torso;
                    else
                    if (i.sharedMesh.name.Contains("Legs"))
                        j.bodyPart = BodyMesh.BodyPart.legs;
                    else
                    if (i.sharedMesh.name.Contains("Shoes"))
                        j.bodyPart = BodyMesh.BodyPart.shoes;

                    foreach (Material k in i.sharedMaterials)
                    {
                        BodyMesh.EditableMaterial editableMaterial = new BodyMesh.EditableMaterial();
                        if (GetEditableMat(k) != null)
                            editableMaterial = GetEditableMat(k);
                        else
                        {
                            editableMaterial.material = k;
                            editableMaterial.colorType = BodyMesh.EditableMaterial.ColorType.custom;

                        }

                        editableMats.Add(editableMaterial);

                    }

                    j.materials = editableMats.ToArray();

                    AssetDatabase.CreateAsset(j, path + "/" + j.name + ".asset");

                    currentTask++;
                }
            }

            Debug.Log("Saved assets to " + path + "!");
            EditorUtility.ClearProgressBar();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        public BodyMesh.EditableMaterial GetEditableMat(Material i)
        {

            foreach (BodyMesh.EditableMaterial j in MaterialReassignments)
                if (j.material == i)
                    return j;


            return null;
        }


    }
}