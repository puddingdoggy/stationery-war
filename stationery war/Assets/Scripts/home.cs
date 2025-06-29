using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class home : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (!player)
        {
            SceneManager.LoadScene("victory");
        }

    }

}
