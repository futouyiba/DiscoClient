using DistantLands.DataType;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace DistantLands
{
    public class AccessoryManager : MonoBehaviour
    {

        private CharacterCustomizer customizer;

        public List<GameObject> currentProps;


        [System.Serializable]
        public class AccessoryType
        {
            [Space(5)]
            public BodyArea area;

            [HideInInspector]
            public int selection;
            [Space(15)]
            public List<Gender> gendersToDisable;

            [HideInInspector]
            public List<Accessory> accessories;


        }


        [Space(10)]
        public List<AccessoryType> accessoryTypes;

        private AccessoryHolder[] accessoryHolders;

        [Space(20)]
        public Accessory[] totalAccessories;



        // Start is called before the first frame update
        void Awake()
        {

            customizer = GetComponent<CharacterCustomizer>();
            accessoryHolders = GetComponentsInChildren<AccessoryHolder>();
            currentProps = new List<GameObject>();

            foreach (Accessory i in totalAccessories)
            {
                foreach (AccessoryType j in accessoryTypes)
                {
                    if (i.area == j.area)
                        j.accessories.Add(i);

                }
            }
        }


        public void UpdateProps()
        {

            foreach (GameObject i in currentProps)
                DestroyAndClean(i);

            currentProps.Clear();

            foreach (AccessoryType i in accessoryTypes)
            {

                if (i.selection == 0 || i.gendersToDisable.Contains(customizer.genders[customizer.genderNum]))
                    continue;

                Accessory j = i.accessories[i.selection - 1];
                Transform k = GetBodySection(i.area);

                GameObject prop = Instantiate(j.prefab, k);

                prop.transform.localPosition = j.positionOffset;
                prop.transform.localEulerAngles = j.rotationOffset;

                if (prop.GetComponentInChildren<MeshRenderer>())
                    prop.GetComponentInChildren<MeshRenderer>().materials = customizer.GetNewMaterials(prop.GetComponentInChildren<MeshRenderer>().sharedMaterials, j.materials);


                currentProps.Add(prop);


            }


        }

        public Accessory[] GetAccessories()
        {

            List<Accessory> accessories = new List<Accessory>();

            foreach (AccessoryType type in accessoryTypes) {


                if (type.selection != 0)
                    accessories.Add(type.accessories[type.selection - 1]);


            }

            return accessories.ToArray();

        }


        public string[] GetAccessoriesNames()
        {

            List<string> accessories = new List<string>();

            foreach (AccessoryType type in accessoryTypes)
            {


                if (type.selection != 0)
                    accessories.Add(type.accessories[type.selection - 1].name);


            }

            return accessories.ToArray();

        }

        public void SetAccessories(Accessory[] accessories)
        {

            foreach (AccessoryType type in accessoryTypes)
            {
                int j = 1;

                foreach (Accessory i in type.accessories)
                {

                    if (accessories.Contains(i))
                    {
                        type.selection = j;
                        j = -1;
                        break;
                    }

                    j++;
                }

                if (j != -1)
                    type.selection = 0;
            }

            UpdateProps();

        }

        public void SetAccessories(string[] accessories)
        {

            foreach (AccessoryType type in accessoryTypes)
            {
                int j = 1;

                foreach (Accessory i in type.accessories)
                {

                    if (accessories.Contains(i.name))
                    {
                        type.selection = j;
                        j = -1;
                        break;
                    }
                    j++;
                }

                if (j != -1)
                    type.selection = 0;

            }

            UpdateProps();

        }

        public void RandomizeAccessories()
        {

            foreach (AccessoryType i in accessoryTypes)
            {
                if (i.gendersToDisable.Contains(customizer.genders[customizer.genderNum]))
                    continue;

                i.selection = Random.Range(0, i.accessories.Count + 1);

            }
        }


        public void ResetMaterials()
        {
            foreach (GameObject i in currentProps)
                DestroyAndClean(i);

            currentProps.Clear();

            foreach (AccessoryType i in accessoryTypes)
            {

                if (i.selection == 0 || i.gendersToDisable.Contains(customizer.genders[customizer.genderNum]))
                    continue;

                Accessory j = i.accessories[i.selection - 1];
                Transform k = GetBodySection(i.area);

                GameObject prop = Instantiate(j.prefab, k);

                prop.transform.localPosition = j.positionOffset;
                prop.transform.localEulerAngles = j.rotationOffset;

                if (prop.GetComponentInChildren<MeshRenderer>())
                    prop.GetComponentInChildren<MeshRenderer>().materials = customizer.GetNewStaticMaterials(prop.GetComponentInChildren<MeshRenderer>().sharedMaterials, j.materials);



            }
        }

        public void DestroyCurrentAccessories()
        {
            Debug.Log(currentProps.Count);
            foreach (GameObject i in currentProps)
            {
                DestroyAndClean(i);

            }

        }


        public void SetProp(BodyArea bodyArea, int dir)
        {

            foreach (AccessoryType i in accessoryTypes)
                if (i.area == bodyArea)
                {
                    i.selection += dir;
                    if (i.selection < 0)
                        i.selection = i.accessories.Count;

                    if (i.selection > i.accessories.Count)
                        i.selection = 0;



                }

            UpdateProps();

        }

        public Transform GetBodySection(BodyArea bone)
        {

            foreach (AccessoryHolder i in accessoryHolders)
                if (bone == i.assignedArea)
                    return i.transform;

            return null;


        }

        public void DestroyAndClean(GameObject obj)
        {



            if (obj.GetComponentInChildren<MeshRenderer>())
                foreach (Material mat in obj.GetComponentInChildren<MeshRenderer>().materials)
                    if (mat.name.Contains("*runtime"))
                        DestroyImmediate(mat);

            DestroyImmediate(obj);

        }


        public bool GetPropActive(BodyArea bodyArea)
        {

            foreach (AccessoryType i in accessoryTypes)
                if (i.area == bodyArea)
                {

                    return !i.gendersToDisable.Contains(customizer.genders[customizer.genderNum]);

                }

            return false;

        }

    }
}