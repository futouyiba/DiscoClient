/** ---------------------------------------------------------------------------- **


    Rotates an object based on mouse input.

    - Distant Lands


*** ---------------------------------------------------------------------------- */



using UnityEngine;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Turntable")]
    public class Turntable : MonoBehaviour
    {

        public float multiplier = 1;
        Vector2 oldMousePosition;


        void Update()
        {

            if (Input.GetMouseButton(1))
            {
                MoveRelative(new Vector2(Input.mousePosition.x, 0) - oldMousePosition);
            }
            oldMousePosition = new Vector2(Input.mousePosition.x, 0);

        }



        // Update is called once per frame
        public void Move(float position)
        {

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, position * multiplier, transform.eulerAngles.z);

        }


        // Update is called once per frame
        public void MoveRelative(Vector2 position)
        {

            Vector3 i = new Vector3(transform.eulerAngles.x + (position.y * multiplier), transform.eulerAngles.y + position.x * multiplier, transform.eulerAngles.z);
            transform.eulerAngles = i;


        }
    }
}