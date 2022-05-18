using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DistantLands.DataType;
using UnityEngine.UI;

namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Stat Icon")]
    public class StatIcon : MonoBehaviour
    {

        public Statistic stat;
        public Image ring;
        public Image icon;
        public float lerpSpeed = 5f;
        private Stats character;




        // Start is called before the first frame update
        void Start()
        {

            character = FindObjectOfType<Stats>();
            icon.sprite = stat.icon;

        }

        // Update is called once per frame
        void Update()
        {

            ring.fillAmount = Mathf.Lerp(ring.fillAmount, character.getStat(stat) / stat.maxAmount, Time.deltaTime * lerpSpeed);


        }
    }
}