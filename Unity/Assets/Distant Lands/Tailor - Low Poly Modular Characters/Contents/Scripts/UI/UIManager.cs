/** ---------------------------------------------------------------------------- **


    Controls the in-game UI for Tailor: Low Poly Modular Characters.

    - Distant Lands


*** ---------------------------------------------------------------------------- */



using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DistantLands.DataType;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Manager")]
    public class UIManager : MonoBehaviour
    {

        [Space(10)]
        [Header("Linked Customizer")]
        [Space(5)]
        public CharacterCustomizer customizer;

        [Space(10)]
        [Header("Windows")]
        [Space(5)]
        public GameObject[] windows;
        public GameObject saveConfirm;
        public GameObject leaveConfirm;
        public GameObject overwriteConfirm;
        public GameObject exitConfirm;

        [Space(10)]
        [Header("Dynamic UI")]
        [Space(5)]
        public Transform aestheticsParent;
        public GameObject aestheticsPrefab;
        public Transform statsParent;
        public GameObject statsPrefab;
        public Transform propsParent;
        public GameObject propsPrefab;
        public Transform skinColoringParent;
        public Transform hairColoringParent;
        public GameObject coloringPrefab;
        public Slider[] colorEditSliders;



        [Space(10)]
        [Header("Save / Load")]
        [Space(5)]
        public Image[] slotDirtIndicators;
        public Text currentSlot;
        public Text saved;
        private int slotConfirm;


        [Space(10)]
        [Header("Animation")]
        [Space(5)]

        public Notify notify;
        public Animator pageFolder;


        private AccessoryManager accessoryManager;


        private void Awake()
        {
            if (customizer == null)
            customizer = FindObjectOfType<CharacterCustomizer>();

            if (!customizer)
                enabled = false;

            accessoryManager = customizer.GetComponent<AccessoryManager>();

            if (customizer.GetComponent<CharacterColoring>())
            {

                CharacterColoring colors = customizer.GetComponent<CharacterColoring>();
                foreach (Aesthetic i in colors.aesthetics)
                {

                    AssignButtonColors j = Instantiate(aestheticsPrefab, aestheticsParent).GetComponent<AssignButtonColors>();
                    j.aesthetic = i;

                }

                foreach (Color i in colors.bodyColoring.skinColors)
                {

                    ColorButton j = Instantiate(coloringPrefab, skinColoringParent).GetComponent<ColorButton>();
                    j.skinColor = true;
                    j.GetComponent<Image>().color = new Color(i.r, i.g, i.b);
                    j.manager = this;

                }
                foreach (Color i in colors.bodyColoring.hairColors)
                {

                    ColorButton j = Instantiate(coloringPrefab, hairColoringParent).GetComponent<ColorButton>();
                    j.skinColor = false;
                    j.GetComponent<Image>().color = new Color(i.r, i.g, i.b);
                    j.manager = this;

                }
            }

            if (customizer.GetComponent<Stats>())
            {
                foreach (Stats.Stat i in customizer.GetComponent<Stats>().stats)
                {

                    StatIcon icon = Instantiate(statsPrefab, statsParent).GetComponent<StatIcon>();
                    icon.stat = i.stat;

                }
            }

            if (accessoryManager)
            {

                foreach(AccessoryManager.AccessoryType i in accessoryManager.accessoryTypes)
                {

                    PropButton prop = Instantiate(propsPrefab, propsParent).GetComponent<PropButton>();

                    prop.manager = this;
                    prop.type = i.area;


                }
            }


            OpenWindow(0);

            CheckSlotDirty();


        }

        private void Start()
        {
            SetSliderColors();
        }

        // Update is called once per frame
        void Update()
        {

            currentSlot.text = "SLOT   " + customizer.saveSlot;
            saved.text = customizer.unsavedChanges ? "UNSAVED" : "SAVED";





        }

        public void LoadScene(int scene)
        {

            if (customizer.unsavedChanges)
                leaveConfirm.SetActive(true);
            else
                GetComponent<SceneLoading>().Load(scene);

        }



        public void OpenWindow(int window)
        {

            StartCoroutine(WindowAnim(window));
            
        }

        public IEnumerator WindowAnim(int window)
        {
            if (Time.timeSinceLevelLoad != 0)
            {
                pageFolder.SetTrigger("Switching");

                yield return null;
                foreach (GameObject i in windows)
                {
                    if (i == windows[window])
                        i.SetActive(true);
                    else
                        i.SetActive(false);

                }
            }
            else
                foreach (GameObject i in windows)
                {
                    if (i == windows[window])
                        i.SetActive(true);
                    else
                        i.SetActive(false);

                }

        }

        public void SetSlot(int slot)
        {

            if (slot == -1)
                customizer.saveSlot = slotConfirm;
            else
                slotConfirm = slot;


        }

        public void SetProp(int dir, BodyArea type)
        {

            accessoryManager.SetProp(type, dir);
            

        }

        public bool CheckPropActive(BodyArea area)
        {

            return accessoryManager.GetPropActive(area);

        }



        public void SetColor(Color color, bool skin)
        {

            if (skin)
                customizer.skinColor = color;
            else
                customizer.hairColor = color;

            accessoryManager.UpdateProps();

        }


        public void OpenConfirmSave(bool open)
        {
            if (open == true)
                if (CheckSlotDirty(slotConfirm))
                {
                    saveConfirm.SetActive(open);
                }
                else
                {
                    customizer.saveSlot = slotConfirm;
                    customizer.Save();
                    notify.Notification("SAVED !");
                    slotConfirm = -1;

                    CheckSlotDirty();

                }
            else
                saveConfirm.SetActive(false);



        }


        public void OpenOverwriteSave(bool open)
        {

            overwriteConfirm.SetActive(open);

        }

        public void StartSave()
        {

            customizer.Save();

        }


        public void StartLoad()
        {

            customizer.LoadChar();

        }


        public void CheckSave()
        {

            string path = "Tailor Saves/Slot " + slotConfirm + ".json";
            string seed = PlayerPrefs.GetString("Tailor Slot " + slotConfirm);

            

            if (seed != "")
                overwriteConfirm.SetActive(true);
            else
            {
                SetSlot(-1);
                overwriteConfirm.SetActive(false);
                customizer.Save();
                notify.Notification("SAVED !");
            }


        }

        public void OpenExitSave(bool open)
        {

            exitConfirm.SetActive(open);


        }


        public void CheckSlotDirty()
        {
            
            int i = 1;
            foreach (Image slot in slotDirtIndicators)
            {

                string seed = PlayerPrefs.GetString("Tailor Slot " + i);



                slot.enabled = seed != "";
                i++;

            }
        }

        public bool CheckSlotDirty(int j)
        {
            string seed = PlayerPrefs.GetString("Tailor Slot " + slotConfirm);


            return seed != "";


        }

        public void SetHueAlterPrimary(float alteration)
        {

            Color.RGBToHSV(customizer.primaryColor, out float H, out float S, out float V);


            if (alteration == -1)
            {

                colorEditSliders[0].image.color = Color.HSVToRGB(H, S, V);
                colorEditSliders[0].value = H;
                return;
            }



            H = alteration;


            customizer.primaryColor = Color.HSVToRGB(H, S, V);

            colorEditSliders[0].image.color = Color.HSVToRGB(H, S, V);

        }

        public void SetHueAlterSecondary(float alteration)
        {

            Color.RGBToHSV(customizer.secondaryColor, out float H, out float S, out float V);


            if (alteration == -1)
            {

                colorEditSliders[1].image.color = Color.HSVToRGB(H, S, V);
                colorEditSliders[1].value = H;
                return;

            }



            H = alteration;


            customizer.secondaryColor = Color.HSVToRGB(H, S, V);

            colorEditSliders[1].image.color = Color.HSVToRGB(H, S, V);

        }

        public void SetHueAlterTertiary(float alteration)
        {

            Color.RGBToHSV(customizer.tertiaryColor, out float H, out float S, out float V);


            if (alteration == -1)
            {

                colorEditSliders[2].image.color = Color.HSVToRGB(H, S, V);
                colorEditSliders[2].value = H;
                return;

            }



            H = alteration;


            customizer.tertiaryColor = Color.HSVToRGB(H, S, V);

            colorEditSliders[2].image.color = Color.HSVToRGB(H, S, V);

        }

        public void SetHueAlterAdditional(float alteration)
        {

            Color.RGBToHSV(customizer.additionalColor, out float H, out float S, out float V);


            if (alteration == -1)
            {

                colorEditSliders[3].image.color = Color.HSVToRGB(H, S, V);
                colorEditSliders[3].value = H;
                return;

            }



            H = alteration;


            customizer.additionalColor = Color.HSVToRGB(H, S, V);

            colorEditSliders[3].image.color = Color.HSVToRGB(H, S, V);

        }

        public void SetSliderColors ()
        {

            SetHueAlterPrimary(-1);
            SetHueAlterSecondary(-1);
            SetHueAlterTertiary(-1);
            SetHueAlterAdditional(-1);


        }

        public void SetHead(int offset) { customizer.SetHead(offset); }
        public void SetTorso(int offset) { customizer.SetTorso(offset); }
        public void SetLegs(int offset) { customizer.SetLegs(offset); }
        public void SetShoes(int offset) { customizer.SetShoes(offset); }

        public void SetPalette(Aesthetic input)
        {
            if (!customizer.GetComponent<CharacterColoring>()) { Debug.LogError("ERROR: Customizer does not have an Aesthetics script attatched to it."); return; }
            

            customizer.GetComponent<CharacterColoring>().SetPalette(input);
            accessoryManager.UpdateProps();


        }

        public void SetGender(int offset)
        {

            customizer.SetGender(offset);
            accessoryManager.UpdateProps();

        }

        public void Randomize()
        {
            if (!customizer.GetComponent<LoadCharacter>()) { Debug.LogError("ERROR: Customizer does not have a Load Character script attatched to it."); return; }

            customizer.GetComponent<LoadCharacter>().LoadRandom();
            accessoryManager.UpdateProps();


        }

    }
}