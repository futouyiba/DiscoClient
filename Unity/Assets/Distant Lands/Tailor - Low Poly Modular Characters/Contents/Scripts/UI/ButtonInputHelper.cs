using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands
{
    public class ButtonInputHelper : MonoBehaviour
    {


        public float shakeAmount;
        public float shakeSpeed;
        private float shakeTime;



        // Start is called before the first frame update
        void Update()
        {


            shakeTime -= Time.deltaTime;

            if (shakeTime > 0)
            {

                transform.eulerAngles = Vector3.forward * ((Mathf.PerlinNoise(Time.time * shakeSpeed, 0) - .5f) * shakeAmount * Mathf.Clamp01(shakeTime));

            }
            else
                transform.eulerAngles = Vector3.zero;


        }

        // Update is called once per frame
        public void Shake(float seconds)
        {

            shakeTime = seconds;

        }



    }
}