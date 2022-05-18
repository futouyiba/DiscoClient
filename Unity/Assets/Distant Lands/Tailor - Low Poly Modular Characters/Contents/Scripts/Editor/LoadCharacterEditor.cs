using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DistantLands.DataType;
using JetBrains.Annotations;

namespace DistantLands
{
    [CustomEditor(typeof(LoadCharacter))]
    public class LoadCharacterEditor : Editor
    {

        LoadCharacter vars;
        SerializedProperty loadType;
        SerializedProperty variables;
        SerializedProperty loadOnStart;
        SerializedProperty slot;

        private void OnEnable()
        {

            vars = (LoadCharacter)target;
            loadType = serializedObject.FindProperty("loadType");
            variables = serializedObject.FindProperty("variables");
            loadOnStart = serializedObject.FindProperty("loadOnStart");
            slot = serializedObject.FindProperty("slot");

        }

        public override void OnInspectorGUI()
        {

            

            EditorGUILayout.PropertyField(loadType);

            EditorGUILayout.PropertyField(loadOnStart);


            if (vars.loadType == LoadCharacter.LoadType.Slot)
            {

                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(slot);

            }

            if (vars.loadType == LoadCharacter.LoadType.Variables)
            {

                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(variables);



                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                if (GUILayout.Button("Snapshot Editor Variables"))
                {

                    Snapshot();

                }

            }


            serializedObject.ApplyModifiedProperties();



        }

        public void Snapshot()
        {


            CharacterCustomizer customizer = vars.customizer;

            if (!vars.variables)
                return;

            vars.variables.primary = customizer.primaryColor;
            vars.variables.secondary = customizer.secondaryColor;
            vars.variables.tertiary = customizer.tertiaryColor;
            vars.variables.additional = customizer.additionalColor;

            vars.variables.skin = customizer.skinColor;
            vars.variables.hair = customizer.hairColor;

            vars.variables.gender = customizer.genders[customizer.genderNum];
            vars.variables.head = customizer.genders[customizer.genderNum].headMeshes[customizer.selection[customizer.genderNum].selectedHead];
            vars.variables.torso = customizer.genders[customizer.genderNum].torsoMeshes[customizer.selection[customizer.genderNum].selectedTorso];
            vars.variables.legs = customizer.genders[customizer.genderNum].legsMeshes[customizer.selection[customizer.genderNum].selectedLegs];
            vars.variables.shoes = customizer.genders[customizer.genderNum].shoesMeshes[customizer.selection[customizer.genderNum].selectedShoes];


            AssetDatabase.Refresh();
            EditorUtility.SetDirty(vars.variables);
            AssetDatabase.SaveAssets();



        }
    }
}