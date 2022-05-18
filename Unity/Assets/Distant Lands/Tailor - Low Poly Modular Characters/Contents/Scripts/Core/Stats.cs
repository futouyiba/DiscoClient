using DistantLands.DataType;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/Character Stats")]
    public class Stats : MonoBehaviour
    {

        [System.Serializable]
        public class Stat
        {
            public Statistic stat;

            [Tooltip("The current amount (controlled by script)")]
            public float amount;


        }

        public List<Stat> stats;
        private CharacterCustomizer customizer;

        public bool updateEveryFrame;

        // Start is called before the first frame update
        void Start()
        {

            customizer = GetComponent<CharacterCustomizer>();


        }

        // Update is called once per frame
        void Update()
        {


            if (updateEveryFrame && customizer && !customizer.ConsistentUpdate)
                UpdateStats();


        }

        public void UpdateStats()
        {
            ResetStats();
            List<Stat> variables = new List<Stat>();

            if (customizer == null)
                return;

            foreach (BodyMesh i in customizer.GetCurrentBodyMeshes())
            {

                variables.AddRange(i.stats);

            }

            foreach (Accessory i in customizer.accessories.GetAccessories())
                variables.AddRange(i.stats);

            foreach (Stat var in variables)
            {
                foreach (Stat statName in stats)
                    if (var.stat == statName.stat)
                        statName.amount += var.amount;
            }

        }


        public void ResetStats()
        {
            foreach (Stat i in stats)
            {

                i.amount = 0;


            }
        }

        public float getStat(string stat)
        {
            float i = 0;

            foreach (Stat j in stats)
            {

                if (j.stat.name == stat)
                    i = j.amount;

            }

            return i;
        }


        public float getStat(Statistic stat)
        {

            float i = 0;

            foreach (Stat j in stats)
            {

                if (j.stat == stat)
                    i = j.amount;

            }

            return i;
        }


    }
}