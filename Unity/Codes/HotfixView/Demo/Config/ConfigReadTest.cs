using System;
using UnityEngine;

namespace ET
{
    public class testConfigReader: MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void Start()
        {

            UnitConfigCategory uConfigCat = UnitConfigCategory.Instance;
            var configGot = uConfigCat.Get(1001);
            Debug.Log(configGot.Name);
        }
    }
}