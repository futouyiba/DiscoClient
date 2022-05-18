using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DistantLands.DataType;
using System.Security.Cryptography;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Assign Button Colors")]
    public class AssignButtonColors : MonoBehaviour
    {



        public Aesthetic aesthetic;




        // Start is called before the first frame update
        void Start()
        {
            if (!aesthetic)
                return;

            name = aesthetic.name;
            GetComponentInChildren<Text>().text = aesthetic.name;

            foreach (Image i in GetComponentsInChildren<Image>())
            {

                switch (i.name)
                {
                    case "1":
                        i.color = aesthetic.primary;
                        break;
                    case "2":
                        i.color = aesthetic.secondary;
                        break;
                    case "3":
                        i.color = aesthetic.tertiary;
                        break;
                    case "4":
                        i.color = aesthetic.additional;
                        break;

                    default:
                        break;
                }
            }

        }

        public void SetAesthetic()
        {
            try
            {
                UIManager i = FindObjectOfType<UIManager>();
                i.SetPalette(aesthetic);
                i.SetSliderColors();

            }
            catch
            {

                Debug.LogError("ERROR: Could not find UI Manager object. Ensure that there is an active object in your scene with the UI Manager script attatched");

            }

        }
    }
}