/** ---------------------------------------------------------------------------- **


    Assigns props to the UI manager from a button input.

    - Distant Lands


*** ---------------------------------------------------------------------------- */


using UnityEngine.UI;
using UnityEngine;
using DistantLands.DataType;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Color Button")]
    public class PropButton : MonoBehaviour
    {


        public BodyArea type;

        [HideInInspector]
        public UIManager manager;
        public Text title;
        public bool active;

        private Image[] images;


        private void Start()
        {
            title.text = type.name;
            images = GetComponentsInChildren<Image>();
        }

        public void Update()
        {

            active = manager.CheckPropActive(type);

            if (!active)
            {
                title.color = Color.grey;
                foreach (Image i in images)
                    i.color = Color.grey;
            } else
            {


                title.color = Color.white;
                foreach (Image i in images)
                    i.color = Color.white;

            }


        }

        public void Clicked(int dir)
        {

            if (active)
            manager.SetProp(dir, type);


        }
    }
}