/** ---------------------------------------------------------------------------- **


    Controls the notification system used by the Tailor in-game UI.

    - Distant Lands


*** ---------------------------------------------------------------------------- */



using UnityEngine;
using UnityEngine.UI;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Notify")]
    public class Notify : MonoBehaviour
    {

        private Text text;
        private Animator animator;

        private void Awake()
        {

            text = GetComponentInChildren<Text>();
            animator = GetComponent<Animator>();

        }


        public void Notification(string message)
        {

            text.text = message;
            animator.SetTrigger("Notify");


        }
    }
}