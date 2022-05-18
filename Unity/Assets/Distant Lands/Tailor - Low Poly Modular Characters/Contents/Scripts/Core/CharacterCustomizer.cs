/** ---------------------------------------------------------------------------- **


    The main powerhouse behind customization and character creation.

    - Distant Lands


*** ---------------------------------------------------------------------------- */



using System.Collections.Generic;
using DistantLands.DataType;
using UnityEngine;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/Character Customizer")]
    public class CharacterCustomizer : MonoBehaviour
    {

        #region Variables

        [HideInInspector]
        public int saveSlot = 1;
        [HideInInspector]
        public string seed;
        [HideInInspector]
        public bool unsavedChanges;
        [HideInInspector]
        public SkinnedMeshRenderer head;
        [HideInInspector]
        public SkinnedMeshRenderer torso;
        [HideInInspector]
        public SkinnedMeshRenderer legs;
        [HideInInspector]
        public SkinnedMeshRenderer shoes;

        [HideInInspector]
        public Color skinColor;
        [HideInInspector]
        public Color hairColor;
        [HideInInspector]
        public Color primaryColor;
        [HideInInspector]
        public Color secondaryColor;
        [HideInInspector]
        public Color tertiaryColor;
        [HideInInspector]
        public Color additionalColor;

        [HideInInspector]
        public List<BodyMesh> bodyMeshes;
        [HideInInspector]
        public Transform rootBone;



        [System.Serializable]
        public class Selection
        {

            public int selectedHead;
            public int selectedTorso;
            public int selectedLegs;
            public int selectedShoes;

        }


        [HideInInspector]
        public List<Selection> selection;




        [Space(20)]
        [Tooltip("Setup the 'genders' or types of characters using different rigs. If you have an alien-type character, put it here as a seperate gender.")]
        public List<Gender> genders;
        [HideInInspector]
        public int genderNum;

        private Stats statManager;
        [HideInInspector]
        public AccessoryManager accessories;

        [Space(20)]
        [Tooltip("Only enable if this character will be changing consistently.")]
        public bool ConsistentUpdate = true;

#endregion Variables

        // Awake is called before the first frame update
        private void Awake()
        {


            Setup();




        }
        

        //Setup assigns all of the default values for the customizer. Called on Awake.
        public void Setup()
        {
            rootBone = GetComponentsInChildren<Transform>()[1];


            foreach (Gender i in genders)
            {
                selection.Add(new Selection());

            }

            foreach (SkinnedMeshRenderer i in GetComponentsInChildren<SkinnedMeshRenderer>())
            {

                if (i.transform.name == "Head")
                    head = i;

                if (i.transform.name == "Torso")
                    torso = i;

                if (i.transform.name == "Legs")
                    legs = i;

                if (i.transform.name == "Shoes")
                    shoes = i;

            }


            if (head == null || torso == null || legs == null || shoes == null)
            {
                Debug.LogError("FORMAT FAIL: Could not find skinned mesh renderers. Ensure this object has 4 skinned mesh renderer components named 'Head', 'Torso', 'Legs', and 'Shoes'.");
                gameObject.SetActive(false);
            }


            if (GetComponent<Stats>())
                statManager = GetComponent<Stats>();


            accessories = GetComponent<AccessoryManager>();

            rootBone.name = genders[genderNum].rootBoneName;
            GetComponentInChildren<Animator>().avatar = genders[genderNum].animationAvatar;


            UpdateBody();


        }

        // Update is called once per frame
        private void Update()
        {



            ClampVariables();

            if (ConsistentUpdate)
            {
                UpdateBody();
                UpdateStats();
                unsavedChanges = CheckDirty();
            }



        }

        //Sets all of the parameters of the body.
        public void UpdateBody()
        {

            SetHead();
            SetTorso();
            SetLegs();
            SetShoes();


            rootBone.name = genders[genderNum].rootBoneName;
            GetComponentInChildren<Animator>().avatar = genders[genderNum].animationAvatar;


        }

        #region Save/Load 


        //Checks if the data currently used by the customizer matches the saved data.
        public bool CheckDirty()
        {

            SaveProperties properties = new SaveProperties();

            properties.gender = genders[genderNum].name;

            properties.head = genders[genderNum].headMeshes[selection[genderNum].selectedHead].name;
            properties.torso = genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].name;
            properties.legs = genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].name;
            properties.shoes = genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].name;

            properties.skin = skinColor;
            properties.hair = hairColor;
            properties.primary = primaryColor;
            properties.secondary = secondaryColor;
            properties.tertiary = tertiaryColor;
            properties.additional = additionalColor;

            properties.accessories = accessories.GetAccessoriesNames();

            string i = JsonUtility.ToJson(properties);



            return seed != i;


        }

        //Saves the current data to the save slot.
        public void Save()
        {


            SaveProperties properties = new SaveProperties();

            properties.gender = genders[genderNum].name;

            properties.head = genders[genderNum].headMeshes[selection[genderNum].selectedHead].name;
            properties.torso = genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].name;
            properties.legs = genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].name;
            properties.shoes = genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].name;

            properties.skin = skinColor;
            properties.hair = hairColor;
            properties.primary = primaryColor;
            properties.secondary = secondaryColor;
            properties.tertiary = tertiaryColor;
            properties.additional = additionalColor;
            properties.accessories = accessories.GetAccessoriesNames();

            string data = JsonUtility.ToJson(properties);
            seed = data;


            PlayerPrefs.SetString("Tailor Slot " + saveSlot, seed);
            PlayerPrefs.Save();

            Debug.Log(data);
            Debug.Log(seed);


        }

        //Loads data from a specific slot.
        public void LoadChar(int slot)
        {

            saveSlot = slot;
            LoadChar();

        }

        //Loads data from the current slot.
        public void LoadChar()
        {


            seed = PlayerPrefs.GetString("Tailor Slot " + saveSlot);



            if (seed.Length == 0)
            {
                Debug.Log("ERROR: Failed to load. There is no data in the slot you are trying to load from. Please ensure that this save slot has data before loading.");
                return;
            }

            SaveProperties properties = JsonUtility.FromJson<SaveProperties>(seed);


            genderNum = GenderFromString(properties.gender);

            selection[genderNum].selectedHead = FindMeshByString(properties.head, genders[genderNum].headMeshes);
            selection[genderNum].selectedTorso = FindMeshByString(properties.torso, genders[genderNum].torsoMeshes);
            selection[genderNum].selectedLegs = FindMeshByString(properties.legs, genders[genderNum].legsMeshes);
            selection[genderNum].selectedShoes = FindMeshByString(properties.shoes, genders[genderNum].shoesMeshes);

            skinColor = properties.skin;
            hairColor = properties.hair;


            primaryColor = properties.primary;
            secondaryColor = properties.secondary;
            tertiaryColor = properties.tertiary;
            additionalColor = properties.additional;
            accessories.SetAccessories(properties.accessories);

            UpdateStats();
            UpdateBody();


        }

        #endregion Save/Load



        #region Settings


        public void SetGender(int i)
        {

            genderNum += i;

            ClampVariables();

        }



        public void SetHead()
        {

            foreach (Material i in head.sharedMaterials)
                if (i != null)
                    if (i.name.Contains("*runtime"))
                    DestroyImmediate(i);

            if (genders[genderNum].headMeshes.Count > 0)
            {
                head.sharedMesh = genders[genderNum].headMeshes[selection[genderNum].selectedHead].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].headMeshes[selection[genderNum].selectedHead].materials)
                {
                    if (k.Count < genders[genderNum].headMeshes[selection[genderNum].selectedHead].mesh.subMeshCount)
                        k.Add(GetNewMaterial(i.material, i.colorType, i.valueChange, i.saturationChange));


                }

                head.materials = k.ToArray();

            }
        }

        public void SetHead(int l)
        {

            if (l != 0)
                selection[genderNum].selectedHead += l;

            ClampVariables();

            SetHead();

            UpdateStats();

        }


        //Used by the Create Static Character method.
        public void SetHeadStatic(CreateStaticCharacter.Materials colors)
        {
            if (genders[genderNum].headMeshes.Count > 0)
            {
                head.sharedMesh = genders[genderNum].headMeshes[selection[genderNum].selectedHead].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].headMeshes[selection[genderNum].selectedHead].materials)
                {
                    if (k.Count < genders[genderNum].headMeshes[selection[genderNum].selectedHead].mesh.subMeshCount)
                    {
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.skin)
                        {

                            k.Add(colors.skin);

                        }
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.hair)
                        {

                            k.Add(colors.hair);

                        }
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.additional)
                        {

                            k.Add(colors.additional);

                        }
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.primary)
                        {

                            k.Add(colors.primary);

                        }
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.secondary)
                        {

                            k.Add(colors.secondary);

                        }
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.tertiary)
                        {

                            k.Add(colors.tertiary);

                        }
                        if (i.colorType == BodyMesh.EditableMaterial.ColorType.custom)
                        {

                            k.Add(i.material);

                        }

                    }
                }

                head.materials = k.ToArray();

            }
        }

        //Used by the Create Static Character method.
        public void SetHeadStatic()
        {
            if (genders[genderNum].headMeshes.Count > 0)
            {
                head.sharedMesh = genders[genderNum].headMeshes[selection[genderNum].selectedHead].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].headMeshes[selection[genderNum].selectedHead].materials)
                {
                    if (k.Count < genders[genderNum].headMeshes[selection[genderNum].selectedHead].mesh.subMeshCount)
                    {


                        k.Add(i.material);


                    }
                }

                head.materials = k.ToArray();

            }
        }


        public void SetTorso()
        {
            foreach (Material i in torso.sharedMaterials)
                if (i != null)
                    if (i.name.Contains("*runtime"))
                DestroyImmediate(i, true);

            if (genders[genderNum].torsoMeshes.Count > 0)
            {
                torso.sharedMesh = genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].materials)
                {

                    k.Add(GetNewMaterial(i.material, i.colorType, i.valueChange, i.saturationChange));


                }

                torso.materials = k.ToArray();

            }
        }

        public void SetTorso(int l)
        {

            if (l != 0)
                selection[genderNum].selectedTorso += l;

            ClampVariables();

            SetTorso();

            UpdateStats();

        }

        //Used by the Create Static Character method.
        public void SetTorsoStatic(CreateStaticCharacter.Materials colors)
        {

            if (genders[genderNum].torsoMeshes.Count > 0)
            {
                torso.sharedMesh = genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].materials)
                {
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.skin)
                    {

                        k.Add(colors.skin);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.hair)
                    {

                        k.Add(colors.hair);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.additional)
                    {

                        k.Add(colors.additional);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.primary)
                    {

                        k.Add(colors.primary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.secondary)
                    {

                        k.Add(colors.secondary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.tertiary)
                    {

                        k.Add(colors.tertiary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.custom)
                    {

                        k.Add(i.material);

                    }

                }

                torso.materials = k.ToArray();

            }
        }

        //Used by the Create Static Character method.
        public void SetTorsoStatic()
        {

            if (genders[genderNum].torsoMeshes.Count > 0)
            {
                torso.sharedMesh = genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso].materials)
                {


                    k.Add(i.material);


                }

                torso.materials = k.ToArray();

            }
        }


        public void SetLegs()
        {
            foreach (Material i in legs.sharedMaterials)
                if (i != null)
                    if (i.name.Contains("*runtime"))
                    DestroyImmediate(i);

            if (genders[genderNum].legsMeshes.Count > 0)
            {
                legs.sharedMesh = genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].materials)
                {

                    k.Add(GetNewMaterial(i.material, i.colorType, i.valueChange, i.saturationChange));


                }

                legs.materials = k.ToArray();


            }
        }

        public void SetLegs(int l)
        {


            if (l != 0)
                selection[genderNum].selectedLegs += l;


            ClampVariables();

            SetLegs();


            UpdateStats();

        }

        //Used by the Create Static Character method.
        public void SetLegsStatic(CreateStaticCharacter.Materials colors)
        {

            if (genders[genderNum].legsMeshes.Count > 0)
            {
                legs.sharedMesh = genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].materials)
                {
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.skin)
                    {

                        k.Add(colors.skin);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.hair)
                    {

                        k.Add(colors.hair);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.additional)
                    {

                        k.Add(colors.additional);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.primary)
                    {

                        k.Add(colors.primary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.secondary)
                    {

                        k.Add(colors.secondary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.tertiary)
                    {

                        k.Add(colors.tertiary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.custom)
                    {

                        k.Add(i.material);

                    }

                }

                legs.materials = k.ToArray();


            }
        }

        //Used by the Create Static Character method.
        public void SetLegsStatic()
        {

            if (genders[genderNum].legsMeshes.Count > 0)
            {
                legs.sharedMesh = genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].legsMeshes[selection[genderNum].selectedLegs].materials)
                {


                    k.Add(i.material);


                }

                legs.materials = k.ToArray();


            }
        }


        public void SetShoes()
        {

            foreach (Material i in shoes.sharedMaterials)
                if (i != null)
                if (i.name.Contains("*runtime"))
                    DestroyImmediate(i);

            if (genders[genderNum].shoesMeshes.Count > 0)
            {
                shoes.sharedMesh = genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].materials)
                {

                    k.Add(GetNewMaterial(i.material, i.colorType, i.valueChange, i.saturationChange));


                }

                shoes.materials = k.ToArray();


            }
            
        }

        public void SetShoes(int l)
        {


            if (l != 0)
                selection[genderNum].selectedShoes += l;


            ClampVariables();

            SetShoes();

            UpdateStats();

        }

        //Used by the Create Static Character method.
        public void SetShoesStatic(CreateStaticCharacter.Materials colors)
        {

            if (genders[genderNum].shoesMeshes.Count > 0)
            {
                shoes.sharedMesh = genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].materials)
                {
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.skin)
                    {

                        k.Add(colors.skin);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.hair)
                    {

                        k.Add(colors.hair);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.additional)
                    {

                        k.Add(colors.additional);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.primary)
                    {

                        k.Add(colors.primary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.secondary)
                    {

                        k.Add(colors.secondary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.tertiary)
                    {

                        k.Add(colors.tertiary);

                    }
                    if (i.colorType == BodyMesh.EditableMaterial.ColorType.custom)
                    {

                        k.Add(i.material);

                    }

                }

                shoes.materials = k.ToArray();


            }
        }

        //Used by the Create Static Character method.
        public void SetShoesStatic()
        {

            if (genders[genderNum].shoesMeshes.Count > 0)
            {
                shoes.sharedMesh = genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].mesh;
                List<Material> k = new List<Material>();


                foreach (BodyMesh.EditableMaterial i in genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes].materials)
                {


                    k.Add(i.material);



                }

                shoes.materials = k.ToArray();


            }
        }



        #endregion Settings


        //Updates the stats based on which meshes are selected.
        public void UpdateStats()
        {

            if (statManager)
            statManager.UpdateStats();

        }


        //Clamps all values to keep from throwing null reference errors.
        public void ClampVariables()
        {

            #region Clamp Values

            if (genderNum > genders.Count - 1)
            {

                genderNum = 0;

            }
            if (genderNum < 0)
            {

                genderNum = genders.Count - 1;

            }
            if (selection[genderNum].selectedHead > genders[genderNum].headMeshes.Count - 1)
            {

                selection[genderNum].selectedHead = 0;

            }
            if (selection[genderNum].selectedHead < 0)
            {

                selection[genderNum].selectedHead = genders[genderNum].headMeshes.Count - 1;

            }

            if (selection[genderNum].selectedTorso > genders[genderNum].torsoMeshes.Count - 1)
            {

                selection[genderNum].selectedTorso = 0;

            }
            if (selection[genderNum].selectedTorso < 0)
            {

                selection[genderNum].selectedTorso = genders[genderNum].torsoMeshes.Count - 1;

            }

            if (selection[genderNum].selectedLegs > genders[genderNum].legsMeshes.Count - 1)
            {

                selection[genderNum].selectedLegs = 0;

            }
            if (selection[genderNum].selectedLegs < 0)
            {

                selection[genderNum].selectedLegs = genders[genderNum].legsMeshes.Count - 1;

            }


            if (selection[genderNum].selectedShoes > genders[genderNum].shoesMeshes.Count - 1)
            {

                selection[genderNum].selectedShoes = 0;

            }
            if (selection[genderNum].selectedShoes < 0)
            {

                selection[genderNum].selectedShoes = genders[genderNum].shoesMeshes.Count - 1;

            }


            #endregion




        }

        #region Get / Find


        //Finds a specific mesh in a list. Used by the variable loading optsion.
        public int FindMeshInList(BodyMesh mesh, List<BodyMesh> list)
        {
            int i = 0;


            foreach (BodyMesh j in list)
            {


                if (j == mesh)
                {
                    i = list.IndexOf(j);
                    break;
                }


            }

            return i;

        }

        //Finds a specific mesh in a list. Used by the load method.
        public int FindMeshByString(string mesh, List<BodyMesh> list)
        {
            int i = 0;


            foreach (BodyMesh j in list)
            {


                if (j.name == mesh)
                {
                    i = list.IndexOf(j);
                    break;
                }


            }

            return i;

        }


        //Gets the gender number from a name.
        public int GenderFromString(string input)
        {

            int i = 0;
            int k = 0;

            foreach (Gender j in genders)
            {

                if (j.name == input)
                    i = k;

                k++;

            }


            return i;
        }

        public List<BodyMesh> GetCurrentBodyMeshes()
        {

            List<BodyMesh> meshes = new List<BodyMesh>();

            meshes.Add(genders[genderNum].headMeshes[selection[genderNum].selectedHead]);
            meshes.Add(genders[genderNum].torsoMeshes[selection[genderNum].selectedTorso]);
            meshes.Add(genders[genderNum].legsMeshes[selection[genderNum].selectedLegs]);
            meshes.Add(genders[genderNum].shoesMeshes[selection[genderNum].selectedShoes]);

            return meshes;

        }

        //Generates a new material from a series of variables.
        private Material GetNewMaterial(Material orignalMat, BodyMesh.EditableMaterial.ColorType colorType)
        {
            Material newMat = new Material(orignalMat);

            newMat.name = newMat.name + "*runtime";

            switch (colorType)
            {
                case BodyMesh.EditableMaterial.ColorType.skin:
                    newMat.color = skinColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.hair:
                    newMat.color = hairColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.primary:
                    newMat.color = primaryColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.secondary:
                    newMat.color = secondaryColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.tertiary:
                    newMat.color = tertiaryColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.additional:
                    newMat.color = additionalColor;
                    break;
                default:
                    break;



            }


            return newMat;

        }

        private Material GetNewMaterial(Material orignalMat, BodyMesh.EditableMaterial.ColorType colorType, float value, float saturation)
        {
            Material newMat = new Material(orignalMat);

            newMat.name = newMat.name + "*runtime";

            switch (colorType)
            {
                case BodyMesh.EditableMaterial.ColorType.skin:
                    newMat.color = skinColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.hair:
                    newMat.color = hairColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.primary:
                    newMat.color = primaryColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.secondary:
                    newMat.color = secondaryColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.tertiary:
                    newMat.color = tertiaryColor;
                    break;
                case BodyMesh.EditableMaterial.ColorType.additional:
                    newMat.color = additionalColor;
                    break;
                default:
                    break;
            }



            Color.RGBToHSV(newMat.color, out float H, out float S, out float V);

            V = Mathf.Clamp01(V + value);
            S = Mathf.Clamp01(S + saturation);


            newMat.color = Color.HSVToRGB(H, S, V);


            return newMat;

        }

        public Material[] GetNewMaterials(Material[] orignalMats, BodyMesh.EditableMaterial[] colorType)
        {

            List<Material> newMats = new List<Material>();

            for (int i = 0; i < orignalMats.Length; i++)
            {

                Material newMat = new Material(colorType[i].material);

                newMat.name = newMat.name + " *runtime";

                switch (colorType[i].colorType)
                {
                    case BodyMesh.EditableMaterial.ColorType.skin:
                        newMat.color = skinColor;
                        break;
                    case BodyMesh.EditableMaterial.ColorType.hair:
                        newMat.color = hairColor;
                        break;
                    case BodyMesh.EditableMaterial.ColorType.primary:
                        newMat.color = primaryColor;
                        break;
                    case BodyMesh.EditableMaterial.ColorType.secondary:
                        newMat.color = secondaryColor;
                        break;
                    case BodyMesh.EditableMaterial.ColorType.tertiary:
                        newMat.color = tertiaryColor;
                        break;
                    case BodyMesh.EditableMaterial.ColorType.additional:
                        newMat.color = additionalColor;
                        break;
                    default:
                        break;
                }



                Color.RGBToHSV(newMat.color, out float H, out float S, out float V);

                V = Mathf.Clamp01(V + colorType[i].valueChange);
                S = Mathf.Clamp01(S + colorType[i].saturationChange);


                newMat.color = Color.HSVToRGB(H, S, V);

                newMats.Add(newMat);


            }


            return newMats.ToArray();

        }


        public Material[] GetNewStaticMaterials(Material[] orignalMats, BodyMesh.EditableMaterial[] colorType)
        {

            List<Material> newMats = new List<Material>();

            for (int i = 0; i < orignalMats.Length; i++)
            {

                newMats.Add(colorType[i].material);


            }


            return newMats.ToArray();

        }

        #endregion Get / Find

    }
}