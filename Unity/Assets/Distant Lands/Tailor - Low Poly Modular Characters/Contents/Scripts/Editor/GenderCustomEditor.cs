using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


namespace DistantLands.DataType
{
    [CustomEditor(typeof(Gender))]
    public class GenderCustomEditor : Editor
    {

        Gender vars;

        bool showHead;
        bool showTorso;
        bool showLegs;
        bool showShoes;

        ReorderableList head;
        ReorderableList torso;
        ReorderableList legs;
        ReorderableList shoes;

        SerializedProperty headMeshes;
        SerializedProperty torsoMeshes;
        SerializedProperty legsMeshes;
        SerializedProperty shoesMeshes;

        SerializedProperty avatar;
        SerializedProperty root;



        void OnEnable()
        {

            vars = (Gender)target;


            headMeshes = serializedObject.FindProperty("headMeshes");
            head = new ReorderableList(serializedObject, headMeshes, true, false, true, true);
            head.drawElementCallback = DrawHeadItems;



            torsoMeshes = serializedObject.FindProperty("torsoMeshes");
            torso = new ReorderableList(serializedObject, torsoMeshes, true, false, true, true);
            torso.drawElementCallback = DrawTorsoItems;


            legsMeshes = serializedObject.FindProperty("legsMeshes");
            legs = new ReorderableList(serializedObject, legsMeshes, true, false, true, true);
            legs.drawElementCallback = DrawLegsItems;


            shoesMeshes = serializedObject.FindProperty("shoesMeshes");
            shoes = new ReorderableList(serializedObject, shoesMeshes, true, false, true, true);
            shoes.drawElementCallback = DrawShoeItems;

            avatar = serializedObject.FindProperty("animationAvatar");
            root = serializedObject.FindProperty("rootBoneName");

        }

        public override void OnInspectorGUI()
        {

            serializedObject.Update();

            EditorGUILayout.PropertyField(avatar);

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(root);

            EditorGUILayout.Space();
            EditorGUILayout.Space();


            showHead = EditorGUILayout.Foldout(showHead, "Head Meshes");
            if (showHead)
                head.DoLayoutList();

            EditorGUILayout.Space();

            showTorso = EditorGUILayout.Foldout(showTorso, "Torso Meshes");
            if (showTorso)
                torso.DoLayoutList();

            EditorGUILayout.Space();

            showLegs = EditorGUILayout.Foldout(showLegs, "Legs Meshes");
            if (showLegs)
                legs.DoLayoutList();

            EditorGUILayout.Space();

            showShoes = EditorGUILayout.Foldout(showShoes, "Shoe Meshes");
            if (showShoes)
                shoes.DoLayoutList();


            EditorGUILayout.Space();
            EditorGUILayout.Space();


            serializedObject.ApplyModifiedProperties();


        }

        void DrawHeadItems(Rect rect, int index, bool isActive, bool isFocused)
        {

            SerializedProperty element = head.serializedProperty.GetArrayElementAtIndex(index); //The element in the list

            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                element,
                GUIContent.none
            );

        }

        void DrawTorsoItems(Rect rect, int index, bool isActive, bool isFocused)
        {

            SerializedProperty element = torso.serializedProperty.GetArrayElementAtIndex(index); //The element in the list

            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                element,
                GUIContent.none
            );




        }

        void DrawLegsItems(Rect rect, int index, bool isActive, bool isFocused)
        {

            SerializedProperty element = legs.serializedProperty.GetArrayElementAtIndex(index); //The element in the list

            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                element,
                GUIContent.none
            );

        }

        void DrawShoeItems(Rect rect, int index, bool isActive, bool isFocused)
        {

            SerializedProperty element = shoes.serializedProperty.GetArrayElementAtIndex(index); //The element in the list

            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                element,
                GUIContent.none
            );

        }


    }
}