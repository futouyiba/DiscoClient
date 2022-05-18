/** ---------------------------------------------------------------------------- **


    Runtime script that aids in the creation of static characters.

    - Distant Lands


*** ---------------------------------------------------------------------------- */



using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DistantLands.DataType;

namespace DistantLands
{
    [AddComponentMenu("Hidden/Create Static Character")]
    public class CreateStaticCharacter : MonoBehaviour
    {

#if UNITY_EDITOR
        public string newName;
        public int suffix;
        public bool saveAccessories;
        public string path;

        public void Load(Materials colors)
        {
                StartCoroutine(Convert(colors));
        }

        public void Load()
        {
            StartCoroutine(Convert());
        }



        // Conversion method.
        public IEnumerator Convert(Materials colors)
        {

            if (!GetComponent<CharacterCustomizer>())
                yield break;

            CharacterCustomizer customizer = GetComponent<CharacterCustomizer>();
            GameObject i = gameObject;

            
            Animator anim = customizer.GetComponent<Animator>();


            foreach (AccessoryHolder j in i.GetComponentsInChildren<AccessoryHolder>())
            {

                foreach (Transform k in j.transform.GetComponentsInChildren<Transform>())
                {
                    if (k == j.transform)
                        continue;

                    if (k.GetComponentInChildren<MeshRenderer>())
                        foreach (Material mat in k.GetComponentInChildren<MeshRenderer>().materials)
                            if (mat.name.Contains("*runtime"))
                                DestroyImmediate(mat);

                    DestroyImmediate(k.gameObject);
                }
            }

            if (saveAccessories)
            {
                customizer.accessories.ResetMaterials();
            }

            if (i.GetComponent<Turntable>())
                DestroyImmediate(i.GetComponent<Turntable>());
            if (i.GetComponent<CharacterColoring>())
                DestroyImmediate(i.GetComponent<CharacterColoring>());
            if (i.GetComponent<LoadCharacter>())
                DestroyImmediate(i.GetComponent<LoadCharacter>());

            

            customizer.SetHeadStatic(colors);
            customizer.SetTorsoStatic(colors);
            customizer.SetLegsStatic(colors);
            customizer.SetShoesStatic(colors);

            Destroy(customizer);

            anim.SetTrigger("T-Pose");

            yield return null;
            DestroyImmediate(customizer.accessories);
            yield return null;


            GameObject finalObject = Instantiate(gameObject);
            finalObject.GetComponent<Animator>().runtimeAnimatorController = null;
            finalObject.name = newName;

            DestroyImmediate(finalObject.GetComponent<CreateStaticCharacter>());

            PrefabUtility.SaveAsPrefabAssetAndConnect(finalObject, path + newName + ".prefab", InteractionMode.AutomatedAction);

            Debug.Log("Character successfully saved at " + path + newName + "!");
            DestroyImmediate(finalObject);
            DestroyImmediate(gameObject);

        }


        public IEnumerator Convert()
        {

            if (!GetComponent<CharacterCustomizer>())
                yield break;

            CharacterCustomizer customizer = GetComponent<CharacterCustomizer>();
            GameObject i = gameObject;

            customizer = i.GetComponent<CharacterCustomizer>();
            Animator anim = customizer.GetComponent<Animator>();

            foreach (AccessoryHolder j in i.GetComponentsInChildren<AccessoryHolder>())
            {

                foreach (Transform k in j.transform.GetComponentsInChildren<Transform>())
                {
                    if (k == j.transform)
                        continue;

                    if (k.GetComponentInChildren<MeshRenderer>())
                        foreach (Material mat in k.GetComponentInChildren<MeshRenderer>().materials)
                            if (mat.name.Contains("*runtime"))
                                DestroyImmediate(mat);

                    DestroyImmediate(k.gameObject);
                }
            }

            if (saveAccessories)
            {
                customizer.accessories.ResetMaterials();
            }



            DestroyImmediate(customizer.accessories);



            if (i.GetComponent<Turntable>())
                DestroyImmediate(i.GetComponent<Turntable>());
            if (i.GetComponent<CharacterColoring>())
                DestroyImmediate(i.GetComponent<CharacterColoring>());
            if (i.GetComponent<LoadCharacter>())
                DestroyImmediate(i.GetComponent<LoadCharacter>());




            customizer.SetHeadStatic();
            customizer.SetTorsoStatic();
            customizer.SetLegsStatic();
            customizer.SetShoesStatic();


            Destroy(customizer);

            anim.SetTrigger("T-Pose");

            yield return null;
            yield return null;


            GameObject finalObject = Instantiate(gameObject);
            finalObject.GetComponent<Animator>().runtimeAnimatorController = null;
            finalObject.name = newName;

            DestroyImmediate(finalObject.GetComponent<CreateStaticCharacter>());

            PrefabUtility.SaveAsPrefabAssetAndConnect(finalObject, path + newName + ".prefab", InteractionMode.AutomatedAction);

            Debug.Log("Character successfully saved at " + path + newName + "!");
            DestroyImmediate(finalObject);
            DestroyImmediate(gameObject);

        }


        public bool IterateMats (List<BodyMesh.EditableMaterial> totalMaterials, BodyMesh.EditableMaterial mat, out BodyMesh.EditableMaterial addition) 
        {

            addition = null;

            foreach (BodyMesh.EditableMaterial total in totalMaterials)
            {
                if (total == mat)
                {

                    addition = mat;
                    return true;
                }
            }

            return false;

        }

#endif

        public class Materials
        {
            public Material skin;
            public Material hair;
            public Material primary;
            public Material secondary;
            public Material tertiary;
            public Material additional;

        }

    }
}