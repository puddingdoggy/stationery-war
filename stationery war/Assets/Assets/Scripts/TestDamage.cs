using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TestDamage : MonoBehaviour
    {
        public FortressHealth blueFortress;
        public FortressHealth redFortress;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                blueFortress.TakeDamage(10);
                Debug.Log("Blue fortress health: " + blueFortress.GetCurrentHealth());
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                redFortress.TakeDamage(10);
                Debug.Log("Red fortress health: " + redFortress.GetCurrentHealth());
            }
        }
    }

