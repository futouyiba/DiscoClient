/** ---------------------------------------------------------------------------- **


    Assigns colors to the UI manager from a button input.

    - Distant Lands


*** ---------------------------------------------------------------------------- */


using UnityEngine.UI;
using UnityEngine;


namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Color Button")]
    public class ColorButton : MonoBehaviour
    {


        [Tooltip("Is this a skin color button? Turn off if a hair color button.")]
        public bool skinColor;

        [HideInInspector]
        public UIManager manager;





        public void Clicked()
        {


            manager.SetColor(GetComponent<Image>().color, skinColor);


        }
    }
}